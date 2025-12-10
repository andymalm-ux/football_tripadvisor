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

    string insert_data = """
        INSERT INTO countries (name) VALUES
        ('Spain'),
        ('England'),
        ('Italy'),
        ('Germany'),
        ('France');

        INSERT INTO cities (name, country_id) VALUES
        ('Barcelona', 1),
        ('Madrid', 1),
        ('Sevilla', 1),
        ('Valencia', 1),
        ('London', 2),
        ('Manchester', 2),
        ('Liverpool', 2),
        ('Newcastle', 2),
        ('Milan', 3),
        ('Rome', 3),
        ('Naples', 3),
        ('Munich', 4),
        ('Dortmund', 4),
        ('Berlin', 4),
        ('Paris', 5),
        ('Marseille', 5);
        """;

    await MySqlHelper.ExecuteNonQueryAsync(config.DB, insert_data);
}
