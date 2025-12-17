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

app.MapGet("/stadiums/search", Hotels.SearchByStadium);
app.MapGet("/hotels/search", Hotels.SearchByCity);

app.MapGet("/attractions", Attractions.Get);

app.MapDelete("/db", reset_DB_to_default);

app.Run();

async Task reset_DB_to_default(Config config)
{
    await MySqlHelper.ExecuteNonQueryAsync(config.DB, File.ReadAllText("db/schema.sql"));
    await MySqlHelper.ExecuteNonQueryAsync(config.DB, File.ReadAllText("db/data.sql"));
}
