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
    Password NVARCHAR(255) NOT NULL
);