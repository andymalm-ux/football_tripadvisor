namespace Server;

static class Hotels
{
    public record Get_Data(string Name, string Address, string City, string Country);

    public static async Task<List<Get_Data>> Get(Config config)
    {
        List<Get_Data> result = new();

        string query = """
            SELECT hotel.name, hotel.address, city.name, country.name
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
}
