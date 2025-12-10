using System.Xml;
using MySql.Data.MySqlClient;
using Server;

var builder = WebApplication.CreateBuilder(args);

Config config = new(
    "server = 127.0.0.1;uid=football_tripadvisor;pwd=football_tripadvisor;database=football_tripadvisor"
);

builder.Services.AddSingleton<Config>(config);

var app = builder.Build();

app.MapGet("/users/", Users.Get);
app.MapPost("/users/", Users.Post);
app.MapDelete("/users/", reset_DB_to_default);
app.MapGet("/users/{id}", Users.GetById);

app.Run();

async Task reset_DB_to_default(Config config)
{
    string create_table_users = """
        CREATE TABLE users
        (
        id BINARY(16) PRIMARY KEY DEFAULT(UUID_TO_BIN(UUID())),
        email VARCHAR(264),
        password VARCHAR(64)
        );
        """;

    await MySqlHelper.ExecuteNonQueryAsync(config.DB, "DROP TABLE IF EXISTS users");
    await MySqlHelper.ExecuteNonQueryAsync(config.DB, create_table_users);
    var a = "SELECT BIN_TO_UUID(id) FROM users WHERE+öä-lkj ¨trewq VB ¨
    Åä+p0";
}
