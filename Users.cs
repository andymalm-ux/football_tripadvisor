namespace Server;

class Users
{
    public record Get_Data(int Id, string Email, string Password);

    public static async Task<List<Get_Data>> Get(Config config)
    {
        List<Get_Data> result = new();
        string query = "Select id, email, password FROM users";
        await using (var reader = await MySqlHelper.ExecuteReaderAsync(config.DB, query))
        {
            while (reader.Read())
            {
                result.Add(new(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
            }

            return result;
        }
    }

    public record POST_Args(string Email, string Password);

    public static async Task Post(POST_Args user, Config config)
    {
        string query = "INSERT INTO users(email, password) VALUES (@email, @password)";
        var parameters = new MySqlParameter[]
        {
            new("@email", user.Email),
            new("@password", user.Password),
        };
        await MySqlHelper.ExecuteNonQueryAsync(config.DB, query, parameters);
    }

    public record GetDataById(String Email, string Password);

    public static async Task<GetDataById?> GetById(int id, Config config)
    {
        GetDataById? result = null;

        string query = "SELECT email, password FROM users WHERE id=@id";
        var parameters = new MySqlParameter[] { new("@id", id) };

        await using (
            var reader = await MySqlHelper.ExecuteReaderAsync(config.DB, query, parameters)
        )
        {
            if (reader.Read())
            {
                result = new(reader.GetString(0), reader.GetString(1));
            }
        }
        return result;
    }
}
