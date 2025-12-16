namespace Server;

static class Hotels
{
    public record Get_Data(string Name, string Address, string City, string Country);

    public static async Task<List<Get_Data>> Get(Config config)
    {
        List<Get_Data> result = new();

        string query = """
            SELECT 
            hotel.name,
            hotel.address, 
            city.name, 
            country.name
            FROM hotels AS hotel
            JOIN cities AS city ON hotel.city_id = city.id
            JOIN countries AS country ON city.country_id = country.id
            LEFT JOIN rooms AS room ON hotel.id = room.hotel_id;
            """;

        using (var reader = await MySqlHelper.ExecuteReaderAsync(config.DB, query))
        {
            while (reader.Read())
            {
                result.Add(
                    new Get_Data(
                        reader.GetString(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3)
                    )
                );
            }
        }

        return result;
    }

    public record Get_Single_Hotel(
        string Name,
        int Capacity,
        string Amenities,
        string Address,
        string City,
        string Country
    );

    public static async Task<IResult> GetHotelById(int hotelId, Config config)
    {
        string query = """
            SELECT 
            hotel.name, 
            COUNT(room.id) AS number_of_rooms,
            GROUP_CONCAT(DISTINCT a.name SEPARATOR ', ') AS amenities,
            hotel.address, 
            city.name, 
            country.name 
            FROM hotels AS hotel
            JOIN cities AS city ON hotel.city_id = city.id
            JOIN countries AS country ON city.country_id = country.id
            LEFT JOIN rooms AS room ON hotel.id = room.hotel_id
            LEFT JOIN amenities_hotel AS ah ON hotel.id = ah.hotel_id
            LEFT JOIN amenities AS a ON a.id = ah.amenity_id
            WHERE hotel.id = @hotel_id
            GROUP BY hotel.name, hotel.address, city.name, country.name;
            """;

        var parameters = new MySqlParameter[] { new("@hotel_id", hotelId) };

        await using var reader = await MySqlHelper.ExecuteReaderAsync(config.DB, query, parameters);

        if (reader.Read())
        {
            Get_Single_Hotel result = new(
                reader.GetString(0),
                reader.GetInt32(1),
                reader.GetString(2),
                reader.GetString(3),
                reader.GetString(4),
                reader.GetString(5)
            );

            return Results.Ok(result);
        }
        else
        {
            return Results.NotFound(new { message = $"Hotel with ID {hotelId} was not found." });
        }
    }

    public record RoomData(int Id, string Name, int Capacity, decimal PricePerNight);

    public static async Task<IResult> GetRooms(Config config, int hotelId)
    {
        List<RoomData> result = new();

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
                new RoomData(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetInt32(2),
                    reader.GetDecimal(3)
                )
            );
        }
        if (result.Count == 0)
        {
            return Results.NotFound(new { message = "No rooms found for this hotel..." });
        }
        return Results.Ok(result);
    }

    public static async Task<IResult> Search(Config config, HttpRequest req)
    {
        List<Get_Data> result = new();
        string? city = req.Query["city"];

        string query = """
            SELECT hotel.name, hotel.address, city.name, country.name
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
                        reader.GetString(0),
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

    public record Get_Amenities(
        string Name,
        string Address,
        string City,
        string Country,
        string Amenities
    );

    public static async Task<IResult> Amenities(Config config, HttpRequest req)
    {
        List<Get_Amenities> result = new();
        string? city = req.Query["city"];
        string? amenity = req.Query["amenity"];

        string query = """
            SELECT
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
            GROUP BY hotel.name, hotel.address, city.name, country.name
            ORDER BY hotel.name;

            """;
        var parameters = new MySqlParameter[] { new("@city_name", city), new("@amenity", amenity) };

        using (var reader = await MySqlHelper.ExecuteReaderAsync(config.DB, query, parameters))
        {
            while (reader.Read())
            {
                result.Add(
                    new Get_Amenities(
                        reader.GetString(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3),
                        reader.GetString(4)
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
}
