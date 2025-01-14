-- Crear base de datos
CREATE DATABASE AppOnecodeDB;
GO

-- Usar la base de datos
USE BDOneCode;
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

CREATE TABLE Prioridad (
    Id INT IDENTITY(1,1) PRIMARY KEY,
	NombrePrioridad NVARCHAR(50) NOT NULL
);


INSERT INTO Prioridad(NombrePrioridad) VALUES ('Alta');

INSERT INTO Prioridad(NombrePrioridad) VALUES ('Media');

INSERT INTO Prioridad(NombrePrioridad) VALUES ('Baja');
select * from Trabajo


CREATE TABLE Estado(
Id INT IDENTITY(1,1) PRIMARY KEY,
Nombre NVARCHAR(50) NOT  NULL
);


INSERT INTO Estado(Nombre) VALUES ('Trabajando');

INSERT INTO Estado(Nombre) VALUES ('Pendiente');

INSERT INTO Estado(Nombre) VALUES ('Completada');


select * from Estado;


CREATE TABLE Tareas (
    Id INT IDENTITY(1,1) PRIMARY KEY, 
    Descripcion NVARCHAR(MAX) NOT NULL,
    UsuarioId INT NOT NULL,
    PrioridadId INT NOT NULL,
    EstadoId INT NOT NULL, 
    CONSTRAINT FK_Tareas_Usuario FOREIGN KEY (UsuarioId) REFERENCES Users(Id),
    CONSTRAINT FK_Tareas_Prioridad FOREIGN KEY (PrioridadId) REFERENCES Prioridad(Id),
    CONSTRAINT FK_Tareas_Estado FOREIGN KEY (EstadoId) REFERENCES Estado(Id)
);
	
select * from Tareas
