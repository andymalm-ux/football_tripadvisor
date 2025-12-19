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

    public static async Task<IResult> GetAllHotels(Config config)
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

        return Results.Ok(result);
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

    public static async Task<IResult> SearchByCity(Config config, string city)
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
            JOIN countries AS country ON city.country_id = country.id
            WHERE city.name = @city_name
            ORDER BY hotel.name;
            """;

        var parameters = new MySqlParameter[] { new("@city_name", city) };

        using var reader = await MySqlHelper.ExecuteReaderAsync(config.DB, query, parameters);

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

        return Results.Ok(result);
    }

    public static async Task<IResult> SearchByStadium(Config config, string stadium)
    {
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

    public static async Task<IResult> SearchByCityAndAmenities(
        Config config,
        string? city,
        string[]? amenity
    )
    {
        // Kontrollerar att både city och amenities finns
        if (string.IsNullOrWhiteSpace(city) || amenity == null || amenity.Length == 0)
            return Results.BadRequest(
                new { message = "City and at least one amenity are required." }
            );

        // Skapar en sträng av alla val separerade med kommatecken
        string amenityList = string.Join(",", amenity);

        // Hitta hotell id som har alla amenities som skrevs in
        string searchQuery = $"""
            SELECT hotel.id
            FROM hotels AS hotel
            JOIN cities AS city ON city.id = hotel.city_id
            JOIN amenities_hotel AS ah ON hotel.id = ah.hotel_id
            JOIN amenities AS a ON a.id = ah.amenity_id
            WHERE city.name = @city_name
            AND a.name IN (@amenity_list) 
            GROUP BY hotel.id
            HAVING COUNT(DISTINCT a.name) = @count;
            """;

        var parameters = new[]
        {
            new MySqlParameter("@city_name", city),
            new MySqlParameter("@amenity_list", amenityList),
            new MySqlParameter("@count", amenity.Length),
        };

        var matchingIds = new List<int>();
        using (
            var reader = await MySqlHelper.ExecuteReaderAsync(config.DB, searchQuery, parameters)
        )
        {
            while (reader.Read())
                matchingIds.Add(reader.GetInt32(0));
        }

        // Om inga hotell matchar
        if (matchingIds.Count == 0)
        {
            // Kolla om staden ens finns i databasen
            string checkCityQuery = "SELECT id FROM cities WHERE name = @city_name LIMIT 1";
            var cityExists = await MySqlHelper.ExecuteScalarAsync(
                config.DB,
                checkCityQuery,
                parameters[0]
            );

            if (cityExists == null)
            {
                return Results.NotFound(new { message = $"City '{city}' not found." });
            }

            // Vi kollar om listan har mer än en amenity för att skriva ut rätt ord i felmeddelandet
            string label = amenity.Length > 1 ? "amenities" : "amenity";
            return Results.NotFound(
                new
                {
                    message = $"No hotels found in {city} with the requested {label}: {amenityList}.",
                }
            );
        }

        // Hämta hotell id för matchande hotell
        string hotelIds = string.Join(",", matchingIds);

        string query = """
            SELECT
                h.id,
                h.name,
                h.address,
                c.name,
                co.name,
                GROUP_CONCAT(a.name SEPARATOR ', ')
            FROM hotels h
            JOIN cities c ON c.id = h.city_id
            JOIN countries co ON co.id = c.country_id
            LEFT JOIN amenities_hotel ah ON ah.hotel_id = h.id
            LEFT JOIN amenities a ON a.id = ah.amenity_id
            WHERE FIND_IN_SET(h.id, @hotel_ids)
            GROUP BY h.id
            ORDER BY h.name;
            """;

        var sqlParameters = new MySqlParameter[] { new("@hotel_ids", hotelIds) };

        var hotelList = new List<Get_Amenities>();
        using (var reader = await MySqlHelper.ExecuteReaderAsync(config.DB, query, sqlParameters))
        {
            while (reader.Read())
            {
                hotelList.Add(
                    new(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3),
                        reader.GetString(4),
                        reader.GetString(5)
                    )
                );
            }
        }

        return Results.Ok(hotelList);
    }

    public static async Task<IResult> SearchHotels(
        Config config,
        string? city,
        string? stadium,
        string[]? amenity
    )
    {
        bool hasCity = !string.IsNullOrWhiteSpace(city);
        bool hasStadium = !string.IsNullOrWhiteSpace(stadium);
        bool hasAmenities = amenity != null && amenity.Any(a => !string.IsNullOrWhiteSpace(a));

        // Sök på amenities utan city
        if (hasAmenities && !hasCity)
        {
            return Results.BadRequest(
                new { message = "Amenities search is only supported together with city" }
            );
        }

        if (hasStadium && hasCity)
        {
            return Results.BadRequest(new { message = "Stadium search is only supported alone" });
        }

        //  Sök på stadium
        if (hasStadium)
        {
            return await SearchByStadium(config, stadium!);
        }

        // Sök på stad + amenities
        if (hasCity && hasAmenities)
        {
            return await SearchByCityAndAmenities(config, city, amenity);
        }

        // Sök bara på stad
        if (hasCity)
        {
            return await SearchByCity(config, city!);
        }

        //  Inget filter - returnera alla hotell
        return await GetAllHotels(config);
    }
}
