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

    // public record Get_Amenities(
    //     string Name,
    //     string Address,
    //     string City,
    //     string Country,
    //     string Amenities
    // );

    // public static async Task<IResult> Amenities(Config config, HttpRequest req)
    // {
    //     List<Get_Amenities> result = new();
    //     string? city = req.Query["city"];

    //     string query = """
    //         SELECT
    //             hotel.name AS hotel,
    //             hotel.address,
    //             city.name AS city,
    //             country.name AS country,
    //             GROUP_CONCAT(a.name SEPARATOR ', ') AS amenities
    //         FROM hotels AS hotel
    //         JOIN cities AS city ON city.id = hotel.city_id
    //         JOIN countries AS country ON country.id = city.country_id
    //         LEFT JOIN amenities_hotel AS ah ON hotel.id = ah.hotel_id
    //         LEFT JOIN amenities AS a ON a.id = ah.amenity_id
    //         WHERE city.name = @city_name
    //         GROUP BY hotel.name, hotel.address, city.name, country.name
    //         ORDER BY hotel.name;

    //         """;
    //     var parameters = new MySqlParameter[] { new("@city_name", city) };

    //     using (var reader = await MySqlHelper.ExecuteReaderAsync(config.DB, query, parameters))
    //     {
    //         while (reader.Read())
    //         {
    //             result.Add(
    //                 new Get_Amenities(
    //                     reader.GetString(0),
    //                     reader.GetString(1),
    //                     reader.GetString(2),
    //                     reader.GetString(3),
    //                     reader.GetString(4)
    //                 )
    //             );
    //         }
    //         if (result.Count == 0)
    //         {
    //             return Results.NotFound(new { message = $"No hotels found in {city}" });
    //         }
    //     }
    //     return Results.Ok(result);
    // }
}
