DROP TABLE IF EXISTS amenities_hotel;
DROP TABLE IF EXISTS booking_details;
DROP TABLE IF EXISTS bookings;
DROP TABLE IF EXISTS rooms;
DROP TABLE IF EXISTS amenities;
DROP TABLE IF EXISTS tourist_attractions;
DROP TABLE IF EXISTS hotels;
DROP TABLE IF EXISTS attraction_types;
DROP TABLE IF EXISTS users;
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

CREATE TABLE rooms 
(
    id INT PRIMARY KEY AUTO_INCREMENT,
    hotel_id INT NOT NULL,
    name VARCHAR(100) NOT NULL,
    capacity INT NOT NULL,
    price_per_night DECIMAL(6,2),
    FOREIGN KEY (hotel_id) REFERENCES hotels(id)
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

CREATE TABLE amenities 
(
    id INT PRIMARY KEY AUTO_INCREMENT,
    name ENUM ('Wi-fi', 'Pool', 'Breakfast') NOT NULL
);

CREATE TABLE amenities_hotel
(
    hotel_id INT NOT NULL,
    amenity_id INT NOT NULL,
    PRIMARY KEY(hotel_id, amenity_id),
    FOREIGN KEY(hotel_id) REFERENCES hotels(id),
    FOREIGN KEY(amenity_id) REFERENCES amenities(id)
);
CREATE TABLE bookings
(
    id INT PRIMARY KEY AUTO_INCREMENT,
    user_id INT NOT NULL,
    number_of_guests INT NOT NULL,
    total_cost DECIMAL(9,2),
    FOREIGN KEY (user_id) REFERENCES users(id)
);

CREATE TABLE booking_details
(
    id INT PRIMARY KEY AUTO_INCREMENT,
    booking_id INT NOT NULL,
    room_id INT NOT NULL,
    check_in DATETIME NOT NULL,
    check_out DATETIME NOT NULL,
    FOREIGN KEY(booking_id) REFERENCES bookings(id),
    FOREIGN KEY(room_id) REFERENCES rooms(id)
);
