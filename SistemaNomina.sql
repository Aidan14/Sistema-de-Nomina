USE master

GO
CREATE DATABASE Sistema_Nomina
GO
USE Sistema_Nomina

DROP DATABASE Sistema_Nomina

SET DATEFORMAT DMY

-- TABLAS --

CREATE TABLE Usuario
(
	ID_Usuario INT IDENTITY PRIMARY KEY,
	Nombre NVARCHAR(50),
	Contraseña NVARCHAR(50),
	Rol NVARCHAR(50),
)

CREATE TABLE Departamento
(
	ID_Departamento INT IDENTITY PRIMARY KEY,
	Nombre NVARCHAR(50),
	Descripcion NVARCHAR(200)
)

CREATE TABLE Cargo
(
	ID_Cargo INT IDENTITY PRIMARY KEY,
	Nombre NVARCHAR(50),
	Descripcion NVARCHAR(200)
)

CREATE TABLE Turno
(
	ID_Turno INT IDENTITY PRIMARY KEY,
	ID_Horario INT,
	Tipo NVARCHAR(50)

	CONSTRAINT FK_Horario_Jornada FOREIGN KEY (ID_Horario) REFERENCES Horario(ID_Horario)
)

CREATE TABLE Jornada
(
	ID_Jornada INT IDENTITY PRIMARY KEY,
	ID_Turno INT,
	Fecha DATE,
	Hora_Entrada TIME,
	Hora_Salida TIME,
	Observacion NVARCHAR(200),

	CONSTRAINT FK_Turno_Jornada FOREIGN KEY (ID_Turno) REFERENCES Turno(ID_Turno)
)

CREATE TABLE Empleado
(
	Cedula INT IDENTITY PRIMARY KEY,
	Nombre NVARCHAR(100),
	Fecha_Nacimiento DATE,
	ID_Departamento INT,
	ID_Cargo INT,
	ID_Jornada INT,
	Sexo CHAR,
	Telefono NVARCHAR(15),
	Direccion NVARCHAR(200),
	Estado NVARCHAR(20),
	Pago_Hora FLOAT

	CONSTRAINT FK_Departamento_Empleado FOREIGN KEY (ID_Departamento) REFERENCES Departamento(ID_Departamento),
	CONSTRAINT FK_Cargo_Empleado FOREIGN KEY (ID_Cargo) REFERENCES Cargo(ID_Cargo),
	CONSTRAINT FK_Jornada_Empleado FOREIGN KEY (ID_Jornada) REFERENCES Jornada(ID_Jornada)
)

CREATE TABLE Nomina
(
	ID_Nomina INT IDENTITY PRIMARY KEY,
	ID_Usuario INT,
	Fecha DATE,
	Periodo_Desde DATE,
	Periodo_Hasta DATE,

	CONSTRAINT FK_Usuario_Nomina FOREIGN KEY (ID_Usuario) REFERENCES Usuario(ID_Usuario)
)

CREATE TABLE Detalle_Nomina
(
	ID_Nomina INT IDENTITY PRIMARY KEY,
	ID_Empleado INT,
	Sueldo_Base FLOAT,
	AFP FLOAT,
	ARS FLOAT,
	ISR FLOAT,
	Sueldo_Neto FLOAT,

	CONSTRAINT FK_Nomina_Detalle FOREIGN KEY (ID_Nomina) REFERENCES Nomina(ID_Nomina),
	CONSTRAINT FK_Empleado_Nomina FOREIGN KEY (ID_Empleado) REFERENCES Empleado(Cedula)
)
                                                                                                                                                                                                                                                                                                                                                                                                                                                           

-- PROCEDIMIENTOS: Usuario

GO
CREATE PROCEDURE SP_BUSCAR_USUARIO
@Buscar NVARCHAR(50)
AS
SELECT * FROM Usuario
WHERE	ID_Usuario LIKE '%' + @Buscar + '%' OR
		Nombre LIKE '%' + @Buscar '%' OR
		Contraseña LIKE '%' + @Buscar '%' OR
		Rol LIKE '%' + @Buscar '%'

GO
CREATE PROCEDURE SP_INSERTAR_USUARIO
@Nombre NVARCHAR(50),
@Contraseña NVARCHAR(50),
@Rol NVARCHAR(50)
AS
INSERT INTO Usuario
VALUES(@Nombre, @Contraseña, @Rol)

GO
CREATE PROCEDURE SP_EDITAR_USUARIO
@ID_Usuario INT,
@Nombre NVARCHAR(50),
@Contraseña NVARCHAR(50),
@Rol NVARCHAR(50)
AS
UPDATE Usuario
SET Nombre = @Nombre, Contraseña = @Contraseña, Rol = @Rol
WHERE ID_Usuario = @ID_Usuario

GO
CREATE PROCEDURE SP_ELIMINAR_USUARIO
@ID_Usuario INT
AS
DELETE FROM Usuario
WHERE ID_Usuario = @ID_Usuario

-- PROCEDIMIENTOS: Departamento

GO
CREATE PROCEDURE SP_BUSCAR_DEPARTAMENTO
@Buscar NVARCHAR(50)
AS
SELECT * FROM Departamento
WHERE	ID_Departamento LIKE '%' + @Buscar + '%' OR
		Nombre LIKE '%' + @Buscar '%' OR
		Departamento LIKE '%' + @Buscar '%' OR

GO
CREATE PROCEDURE SP_INSERTAR_DEPARTAMENTO
@Nombre NVARCHAR(50),
@Descripcion NVARCHAR(200)
AS
INSERT INTO Usuario
VALUES(@Nombre, @Descripcion)

GO
CREATE PROCEDURE SP_EDITAR_DEPARTAMENTO
@ID_Departamento INT,
@Nombre NVARCHAR(50),
@Descripcion NVARCHAR(200)
AS
UPDATE Usuario
SET Nombre = @Nombre, @Descripcion = @Descripcion
WHERE @ID_Departamento = @ID_Departamento

GO
CREATE PROCEDURE SP_ELIMINAR_Departamento
@ID_Departamento INT
AS
DELETE FROM Departamento
WHERE ID_Departamento = @ID_Departamento

-- PROCEDIMIENTOS: Cargo

GO
CREATE PROCEDURE SP_BUSCAR_CARGO
@Buscar NVARCHAR(50)
AS
SELECT * FROM Cargo
WHERE	ID_Cargo LIKE '%' + @Buscar + '%' OR
		Nombre LIKE '%' + @Buscar '%' OR
		Departamento LIKE '%' + @Buscar '%' OR

GO
CREATE PROCEDURE SP_INSERTAR_CARGO
@Nombre NVARCHAR(50),
@Descripcion NVARCHAR(200)
AS
INSERT INTO Usuario
VALUES(@Nombre, @Descripcion)

GO
CREATE PROCEDURE SP_EDITAR_CARGO
ID_Cargo INT,
Nombre NVARCHAR(50),
Descripcion NVARCHAR(200)
AS
UPDATE Cargo
SET Nombre = @Nombre, Descripcion = @Descripcion
WHERE ID_Cargo = @ID_Cargo

GO
CREATE PROCEDURE SP_ELIMINAR_CARGO
@ID_Cargo INT
AS
DELETE FROM Cargo
WHERE ID_Cargo = @ID_Cargo

--PROCEDIMIENTOS: Turno

GO
CREATE PROCEDURE SP_BUSCAR_TURNO
@Buscar NVARCHAR(50)
AS
SELECT * FROM Usuario
WHERE	ID_Usuario LIKE '%' + @Buscar + '%' OR
		Nombre LIKE '%' + @Buscar '%' OR
		Contraseña LIKE '%' + @Buscar '%' OR
		Rol LIKE '%' + @Buscar '%'

GO
CREATE PROCEDURE SP_INSERTAR_TURNO
@Nombre NVARCHAR(50),
@Contraseña NVARCHAR(50),
@Rol NVARCHAR(50)
AS
INSERT INTO Usuario
VALUES(@Nombre, @Contraseña, @Rol)

GO
CREATE PROCEDURE SP_EDITAR_TURNO
@ID_Usuario INT,
@Nombre NVARCHAR(50),
@Contraseña NVARCHAR(50),
@Rol NVARCHAR(50)
AS
UPDATE Usuario
SET Nombre = @Nombre, Contraseña = @Contraseña, Rol = @Rol
WHERE ID_Usuario = @ID_Usuario

GO
CREATE PROCEDURE SP_ELIMINAR_TURNO
@ID_Usuario INT
AS
DELETE FROM Usuario
WHERE ID_Usuario = @ID_Usuario

--PROCEDIMIENTOS: Jornada

GO
CREATE PROCEDURE SP_BUSCAR_JORNADA
@Buscar NVARCHAR(50)
AS
SELECT * FROM Usuario
WHERE	ID_Usuario LIKE '%' + @Buscar + '%' OR
		Nombre LIKE '%' + @Buscar '%' OR
		Contraseña LIKE '%' + @Buscar '%' OR
		Rol LIKE '%' + @Buscar '%'

GO
CREATE PROCEDURE SP_INSERTAR_JORNADA
@Nombre NVARCHAR(50),
@Contraseña NVARCHAR(50),
@Rol NVARCHAR(50)
AS
INSERT INTO Usuario
VALUES(@Nombre, @Contraseña, @Rol)

GO
CREATE PROCEDURE SP_EDITAR_JORNADA
@ID_Usuario INT,
@Nombre NVARCHAR(50),
@Contraseña NVARCHAR(50),
@Rol NVARCHAR(50)
AS
UPDATE Usuario
SET Nombre = @Nombre, Contraseña = @Contraseña, Rol = @Rol
WHERE ID_Usuario = @ID_Usuario

GO
CREATE PROCEDURE SP_ELIMINAR_JORNADA
@ID_Usuario INT
AS
DELETE FROM Usuario
WHERE ID_Usuario = @ID_Usuario

--PROCEDIMIENTOS: Empleado
GO
CREATE PROCEDURE SP_BUSCAR_EMPLEADO
@Buscar NVARCHAR(50)
AS
SELECT * FROM Usuario
WHERE	ID_Usuario LIKE '%' + @Buscar + '%' OR
		Nombre LIKE '%' + @Buscar '%' OR
		Contraseña LIKE '%' + @Buscar '%' OR
		Rol LIKE '%' + @Buscar '%'

GO
CREATE PROCEDURE SP_INSERTAR_EMPLEADO
@Nombre NVARCHAR(50),
@Contraseña NVARCHAR(50),
@Rol NVARCHAR(50)
AS
INSERT INTO Usuario
VALUES(@Nombre, @Contraseña, @Rol)

GO
CREATE PROCEDURE SP_EDITAR_EMPLEADO
@ID_Usuario INT,
@Nombre NVARCHAR(50),
@Contraseña NVARCHAR(50),
@Rol NVARCHAR(50)
AS
UPDATE Usuario
SET Nombre = @Nombre, Contraseña = @Contraseña, Rol = @Rol
WHERE ID_Usuario = @ID_Usuario

GO
CREATE PROCEDURE SP_ELIMINAR_EMPLEADO
@ID_Usuario INT
AS
DELETE FROM Usuario
WHERE ID_Usuario = @ID_Usuario

--PROCEDIMIENTOS: Nomina
GO
CREATE PROCEDURE SP_BUSCAR_NOMINA
@Buscar NVARCHAR(50)
AS
SELECT * FROM Usuario
WHERE	ID_Usuario LIKE '%' + @Buscar + '%' OR
		Nombre LIKE '%' + @Buscar '%' OR
		Contraseña LIKE '%' + @Buscar '%' OR
		Rol LIKE '%' + @Buscar '%'

GO
CREATE PROCEDURE SP_INSERTAR_NOMINA
@Nombre NVARCHAR(50),
@Contraseña NVARCHAR(50),
@Rol NVARCHAR(50)
AS
INSERT INTO Usuario
VALUES(@Nombre, @Contraseña, @Rol)

GO
CREATE PROCEDURE SP_EDITAR_NOMINA
@ID_Usuario INT,
@Nombre NVARCHAR(50),
@Contraseña NVARCHAR(50),
@Rol NVARCHAR(50)
AS
UPDATE Usuario
SET Nombre = @Nombre, Contraseña = @Contraseña, Rol = @Rol
WHERE ID_Usuario = @ID_Usuario

GO
CREATE PROCEDURE SP_ELIMINAR_NOMINA
@ID_Usuario INT
AS
DELETE FROM Usuario
WHERE ID_Usuario = @ID_Usuario

--PROCEDIMIENTOS: Detalle Nomina
GO
CREATE PROCEDURE SP_BUSCAR_DETALLE
@Buscar NVARCHAR(50)
AS
SELECT * FROM Usuario
WHERE	ID_Usuario LIKE '%' + @Buscar + '%' OR
		Nombre LIKE '%' + @Buscar '%' OR
		Contraseña LIKE '%' + @Buscar '%' OR
		Rol LIKE '%' + @Buscar '%'

GO
CREATE PROCEDURE SP_INSERTAR_DETALLE
@Nombre NVARCHAR(50),
@Contraseña NVARCHAR(50),
@Rol NVARCHAR(50)
AS
INSERT INTO Usuario
VALUES(@Nombre, @Contraseña, @Rol)

GO
CREATE PROCEDURE SP_EDITAR_DETALLE
@ID_Usuario INT,
@Nombre NVARCHAR(50),
@Contraseña NVARCHAR(50),
@Rol NVARCHAR(50)
AS
UPDATE Usuario
SET Nombre = @Nombre, Contraseña = @Contraseña, Rol = @Rol
WHERE ID_Usuario = @ID_Usuario

GO
CREATE PROCEDURE SP_ELIMINAR_DETALLE
@ID_Usuario INT
AS
DELETE FROM Usuario
WHERE ID_Usuario = @ID_Usuario

-- INNER JOIN NOMINA

SELECT Nomina.ID_Empleado, Nomina.ID_Empleado, Nomina.Fecha, Nomina.Periodo_Desde, Nomina.Periodo_Hasta, Sueldo_Base, AFP, ARS, ISR, Sueldo_Base
FROM Nomina
INNER JOIN Detalle_Nomina
ON Detalle_Nomina.ID_Nomina = Nomina.ID_Nomina