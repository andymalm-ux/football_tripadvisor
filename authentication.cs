namespace Server;

static class Authentication
{
    public static bool LoggedIn(HttpContext context)
    {
        return context.Session.GetInt32("user_id") != null;
    }

    public static bool AdminLoggedIn(HttpContext context)
    {
        return context.Session.GetString("role") == "admin";
    }
}
