INSERT INTO users (email, password) VALUES
('admin', '1234');

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

INSERT INTO attraction_types (name) VALUES
('Stadium'),
('Pub');     

-- Spain: 
-- Barcelona
INSERT INTO hotels (name, address, city_id, check_in_time, check_out_time) VALUES
('Hotel Alguer Camp Nou', 'Passatge Pere Rodriguez 20', 1, '15:00', '11:00'), 
('Onefam Les Corts', 'Passatge Regente Mendieta 5', 1, '14:00', '11:00'),  
('NH Barcelona Stadium', 'Travessera de les Corts 150-152', 1, '15:00', '12:00'), 
('Arya Stadium Hotel', 'CARRER DE SANTS 383', 1, '16:00', '11:00');

INSERT INTO tourist_attractions (name, type_id, address, city_id) VALUES
('Camp Nou', 1, 'Les Corts' ,1),
('Pick Otheo', 2, 'Av de Xile 38', 1),
('Futballárium Barcelona', 2, 'Carrer de Benavent 7', 1),
('Akihabar BCN', 2, 'Carrer d Eugeni d Ors 5', 1);

INSERT INTO hotel_attraction_distance (hotel_id, attraction_id, distance_km) VALUES
(1, 1, 0.5),
(1, 2, 0.6),
(2, 1, 1.0),
(2, 3, 0.55),
(3, 1, 0.9),
(3, 4, 0.4),
(4, 1, 0.8),
(4, 4, 1.3);


-- Madrid
INSERT INTO hotels (name, address, city_id, check_in_time, check_out_time) VALUES
('H10 Tribeca', 'Pedro Teixeira 5', 2, '15:00', '12:00'),
('Melia Castilla', 'Calle del Poeta Joan Maragall 43', 2, '15:00', '12:00'),
('NH Paseo de la Habana', 'Paseo de la Habana 73', 2, '15:00', '11:00'),
('NYX Hotel Madrid', 'Aviador Zorita 34', 2, '15:00', '11:00');

INSERT INTO tourist_attractions (name, type_id, address, city_id) VALUES
('Metropolitano', 1, 'Av. de Luis Aragonés, 4', 2),
('Bernabéu', 1, 'Av de Concha Espina 1', 2),
('The Irish Rover', 2, 'Av de Brasil 7', 2),
('Covent Garden Craic Pub', 2, 'Calle del Dr Fleming 31', 2),
('Paddys Irish pub', 2, 'Av de Concha Espina 69', 2),
('BB2 TOMACOPAS', 2, 'C del aviador Zorita 49', 2);

INSERT INTO hotel_attraction_distance (hotel_id, attraction_id, distance_km) VALUES
(5, 6, 0.6),
(5, 7, 0.09),
(6, 6, 1.5),
(6, 8, 0.55),
(7, 6, 0.3),
(7, 9, 0.7),
(8, 6, 1.2),
(8, 10, 0.6);

-- Sevilla
INSERT INTO hotels (name, address, city_id, check_in_time, check_out_time) VALUES
('Novotel Sevilla', 'Avenida Eduardo Dato 71', 3, '15:00', '12:00'),
('Meliá Lebreros', 'Luis de Morales 2', 3, '15:00', '12:00'),
('Only YOU Hotel Sevilla', 'Avenida Kansas City 7', 3, '15:00', '11:00'),
('Hotel Giralda Center', 'Calle Juan de Mata Carriazo 7', 3, '14:00', '11:00');

INSERT INTO tourist_attractions (name, type_id, address, city_id) VALUES
('Estadio Ramón Sánchez Pizjuán', 1, 'C. Sevilla Fútbol Club', 3),
('The Wessex Pub', 2, 'Av de la Buhaira 5', 3),
('Remember pub', 2, 'C Concejal Francisco Ballesteros 2', 3),
('Bocao Bar', 2, 'C Recaredo 14', 3);

INSERT INTO hotel_attraction_distance (hotel_id, attraction_id, distance_km) VALUES
(9, 11, 0.1),
(9, 12, 1.0),
(10, 11, 0.3),
(10, 13, 0.55),
(11, 11, 0.75),
(11, 13, 0.08),
(12, 11, 1.8),
(12, 14, 1.2);

-- Valencia
INSERT INTO hotels (name, address, city_id, check_in_time, check_out_time) VALUES
('Silken Puerta Valencia', 'Cardenal Benlloch 28', 4, '15:00', '12:00'),
('SH Valencia Palace', 'Placa de Margarita Valldaura 2', 4, '16:00', '12:00'),
('Hotel Dimar', 'Gran Via del Marqués del Túria 80', 4, '15:00', '11:00'),
('Hospes Palau de la Mar', 'Avenida de Navarro Reverter 14-16', 4, '15:00', '12:00');

INSERT INTO tourist_attractions (name, type_id, address, city_id) VALUES
('Mestalla', 1, 'Av de Suécia', 4),
('Pub Lux Valencia', 2, 'Carrer del Dr Ferran 2', 4),
('Hocus Pocus Pub', 2, 'Carrer dels manyans 3', 4),
('St Patricks', 2, 'Gran Via del Marqués del túria 69', 4),
('Boricua Pub', 2, 'Carrer Serrano Morales 5', 4);

INSERT INTO hotel_attraction_distance (hotel_id, attraction_id, distance_km) VALUES
(13, 15, 0.7),
(13, 16, 0.15),
(14, 15, 1.7),
(14, 17, 0.2),
(15, 15, 1.3),
(15, 18, 0.5),
(16, 15, 0.75),
(16, 19, 0.3);

-- England:
-- London 
INSERT INTO hotels (name, address, city_id, check_in_time, check_out_time) VALUES
('Maldron Hotel Finsbury Park London', '175 Willoughby Lane, Finsbury Park', 5, '15:00', '11:00'),
('The Bull & Last', '168 Highgate Road', 5, '14:00', '11:00'),
('The Wesley Camden Town', '89 Plender Street', 5, '15:00', '12:00'),
('The Luxury Inn', '156 Tottenham Road', 5, '16:00', '11:00');

INSERT INTO tourist_attractions (name, type_id, address, city_id) VALUES
('Emirates Stadium', 1, 'Hornsey Rd', 5),
('The BlackStock Pub', 2, '284 Seven Sisters Rd', 5),
('The Sheephaven Bay', 2, '2 Mornington St', 5),
('The Hunter S', 2, '194 Southgate Rd', 5),
('The Bull & Last Pub', 2, 'The Bull & Last', 5);

INSERT INTO hotel_attraction_distance (hotel_id, attraction_id, distance_km) VALUES
(17, 20, 1.7),
(17, 21, 1.0),
(18, 20, 3.6),
(18, 24, 0.0),
(19, 20, 3.5),
(19, 22, 0.2),
(20, 20, 2.0),
(20, 23, 0.02);

-- Manchester 
INSERT INTO hotels (name, address, city_id, check_in_time, check_out_time) VALUES
('Hotel Football Old Trafford', '99 Sir Matt Busby Way', 6, '15:00', '11:00'),
('Hilton Garden Inn Manchester Emirates Old Trafford', 'Talbot Road', 6, '15:00', '12:00'),
('Trafford Hall Hotel Manchester', '23 Talbot Road', 6, '14:00', '11:00'),
('Holiday Inn Express Manchester - Salford Quays', 'Waterfront Quay, Salford Quays', 6, '15:00', '11:00');

INSERT INTO tourist_attractions (name, type_id, address, city_id) VALUES
('Old Trafford', 1, 'Old Trafford', 6),
('The Trafford', 2, '669 Chester Rd', 6),
('Tollgate', 2, 'Stretford', 6),
('Matchstick Man', 2, 'Ugly Bull Rd', 6);

INSERT INTO hotel_attraction_distance (hotel_id, attraction_id, distance_km) VALUES
(21, 25, 0.02),
(21, 26, 0.3),
(22, 25, 0.3),
(22, 26, 0.3),
(23, 25, 0.1),
(23, 27, 0.2),
(24, 25, 1.7),
(24, 28, 0.3);

-- Liverpool
INSERT INTO hotels (name, address, city_id, check_in_time, check_out_time) VALUES
('Hotel Tia', '21 Anfield Road', 7, '15:00', '11:00'),
('Hotel Anfield', '23 Anfield Road', 7, '14:00', '11:00'),
('The Cabbage Hall Hotel', '57 Breck Road', 7, '15:00', '10:00');

INSERT INTO tourist_attractions (name, type_id, address, city_id) VALUES
('Anfield', 1, 'Drunken monkey Rd', 7),
('The Albert Pub Anfield', 2, 'Slaughter way 4', 7),
('The Cabbage Hall Pub', 2, 'The Cabbage Hall Hotel', 7);

INSERT INTO hotel_attraction_distance (hotel_id, attraction_id, distance_km) VALUES
(25, 29, 0.3),
(25, 30, 0.3),
(26, 29, 0.3),
(26, 30, 0.3),
(27, 29, 0.9),
(27, 31, 0.0);

-- Newcastle
INSERT INTO hotels (name, address, city_id, check_in_time, check_out_time) VALUES
('Sandman Signature Newcastle Hotel', 'Gallowgate', 8, '15:00', '11:00'),
('Maldron Hotel Newcastle', 'Newgate Street 17', 8, '15:00', '11:00'),
('Royal Station Hotel', 'Neville Street', 8, '14:00', '11:00'),
('The County Hotel Newcastle', 'Neville Street 38-42', 8, '15:00', '12:00');

INSERT INTO tourist_attractions (name, type_id, address, city_id) VALUES
('St James Park', 1, 'Beer Way 2', 8),
('St. James STACK', 2, 'Jack The Ripper Rd 9', 8),
('Slug & Lettuce', 2, 'Grainger St', 8),
('Tickets Bar Newcastle', 2, '43 Neville St', 8),
('The Victoria Comet', 2, '19 Neville St', 8);

INSERT INTO hotel_attraction_distance (hotel_id, attraction_id, distance_km) VALUES
(28, 32, 0.1),
(28, 35, 0.3),
(29, 32, 1.0),
(29, 34, 0.6),
(30, 32, 0.9),
(30, 36, 0.4),
(31, 32, 0.95),
(31, 36, 0.5);

-- Italy:
-- Milan
INSERT INTO hotels (name, address, city_id, check_in_time, check_out_time) VALUES
('B&B Hotel Milano San Siro', 'Via Achille 4', 9, '15:00', '12:00'),
('Sheraton Milan San Siro', 'Via Caldera 3', 9, '15:00', '12:00'),
('Idea Hotel Milano San Siro', 'Via Gaetano Airaghi 125', 9, '14:00', '11:00');

INSERT INTO tourist_attractions (name, type_id, address, city_id) VALUES
('San Siro', 1, 'Piazzale Angelo Moratti', 9),
('Chiringuito', 2, 'Piazzale dello Sport', 9),
('Green Bar', 2, 'La Prego 4', 9),
('Baroon', 2, 'Viale Monte Nero 5', 9);

INSERT INTO hotel_attraction_distance (hotel_id, attraction_id, distance_km) VALUES
(32, 37, 0.3),
(32, 38, 0.5),
(33, 37, 1.4),
(33, 39, 0.6),
(34, 37, 2.5),
(34, 40, 0.7);

-- Rome 
INSERT INTO hotels (name, address, city_id, check_in_time, check_out_time) VALUES
('BeYou Hotel Ponte Milvio', 'Via Cassia 4', 10, '15:00', '11:00'),
('FAIROME Guest House', 'Via Flaminia 305', 10, '14:00', '10:00'),
('Suite Pinturicchio', 'Via Pinturicchio 19', 10, '15:00', '11:00');

INSERT INTO tourist_attractions (name, type_id, address, city_id) VALUES
('Olympic Stadium', 1, 'Viale dello Stadio Olimpico', 10),
('Bar Palotta', 2, 'Viale dello Spagetti 5', 10),
('Tree Bar', 2, 'Viale Espresso Machiato 6', 10),
('Metropolita', 2, 'Viale Prosciutto di Parma 54', 10);

INSERT INTO hotel_attraction_distance (hotel_id, attraction_id, distance_km) VALUES
(35, 41, 0.9),
(35, 42, 0.4),
(36, 41, 1.5),
(36, 43, 0.6),
(37, 41, 0.8),
(37, 44, 0.5);

-- Naples
INSERT INTO hotels (name, address, city_id, check_in_time, check_out_time) VALUES
('Palazzo Esedra', 'Piazzale Vincenzo Tecchio 50', 11, '15:00', '12:00'),
('LHP Napoli Palace & SPA', 'Viale Augusto 74', 11, '15:00', '11:00'),
('Hotel Leopardi', 'Piazza Pilastri 12', 11, '14:00', '11:00');

INSERT INTO tourist_attractions (name, type_id, address, city_id) VALUES
('Stadio Diego Armando Maradona', 1, 'Piazzale Vincenzo Tecchio', 11),
('The Penny Black Pub', 2, 'Via Partenope 29', 11),
('Frank Malone Pub', 2, 'Viale Antonio Gramsci 14', 11);

INSERT INTO hotel_attraction_distance (hotel_id, attraction_id, distance_km) VALUES
(38, 45, 0.2),
(38, 46, 0.6),
(39, 45, 0.7),
(39, 47, 0.5),
(40, 45, 1.0),
(40, 46, 0.8);

-- Germany:
-- Munich
INSERT INTO hotels (name, address, city_id, check_in_time, check_out_time) VALUES
('Hampton by Hilton Munich City North', 'Ingolstädter Straße 44', 12, '15:00', '12:00'),
('B&B Hotel München City-Nord', 'Frankfurter Ring 243', 12, '14:00', '11:00'),
('AMERON München Motorworld', 'Am Ausbesserungswerk 8', 12, '15:00', '11:00');

INSERT INTO tourist_attractions (name, type_id, address, city_id) VALUES
('Allianz Arena', 1, 'Werner-Heisenberg-Allee 25', 12),
('Münchner Freiheit Bierpub', 2, 'Leopoldstraße 82', 12),
('Flemings Beer Lounge', 2, 'Leopoldstraße 130', 12),
('Motorworld Bar', 2, 'Am Ausbesserungswerk 8', 12);

INSERT INTO hotel_attraction_distance (hotel_id, attraction_id, distance_km) VALUES
(41, 48, 5.5),
(41, 49, 0.7),
(42, 48, 4.8),
(42, 50, 0.6),
(43, 48, 6.0),
(43, 51, 0.0);

-- Dortmund
INSERT INTO hotels (name, address, city_id, check_in_time, check_out_time) VALUES
('Mercure Hotel Dortmund Messe', 'Strobelallee 41', 13, '15:00', '12:00'),
('Dorint An den Westfalenhallen Dortmund', 'Lindemannstrasse 88', 13, '15:00', '11:00'),
('PLAZA INN Stays Design Dortmund', 'Märkische Straße 73', 13, '14:00', '11:00');

INSERT INTO tourist_attractions (name, type_id, address, city_id) VALUES
('Signal Iduna Park', 1, 'Strobelallee 50', 13),
('Strobels Sportsbar', 2, 'Strobelallee 50', 13),
('Wenkers am Markt', 2, 'Betenstraße 1', 13),
('Hovels Hausbrauerei', 2, 'Hoher Wall 5', 13);

INSERT INTO hotel_attraction_distance (hotel_id, attraction_id, distance_km) VALUES
(44, 52, 0.3),
(44, 53, 0.1),
(45, 52, 0.8),
(45, 54, 0.9),
(46, 52, 1.7),
(46, 55, 1.0);

-- Berlin
INSERT INTO hotels (name, address, city_id, check_in_time, check_out_time) VALUES
('Hotel Brandies Berlin', 'Kaiserdamm 27', 14, '15:00', '11:00'),
('Hotel Rotdorn', 'Heerstraße 36', 14, '14:00', '11:00'),
('Enjoy Hotel am Studio', 'Kaiserdamm 80', 14, '15:00', '12:00');

INSERT INTO tourist_attractions (name, type_id, address, city_id) VALUES
('Olympiastadion Berlin', 1, 'Olympischer Platz 3', 14),
('The Harp Pub', 2, 'Giesebrechtstraße 15', 14),
('Die kleine Kneipe', 2, 'Heerstraße 22', 14),
('Brauhaus Südstern', 2, 'Hasenheide 69', 14);

INSERT INTO hotel_attraction_distance (hotel_id, attraction_id, distance_km) VALUES
(47, 56, 1.8),
(47, 57, 0.6),
(48, 56, 2.7),
(48, 58, 0.4),
(49, 56, 2.3),
(49, 59, 1.5);

-- France:
-- Paris 
INSERT INTO hotels (name, address, city_id, check_in_time, check_out_time) VALUES
('Hôtel Botaniste', 'Rue Saint-Serge 5', 15, '15:00', '12:00'),
('Hotel De Paris Boulogne', '104 Boulevard de la République, Boulogne-Billancourt', 15, '14:00', '11:00'),
('Mercure Paris Boulogne', '37 Place René Clair, Boulogne-Billancourt', 15, '15:00', '11:00');

INSERT INTO tourist_attractions (name, type_id, address, city_id) VALUES
('Parc des Princes', 1, '24 Rue du Commandant Guilbaud', 15),
('OSullivans Rebel Bar', 2, '8 Place de la Porte de Saint-Cloud', 15),
('Le Parc Lounge Bar', 2, '37 Place René Clair', 15),
('Le Moulinsard', 2, '11 Rue Molière', 15);

INSERT INTO hotel_attraction_distance (hotel_id, attraction_id, distance_km) VALUES
(50, 60, 1.3),
(50, 61, 0.8),
(51, 60, 1.1),
(51, 62, 0.6),
(52, 60, 0.9),
(52, 63, 0.4);

-- Marseille
INSERT INTO hotels (name, address, city_id, check_in_time, check_out_time) VALUES
('B&B HOTEL Marseille Prado Parc des Expositions', '192 Avenue Pierre Mendès France', 16, '15:00', '10:00'),
('RockyPop Marseille Hôtel', '4 Boulevard Charles Livon', 16, '15:30', '12:00'),
('Comfort Aparthotel Marseille Prado', '23 Rue du Rouet', 16, '14:00', '11:00');   

INSERT INTO tourist_attractions (name, type_id, address, city_id) VALUES
('Stade Vélodrome', 1, '3 Boulevard Michelet', 16),
('The Shamrock Irish Pub', 2, 'Stade Vélodrome Parvis Norte', 16),
('Bar Le Marseillais', 2, '1 Rue Fort du Sanctuaire', 16),
('OBradys Irish Pub', 2, '378 Avenue de Mazargues', 16);

INSERT INTO hotel_attraction_distance (hotel_id, attraction_id, distance_km) VALUES
(53, 64, 0.7),
(53, 65, 0.5),
(54, 64, 3.0),
(54, 66, 0.8),
(55, 64, 1.2),
(55, 67, 0.6);

-- Hotel rooms:
-- Amenities:
INSERT INTO amenities (name) VALUES
('Wi-fi'),
('Pool'),
('Breakfast'); 

-- (1) Hotel Alguer Camp Nou
INSERT INTO amenities_hotel (hotel_id, amenity_id) 
VALUES (1,1),(1,3);
-- (2) Onefam Les Corts
INSERT INTO amenities_hotel (hotel_id, amenity_id) 
VALUES (2,1),(2,2),(2,3);
-- (3) NH Barcelona Stadium
INSERT INTO amenities_hotel (hotel_id, amenity_id) 
VALUES (3,1),(3,3);
-- (4) Arya Stadium Hotel
INSERT INTO amenities_hotel (hotel_id, amenity_id) 
VALUES (4,1);
-- (5) H10 Tribeca
INSERT INTO amenities_hotel (hotel_id, amenity_id) 
VALUES (5,1),(5,3);
-- (6) Melia Castilla
INSERT INTO amenities_hotel (hotel_id, amenity_id) 
VALUES (6,1),(6,2),(6,3);
-- (7) NH Paseo de la Habana
INSERT INTO amenities_hotel (hotel_id, amenity_id) 
VALUES (7,1),(7,3);
-- (8) NYX Hotel Madrid
INSERT INTO amenities_hotel (hotel_id, amenity_id) 
VALUES (8,1);
-- (9) Novotel Sevilla
INSERT INTO amenities_hotel (hotel_id, amenity_id) 
VALUES (9,1),(9,3);
-- (10) Meliá Lebreros
INSERT INTO amenities_hotel (hotel_id, amenity_id) 
VALUES (10,1),(10,2),(10,3);
-- (11) Only YOU Hotel
INSERT INTO amenities_hotel (hotel_id, amenity_id) 
VALUES (11,1);
-- (12) Hotel Giralda Center
INSERT INTO amenities_hotel (hotel_id, amenity_id) 
VALUES (12,1),(12,2);
-- (13) Silken Puerta Valencia
INSERT INTO amenities_hotel (hotel_id, amenity_id) 
VALUES (13,1),(13,3);
-- (14) SH Valencia Palace
INSERT INTO amenities_hotel (hotel_id, amenity_id) 
VALUES (14,1),(14,2),(14,3);
-- (17) Maldron Hotel Finsbury Park London
INSERT INTO amenities_hotel (hotel_id, amenity_id) 
VALUES (17,1),(17,3);
-- (18) The Bull & Last
INSERT INTO amenities_hotel (hotel_id, amenity_id) 
VALUES (18,1),(18,2),(18,3);
-- (19) The Wesley Camden Town
INSERT INTO amenities_hotel (hotel_id, amenity_id) 
VALUES (19,1),(19,3);
-- (20) The Luxury Inn
INSERT INTO amenities_hotel (hotel_id, amenity_id) 
VALUES (20,1),(20,2);
-- (21) Hotel Football Old Trafford
INSERT INTO amenities_hotel (hotel_id, amenity_id) 
VALUES (21,1),(21,3);
-- (22) Hilton Garden Inn Manchester Emirates Old Trafford
INSERT INTO amenities_hotel (hotel_id, amenity_id) 
VALUES (22,1),(22,2),(22,3);
-- (23) Trafford Hall Hotel Manchester
INSERT INTO amenities_hotel (hotel_id, amenity_id) 
VALUES (23,1),(23,3);
-- (24) Holiday Inn Express Manchester
INSERT INTO amenities_hotel (hotel_id, amenity_id) 
VALUES (24,1),(24,2);
-- (25) Hotel Tia
INSERT INTO amenities_hotel (hotel_id, amenity_id) 
VALUES (25,1),(25,3);
-- (26) Hotel Anfield
INSERT INTO amenities_hotel (hotel_id, amenity_id) 
VALUES (26,1),(26,2),(26,3);
-- (28) Sandman Signature Newcastle Hotel
INSERT INTO amenities_hotel (hotel_id, amenity_id) 
VALUES (28,1),(28,3);
-- (29) Maldron Hotel Newcastle
INSERT INTO amenities_hotel (hotel_id, amenity_id) 
VALUES (29,1),(29,3);
-- (30) Royal Station Hotel
INSERT INTO amenities_hotel (hotel_id, amenity_id) 
VALUES (30,1),(30,3);
-- (31) The County Hotel Newcastle
INSERT INTO amenities_hotel (hotel_id, amenity_id) 
VALUES (31,1),(31,3);
-- (36) FAIROME Guest House
INSERT INTO amenities_hotel (hotel_id, amenity_id) 
VALUES (36,1),(36,2),(36,3);
-- (37) Suite Pinturicchio
INSERT INTO amenities_hotel (hotel_id, amenity_id) 
VALUES (37,1),(37,3);
-- (38) Palazzo Esedra
INSERT INTO amenities_hotel (hotel_id, amenity_id) 
VALUES (38,1),(38,3);
-- (39) LHP Napoli Palace & SPA
INSERT INTO amenities_hotel (hotel_id, amenity_id) 
VALUES (39,1),(39,2),(39,3);
-- (40) Hotel Leopardi
INSERT INTO amenities_hotel (hotel_id, amenity_id) 
VALUES (40,1),(40,3);
-- (41) Hampton by Hilton Munich City North
INSERT INTO amenities_hotel (hotel_id, amenity_id) 
VALUES (41,1);
-- (42) B&B Hotel München City-Nord
INSERT INTO amenities_hotel (hotel_id, amenity_id) 
VALUES (42,1),(42,2),(42,3);
-- (43) AMERON München Motorworld
INSERT INTO amenities_hotel (hotel_id, amenity_id) 
VALUES (43,1),(43,3);
-- (45) Dorint An den Westfalenhallen Dortmund
INSERT INTO amenities_hotel (hotel_id, amenity_id) 
VALUES (45,1),(45,2),(45,3);
-- (47) Hotel Brandies Berlin
INSERT INTO amenities_hotel (hotel_id, amenity_id) 
VALUES (47,1),(47,3);
-- (48) Hotel Rotdorn
INSERT INTO amenities_hotel (hotel_id, amenity_id) 
VALUES (48,1),(48,2),(48,3);
-- (51) Hotel De Paris Boulogne
INSERT INTO amenities_hotel (hotel_id, amenity_id) 
VALUES (51,1),(51,2),(51,3);
-- (52) Mercure Paris Boulogne
INSERT INTO amenities_hotel (hotel_id, amenity_id) 
VALUES (52,1);
-- (54) RockyPop Marseille Hôtel
INSERT INTO amenities_hotel (hotel_id, amenity_id) 
VALUES (54,1),(54,2),(54,3);
-- (55) Comfort Aparthotel Marseille Prado
INSERT INTO amenities_hotel (hotel_id, amenity_id) 
VALUES (55,1),(55,3);

INSERT INTO rooms (hotel_id, name, capacity, price_per_night) VALUES
-- Hotel 1
(1, 'Standard Room 1001', 2, 900),
(1, 'Superior Room 1002', 2, 1100),
(1, 'Deluxe Room 1003', 2, 1300),
(1, 'Premium Room 1004', 2, 1500),

-- Hotel 2
(2, 'Standard Room 2001', 2, 920),
(2, 'Superior Room 2002', 2, 1120),
(2, 'Deluxe Room 2003', 2, 1320),
(2, 'Premium Room 2004', 2, 1520),

-- Hotel 3
(3, 'Standard Room 3001', 2, 940),
(3, 'Superior Room 3002', 2, 1150),
(3, 'Deluxe Room 3003', 2, 1350),
(3, 'Premium Room 3004', 2, 1550),

-- Hotel 4
(4, 'Standard Room 4001', 2, 910),
(4, 'Superior Room 4002', 2, 1120),
(4, 'Deluxe Room 4003', 2, 1330),
(4, 'Premium Room 4004', 2, 1510),

-- Hotel 5
(5, 'Standard Room 5001', 2, 930),
(5, 'Superior Room 5002', 2, 1160),
(5, 'Deluxe Room 5003', 2, 1360),
(5, 'Premium Room 5004', 2, 1560),

-- Hotel 6
(6, 'Standard Room 6001', 2, 940),
(6, 'Superior Room 6002', 2, 1180),
(6, 'Deluxe Room 6003', 2, 1380),
(6, 'Premium Room 6004', 2, 1580),

-- Hotel 7
(7, 'Standard Room 7001', 2, 950),
(7, 'Superior Room 7002', 2, 1190),
(7, 'Deluxe Room 7003', 2, 1390),
(7, 'Premium Room 7004', 2, 1590),

-- Hotel 8
(8, 'Standard Room 8001', 2, 920),
(8, 'Superior Room 8002', 2, 1140),
(8, 'Deluxe Room 8003', 2, 1340),
(8, 'Premium Room 8004', 2, 1540),

-- Hotel 9
(9, 'Standard Room 9001', 2, 930),
(9, 'Superior Room 9002', 2, 1160),
(9, 'Deluxe Room 9003', 2, 1360),
(9, 'Premium Room 9004', 2, 1550),

-- Hotel 10
(10, 'Standard Room 10001', 2, 950),
(10, 'Superior Room 10002', 2, 1200),
(10, 'Deluxe Room 10003', 2, 1400),
(10, 'Premium Room 10004', 2, 1600),

-- Hotel 11
(11, 'Standard Room 11001', 2, 910),
(11, 'Superior Room 11002', 2, 1120),
(11, 'Deluxe Room 11003', 2, 1320),
(11, 'Premium Room 11004', 2, 1500),

-- Hotel 12
(12, 'Standard Room 12001', 2, 920),
(12, 'Superior Room 12002', 2, 1150),
(12, 'Deluxe Room 12003', 2, 1350),
(12, 'Premium Room 12004', 2, 1540),

-- Hotel 13
(13, 'Standard Room 13001', 2, 940),
(13, 'Superior Room 13002', 2, 1180),
(13, 'Deluxe Room 13003', 2, 1380),
(13, 'Premium Room 13004', 2, 1580),

-- Hotel 14
(14, 'Standard Room 14001', 2, 950),
(14, 'Superior Room 14002', 2, 1200),
(14, 'Deluxe Room 14003', 2, 1400),
(14, 'Premium Room 14004', 2, 1600),

-- Hotel 15
(15, 'Standard Room 15001', 2, 930),
(15, 'Superior Room 15002', 2, 1160),
(15, 'Deluxe Room 15003', 2, 1360),
(15, 'Premium Room 15004', 2, 1550),

-- Hotel 16
(16, 'Standard Room 16001', 2, 940),
(16, 'Superior Room 16002', 2, 1180),
(16, 'Deluxe Room 16003', 2, 1380),
(16, 'Premium Room 16004', 2, 1590),

-- Hotel 17
(17, 'Standard Room 17001', 2, 910),
(17, 'Superior Room 17002', 2, 1120),
(17, 'Deluxe Room 17003', 2, 1320),
(17, 'Premium Room 17004', 2, 1500),

-- Hotel 18
(18, 'Standard Room 18001', 2, 920),
(18, 'Superior Room 18002', 2, 1140),
(18, 'Deluxe Room 18003', 2, 1340),
(18, 'Premium Room 18004', 2, 1540),

-- Hotel 19
(19, 'Standard Room 19001', 2, 930),
(19, 'Superior Room 19002', 2, 1180),
(19, 'Deluxe Room 19003', 2, 1380),
(19, 'Premium Room 19004', 2, 1580),

-- Hotel 20
(20, 'Standard Room 20001', 2, 950),
(20, 'Superior Room 20002', 2, 1210),
(20, 'Deluxe Room 20003', 2, 1410),
(20, 'Premium Room 20004', 2, 1610),

-- Hotel 21
(21, 'Standard Room 21001', 2, 920),
(21, 'Superior Room 21002', 2, 1140),
(21, 'Deluxe Room 21003', 2, 1340),
(21, 'Premium Room 21004', 2, 1530),

-- Hotel 22
(22, 'Standard Room 22001', 2, 930),
(22, 'Superior Room 22002', 2, 1170),
(22, 'Deluxe Room 22003', 2, 1370),
(22, 'Premium Room 22004', 2, 1560),

-- Hotel 23
(23, 'Standard Room 23001', 2, 960),
(23, 'Superior Room 23002', 2, 1220),
(23, 'Deluxe Room 23003', 2, 1420),
(23, 'Premium Room 23004', 2, 1620),

-- Hotel 24
(24, 'Standard Room 24001', 2, 900),
(24, 'Superior Room 24002', 2, 1100),
(24, 'Deluxe Room 24003', 2, 1300),
(24, 'Premium Room 24004', 2, 1480),

-- Hotel 25
(25, 'Standard Room 25001', 2, 920),
(25, 'Superior Room 25002', 2, 1140),
(25, 'Deluxe Room 25003', 2, 1340),
(25, 'Premium Room 25004', 2, 1540),

-- Hotel 26
(26, 'Standard Room 26001', 2, 930),
(26, 'Superior Room 26002', 2, 1160),
(26, 'Deluxe Room 26003', 2, 1360),
(26, 'Premium Room 26004', 2, 1550),

-- Hotel 27
(27, 'Standard Room 27001', 2, 950),
(27, 'Superior Room 27002', 2, 1200),
(27, 'Deluxe Room 27003', 2, 1400),
(27, 'Premium Room 27004', 2, 1600),

-- Hotel 28
(28, 'Standard Room 28001', 2, 960),
(28, 'Superior Room 28002', 2, 1220),
(28, 'Deluxe Room 28003', 2, 1420),
(28, 'Premium Room 28004', 2, 1610),

-- Hotel 29
(29, 'Standard Room 29001', 2, 910),
(29, 'Superior Room 29002', 2, 1120),
(29, 'Deluxe Room 29003', 2, 1320),
(29, 'Premium Room 29004', 2, 1510),

-- Hotel 30
(30, 'Standard Room 30001', 2, 930),
(30, 'Superior Room 30002', 2, 1150),
(30, 'Deluxe Room 30003', 2, 1360),
(30, 'Premium Room 30004', 2, 1550),

-- Hotel 31
(31, 'Standard Room 31001', 2, 940),
(31, 'Superior Room 31002', 2, 1180),
(31, 'Deluxe Room 31003', 2, 1380),
(31, 'Premium Room 31004', 2, 1570),

-- Hotel 32
(32, 'Standard Room 32001', 2, 960),
(32, 'Superior Room 32002', 2, 1220),
(32, 'Deluxe Room 32003', 2, 1420),
(32, 'Premium Room 32004', 2, 1630),

-- Hotel 33
(33, 'Standard Room 33001', 2, 900),
(33, 'Superior Room 33002', 2, 1100),
(33, 'Deluxe Room 33003', 2, 1300),
(33, 'Premium Room 33004', 2, 1490),

-- Hotel 34
(34, 'Standard Room 34001', 2, 920),
(34, 'Superior Room 34002', 2, 1150),
(34, 'Deluxe Room 34003', 2, 1350),
(34, 'Premium Room 34004', 2, 1540),

-- Hotel 35
(35, 'Standard Room 35001', 2, 930),
(35, 'Superior Room 35002', 2, 1170),
(35, 'Deluxe Room 35003', 2, 1370),
(35, 'Premium Room 35004', 2, 1570),

-- Hotel 36
(36, 'Standard Room 36001', 2, 950),
(36, 'Superior Room 36002', 2, 1200),
(36, 'Deluxe Room 36003', 2, 1400),
(36, 'Premium Room 36004', 2, 1600),

-- Hotel 37
(37, 'Standard Room 37001', 2, 910),
(37, 'Superior Room 37002', 2, 1120),
(37, 'Deluxe Room 37003', 2, 1320),
(37, 'Premium Room 37004', 2, 1500),

-- Hotel 38
(38, 'Standard Room 38001', 2, 930),
(38, 'Superior Room 38002', 2, 1150),
(38, 'Deluxe Room 38003', 2, 1360),
(38, 'Premium Room 38004', 2, 1550),

-- Hotel 39
(39, 'Standard Room 39001', 2, 940),
(39, 'Superior Room 39002', 2, 1180),
(39, 'Deluxe Room 39003', 2, 1380),
(39, 'Premium Room 39004', 2, 1580),

-- Hotel 40
(40, 'Standard Room 40001', 2, 960),
(40, 'Superior Room 40002', 2, 1220),
(40, 'Deluxe Room 40003', 2, 1420),
(40, 'Premium Room 40004', 2, 1630),

-- Hotel 41
(41, 'Standard Room 41001', 2, 900),
(41, 'Superior Room 41002', 2, 1100),
(41, 'Deluxe Room 41003', 2, 1300),
(41, 'Premium Room 41004', 2, 1480),

-- Hotel 42
(42, 'Standard Room 42001', 2, 920),
(42, 'Superior Room 42002', 2, 1130),
(42, 'Deluxe Room 42003', 2, 1330),
(42, 'Premium Room 42004', 2, 1520),

-- Hotel 43
(43, 'Standard Room 43001', 2, 950),
(43, 'Superior Room 43002', 2, 1200),
(43, 'Deluxe Room 43003', 2, 1400),
(43, 'Premium Room 43004', 2, 1600),

-- Hotel 44
(44, 'Standard Room 44001', 2, 930),
(44, 'Superior Room 44002', 2, 1170),
(44, 'Deluxe Room 44003', 2, 1370),
(44, 'Premium Room 44004', 2, 1570),

-- Hotel 45
(45, 'Standard Room 45001', 2, 940),
(45, 'Superior Room 45002', 2, 1190),
(45, 'Deluxe Room 45003', 2, 1390),
(45, 'Premium Room 45004', 2, 1590),

-- Hotel 46
(46, 'Standard Room 4601', 2, 980),
(46, 'Superior Room 4602', 2, 1190),
(46, 'Deluxe Room 4603', 2, 1390),
(46, 'Premium Room 4604', 2, 1590),

-- Hotel 47
(47, 'Standard Room 4701', 2, 990),
(47, 'Superior Room 4702', 2, 1210),
(47, 'Deluxe Room 4703', 2, 1420),
(47, 'Premium Room 4704', 2, 1620),

-- Hotel 48
(48, 'Standard Room 4801', 2, 940),
(48, 'Superior Room 4802', 2, 1130),
(48, 'Deluxe Room 4803', 2, 1340),
(48, 'Premium Room 4804', 2, 1520),

-- Hotel 49
(49, 'Standard Room 4901', 2, 960),
(49, 'Superior Room 4902', 2, 1180),
(49, 'Deluxe Room 4903', 2, 1380),
(49, 'Premium Room 4904', 2, 1570),

-- Hotel 50
(50, 'Standard Room 5001', 2, 990),
(50, 'Superior Room 5002', 2, 1230),
(50, 'Deluxe Room 5003', 2, 1440),
(50, 'Premium Room 5004', 2, 1640),

-- Hotel 51
(51, 'Standard Room 5101', 2, 930),
(51, 'Superior Room 5102', 2, 1100),
(51, 'Deluxe Room 5103', 2, 1290),
(51, 'Premium Room 5104', 2, 1470),

-- Hotel 52
(52, 'Standard Room 5201', 2, 950),
(52, 'Superior Room 5202', 2, 1150),
(52, 'Deluxe Room 5203', 2, 1350),
(52, 'Premium Room 5204', 2, 1530),

-- Hotel 53
(53, 'Standard Room 5301', 2, 970),
(53, 'Superior Room 5302', 2, 1180),
(53, 'Deluxe Room 5303', 2, 1390),
(53, 'Premium Room 5304', 2, 1580),

-- Hotel 54
(54, 'Standard Room 5401', 2, 980),
(54, 'Superior Room 5402', 2, 1210),
(54, 'Deluxe Room 5403', 2, 1410),
(54, 'Premium Room 5404', 2, 1600),

-- Hotel 55
(55, 'Standard Room 5501', 2, 1000),
(55, 'Superior Room 5502', 2, 1250),
(55, 'Deluxe Room 5503', 2, 1450),
(55, 'Premium Room 5504', 2, 1650);
