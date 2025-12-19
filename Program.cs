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

app.MapGet(
    "/users/profile",
    (HttpContext context) =>
    {
        if (!Authentication.LoggedIn(context))
        {
            return Results.Text(
                "No profile logged in",
                statusCode: StatusCodes.Status401Unauthorized
            );
        }
        return Results.Ok("User profile");
    }
);

app.MapGet(
    "/users/admin",
    (HttpContext context) =>
    {
        if (!Authentication.AdminLoggedIn(context))
        {
            return Results.Forbid();
        }
        return Results.Ok("Admin page");
    }
);

app.MapPost("/login/", Login.Post);
app.MapGet("/login/", Login.Get);

app.MapGet("/hotels", Hotels.GetAllHotels);
app.MapGet("/hotels/search", Hotels.SearchHotels);

app.MapGet("/hotels/{hotelId}", Hotels.GetHotelById);
app.MapGet("/hotels/{hotelId}/rooms", Hotels.GetRooms);

app.MapPost("/hotels/{hotelId}/rooms/{roomId}/bookings", Bookings.Post);
app.MapPost("/hotels/{hotelId}/rooms/{roomId}/price", Bookings.Price);

app.MapGet("/attractions", Attractions.Get);

app.MapDelete("/db", reset_DB_to_default);

app.Run();

async Task reset_DB_to_default(Config config)
{
    string create_tables = """

        CREATE TABLE users
        (
        id INT PRIMARY KEY AUTO_INCREMENT,
        email VARCHAR(264) NOT NULL UNIQUE,
        password VARCHAR(64) NOT NULL,
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
}
