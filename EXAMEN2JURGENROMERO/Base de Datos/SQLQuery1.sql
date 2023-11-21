CREATE DATABASE MantenimientoJurgen;

USE MantenimientoJurgen;

-- Crea la tabla Usuarios
CREATE TABLE Usuarios (
    UsuarioID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(50) NOT NULL,
    CorreoElectronico NVARCHAR(50),
    Telefono NVARCHAR(15) UNIQUE
);

-- Crea la tabla Equipos
CREATE TABLE Equipos (
    EquipoID INT PRIMARY KEY IDENTITY(1,1),
    TipoEquipo NVARCHAR(50) NOT NULL,
    Modelo NVARCHAR(50),
    UsuarioID INT,
    FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID)
);

-- Crea la tabla Reparaciones
CREATE TABLE Reparaciones (
    ReparacionID INT PRIMARY KEY IDENTITY(1,1),
    EquipoID INT,
    FechaSolicitud DATETIME,
    Estado CHAR(1),
    FOREIGN KEY (EquipoID) REFERENCES Equipos(EquipoID)
);

-- Crea la tabla DetallesReparacion
CREATE TABLE DetallesReparacion (
    DetalleID INT PRIMARY KEY IDENTITY(1,1),
    ReparacionID INT,
    Descripcion NVARCHAR(50),
    FechaInicio DATETIME,
    FechaFin DATETIME,
    FOREIGN KEY (ReparacionID) REFERENCES Reparaciones(ReparacionID)
);

-- Crea la tabla Asignaciones
CREATE TABLE Asignaciones (
    AsignacionID INT PRIMARY KEY IDENTITY(1,1),
    ReparacionID INT,
    TecnicoID INT,
    FechaAsignacion DATETIME,
    FOREIGN KEY (ReparacionID) REFERENCES Reparaciones(ReparacionID),
    FOREIGN KEY (TecnicoID) REFERENCES Tecnicos(TecnicoID)
);

-- Crea la tabla Tecnicos
CREATE TABLE Tecnicos (
    TecnicoID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(50),
    Especialidad NVARCHAR(50)
);

-- Inserta datos en Usuarios
INSERT INTO Usuarios (Nombre, CorreoElectronico, Telefono) VALUES
    ('Juan Pérez', 'juan@gmail.com', '123-456-7890'),
    ('María González', 'maria@gmail.com', '987-654-3210'),
    ('Carlos López', 'carlos@gmail.com', '555-123-4567');

-- Inserta datos en Equipos
INSERT INTO Equipos (TipoEquipo, Modelo, UsuarioID) VALUES
    ('Laptop', 'Dell XPS', 1),
    ('Impresora', 'HP LaserJet', 2),
    ('Teléfono', 'iPhone 12', 3);

-- Inserta datos en Reparaciones
INSERT INTO Reparaciones (EquipoID, FechaSolicitud, Estado) VALUES
    (1, GETDATE(), 'P'),
    (2, GETDATE(), 'P'),
    (3, GETDATE(), 'P');

-- Inserta datos en DetallesReparacion
INSERT INTO DetallesReparacion (ReparacionID, Descripcion, FechaInicio, FechaFin) VALUES
    (1, 'Reemplazo de batería', GETDATE(), GETDATE()),
    (2, 'Reemplazo de tóner', GETDATE(), GETDATE()),
    (3, 'Actualización de software', GETDATE(), GETDATE());

-- Inserta datos en Tecnicos
INSERT INTO Tecnicos (Nombre, Especialidad) VALUES
    ('Ana Martínez', 'Hardware'),
    ('Pedro Rodríguez', 'Impresoras'),
    ('Laura Sánchez', 'Software');



-- Agregar Usuario
CREATE PROCEDURE AgregarUsuario
    @Nombre NVARCHAR(50),
    @CorreoElectronico NVARCHAR(50),
    @Telefono NVARCHAR(15)
AS
BEGIN
    INSERT INTO Usuarios (Nombre, CorreoElectronico, Telefono)
    VALUES (@Nombre, @CorreoElectronico, @Telefono);
END;

-- Borrar Usuario
CREATE PROCEDURE BorrarUsuario
    @UsuarioID INT
AS
BEGIN
    DELETE FROM Usuarios WHERE UsuarioID = @UsuarioID;
END;

-- Consultar Usuario con Filtro
CREATE PROCEDURE ConsultarUsuario
    @UsuarioID INT
AS
BEGIN
    SELECT * FROM Usuarios WHERE UsuarioID = @UsuarioID;
END;

-- Modificar Usuario
CREATE PROCEDURE ModificarUsuario
    @UsuarioID INT,
    @Nombre NVARCHAR(50),
    @CorreoElectronico NVARCHAR(50),
    @Telefono NVARCHAR(15)
AS
BEGIN
    UPDATE Usuarios
    SET Nombre = @Nombre,
        CorreoElectronico = @CorreoElectronico,
        Telefono = @Telefono
    WHERE UsuarioID = @UsuarioID;
END;


-- Procedimientos almacenados para mantenimiento de Equipos

-- Agregar Equipo
CREATE PROCEDURE AgregarEquipo
    @TipoEquipo NVARCHAR(50),
    @Modelo NVARCHAR(50),
    @UsuarioID INT
AS
BEGIN
    INSERT INTO Equipos (TipoEquipo, Modelo, UsuarioID)
    VALUES (@TipoEquipo, @Modelo, @UsuarioID);
END;

-- Borrar Equipo
CREATE PROCEDURE BorrarEquipo
    @EquipoID INT
AS
BEGIN
    DELETE FROM Equipos WHERE EquipoID = @EquipoID;
END;

-- Consultar Equipo con Filtro
CREATE PROCEDURE ConsultarEquipo
    @EquipoID INT
AS
BEGIN
    SELECT * FROM Equipos WHERE EquipoID = @EquipoID;
END;

-- Modificar Equipo
CREATE PROCEDURE ModificarEquipo
    @EquipoID INT,
    @TipoEquipo NVARCHAR(50),
    @Modelo NVARCHAR(50),
    @UsuarioID INT
AS
BEGIN
    UPDATE Equipos
    SET TipoEquipo = @TipoEquipo,
        Modelo = @Modelo,
        UsuarioID = @UsuarioID
    WHERE EquipoID = @EquipoID;
END;


-- Procedimientos almacenados para mantenimiento de Tecnicos

-- Agregar Tecnico
CREATE PROCEDURE AgregarTecnico
    @Nombre NVARCHAR(50),
    @Especialidad NVARCHAR(50)
AS
BEGIN
    INSERT INTO Tecnicos (Nombre, Especialidad)
    VALUES (@Nombre, @Especialidad);
END;

-- Borrar Tecnico
CREATE PROCEDURE BorrarTecnico
    @TecnicoID INT
AS
BEGIN
    DELETE FROM Tecnicos WHERE TecnicoID = @TecnicoID;
END;

-- Consultar Tecnico con Filtro
CREATE PROCEDURE ConsultarTecnico
    @TecnicoID INT
AS
BEGIN
    SELECT * FROM Tecnicos WHERE TecnicoID = @TecnicoID;
END;

-- Modificar Tecnico
CREATE PROCEDURE ModificarTecnico
    @TecnicoID INT,
    @Nombre NVARCHAR(50),
    @Especialidad NVARCHAR(50)
AS
BEGIN
    UPDATE Tecnicos
    SET Nombre = @Nombre,
        Especialidad = @Especialidad
    WHERE TecnicoID = @TecnicoID;
END;