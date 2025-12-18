using System.Globalization;

namespace Server;

static class Hotels
{
    public record Get_Data(int Id, string Name, string City, string Country);

    public record Room_Data(int Id, string Name, int Capacity, string PricePerNight);

    public record Get_Attractions(string Name, string Type, string Distance);

    public record AttractionsByType(List<Get_Attractions> Stadiums, List<Get_Attractions> Pubs);

    public record Get_Single_Hotel(
        string Name,
        string Address,
        string City,
        string Country,
        string Amenities,
        AttractionsByType Attractions,
        List<Room_Data> Rooms
    );

    public record Get_Amenities(
        int Id,
        string Name,
        string Address,
        string City,
        string Country,
        string Amenities
    );

    public record Hotels_By_Stadium(
        int Id,
        string Name,
        string City,
        string Country,
        string Distance
    );

    public static async Task<List<Get_Data>> Get(Config config)
    {
        List<Get_Data> result = new();

        string query = """
            SELECT 
            hotel.id,
            hotel.name,
            city.name, 
            country.name
            FROM hotels AS hotel
            JOIN cities AS city ON hotel.city_id = city.id
            JOIN countries AS country ON city.country_id = country.id;
            """;

        using (var reader = await MySqlHelper.ExecuteReaderAsync(config.DB, query))
        {
            while (reader.Read())
            {
                result.Add(
                    new Get_Data(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3)
                    )
                );
            }
        }

        return result;
    }

    public static async Task<IResult> GetHotelById(int hotelId, Config config)
    {
        List<Room_Data> rooms = new();
        var parameters = new MySqlParameter[] { new("@hotel_id", hotelId) };

        string roomQuery = """
            SELECT id, name, capacity, price_per_night
            FROM rooms
            WHERE hotel_id = @hotel_id
            """;

        await using var roomReader = await MySqlHelper.ExecuteReaderAsync(
            config.DB,
            roomQuery,
            parameters
        );

        while (roomReader.Read())
        {
            rooms.Add(
                new Room_Data(
                    roomReader.GetInt32(0),
                    roomReader.GetString(1),
                    roomReader.GetInt32(2),
                    roomReader.GetDecimal(3).ToString() + " SEK"
                )
            );
        }

        List<Get_Attractions> attractions = new();

        string attractionsQuery = """
            SELECT 
            ta.name as tourist_attraction, 
            at.name as type, 
            had.distance_km * 1000 AS distance_m
            FROM tourist_attractions AS ta
            JOIN hotel_attraction_distance AS had ON ta.id = had.attraction_id
            JOIN hotels AS h ON h.id = had.hotel_id
            JOIN attraction_types AS at ON at.id = ta.type_id
            WHERE h.id = @hotel_id;
            """;

        await using var attractionReader = await MySqlHelper.ExecuteReaderAsync(
            config.DB,
            attractionsQuery,
            parameters
        );

        while (attractionReader.Read())
        {
            attractions.Add(
                new(
                    attractionReader.GetString(0),
                    attractionReader.GetString(1),
                    Math.Truncate(attractionReader.GetDecimal(2)).ToString() + " m"
                )
            );
        }

        AttractionsByType groupedAttractions = new(
            attractions.FindAll(a => a.Type == "Stadium"),
            attractions.FindAll(a => a.Type == "Pubs")
        );

        string query = """
            SELECT 
            hotel.name,
            hotel.address, 
            city.name, 
            country.name,
            IFNULL(GROUP_CONCAT(DISTINCT a.name SEPARATOR ', '), "No amenities") AS amenities
            FROM hotels AS hotel
            JOIN cities AS city ON hotel.city_id = city.id
            JOIN countries AS country ON city.country_id = country.id
            LEFT JOIN rooms AS room ON hotel.id = room.hotel_id
            LEFT JOIN amenities_hotel AS ah ON hotel.id = ah.hotel_id
            LEFT JOIN amenities AS a ON a.id = ah.amenity_id
            WHERE hotel.id = @hotel_id
            GROUP BY hotel.id;
            """;

        await using var reader = await MySqlHelper.ExecuteReaderAsync(config.DB, query, parameters);

        if (reader.Read())
        {
            Get_Single_Hotel result = new(
                reader.GetString(0),
                reader.GetString(1),
                reader.GetString(2),
                reader.GetString(3),
                reader.GetString(4),
                groupedAttractions,
                rooms
            );

            return Results.Ok(result);
        }
        else
        {
            return Results.NotFound(new { message = $"Hotel with ID {hotelId} was not found." });
        }
    }

    public static async Task<IResult> GetRooms(Config config, int hotelId)
    {
        List<Room_Data> result = new();

        string query = """
            SELECT id, name, capacity, price_per_night
            FROM rooms
            WHERE hotel_id = @hotel_id
            """;

        var parameters = new MySqlParameter[] { new("hotel_id", hotelId) };

        using var reader = await MySqlHelper.ExecuteReaderAsync(config.DB, query, parameters);

        while (reader.Read())
        {
            result.Add(
                new(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetInt32(2),
                    reader.GetDecimal(3).ToString() + " SEK"
                )
            );
        }
        if (result.Count == 0)
        {
            return Results.NotFound(new { message = "No rooms found for this hotel..." });
        }
        return Results.Ok(result);
    }

    public static async Task<IResult> SearchByCity(Config config, HttpRequest req)
    {
        List<Get_Data> result = new();
        string? city = req.Query["city"];

        string query = """
            SELECT hotel.id, hotel.name, city.name, country.name
            FROM hotels AS hotel
            JOIN cities AS city ON hotel.city_id = city.id
            JOIN countries AS country ON city.country_id = country.id
            WHERE city.name = @city_name;
            """;

        var parameters = new MySqlParameter[] { new("@city_name", city) };

        using (var reader = await MySqlHelper.ExecuteReaderAsync(config.DB, query, parameters))
        {
            while (reader.Read())
            {
                result.Add(
                    new Get_Data(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3)
                    )
                );
            }
            if (result.Count == 0)
            {
                return Results.NotFound(new { message = $"No hotels found in {city}" });
            }
        }
        return Results.Ok(result);
    }

    public static async Task<IResult> Amenities(Config config, HttpRequest req)
    {
        List<Get_Amenities> result = new();
        string? city = req.Query["city"];
        string? amenity = req.Query["amenity"];

        string query = """
            SELECT
                hotel.Id,
                hotel.name AS hotel,
                hotel.address,
                city.name AS city,
                country.name AS country,
                GROUP_CONCAT(a.name SEPARATOR ', ') AS amenities
            FROM hotels AS hotel
            JOIN cities AS city ON city.id = hotel.city_id
            JOIN countries AS country ON country.id = city.country_id
            LEFT JOIN amenities_hotel AS ah ON hotel.id = ah.hotel_id
            LEFT JOIN amenities AS a ON a.id = ah.amenity_id
            WHERE city.name = @city_name
            AND a.name = @amenity
            GROUP BY hotel.id, hotel.name, hotel.address, city.name, country.name
            ORDER BY hotel.name;
            """;

        var parameters = new MySqlParameter[] { new("@city_name", city), new("@amenity", amenity) };

        using (var reader = await MySqlHelper.ExecuteReaderAsync(config.DB, query, parameters))
        {
            while (reader.Read())
            {
                result.Add(
                    new Get_Amenities(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3),
                        reader.GetString(4),
                        reader.GetString(5)
                    )
                );
            }
            if (result.Count == 0)
            {
                return Results.NotFound(new { message = $"No hotels found in {city}" });
            }
        }
        return Results.Ok(result);
    }

    public static async Task<IResult> SearchByStadium(Config config, HttpRequest req)
    {
        string? stadium = req.Query["stadium"];
        if (stadium == "" || stadium == null)
        {
            return Results.BadRequest(new { message = "You have to search for a stadium" });
        }

        List<Hotels_By_Stadium> result = new();

        TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
        string query = """
            SELECT 
                h.id,
                h.name,
                c.name AS city,
                co.name AS country,
                ROUND(had.distance_km * 1000) AS distance_m
            FROM tourist_attractions AS ta
            JOIN hotel_attraction_distance AS had ON had.attraction_id = ta.id
            JOIN hotels AS h ON h.id = had.hotel_id
            JOIN cities AS c ON c.id = h.city_id
            JOIN countries AS co ON co.id = c.country_id
            WHERE ta.type_id = 1
            AND ta.name = @stadium 
            ORDER BY had.distance_km ASC, h.name ASC;
            """;

        var parameters = new MySqlParameter[] { new("@stadium", stadium) };

        using var reader = await MySqlHelper.ExecuteReaderAsync(config.DB, query, parameters);

        while (reader.Read())
        {
            result.Add(
                new Hotels_By_Stadium(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetInt32(4) + " m"
                )
            );
        }

        if (result.Count == 0)
            return Results.NotFound(
                new { message = $"No hotels found near {ti.ToTitleCase(stadium)}" }
            );

        return Results.Json(
            new { message = $"Hotels near {ti.ToTitleCase(stadium)}", data = result },
            statusCode: 200
        );
    }
}
