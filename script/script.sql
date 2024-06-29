\c postgres;
drop database location_bien_immobilier;
create database location_bien_immobilier;
\c location_bien_immobilier;

create sequence seq_admin;
create table admin(
    id varchar primary key default CONCAT('ADM', LPAD(nextval('seq_admin')::TEXT , 3, '0')),
    nom varchar,
    email varchar,
    password varchar
);

create sequence seq_proprietaire;
create table proprietaire(
    id varchar primary key default CONCAT('PROP', LPAD(nextval('seq_proprietaire')::TEXT, 3,'0')),
    nom varchar,
    contact varchar,
    etat varchar
);

create sequence seq_client;
create table client(
    id varchar primary key default CONCAT('CL', LPAD(nextval('seq_client')::TEXT , 3 , '0')),
    nom varchar,
    email varchar,
    etat varchar
);

create sequence seq_bien_immobilier;
create table bien_immobilier(
    id varchar primary key default CONCAT('BI', LPAD(nextval('seq_bien_immobilier')::TEXT , 3 , '0')),
    nom varchar,
    description text,
    region varchar,
    loyer numeric,
    photo varchar,
    id_proprietaire varchar references proprietaire(id)
);

create sequence seq_type_bien;
create table type_bien(
    id  varchar primary key default CONCAT('TYB', LPAD(nextval('seq_type_bien')::TEXT , 3 , '0')),
    nom varchar,
    commission numeric
);

create sequence seq_bien_type_bien;
create table bien_type_bien(
    id varchar primary key default CONCAT('BTYB', LPAD(nextval('seq_bien_type_bien')::TEXT , 3 , '0')),
    id_bien varchar references bien_immobilier(id),
    id_type_bien varchar references type_bien(id)
);


create sequence seq_location_bien;
create table location_bien(
    id varchar primary key default CONCAT('LB', LPAD(nextval('seq_location_bien')::TEXT , 3 , '0')),
    id_client varchar references client(id),
    id_bien varchar references bien_immobilier(id),
    duree numeric,
    date_debut TIMESTAMP  
);


-- les jointure et fonction :
