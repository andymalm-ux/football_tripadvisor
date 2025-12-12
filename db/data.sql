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
INSERT INTO hotels (name, address, city_id) VALUES
('Hotel Alguer Camp Nou', 'Passatge Pere Rodriguez 20', 1), 
('Onefam Les Corts', 'Passatge Regente Mendieta 5', 1),  
('NH Barcelona Stadium', 'Travessera de les Corts 150-152', 1), 
('Arya Stadium Hotel', 'CARRER DE SANTS 383', 1);

INSERT INTO tourist_attractions (name, type_id, address, city_id) VALUES
('Camp Nou', 1, 'Les Corts' ,1),
('Pick Otheo', 2, 'Av de Xile 38', 1),
('Futballárium Barcelona', 2, 'Carrer de Benavent 7', 1),
('Akihabar BCN', 2, 'Carrer d Eugeni d Ors 5', 1);

-- Madrid
INSERT INTO hotels (name, address, city_id) VALUES
('H10 Tribeca', 'Pedro Teixeira 5', 2),
('Melia Castilla', 'Calle del Poeta Joan Maragall 43', 2),
('NH Paseo de la Habana', 'Paseo de la Habana 73', 2),
('NYX Hotel Madrid', 'Aviador Zorita 34', 2);

INSERT INTO tourist_attractions (name, type_id, address, city_id) VALUES
('Metropolitano', 1, 'Av. de Luis Aragonés, 4', 2),
('Bernabéu', 1, 'Av de Concha Espina 1', 2),
('The Irish Rover', 2, 'Av de Brasil 7', 2),
('Covent Garden Craic Pub', 2, 'Calle del Dr Fleming 31', 2),
('Paddys Irish pub', 2, 'Av de Concha Espina 69', 2),
('BB2 TOMACOPAS', 2, 'C del aviador Zorita 49', 2);

-- Sevilla
INSERT INTO hotels (name, address, city_id) VALUES
('Novotel Sevilla', 'Avenida Eduardo Dato 71', 3),
('Meliá Lebreros', 'Luis de Morales 2', 3),
('Only YOU Hotel Sevilla', 'Avenida Kansas City 7', 3),
('Hotel Giralda Center', 'Calle Juan de Mata Carriazo 7', 3);

INSERT INTO tourist_attractions (name, type_id, address, city_id) VALUES
('Estadio Ramón Sánchez Pizjuán', 1, 'C. Sevilla Fútbol Club', 3),
('The Wessex Pub', 2, 'Av de la Buhaira 5', 3),
('Remember pub', 2, 'C Concejal Francisco Ballesteros 2', 3),
('Bocao Bar', 2, 'C Recaredo 14', 3);

-- Valencia
INSERT INTO hotels (name, address, city_id) VALUES
('Silken Puerta Valencia', 'Cardenal Benlloch 28', 4),
('SH Valencia Palace', 'Placa de Margarita Valldaura 2', 4),
('Hotel Dimar', 'Gran Via del Marqués del Túria 80', 4),
('Hospes Palau de la Mar', 'Avenida de Navarro Reverter 14-16', 4);

INSERT INTO tourist_attractions (name, type_id, address, city_id) VALUES
('Mestalla', 1, 'Av de Suécia', 4),
('Pub Lux Valencia', 2, 'Carrer del Dr Ferran 2', 4),
('Hocus Pocus Pub', 2, 'Carrer dels manyans 3', 4),
('St Patricks', 2, 'Gran Via del Marqués del túria 69', 4),
('Boricua Pub', 2, 'Carrer Serrano Morales 5', 4);

-- England:
-- London 
INSERT INTO hotels (name, address, city_id) VALUES
('Maldron Hotel Finsbury Park London', '175 Willoughby Lane, Finsbury Park', 5),
('The Bull & Last', '168 Highgate Road', 5),
('The Wesley Camden Town', '89 Plender Street', 5),
('The Luxury Inn', '156 Tottenham Road', 5);

INSERT INTO tourist_attractions (name, type_id, address, city_id) VALUES
('Emirates Stadium', 1, 'Hornsey Rd', 5),
('The BlackStock Pub', 2, '284 Seven Sisters Rd', 5),
('The Sheephaven Bay', 2, '2 Mornington St', 5),
('The Hunter S', 2, '194 Southgate Rd', 5),
('The Bull & Last Pub', 2, 'The Bull & Last', 5);

-- Manchester 
INSERT INTO hotels (name, address, city_id) VALUES
('Hotel Football Old Trafford', '99 Sir Matt Busby Way', 6),
('Hilton Garden Inn Manchester Emirates Old Trafford', 'Talbot Road', 6),
('Trafford Hall Hotel Manchester', '23 Talbot Road', 6),
('Holiday Inn Express Manchester - Salford Quays', 'Waterfront Quay, Salford Quays', 6);

INSERT INTO tourist_attractions (name, type_id, address, city_id) VALUES
('Old Trafford', 1, 'Old Trafford', 6),
('The Trafford', 2, '669 Chester Rd', 6),
('Tollgate', 2, 'Stretford', 6),
('Matchstick Man', 2, 'Ugly Bull Rd', 6);

-- Liverpool
INSERT INTO hotels (name, address, city_id) VALUES
('Hotel Tia', '21 Anfield Road', 7),
('Hotel Anfield', '23 Anfield Road', 7),
('The Cabbage Hall Hotel', '57 Breck Road', 7);

INSERT INTO tourist_attractions (name, type_id, address, city_id) VALUES
('Anfield', 1, 'Drunken monkey Rd', 7),
('The Albert Pub Anfield', 2, 'Slaughter way 4', 7),
('The Cabbage Hall Pub', 2, 'The Cabbage Hall Hotel', 7);

-- Newcastle
INSERT INTO hotels (name, address, city_id) VALUES
('Sandman Signature Newcastle Hotel', 'Gallowgate', 8),
('Maldron Hotel Newcastle', 'Newgate Street 17', 8),
('Royal Station Hotel', 'Neville Street', 8),
('The County Hotel Newcastle', 'Neville Street 38-42', 8);

INSERT INTO tourist_attractions (name, type_id, address, city_id) VALUES
('St James Park', 1, 'Beer Way 2', 8),
('St. James STACK', 2, 'Jack The Ripper Rd 9', 8),
('Slug & Lettuce', 2, 'Grainger St', 8),
('Tickets Bar Newcastle', 2, '43 Neville St', 8),
('The Victoria Comet', 2, '19 Neville St', 8);

-- Italy:
-- Milan
INSERT INTO hotels (name, address, city_id) VALUES
('B&B Hotel Milano San Siro', 'Via Achille 4', 9),
('Sheraton Milan San Siro', 'Via Caldera 3', 9),
('Idea Hotel Milano San Siro', 'Via Gaetano Airaghi 125', 9);

INSERT INTO tourist_attractions (name, type_id, address, city_id) VALUES
('San Siro', 1, 'Piazzale Angelo Moratti', 9),
('Chiringuito', 2, 'Piazzale dello Sport', 9),
('Green Bar', 2, 'La Prego 4', 9),
('Baroon', 2, 'Viale Monte Nero 5', 9);

-- Rome 
INSERT INTO hotels (name, address, city_id) VALUES
('BeYou Hotel Ponte Milvio', 'Via Cassia 4', 10),
('FAIROME Guest House', 'Via Flaminia 305', 10),
('Suite Pinturicchio', 'Via Pinturicchio 19', 10);

INSERT INTO tourist_attractions (name, type_id, address, city_id) VALUES
('Olympic Stadium', 1, 'Viale dello Stadio Olimpico', 10),
('Bar Palotta', 2, 'Viale dello Spagetti 5', 10),
('Tree Bar', 2, 'Viale Espresso Machiato 6', 10),
('Metropolita', 2, 'Viale Prosciutto di Parma 54', 10);

-- Naples
INSERT INTO hotels (name, address, city_id) VALUES
('Palazzo Esedra', 'Piazzale Vincenzo Tecchio 50', 11),
('LHP Napoli Palace & SPA', 'Viale Augusto 74', 11),
('Hotel Leopardi', 'Piazza Pilastri 12', 11);

INSERT INTO tourist_attractions (name, type_id, address, city_id) VALUES
('Stadio Diego Armando Maradona', 1, 'Piazzale Vincenzo Tecchio', 11),
('The Penny Black Pub', 2, 'Via Partenope 29', 11),
('Frank Malone Pub', 2, 'Viale Antonio Gramsci 14', 11);

-- Germany:
-- Munich
INSERT INTO hotels (name, address, city_id) VALUES
('Hampton by Hilton Munich City North', 'Ingolstädter Straße 44', 12),
('B&B Hotel München City-Nord', 'Frankfurter Ring 243', 12),
('AMERON München Motorworld', 'Am Ausbesserungswerk 8', 12);

INSERT INTO tourist_attractions (name, type_id, address, city_id) VALUES
('Allianz Arena', 1, 'Werner-Heisenberg-Allee 25', 12),
('Münchner Freiheit Bierpub', 2, 'Leopoldstraße 82', 12),
('Flemings Beer Lounge', 2, 'Leopoldstraße 130', 12),
('Motorworld Bar', 2, 'Am Ausbesserungswerk 8', 12);

-- Dortmund
INSERT INTO hotels (name, address, city_id) VALUES
('Mercure Hotel Dortmund Messe', 'Strobelallee 41', 13),
('Dorint An den Westfalenhallen Dortmund', 'Lindemannstrasse 88', 13),
('PLAZA INN Stays Design Dortmund', 'Märkische Straße 73', 13);

INSERT INTO tourist_attractions (name, type_id, address, city_id) VALUES
('Signal Iduna Park', 1, 'Strobelallee 50', 13),
('Strobels Sportsbar', 2, 'Strobelallee 50', 13),
('Wenkers am Markt', 2, 'Betenstraße 1', 13),
('Hovels Hausbrauerei', 2, 'Hoher Wall 5', 13);

-- Berlin
INSERT INTO hotels (name, address, city_id) VALUES
('Hotel Brandies Berlin', 'Kaiserdamm 27', 14),
('Hotel Rotdorn', 'Heerstraße 36', 14),
('Enjoy Hotel am Studio', 'Kaiserdamm 80', 14);

INSERT INTO tourist_attractions (name, type_id, address, city_id) VALUES
('Olympiastadion Berlin', 1, 'Olympischer Platz 3', 14),
('The Harp Pub', 2, 'Giesebrechtstraße 15', 14),
('Die kleine Kneipe', 2, 'Heerstraße 22', 14),
('Brauhaus Südstern', 2, 'Hasenheide 69', 14);

-- France:
-- Paris 
INSERT INTO hotels (name, address, city_id) VALUES
('Hôtel Botaniste', 'Rue Saint-Serge 5', 15),
('Hotel De Paris Boulogne', '104 Boulevard de la République, Boulogne-Billancourt', 15),
('Mercure Paris Boulogne', '37 Place René Clair, Boulogne-Billancourt', 15);

INSERT INTO tourist_attractions (name, type_id, address, city_id) VALUES
('Parc des Princes', 1, '24 Rue du Commandant Guilbaud', 15),
('OSullivans Rebel Bar', 2, '8 Place de la Porte de Saint-Cloud', 15),
('Le Parc Lounge Bar', 2, '37 Place René Clair', 15),
('Le Moulinsard', 2, '11 Rue Molière', 15);

-- Marseille
INSERT INTO hotels (name, address, city_id) VALUES
('B&B HOTEL Marseille Prado Parc des Expositions', '192 Avenue Pierre Mendès France', 16),
('RockyPop Marseille Hôtel', '4 Boulevard Charles Livon', 16),
('Comfort Aparthotel Marseille Prado', '23 Rue du Rouet', 16);   

INSERT INTO tourist_attractions (name, type_id, address, city_id) VALUES
('Stade Vélodrome', 1, '3 Boulevard Michelet', 16),
('The Shamrock Irish Pub', 2, 'Stade Vélodrome Parvis Norte', 16),
('Bar Le Marseillais', 2, '1 Rue Fort du Sanctuaire', 16),
('OBradys Irish Pub', 2, '378 Avenue de Mazargues', 16);

-- INSERT INTO hotel_attraction_distance (hotel_id, attraction_id, distance) VALUES
-- ()