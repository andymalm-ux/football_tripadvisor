namespace Server;

static class Attractions
{
    public record Get_Data(string Type, string Name, string Address, string City);

    public static async Task<List<Get_Data>> Get(Config config)
    {
        List<Get_Data> result = new();

        string query = """
            SELECT type.name, attraction.name, attraction.address, city.name
            FROM tourist_attractions AS attraction
            JOIN attraction_types AS type ON attraction.type_id = type.id
            JOIN cities AS city ON attraction.city_id = city.id
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
