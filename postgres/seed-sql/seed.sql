-- Delete DataBase If Exists
DROP DATABASE IF EXISTS empdb;

-- Create DataBase
CREATE DATABASE empdb
    WITH 
    OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'English_United States.1252'
    LC_CTYPE = 'English_United States.1252'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1;

-- Switch To New DataBase Drop the table is already exists
DROP TABLE IF EXISTS EMPLOYEE;

-- Create New Table
CREATE TABLE IF NOT EXISTS EMPLOYEE (
  	id serial PRIMARY KEY,
	name text,
	sex text,
	comments text
);
-- Insert Sample Data
INSERT INTO EMPLOYEE(name, sex, comments) 
VALUES ('Kevin Smith','Male', 'I saw a spotted striped blue worm shake hands with a legless lizard.');

INSERT INTO EMPLOYEE(name, sex, comments) 
VALUES ('Peter Becker','Male', 'Wednesday is hump day, but has anyone asked the camel about it?');

-- Check The sample Data
select * from EMPLOYEE
