global using MySql.Data.MySqlClient;
using Server;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

Config config = new(
    "server = 127.0.0.1;uid=football_tripadvisor;pwd=football_tripadvisor;database=football_tripadvisor"
);

builder.Services.AddSingleton(config);

var app = builder.Build();

app.UseSession();

app.MapGet("/users/", Users.Get);
app.MapPost("/users/", Users.Post);
app.MapGet("/users/{id}", Users.GetById);

app.MapPost("/login/", Login.Post);
app.MapGet("/login/", Login.Get);

app.MapGet("/hotels", Hotels.Get);
app.MapGet("/amenities", Hotels.Amenities);
app.MapGet("/hotels/{hotelId}", Hotels.GetHotelById);
app.MapGet("/hotels/{hotelId}/rooms", Hotels.GetRooms);

app.MapPost("/hotels/{hotelId}/rooms/{roomId}/bookings", Bookings.Post);

app.MapGet("/search", Hotels.Search);
app.MapGet("/attractions", Attractions.Get);

app.MapDelete("/db", reset_DB_to_default);

app.Run();

async Task reset_DB_to_default(Config config)
{
<<<<<<< HEAD
    string create_tables = """

        CREATE TABLE users
        (
        id INT PRIMARY KEY AUTO_INCREMENT,
        email VARCHAR(264),
        password VARCHAR(64)
        role ENUM('user', 'admin') NOT NULL DEFAULT 'user'
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
=======
    await MySqlHelper.ExecuteNonQueryAsync(config.DB, File.ReadAllText("db/schema.sql"));
    await MySqlHelper.ExecuteNonQueryAsync(config.DB, File.ReadAllText("db/data.sql"));
>>>>>>> main
}
