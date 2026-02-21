-- Script para la creación de Procedimientos Almacenados de Empleados
-- Proyecto: SisPersonal

USE dbControlPersonal;
GO

-- Asegurar que la columna Foto pueda almacenar imágenes grandes
ALTER TABLE Empleados ALTER COLUMN Foto varbinary(MAX);
GO

-- 1. Listar Empleados
IF OBJECT_ID('spListarEmpleados', 'P') IS NOT NULL DROP PROCEDURE spListarEmpleados;
GO
CREATE PROCEDURE spListarEmpleados
AS
BEGIN
    SELECT 
        Id_Empleado, 
        Ape_Paterno, 
        Ape_Materno, 
        Nombres, 
        DNI, 
        Direccion, 
        Foto, 
        Estado, 
        SBasicoHora, 
        SHorasExtraHora
    FROM Empleados;
END
GO

-- 2. Insertar Empleado
IF OBJECT_ID('spInsertarEmpleado', 'P') IS NOT NULL DROP PROCEDURE spInsertarEmpleado;
GO
CREATE PROCEDURE spInsertarEmpleado
    @Id_Empleado char(10),
    @Ape_Paterno varchar(50),
    @Ape_Materno varchar(50),
    @Nombres varchar(50),
    @DNI char(8),
    @Direccion varchar(150),
    @Foto varbinary(MAX), -- Cambiado a MAX para soportar imágenes reales
    @Estado bit,
    @SBasicoHora money,
    @SHorasExtraHora money
AS
BEGIN
    INSERT INTO Empleados (
        Id_Empleado, Ape_Paterno, Ape_Materno, Nombres, DNI, 
        Direccion, Foto, Estado, SBasicoHora, SHorasExtraHora
    )
    VALUES (
        @Id_Empleado, @Ape_Paterno, @Ape_Materno, @Nombres, @DNI, 
        @Direccion, @Foto, @Estado, @SBasicoHora, @SHorasExtraHora
    );
END
GO

-- 3. Actualizar Empleado
IF OBJECT_ID('spActualizarEmpleado', 'P') IS NOT NULL DROP PROCEDURE spActualizarEmpleado;
GO
CREATE PROCEDURE spActualizarEmpleado
    @Id_Empleado char(10),
    @Ape_Paterno varchar(50),
    @Ape_Materno varchar(50),
    @Nombres varchar(50),
    @DNI char(8),
    @Direccion varchar(150),
    @Foto varbinary(MAX),
    @Estado bit,
    @SBasicoHora money,
    @SHorasExtraHora money
AS
BEGIN
    UPDATE Empleados
    SET Ape_Paterno = @Ape_Paterno,
        Ape_Materno = @Ape_Materno,
        Nombres = @Nombres,
        DNI = @DNI,
        Direccion = @Direccion,
        Foto = @Foto,
        Estado = @Estado,
        SBasicoHora = @SBasicoHora,
        SHorasExtraHora = @SHorasExtraHora
    WHERE Id_Empleado = @Id_Empleado;
END
GO

-- 4. Eliminar Empleado
IF OBJECT_ID('spEliminarEmpleado', 'P') IS NOT NULL DROP PROCEDURE spEliminarEmpleado;
GO
CREATE PROCEDURE spEliminarEmpleado
    @Id_Empleado char(10)
AS
BEGIN
    DELETE FROM Empleados WHERE Id_Empleado = @Id_Empleado;
END
GO

-- 5. Buscar Empleado
IF OBJECT_ID('spBuscarEmpleado', 'P') IS NOT NULL DROP PROCEDURE spBuscarEmpleado;
GO
CREATE PROCEDURE spBuscarEmpleado
    @criterio varchar(100)
AS
BEGIN
    SELECT * FROM Empleados
    WHERE Nombres LIKE '%' + @criterio + '%' 
       OR Ape_Paterno LIKE '%' + @criterio + '%'
       OR DNI = @criterio;
END
GO
