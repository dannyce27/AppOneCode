-- Crear base de datos
CREATE DATABASE AppOnecodeDB;
GO

-- Usar la base de datos
USE AppOnecodeDB;
GO

-- Crear tabla para usuarios con email
CREATE TABLE Users (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Contrasenaa NVARCHAR (250) NOT NULL
);

CREATE TABLE MarcasDeTiempo (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Fecha DATE NOT NULL,
    Hora TIME NOT NULL,
    Tiempo VARCHAR(50) NOT NULL
);
GO


select  * from MarcasDeTiempo;

select * From Users

drop table	Users

INSERT INTO Users (Username, Email, Contrasenaa) 
VALUES ('testUser', 'test@example.com', '123');


SELECT COLUMN_NAME 
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = 'Users'



CREATE TABLE Trabajo (
    Id INT IDENTITY(1,1) PRIMARY KEY,     
    Nombre NVARCHAR(100) NOT NULL,       
    Encargado NVARCHAR(100) NOT NULL,    
    AreaDeTrabajo NVARCHAR(100) NOT NULL, 
    Descripcion NVARCHAR(MAX) NULL              
);


select * from Trabajo