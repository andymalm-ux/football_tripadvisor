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

    public static async Task<IResult> Post(Post_Args credentials, Config config, HttpContext context)
    {
        string query = "SELECT id, role FROM users WHERE email = @email AND password = @password";
        var parameters = new MySqlParameter[]
        {
            new("@email", credentials.Email),
            new("@password", credentials.Password),
        };
        

        using var reader = await MySqlHelper.ExecuteReaderAsync(config.DB, query, parameters);

        if (!reader.Read())
        {
            return Results.Text("Fel epost eller lösenord", statusCode: StatusCodes.Status401Unauthorized);
        }
        else 
        {
        int id = reader.GetInt32("id");
        string role = reader.GetString("role");

        context.Session.SetInt32("user_id", id);
        context.Session.SetString("role", role);

        return Results.Ok("Login ok");
        }
    }
}

