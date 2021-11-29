CREATE USER keylogger WITH
    LOGIN
    NOSUPERUSER
    INHERIT
    NOCREATEDB
    NOCREATEROLE
    NOREPLICATION;
	
ALTER USER keylogger WITH PASSWORD 'keylogger_admin';

CREATE DATABASE keylogger WITH OWNER keylogger;

GRANT ALL PRIVILEGES ON DATABASE keylogger TO keylogger;

CREATE TABLE victima (
	victima_id serial PRIMARY KEY ,
	username VARCHAR ( 50 ) UNIQUE NOT NULL
);

CREATE TABLE log(
   log_id INT GENERATED ALWAYS AS IDENTITY,
   victima_id INT,
   log VARCHAR(255) NOT NULL,
   log_date varchar(255), 
   PRIMARY KEY(log_id),
   CONSTRAINT fk_victima
      FOREIGN KEY(victima_id) 
	  REFERENCES victima(victima_id)
);

insert into victima(victima_id,username) values(1,'prueba');