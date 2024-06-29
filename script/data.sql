-- Insertion dans la table admin
INSERT INTO admin (nom, email, password) VALUES ('Admin1', 'admin1@gmail.com', 'password123');
INSERT INTO admin (nom, email, password) VALUES ('Admin2', 'admin2@gmail.com', 'password456');

-- Insertion dans la table proprietaire
INSERT INTO proprietaire (nom, contact, etat) VALUES ('Proprietaire1', '0344351080', 'particulier');
INSERT INTO proprietaire (nom, contact, etat) VALUES ('Proprietaire2', '0344351081', 'particulier');

-- Insertion dans la table client
INSERT INTO client (nom, email, etat) VALUES ('Client1', 'client1@gmail.com', 'particulier');
INSERT INTO client (nom, email, etat) VALUES ('Client2', 'client2@gmail.com', 'professionnel');

-- Insertion dans la table type_bien
INSERT INTO type_bien (nom, commission) VALUES ('Maison', 10.0);
INSERT INTO type_bien (nom, commission) VALUES ('Appartement', 8.0);
INSERT INTO type_bien (nom, commission) VALUES ('Villa', 15.0);
INSERT INTO type_bien (nom, commission) VALUES ('Immeuble', 12.0);

-- Insertion dans la table bien_immobilier
INSERT INTO bien_immobilier (nom, description, region, loyer, photo, id_proprietaire) VALUES ('Maison1', 'Belle maison avec jardin', 'Antananarivo', 500, 'maison1.jpg', 'PROP001');
INSERT INTO bien_immobilier (nom, description, region, loyer, photo, id_proprietaire) VALUES ('Appartement1', 'Appartement moderne', 'Antananarivo', 300, 'appartement1.jpg', 'PROP002');
INSERT INTO bien_immobilier (nom, description, region, loyer, photo, id_proprietaire) VALUES ('Villa1', 'Villa luxueuse avec piscine', 'Nosy Be', 1500, 'villa1.jpg', 'PROP001');
INSERT INTO bien_immobilier (nom, description, region, loyer, photo, id_proprietaire) VALUES ('Immeuble1', 'Immeuble de bureaux', 'Tamatave', 2000, 'immeuble1.jpg', 'PROP002');

-- Insertion dans la table bien_type_bien
INSERT INTO bien_type_bien (id_bien, id_type_bien) VALUES ('BI001', 'TYB001'); -- Maison1 - Maison
INSERT INTO bien_type_bien (id_bien, id_type_bien) VALUES ('BI002', 'TYB002'); -- Appartement1 - Appartement
INSERT INTO bien_type_bien (id_bien, id_type_bien) VALUES ('BI003', 'TYB003'); -- Villa1 - Villa
INSERT INTO bien_type_bien (id_bien, id_type_bien) VALUES ('BI004', 'TYB004'); -- Immeuble1 - Immeuble

-- Insertion dans la table location_bien
INSERT INTO location_bien (id_client, id_bien, duree, date_debut) VALUES ('CL001', 'BI001', 12, '2024-06-01');
INSERT INTO location_bien (id_client, id_bien, duree, date_debut) VALUES ('CL002', 'BI002', 6, '2024-06-15');
INSERT INTO location_bien (id_client, id_bien, duree, date_debut) VALUES ('CL001', 'BI003', 24, '2024-07-01');
INSERT INTO location_bien (id_client, id_bien, duree, date_debut) VALUES ('CL002', 'BI004', 12, '2024-07-15');

