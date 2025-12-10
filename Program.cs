using System.Xml;
using Google.Protobuf.WellKnownTypes;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using Server;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
}
);

Config config = new(
    "server = 127.0.0.1;uid=football_tripadvisor;pwd=football_tripadvisor;database=football_tripadvisor"
);

builder.Services.AddSingleton<Config>(config);

var app = builder.Build();

app.MapGet("/users/", Users.Get);
app.MapPost("/users/", Users.Post);
app.MapDelete("/users/", reset_DB_to_default);
app.MapGet("/users/{id}", Users.GetById);

app.MapPost("/login", Login.Post);
app.MapGet("/login", Login.Get);

app.Run();

async Task reset_DB_to_default(Config config)
{
    string create_table_users = """
        CREATE TABLE users
        (
        id INT PRIMARY KEY AUTO_INCREMENT,
        email VARCHAR(264),
        password VARCHAR(64)
        );
        """;

    await MySqlHelper.ExecuteNonQueryAsync(config.DB, "DROP TABLE IF EXISTS users");
    await MySqlHelper.ExecuteNonQueryAsync(config.DB, create_table_users);

}
