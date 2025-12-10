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
app.MapDelete("/db", reset_DB_to_default);
app.MapGet("/users/{id}", Users.GetById);

app.Run();

async Task reset_DB_to_default(Config config)
{
    string create_tables = """

        CREATE TABLE users
        (
        id INT PRIMARY KEY AUTO_INCREMENT,
        email VARCHAR(264),
        password VARCHAR(64)
        );

        CREATE TABLE countries
        (
        id INT PRIMARY KEY AUTO_INCREMENT,
        name VARCHAR (50)
        );

        CREATE TABLE cities
        (
        id INT PRIMARY KEY AUTO_INCREMENT,
        name VARCHAR (50),
        country_id INT,
        FOREIGN KEY (country_id) REFERENCES countries (id)
        );

        CREATE TABLE hotels
        (
        id INT PRIMARY KEY AUTO_INCREMENT,
        name VARCHAR(100) NOT NULL,
        address VARCHAR(100) NOT NULL,
        city_id INT,
        FOREIGN KEY (city_id) REFERENCES cities (id)
        );
        """;

    await MySqlHelper.ExecuteNonQueryAsync(config.DB, "DROP TABLE IF EXISTS users");
    await MySqlHelper.ExecuteNonQueryAsync(config.DB, "DROP TABLE IF EXISTS cities");
    await MySqlHelper.ExecuteNonQueryAsync(config.DB, "DROP TABLE IF EXISTS countries");
    await MySqlHelper.ExecuteNonQueryAsync(config.DB, "DROP TABLE IF EXISTS hotels");
    await MySqlHelper.ExecuteNonQueryAsync(config.DB, create_tables);
    //     await MySqlHelper.ExecuteNonQueryAsync(config.DB, create_table_cities);
    //     await MySqlHelper.ExecuteNonQueryAsync(config.DB, create_table_countries);
    //     await MySqlHelper.ExecuteNonQueryAsync(config.DB, create_table_hotels);
}
