DROP TABLE IF EXISTS users;
DROP TABLE IF EXISTS hotels;
DROP TABLE IF EXISTS tourist_attractions;
DROP TABLE IF EXISTS attraction_types;
DROP TABLE IF EXISTS cities;
DROP TABLE IF EXISTS countries;

CREATE TABLE users
(
    id INT PRIMARY KEY AUTO_INCREMENT,
    email VARCHAR(264) UNIQUE,
    password VARCHAR(64)
);

CREATE TABLE countries
(
    id INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR (50) NOT NULL
);

CREATE TABLE cities
(
    id INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR (50),
    country_id INT NOT NULL,
    FOREIGN KEY (country_id) REFERENCES countries (id)
);

CREATE TABLE hotels
(
    id INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(100) NOT NULL,
    address VARCHAR(100) NOT NULL,
    city_id INT NOT NULL,
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
    city_id INT NOT NULL,
    FOREIGN KEY (type_id) REFERENCES attraction_types (id),
    FOREIGN KEY (city_id) REFERENCES cities (id)
);
