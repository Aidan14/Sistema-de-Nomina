USE master
DROP DATABASE Sistema_Nomina

GO
CREATE DATABASE Sistema_Nomina
GO
USE Sistema_Nomina

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
	Nombre NVARCHAR(50)
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
	Tipo NVARCHAR(20),
	Desde TIME,
	Hasta TIME,
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
	ID_Empleado INT IDENTITY PRIMARY KEY,
	Cedula NVARCHAR(20),
	Nombre NVARCHAR(100),
	Fecha_Nacimiento DATE,
	ID_Departamento INT,
	ID_Cargo INT,
	Sexo CHAR,
	Telefono NVARCHAR(15),
	Direccion NVARCHAR(200),
	Estado NVARCHAR(20),
	Pago_Hora FLOAT

	CONSTRAINT FK_Departamento_Empleado FOREIGN KEY (ID_Departamento) REFERENCES Departamento(ID_Departamento),
	CONSTRAINT FK_Cargo_Empleado FOREIGN KEY (ID_Cargo) REFERENCES Cargo(ID_Cargo),
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
	Horas_Trabajadas FLOAT,
	AFP FLOAT,
	ARS FLOAT,
	ISR FLOAT,
	Sueldo_Neto FLOAT,

	CONSTRAINT FK_Nomina_Detalle FOREIGN KEY (ID_Nomina) REFERENCES Nomina(ID_Nomina),
	CONSTRAINT FK_Empleado_Nomina FOREIGN KEY (ID_Empleado) REFERENCES Empleado(ID_Empleado)
)
                                                                                                                                                                                                                                                                                                                                                                                                                                                           

-- PROCEDIMIENTOS: Usuario

GO
CREATE PROCEDURE SP_BUSCAR_USUARIO
@Buscar NVARCHAR(50)
AS
SELECT * FROM Usuario
WHERE	ID_Usuario LIKE '%' + @Buscar + '%' OR
		Nombre LIKE '%' + @Buscar + '%' OR
		Contraseña LIKE '%' + @Buscar + '%' OR
		Rol LIKE '%' + @Buscar + '%'

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
		Nombre LIKE '%' + @Buscar + '%'

GO
CREATE PROCEDURE SP_INSERTAR_DEPARTAMENTO
@Nombre NVARCHAR(50)
AS
INSERT INTO Departamento
VALUES(@Nombre)

GO
CREATE PROCEDURE SP_EDITAR_DEPARTAMENTO
@ID_Departamento INT,
@Nombre NVARCHAR(50)
AS
UPDATE Departamento
SET Nombre = @Nombre
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
		Nombre LIKE '%' + @Buscar + '%' OR
		Descripcion LIKE '%' + @Buscar + '%'

GO
CREATE PROCEDURE SP_INSERTAR_CARGO
@Nombre NVARCHAR(50),
@Descripcion NVARCHAR(200)
AS
INSERT INTO Cargo
VALUES(@Nombre, @Descripcion)

GO
CREATE PROCEDURE SP_EDITAR_CARGO
@ID_Cargo INT,
@Nombre NVARCHAR(50),
@Descripcion NVARCHAR(200)
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
		Nombre LIKE '%' + @Buscar + '%' OR
		Contraseña LIKE '%' + @Buscar + '%' OR
		Rol LIKE '%' + @Buscar + '%'

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
SELECT * FROM Jornada
WHERE	ID_Jornada LIKE '%' + @Buscar + '%' OR
		ID_Turno LIKE '%' + @Buscar + '%' OR
		Fecha LIKE '%' + @Buscar + '%' OR
		Hora_Entrada LIKE '%' + @Buscar + '%' OR
		Hora_Salida LIKE '%' + @Buscar + '%' OR
		Observacion LIKE '%' + @Buscar + '%'

GO
CREATE PROCEDURE SP_INSERTAR_JORNADA
@ID_Turno INT,
@Fecha DATE,
@Hora_Entrada TIME,
@Hora_Salida TIME,
@Observacion NVARCHAR(200)
AS
INSERT INTO Jornada
VALUES(@ID_Turno, @Fecha, @Hora_Entrada, @Hora_Salida, @Observacion)

GO
CREATE PROCEDURE SP_EDITAR_JORNADA
@ID_Jornada INT,
@ID_Turno INT,
@Fecha DATE,
@Hora_Entrada TIME,
@Hora_Salida TIME,
@Observacion NVARCHAR(200)
AS
UPDATE Jornada
SET ID_Turno = @ID_Turno, Fecha = @Fecha, Hora_Entrada = @Hora_Entrada, Hora_Salida = @Hora_Salida, Observacion = @Observacion
WHERE ID_Jornada = @ID_Jornada

GO
CREATE PROCEDURE SP_ELIMINAR_JORNADA
@ID_Jornada INT
AS
DELETE FROM Jornada
WHERE ID_Jornada = @ID_Jornada

--PROCEDIMIENTOS: Empleado
GO
CREATE PROCEDURE SP_BUSCAR_EMPLEADO
@Buscar NVARCHAR(50)
AS
SELECT * FROM Empleado
WHERE	ID_Empleado LIKE '%' + @Buscar + '%' OR
		Cedula LIKE '%' + @Buscar + '%' OR
		Nombre LIKE '%' + @Buscar + '%' OR
		Fecha_Nacimiento LIKE '%' + @Buscar + '%' OR
		ID_Departamento LIKE '%' + @Buscar + '%' OR
		ID_Cargo LIKE '%' + @Buscar + '%' OR
		Sexo LIKE '%' + @Buscar + '%' OR
		Telefono LIKE '%' + @Buscar + '%' OR
		Direccion LIKE '%' + @Buscar + '%' OR
		Estado LIKE '%' + @Buscar + '%' OR
		Pago_Hora LIKE '%' + @Buscar + '%'

GO
CREATE PROCEDURE SP_INSERTAR_EMPLEADO
@Cedula NVARCHAR(20),
@Nombre NVARCHAR(100),
@Fecha_Nacimiento DATE,
@ID_Departamento INT,
@ID_Cargo INT,
@Sexo CHAR,
@Telefono NVARCHAR(15),
@Direccion NVARCHAR(200),
@Estado NVARCHAR(20),
@Pago_Hora FLOAT
AS
INSERT INTO Empleado
VALUES(@Cedula, @Nombre, @Fecha_Nacimiento, @ID_Departamento, @ID_Cargo, @Sexo, @Telefono, @Direccion, @Estado, @Pago_Hora)

GO
CREATE PROCEDURE SP_EDITAR_EMPLEADO
@ID_Empleado INT,
@Cedula NVARCHAR(20),
@Nombre NVARCHAR(100),
@Fecha_Nacimiento DATE,
@ID_Departamento INT,
@ID_Cargo INT,
@Sexo CHAR,
@Telefono NVARCHAR(15),
@Direccion NVARCHAR(200),
@Estado NVARCHAR(20),
@Pago_Hora FLOAT
AS
UPDATE Empleado
SET Cedula = @Cedula, Nombre = @Nombre, Fecha_Nacimiento = @Fecha_Nacimiento, ID_Departamento = @ID_Departamento, ID_Cargo = @ID_Cargo, Sexo = @Sexo, Telefono = @Telefono, Direccion = @Direccion, Estado = @Estado, Pago_Hora = @Pago_Hora
WHERE ID_Empleado = @ID_Empleado

GO
CREATE PROCEDURE SP_ELIMINAR_EMPLEADO
@ID_Empleado INT
AS
DELETE FROM Empleado
WHERE ID_Empleado = @ID_Empleado

--PROCEDIMIENTOS: Nomina
GO
CREATE PROCEDURE SP_BUSCAR_NOMINA
@Buscar NVARCHAR(50)
AS
SELECT * FROM Nomina
WHERE	ID_Nomina LIKE '%' + @Buscar + '%' OR
		ID_Usuario LIKE '%' + @Buscar + '%' OR
		Fecha LIKE '%' + @Buscar + '%' OR
		Periodo_Desde LIKE '%' + @Buscar + '%' OR
		Periodo_Hasta LIKE '%' + @Buscar + '%'

GO
CREATE PROCEDURE SP_INSERTAR_NOMINA
@ID_Usuario INT,
@Fecha DATE,
@Periodo_Desde DATE,
@Periodo_Hasta DATE
AS
INSERT INTO Nomina
VALUES(@ID_Usuario, @Fecha, @Periodo_Desde, @Periodo_Hasta)

GO
CREATE PROCEDURE SP_EDITAR_NOMINA
@ID_Nomina INT,
@ID_Usuario INT,
@Fecha DATE,
@Periodo_Desde DATE,
@Periodo_Hasta DATE
AS
UPDATE Nomina
SET ID_Usuario = @ID_Usuario, Fecha = @Fecha, Periodo_Desde = @Periodo_Desde, Periodo_Hasta = @Periodo_Hasta
WHERE ID_Nomina = @ID_Nomina

GO
CREATE PROCEDURE SP_ELIMINAR_NOMINA
@ID_Nomina INT
AS
DELETE FROM Nomina
WHERE ID_Nomina = @ID_Nomina

--PROCEDIMIENTOS: Detalle Nomina
GO
CREATE PROCEDURE SP_BUSCAR_DETALLE
@Buscar NVARCHAR(50)
AS
SELECT * FROM Detalle
WHERE	ID_Nomina LIKE '%' + @Buscar + '%' OR
		ID_Empleado LIKE '%' + @Buscar + '%' OR
		Contraseña LIKE '%' + @Buscar + '%' OR
		Rol LIKE '%' + @Buscar + '%'

GO
CREATE PROCEDURE SP_INSERTAR_DETALLE
@Nombre NVARCHAR(50),
@Contraseña NVARCHAR(50),
@Rol NVARCHAR(50)
AS
INSERT INTO Detalle
VALUES(@Nombre, @Contraseña, @Rol)

GO
CREATE PROCEDURE SP_EDITAR_DETALLE
@ID_Nomina INT,
@ID_Empleado INT,
@Sueldo_Base FLOAT,
@Horas_Trabajadas FLOAT,
@AFP FLOAT,
@ARS FLOAT,
@ISR FLOAT,
@Sueldo_Neto FLOAT
AS
UPDATE Detalle
SET ID_Nomina = @ID_Nomina, ID_Empleado = @ID_Empleado, Sueldo_Base = @Sueldo_Base, Horas_Trabajadas = @Horas_Trabajadas,
AFP = @AFP, ARS = @ARS, ISR = @ISR, Sueldo_Neto = @Sueldo_Neto
WHERE ID_Nomina = @ID_Nomina AND ID_Empleado = @ID_Empleado

GO
CREATE PROCEDURE SP_ELIMINAR_DETALLE
@ID_Nomina INT,
@ID_Empleado INT
AS
DELETE FROM Detalle
WHERE ID_Nomina = @ID_Nomina AND ID_Empleado = @ID_Empleado

-- INNER JOIN NOMINA

SELECT Nomina.Fecha, Nomina.Periodo_Desde, Nomina.Periodo_Hasta, Sueldo_Base, AFP, ARS, ISR, Sueldo_Neto
FROM Nomina
INNER JOIN Detalle_Nomina
ON Detalle_Nomina.ID_Nomina = Nomina.ID_Nomina