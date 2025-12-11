namespace Server;

static class Login
{
    public record Get_Data(string Email);

    public static async Task<Get_Data?> Get(Config config, HttpContext context)
    {
        Get_Data? result = null;
        if (context.Session.IsAvailable)
        {
            if (context.Session.Keys.Contains("user_id"))
            {
                string query = "SELECT email FROM users WHERE id = @id";
                var parameters = new MySqlParameter[]
                {
                    new("@id", context.Session.GetInt32("user_id")),
                };

                using (
                    var reader = await MySqlHelper.ExecuteReaderAsync(config.DB, query, parameters)
                )
                {
                    if (reader.Read())
                    {
                        result = new(reader.GetString(0));
                    }
                }
            }
        }
        return result;
    }

    public record Post_Args(string Email, string Password);

    public static async Task<bool> Post(Post_Args credentials, Config config, HttpContext context)
    {
        bool result = false;
        string query = "SELECT id FROM users WHERE email = @email AND password = @password";
        var parameters = new MySqlParameter[]
        {
            new("@email", credentials.Email),
            new("@password", credentials.Password),
        };

        object query_result = await MySqlHelper.ExecuteScalarAsync(config.DB, query, parameters);

        if (query_result is int id)
        {
            context.Session.SetInt32("user_id", id);
            result = true;
        }
        return result;
    }
}
