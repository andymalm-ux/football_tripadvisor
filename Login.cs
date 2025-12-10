using MySql.Data.MySqlClient;

namespace Server;

static class Login
{
    public record Get_Data(string Name, String Email);

    public static async Task<Get_Data> Get(Config config, HttpContext context)
    {
        Get_Data result = null;
        if (context.Session.GetString("user_id") is string user_id)
        {
            string query = "SELECT email FROM users WHERE id = UUID_TO_BIN(@id)";
            var parameters = new MySqlParameter[] { new("@id", user_id) };
        }
    }

    public static async Task<bool> Post(Post_Args credentials, Config config, HttpContext ctx)
    {
        string query =
            "SELECT BIN_TO_UUID(id) FROM users WHERE email = @email AND password = @password";
        string? user_id = await MySqlHelper.ExecuteScalarAsync(config.DB, query, parameters);
        ctx.Session.SetString("user_id", user_id);
    }
}
