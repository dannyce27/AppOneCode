	-- Crear base de datos
CREATE DATABASE BDOneCode;
GO

-- Usar la base de datos
USE BDOneCode;
GO


CREATE TABLE TipoUsuario(
idTipoUsuario INT IDENTITY(1,1) PRIMARY KEY,
NombreTipoUsuario NVARCHAR(50) NOT NULL
);


-- Crear tabla para usuarios con email
CREATE TABLE Users (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Contrasenaa NVARCHAR(250) NOT NULL,
	ImagenPerfil VARBINARY(MAX),
	idTipoUsuario INT 
    FOREIGN KEY (idTipoUsuario) REFERENCES TipoUsuario(idTipoUsuario)
);







INSERT INTO Users (Username, Email, Contrasenaa, idTipoUsuario)
VALUES ('NuevoUsuario', 'nuevo.usuario@dominio.com', 'hashedPassword123', 1);

		

		
INSERT INTO TipoUsuario (NombreTipoUsuario)
VALUES 
    ('Administrador'), 
    ('Empleado'), 
    ('Comentarista');













CREATE TABLE MarcasDeTiempo (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Fecha DATE NOT NULL,
    Hora TIME NOT NULL,
    Tiempo VARCHAR(50) NOT NULL
);
GO




INSERT INTO Users (Username, Email, Contrasenaa) 
VALUES ('testUser', 'test@example.com', '123');

EXEC sp_help 'Users';
SELECT COLUMN_NAME 
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = 'Users'


Create table AreaTrabajo( 
    Id INT IDENTITY(1,1) PRIMARY KEY, 
	NombreArea NVARCHAR(MAX) NOT NULL

);


INSERT INTO AreaTrabajo (NombreArea) VALUES ('Diseñador')
INSERT INTO AreaTrabajo (NombreArea) VALUES ('Programador')
INSERT INTO AreaTrabajo (NombreArea) VALUES ('Supervisor')

select * From AreaTrabajo

CREATE TABLE Trabajo (
    Id INT IDENTITY(1,1) PRIMARY KEY,     
    Nombre NVARCHAR(100) NOT NULL,       
    IdEncargado INT NOT NULL,    
    IdAreaTrabajo INT NOT NULL, 
    Descripcion NVARCHAR(MAX) NULL,  
	FechaInicio DATE NOT NULL,
	FechaFinalizacion DATE NOT NULL,
	CONSTRAINT FK_ID_Encargaodo FOREIGN KEY (IdEncargado) REFERENCES Users (Id),
	CONSTRAINT FK_ID_AreaT FOREIGN KEY (IdAreaTrabajo) REFERENCES AreaTrabajo (Id)

);




CREATE TABLE Prioridad (
    Id INT IDENTITY(1,1) PRIMARY KEY,
	NombrePrioridad NVARCHAR(50) NOT NULL
);


INSERT INTO Prioridad(NombrePrioridad) VALUES ('Alta');

INSERT INTO Prioridad(NombrePrioridad) VALUES ('Media');

INSERT INTO Prioridad(NombrePrioridad) VALUES ('Baja');
select * from Estado


CREATE TABLE Estado(
Id INT IDENTITY(1,1) PRIMARY KEY,
NombreEstado NVARCHAR(50) NOT  NULL
);



INSERT INTO Estado(NombreEstado) VALUES ('Trabajando');

INSERT INTO Estado(NombreEstado) VALUES ('Pendiente');

INSERT INTO Estado(NombreEstado) VALUES ('Completada');





CREATE TABLE Tareas (
    Id INT IDENTITY(1,1) PRIMARY KEY, 
    Descripcion NVARCHAR(MAX) NOT NULL,
    UsuarioId INT NOT NULL,
    PrioridadId INT NOT NULL,
    EstadoId INT NOT NULL, 
	FechaInicio DATE NOT NULL,
	FechaFinalizacion DATE NOT NULL,
	idProyecto INT NOT NULL,
	CONSTRAINT FK_ID_Proyecto FOREIGN KEY (idProyecto) REFERENCES Trabajo(Id),
    CONSTRAINT FK_Tareas_Usuario FOREIGN KEY (UsuarioId) REFERENCES Users(Id),
    CONSTRAINT FK_Tareas_Prioridad FOREIGN KEY (PrioridadId) REFERENCES Prioridad(Id),
    CONSTRAINT FK_Tareas_Estado FOREIGN KEY (EstadoId) REFERENCES Estado(Id)
);
	
--TABLAS DE AUDITORIAS 

CREATE TABLE AuditoriaCambiosTareas (
    Id INT IDENTITY(1,1) PRIMARY KEY,    
    Fecha DATE NOT NULL,                 
    Hora TIME NOT NULL,                    
    NombreUsuario NVARCHAR(100) NOT NULL, 
    TipoCambio NVARCHAR(10) NOT NULL,      
    DescripcionCambio NVARCHAR(MAX) NULL,  
    TareaId INT NOT NULL                   
);


CREATE  TRIGGER trg_AuditoriaInsertTareas
ON Tareas
FOR INSERT
AS
BEGIN
    DECLARE @Fecha DATE = GETDATE();
    DECLARE @Hora TIME = CONVERT(TIME, GETDATE());
    DECLARE @NombreUsuario NVARCHAR(100) = SUSER_SNAME(); 
    DECLARE @TareaId INT;

  
    SELECT @TareaId = Id FROM INSERTED;

    
    INSERT INTO AuditoriaCambiosTareas (Fecha, Hora, NombreUsuario, TipoCambio, TareaId)
    VALUES (@Fecha, @Hora, @NombreUsuario, 'INSERT', @TareaId);
END;


CREATE TRIGGER trg_AuditoriaUpdateTareas
ON Tareas
FOR UPDATE
AS
BEGIN
    DECLARE @Fecha DATE = GETDATE();
    DECLARE @Hora TIME = CONVERT(TIME, GETDATE());
    DECLARE @NombreUsuario NVARCHAR(100) = SUSER_SNAME(); 
    DECLARE @TareaId INT;

   
    SELECT @TareaId = Id FROM INSERTED;

   
    INSERT INTO AuditoriaCambiosTareas (Fecha, Hora, NombreUsuario, TipoCambio, TareaId)
    VALUES (@Fecha, @Hora, @NombreUsuario, 'UPDATE', @TareaId);
END;


CREATE TRIGGER trg_AuditoriaDeleteTareas
ON Tareas
FOR DELETE
AS
BEGIN
    DECLARE @Fecha DATE = GETDATE();
    DECLARE @Hora TIME = CONVERT(TIME, GETDATE());
    DECLARE @NombreUsuario NVARCHAR(100) = SUSER_SNAME(); 
    DECLARE @TareaId INT;

   
    SELECT @TareaId = Id FROM DELETED;

    
    INSERT INTO AuditoriaCambiosTareas (Fecha, Hora, NombreUsuario, TipoCambio, TareaId)
    VALUES (@Fecha, @Hora, @NombreUsuario, 'DELETE', @TareaId);
END;


CREATE TABLE AuditoriaCambiosTrabajo (
    Id INT IDENTITY(1,1) PRIMARY KEY,     
    Fecha DATE NOT NULL,                  
    Hora TIME NOT NULL,                    
    NombreUsuario NVARCHAR(100) NOT NULL, 
    TipoCambio NVARCHAR(10) NOT NULL,      
    DescripcionCambio NVARCHAR(MAX) NULL, 
    TrabajoId INT NOT NULL                 
);


CREATE TRIGGER trg_AuditoriaInsertTrabajo
ON Trabajo
FOR INSERT
AS
BEGIN
    DECLARE @Fecha DATE = GETDATE();
    DECLARE @Hora TIME = CONVERT(TIME, GETDATE());
    DECLARE @NombreUsuario NVARCHAR(100) = SUSER_SNAME(); -- Nombre del usuario actual
    DECLARE @TrabajoId INT;

    -- Obtener el Id del trabajo insertado
    SELECT @TrabajoId = Id FROM INSERTED;

    -- Registrar en la tabla de auditoría
    INSERT INTO AuditoriaCambiosTrabajo (Fecha, Hora, NombreUsuario, TipoCambio, TrabajoId)
    VALUES (@Fecha, @Hora, @NombreUsuario, 'INSERT', @TrabajoId);
END;

CREATE TRIGGER trg_AuditoriaUpdateTrabajo
ON Trabajo
FOR UPDATE
AS
BEGIN
    DECLARE @Fecha DATE = GETDATE();
    DECLARE @Hora TIME = CONVERT(TIME, GETDATE());
    DECLARE @NombreUsuario NVARCHAR(100) = SUSER_SNAME(); -- Nombre del usuario actual
    DECLARE @TrabajoId INT;

    -- Obtener el Id del trabajo actualizado
    SELECT @TrabajoId = Id FROM INSERTED;

    -- Registrar en la tabla de auditoría
    INSERT INTO AuditoriaCambiosTrabajo (Fecha, Hora, NombreUsuario, TipoCambio, TrabajoId)
    VALUES (@Fecha, @Hora, @NombreUsuario, 'UPDATE', @TrabajoId);
END;

CREATE TRIGGER trg_AuditoriaDeleteTrabajo
ON Trabajo
FOR DELETE
AS
BEGIN
    DECLARE @Fecha DATE = GETDATE();
    DECLARE @Hora TIME = CONVERT(TIME, GETDATE());
    DECLARE @NombreUsuario NVARCHAR(100) = SUSER_SNAME(); -- Nombre del usuario actual
    DECLARE @TrabajoId INT;

    -- Obtener el Id del trabajo eliminado
    SELECT @TrabajoId = Id FROM DELETED;

    -- Registrar en la tabla de auditoría
    INSERT INTO AuditoriaCambiosTrabajo (Fecha, Hora, NombreUsuario, TipoCambio, TrabajoId)
    VALUES (@Fecha, @Hora, @NombreUsuario, 'DELETE', @TrabajoId);
END;
	


select * from AuditoriaCambiosTrabajo;
select * from AuditoriaCambiosTareas;
