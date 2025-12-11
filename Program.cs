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

app.MapDelete("/db", reset_DB_to_default);

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

        CREATE TABLE attraction_types
        (
        id INT PRIMARY KEY AUTO_INCREMENT,
        name VARCHAR(100) NOT NULL
        );

        CREATE TABLE tourist_attractions
        (
        id INT PRIMARY KEY AUTO_INCREMENT,
        name VARCHAR(100) NOT NULL,
        type_id INT NOT NULL,
        address VARCHAR(100) NOT NULL,
        city_id INT,
        FOREIGN KEY (type_id) REFERENCES attraction_types (id),
        FOREIGN KEY (city_id) REFERENCES cities (id)
        );

        """;

    await MySqlHelper.ExecuteNonQueryAsync(config.DB, "DROP TABLE IF EXISTS users");
    await MySqlHelper.ExecuteNonQueryAsync(config.DB, "DROP TABLE IF EXISTS hotels");
    await MySqlHelper.ExecuteNonQueryAsync(config.DB, "DROP TABLE IF EXISTS tourist_attractions");
    await MySqlHelper.ExecuteNonQueryAsync(config.DB, "DROP TABLE IF EXISTS attraction_types");
    await MySqlHelper.ExecuteNonQueryAsync(config.DB, "DROP TABLE IF EXISTS cities");
    await MySqlHelper.ExecuteNonQueryAsync(config.DB, "DROP TABLE IF EXISTS countries");
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

        -- Spain: 
        -- Barcelona
        INSERT INTO hotels (name, address, city_id) VALUES
        ('Hotel Alguer Camp Nou', 'Passatge Pere Rodriguez 20', 1), 
        ('Onefam Les Corts', 'Passatge Regente Mendieta 5', 1),  
        ('NH Barcelona Stadium', 'Travessera de les Corts 150-152', 1), 
        ('Arya Stadium Hotel', 'CARRER DE SANTS 383', 1);

        -- Madrid
        INSERT INTO hotels (name, address, city_id) VALUES
        ('H10 Tribeca', 'Pedro Teixeira 5', 2),
        ('Melia Castilla', 'Calle del Poeta Joan Maragall 43', 2),
        ('NH Paseo de la Habana', 'Paseo de la Habana 73', 2),
        ('NYX Hotel Madrid', 'Aviador Zorita 34', 2);

        -- Sevilla
        INSERT INTO hotels (name, address, city_id) VALUES
        ('Novotel Sevilla', 'Avenida Eduardo Dato 71', 3),
        ('Meliá Lebreros', 'Luis de Morales 2', 3),
        ('Only YOU Hotel Sevilla', 'Avenida Kansas City 7', 3),
        ('Hotel Giralda Center', 'Calle Juan de Mata Carriazo 7', 3);

        -- Valencia
        INSERT INTO hotels (name, address, city_id) VALUES
        ('Silken Puerta Valencia', 'Cardenal Benlloch 28', 4),
        ('SH Valencia Palace', 'Placa de Margarita Valldaura 2', 4),
        ('Hotel Dimar', 'Gran Via del Marqués del Túria 80', 4),
        ('Hospes Palau de la Mar', 'Avenida de Navarro Reverter 14-16', 4);

        -- England:
        -- London 
        INSERT INTO hotels (name, address, city_id) VALUES
        ('Maldron Hotel Finsbury Park London', '175 Willoughby Lane, Finsbury Park', 5),
        ('The Bull & Last', '168 Highgate Road', 5),
        ('The Wesley Camden Town', '89 Plender Street', 5),
        ('The Luxury Inn', '156 Tottenham Road', 5);

        -- Manchester 
        INSERT INTO hotels (name, address, city_id) VALUES
        ('Hotel Football Old Trafford', '99 Sir Matt Busby Way', 6),
        ('Hilton Garden Inn Manchester Emirates Old Trafford', 'Talbot Road', 6),
        ('Trafford Hall Hotel Manchester', '23 Talbot Road', 6),
        ('Holiday Inn Express Manchester - Salford Quays', 'Waterfront Quay, Salford Quays', 6);

        -- Liverpool
        INSERT INTO hotels (name, address, city_id) VALUES
        ('Hotel Tia', '21 Anfield Road', 7),
        ('Hotel Anfield', '23 Anfield Road', 7),
        ('The Cabbage Hall Hotel', '57 Breck Road', 7);

        -- Newcastle
        INSERT INTO hotels (name, address, city_id) VALUES
        ('Sandman Signature Newcastle Hotel', 'Gallowgate', 8),
        ('Maldron Hotel Newcastle', 'Newgate Street 17', 8),
        ('Royal Station Hotel', 'Neville Street', 8),
        ('The County Hotel Newcastle', 'Neville Street 38-42', 8);

        -- Italy:
        -- Milan
        INSERT INTO hotels (name, address, city_id) VALUES
        ('B&B Hotel Milano San Siro', 'Via Achille 4', 9),
        ('Sheraton Milan San Siro', 'Via Caldera 3', 9),
        ('Idea Hotel Milano San Siro', 'Via Gaetano Airaghi 125', 9);

        -- Rome 
        INSERT INTO hotels (name, address, city_id) VALUES
        ('BeYou Hotel Ponte Milvio', 'Via Cassia 4', 10),
        ('FAIROME Guest House', 'Via Flaminia 305', 10),
        ('Suite Pinturicchio', 'Via Pinturicchio 19', 10);

        -- Naples
        INSERT INTO hotels (name, address, city_id) VALUES
        ('Palazzo Esedra', 'Piazzale Vincenzo Tecchio 50', 11),
        ('LHP Napoli Palace & SPA', 'Viale Augusto 74', 11),
        ('Hotel Leopardi', 'Piazza Pilastri 12', 11);

        -- Germany:
        -- Munich
        INSERT INTO hotels (name, address, city_id) VALUES
        ('Hampton by Hilton Munich City North', 'Ingolstädter Straße 44', 12),
        ('B&B Hotel München City-Nord', 'Frankfurter Ring 243', 12),
        ('AMERON München Motorworld', 'Am Ausbesserungswerk 8', 12);

        -- Dortmund
        INSERT INTO hotels (name, address, city_id) VALUES
        ('Mercure Hotel Dortmund Messe', 'Strobelallee 41', 13),
        ('Dorint An den Westfalenhallen Dortmund', 'Lindemannstrasse 88', 13),
        ('PLAZA INN Stays Design Dortmund', 'Märkische Straße 73', 13);

        -- Berlin
        INSERT INTO hotels (name, address, city_id) VALUES
        ('Hotel Brandies Berlin', 'Kaiserdamm 27', 14),
        ('Hotel Rotdorn', 'Heerstraße 36', 14),
        ('Enjoy Hotel am Studio', 'Kaiserdamm 80', 14);

        -- France:
        -- Paris 
        INSERT INTO hotels (name, address, city_id) VALUES
        ('Hôtel Botaniste', 'Rue Saint-Serge 5', 15),
        ('Hotel De Paris Boulogne', '104 Boulevard de la République, Boulogne-Billancourt', 15),
        ('Mercure Paris Boulogne', '37 Place René Clair, Boulogne-Billancourt', 15);

        -- Marseille
        INSERT INTO hotels (name, address, city_id) VALUES
        ('B&B HOTEL Marseille Prado Parc des Expositions', '192 Avenue Pierre Mendès France', 16),
        ('RockyPop Marseille Hôtel', '4 Boulevard Charles Livon', 16),
        ('Comfort Aparthotel Marseille Prado', '23 Rue du Rouet', 16);

        INSERT INTO attraction_types (name) VALUES
        ('Stadium'),
        ('Pub');     
        """;

    await MySqlHelper.ExecuteNonQueryAsync(config.DB, insert_data);
}
