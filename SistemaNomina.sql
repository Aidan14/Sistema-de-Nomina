USE master
DROP DATABASE Sistema_Nomina

GO
CREATE DATABASE Sistema_Nomina
GO
USE Sistema_Nomina

SET DATEFORMAT DMY

-- TABLAS --

CREATE TABLE Usuarios
(
	ID_Usuario INT IDENTITY PRIMARY KEY,
	Nombre NVARCHAR(50),
	Contraseña NVARCHAR(50),
	Rol NVARCHAR(50),
)

CREATE TABLE Departamentos
(
	ID_Departamento INT IDENTITY PRIMARY KEY,
	Nombre NVARCHAR(50)
)

CREATE TABLE Cargos
(
	ID_Cargo INT IDENTITY PRIMARY KEY,
	Nombre NVARCHAR(50)
)

CREATE TABLE Horarios
(
	ID_Horario INT IDENTITY PRIMARY KEY,
	Tipo NVARCHAR(20),
	Desde TIME,
	Hasta TIME,
)

CREATE TABLE Empleados
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

	CONSTRAINT FK_Departamento_Empleado FOREIGN KEY (ID_Departamento) REFERENCES Departamentos(ID_Departamento),
	CONSTRAINT FK_Cargo_Empleado FOREIGN KEY (ID_Cargo) REFERENCES Cargos(ID_Cargo)
)

CREATE TABLE Jornadas
(
	ID_Jornada INT IDENTITY PRIMARY KEY,
	ID_Empleado INT,
	Fecha DATE,
	Hora_Entrada TIME,
	Hora_Salida TIME,
	Observacion NVARCHAR(200),

	CONSTRAINT FK_Horario_Empleado FOREIGN KEY (ID_Empleado) REFERENCES Empleados(ID_Empleado)
)

CREATE TABLE Nominas
(
	ID_Nomina INT IDENTITY PRIMARY KEY,
	ID_Usuario INT,
	Fecha DATE,
	Periodo_Desde DATE,
	Periodo_Hasta DATE,

	CONSTRAINT FK_Usuario_Nomina FOREIGN KEY (ID_Usuario) REFERENCES Usuarios(ID_Usuario)
)

CREATE TABLE Detalles
(
	ID_Nomina INT,
	ID_Empleado INT,
	Sueldo_Base FLOAT,
	Horas_Trabajadas INT,
	AFP FLOAT,
	ARS FLOAT,
	ISR FLOAT,
	Sueldo_Neto FLOAT,

	CONSTRAINT FK_Nomina_Detalle FOREIGN KEY (ID_Nomina) REFERENCES Nominas(ID_Nomina),
	CONSTRAINT FK_Empleado_Nomina FOREIGN KEY (ID_Empleado) REFERENCES Empleados(ID_Empleado)
) 

-- PROCEDIMIENTOS: Usuarios

GO
CREATE PROCEDURE SP_BUSCAR_USUARIO
@Buscar NVARCHAR(50)
AS
SELECT * FROM Usuarios
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
INSERT INTO Usuarios
VALUES(@Nombre, @Contraseña, @Rol)

GO
CREATE PROCEDURE SP_EDITAR_USUARIO
@ID_Usuario INT,
@Nombre NVARCHAR(50),
@Contraseña NVARCHAR(50),
@Rol NVARCHAR(50)
AS
UPDATE Usuarios
SET Nombre = @Nombre, Contraseña = @Contraseña, Rol = @Rol
WHERE ID_Usuario = @ID_Usuario

GO
CREATE PROCEDURE SP_ELIMINAR_USUARIO
@ID_Usuario INT
AS
DELETE FROM Usuarios
WHERE ID_Usuario = @ID_Usuario

-- PROCEDIMIENTOS: Departamentos

GO
CREATE PROCEDURE SP_BUSCAR_DEPARTAMENTO
@Buscar NVARCHAR(50)
AS
SELECT * FROM Departamentos
WHERE	ID_Departamento LIKE '%' + @Buscar + '%' OR
		Nombre LIKE '%' + @Buscar + '%'

GO
CREATE PROCEDURE SP_INSERTAR_DEPARTAMENTO
@Nombre NVARCHAR(50)
AS
INSERT INTO Departamentos
VALUES(@Nombre)

GO
CREATE PROCEDURE SP_EDITAR_DEPARTAMENTO
@ID_Departamento INT,
@Nombre NVARCHAR(50)
AS
UPDATE Departamentos
SET Nombre = @Nombre
WHERE ID_Departamento = @ID_Departamento

GO
CREATE PROCEDURE SP_ELIMINAR_DEPARTAMENTO
@ID_Departamento INT
AS
DELETE FROM Departamentos
WHERE ID_Departamento = @ID_Departamento

-- PROCEDIMIENTOS: Cargos

GO
CREATE PROCEDURE SP_BUSCAR_CARGO
@Buscar NVARCHAR(50)
AS
SELECT * FROM Cargos
WHERE	ID_Cargo LIKE '%' + @Buscar + '%' OR
		Nombre LIKE '%' + @Buscar + '%'

GO
CREATE PROCEDURE SP_INSERTAR_CARGO
@Nombre NVARCHAR(50)
AS
INSERT INTO Cargos
VALUES(@Nombre)

GO
CREATE PROCEDURE SP_EDITAR_CARGO
@ID_Cargo INT,
@Nombre NVARCHAR(50)
AS
UPDATE Cargos
SET Nombre = @Nombre
WHERE ID_Cargo = @ID_Cargo

GO
CREATE PROCEDURE SP_ELIMINAR_CARGO
@ID_Cargo INT
AS
DELETE FROM Cargos
WHERE ID_Cargo = @ID_Cargo

--PROCEDIMIENTOS: Horarios

GO
CREATE PROCEDURE SP_BUSCAR_HORARIO
@Buscar NVARCHAR(50)
AS
SELECT * FROM Horarios
WHERE	ID_Horario LIKE '%' + @Buscar + '%' OR
		Tipo LIKE '%' + @Buscar + '%' OR
		Desde LIKE '%' + @Buscar + '%' OR
		Hasta LIKE '%' + @Buscar + '%'

GO
CREATE PROCEDURE SP_INSERTAR_HORARIO
@Tipo NVARCHAR(20),
@Desde TIME,
@Hasta TIME
AS
INSERT INTO Horarios
VALUES(@Tipo, @Desde, @Hasta)

GO
CREATE PROCEDURE SP_EDITAR_HORARIO
@ID_Horario INT,
@Tipo NVARCHAR(20),
@Desde TIME,
@Hasta TIME
AS
UPDATE Horarios
SET Tipo = @Tipo, Desde = @Desde, Hasta = @Hasta
WHERE ID_Horario = @ID_Horario

GO
CREATE PROCEDURE SP_ELIMINAR_HORARIO
@ID_Horario INT
AS
DELETE FROM Horarios
WHERE ID_Horario = @ID_Horario

--PROCEDIMIENTOS: Empleados

GO
CREATE PROCEDURE SP_BUSCAR_EMPLEADO
@Buscar NVARCHAR(50)
AS
SELECT * FROM Empleados
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
INSERT INTO Empleados
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
UPDATE Empleados
SET Cedula = @Cedula, Nombre = @Nombre, Fecha_Nacimiento = @Fecha_Nacimiento, ID_Departamento = @ID_Departamento, ID_Cargo = @ID_Cargo, Sexo = @Sexo, Telefono = @Telefono, Direccion = @Direccion, Estado = @Estado, Pago_Hora = @Pago_Hora
WHERE ID_Empleado = @ID_Empleado

GO
CREATE PROCEDURE SP_ELIMINAR_EMPLEADO
@ID_Empleado INT
AS
DELETE FROM Empleados
WHERE ID_Empleado = @ID_Empleado

--PROCEDIMIENTOS: Jornadas

GO
CREATE PROCEDURE SP_BUSCAR_JORNADA
@Buscar NVARCHAR(50)
AS
SELECT * FROM Jornadas
WHERE	ID_Jornada LIKE '%' + @Buscar + '%' OR
		ID_Empleado LIKE '%' + @Buscar + '%' OR
		Fecha LIKE '%' + @Buscar + '%' OR
		Hora_Entrada LIKE '%' + @Buscar + '%' OR
		Hora_Salida LIKE '%' + @Buscar + '%' OR
		Observacion LIKE '%' + @Buscar + '%'

GO
CREATE PROCEDURE SP_INSERTAR_JORNADA
@ID_Empleado INT,
@Fecha DATE,
@Hora_Entrada TIME,
@Hora_Salida TIME,
@Observacion NVARCHAR(200)
AS
INSERT INTO Jornadas
VALUES(@ID_Empleado, @Fecha, @Hora_Entrada, @Hora_Salida, @Observacion)

GO
CREATE PROCEDURE SP_EDITAR_JORNADA
@ID_Empleado INT,
@ID_Jornada INT,
@Fecha DATE,
@Hora_Entrada TIME,
@Hora_Salida TIME,
@Observacion NVARCHAR(200)
AS
UPDATE Jornadas
SET ID_Empleado = @ID_Empleado, Fecha = @Fecha, Hora_Entrada = @Hora_Entrada, Hora_Salida = @Hora_Salida, Observacion = @Observacion
WHERE ID_Jornada = @ID_Jornada

GO
CREATE PROCEDURE SP_ELIMINAR_JORNADA
@ID_Jornada INT
AS
DELETE FROM Jornadas
WHERE ID_Jornada = @ID_Jornada

--PROCEDIMIENTOS: Nominas

GO
CREATE PROCEDURE SP_BUSCAR_NOMINA
@Buscar NVARCHAR(50)
AS
SELECT * FROM Nominas
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
INSERT INTO Nominas
VALUES(@ID_Usuario, @Fecha, @Periodo_Desde, @Periodo_Hasta)

GO
CREATE PROCEDURE SP_EDITAR_NOMINA
@ID_Nomina INT,
@ID_Usuario INT,
@Fecha DATE,
@Periodo_Desde DATE,
@Periodo_Hasta DATE
AS
UPDATE Nominas
SET ID_Usuario = @ID_Usuario, Fecha = @Fecha, Periodo_Desde = @Periodo_Desde, Periodo_Hasta = @Periodo_Hasta
WHERE ID_Nomina = @ID_Nomina

GO
CREATE PROCEDURE SP_ELIMINAR_NOMINA
@ID_Nomina INT
AS
DELETE FROM Nominas
WHERE ID_Nomina = @ID_Nomina

--PROCEDIMIENTOS: Detalles

GO
CREATE PROCEDURE SP_BUSCAR_DETALLE
@Buscar NVARCHAR(50)
AS
SELECT * FROM Detalles
WHERE	ID_Nomina LIKE '%' + @Buscar + '%'

GO
CREATE PROCEDURE SP_INSERTAR_DETALLE
@ID_Nomina INT,
@ID_Empleado INT,
@Sueldo_Base FLOAT,
@Horas_Trabajadas INT,
@AFP FLOAT,
@ARS FLOAT,
@ISR FLOAT,
@Sueldo_Neto FLOAT
AS
INSERT INTO Detalles
VALUES(@ID_Nomina, @ID_Empleado, @Sueldo_Base, @Horas_Trabajadas, @AFP, @ARS, @ISR, @Sueldo_Neto)

GO
CREATE PROCEDURE SP_EDITAR_DETALLE
@ID_Nomina INT,
@ID_Empleado INT,
@Sueldo_Base FLOAT,
@Horas_Trabajadas INT,
@AFP FLOAT,
@ARS FLOAT,
@ISR FLOAT,
@Sueldo_Neto FLOAT
AS
UPDATE Detalles
SET ID_Nomina = @ID_Nomina, ID_Empleado = @ID_Empleado, Sueldo_Base = @Sueldo_Base, Horas_Trabajadas = @Horas_Trabajadas,
AFP = @AFP, ARS = @ARS, ISR = @ISR, Sueldo_Neto = @Sueldo_Neto
WHERE ID_Nomina = @ID_Nomina AND ID_Empleado = @ID_Empleado

GO
CREATE PROCEDURE SP_ELIMINAR_DETALLE
@ID_Nomina INT,
@ID_Empleado INT
AS
DELETE FROM Detalles
WHERE ID_Nomina = @ID_Nomina AND ID_Empleado = @ID_Empleado

-- INNER JOIN NOMINA

/*SELECT Nomina.Fecha, Nomina.Periodo_Desde, Nomina.Periodo_Hasta, Sueldo_Base, AFP, ARS, ISR, Sueldo_Neto
FROM Nomina
INNER JOIN Detalle_Nomina
ON Detalle_Nomina.ID_Nomina = Nomina.ID_Nomina*/

GO
INSERT INTO Usuarios VALUES ('Admin', '1234', 'admin')

INSERT INTO Horarios VALUES ('Matutino', '8:00:00', '16:00:00')
INSERT INTO Horarios VALUES ('Nocturno', '22:00:00', '6:00:00')

INSERT INTO Cargos VALUES ('Programador')
INSERT INTO Cargos VALUES ('Contable')
INSERT INTO Cargos VALUES ('Director')
INSERT INTO Cargos VALUES ('Gerente')
INSERT INTO Cargos VALUES ('Publicista')

INSERT INTO Departamentos VALUES ('Recursos Humanos')
INSERT INTO Departamentos VALUES ('Tecnologia')
INSERT INTO Departamentos VALUES ('Administracion')
INSERT INTO Departamentos VALUES ('Contabilidad')
INSERT INTO Departamentos VALUES ('Marketing')
INSERT INTO Departamentos VALUES ('Procesos')

INSERT INTO Empleados VALUES ('B1651616', 'Pepe Ortega', '14/07/2005', 2, 1, 'M', '849-897-3216', 'La Esperilla, Calle Primera', 'Activo', 200)
INSERT INTO Empleados VALUES ('B1651616', 'Jack Sparrow', '09/03/2004', 3, 2, 'M', '809-163-7137', 'La Altagracia, Calle #6', 'Activo', 100)
INSERT INTO Empleados VALUES ('B1651616', 'Pepe Ortega', '10/11/2005', 1, 4, 'M', '829-180-6106', 'Av. John F. Kennedy', 'Activo', 150)

INSERT INTO Jornadas VALUES (1, '01/03/2022', '08:00:00', '16:00:00', '');
INSERT INTO Jornadas VALUES (1, '02/03/2022', '08:00:00', '16:00:00', '');
INSERT INTO Jornadas VALUES (1, '03/03/2022', '08:00:00', '16:00:00', '');
INSERT INTO Jornadas VALUES (1, '04/03/2022', '08:00:00', '16:00:00', '');
INSERT INTO Jornadas VALUES (1, '05/03/2022', '08:00:00', '16:00:00', '');
INSERT INTO Jornadas VALUES (1, '06/03/2022', '08:00:00', '16:00:00', '');
INSERT INTO Jornadas VALUES (1, '07/03/2022', '08:00:00', '16:00:00', '');
INSERT INTO Jornadas VALUES (1, '08/03/2022', '08:00:00', '16:00:00', '');
INSERT INTO Jornadas VALUES (1, '09/03/2022', '08:00:00', '16:00:00', '');
INSERT INTO Jornadas VALUES (1, '10/03/2022', '08:00:00', '16:00:00', '');
INSERT INTO Jornadas VALUES (1, '11/03/2022', '08:00:00', '16:00:00', '');
INSERT INTO Jornadas VALUES (1, '12/03/2022', '08:00:00', '16:00:00', '');
INSERT INTO Jornadas VALUES (1, '13/03/2022', '08:00:00', '16:00:00', '');
INSERT INTO Jornadas VALUES (1, '14/03/2022', '08:00:00', '16:00:00', '');
INSERT INTO Jornadas VALUES (1, '15/03/2022', '08:00:00', '16:00:00', '');
INSERT INTO Jornadas VALUES (1, '16/03/2022', '08:00:00', '16:00:00', '');
INSERT INTO Jornadas VALUES (1, '17/03/2022', '08:00:00', '16:00:00', '');
INSERT INTO Jornadas VALUES (1, '18/03/2022', '08:00:00', '16:00:00', '');
INSERT INTO Jornadas VALUES (1, '19/03/2022', '08:00:00', '16:00:00', '');
INSERT INTO Jornadas VALUES (1, '20/03/2022', '08:00:00', '16:00:00', '');
INSERT INTO Jornadas VALUES (1, '21/03/2022', '08:00:00', '16:00:00', '');
INSERT INTO Jornadas VALUES (1, '22/03/2022', '08:00:00', '16:00:00', '');
INSERT INTO Jornadas VALUES (1, '23/03/2022', '08:00:00', '16:00:00', '');
INSERT INTO Jornadas VALUES (1, '24/03/2022', '08:00:00', '16:00:00', '');
INSERT INTO Jornadas VALUES (1, '25/03/2022', '08:00:00', '16:00:00', '');
INSERT INTO Jornadas VALUES (1, '26/03/2022', '08:00:00', '16:00:00', '');
INSERT INTO Jornadas VALUES (1, '27/03/2022', '08:00:00', '16:00:00', '');

INSERT INTO Nominas VALUES (1, '29/03/2022', '01/03/2022', '15/03/2022')

GO
SELECT * FROM Cargos
SELECT * FROM Departamentos
SELECT * FROM Detalles
SELECT * FROM Empleados
SELECT * FROM Horarios
SELECT * FROM Jornadas
SELECT * FROM Nominas
SELECT * FROM Usuarios



SELECT * FROM Jornadas WHERE Fecha = '29/03/2022' AND ID_Empleado = 1

SELECT * FROM Jornadas WHERE ID_Empleado = 1 AND Fecha BETWEEN '01/03/2022' AND '30/03/2022'

SELECT Periodo_Desde, Periodo_Hasta FROM Nominas WHERE ID_Nomina = 1

SELECT * FROM Jornadas WHERE ID_Empleado = 1 AND Fecha BETWEEN '01/03/2022' AND '16/03/2022'

SELECT ID_Empleado, Pago_Hora FROM Empleados WHERE Estado = 'Activo'

SELECT SUM(Sueldo_Base) AS 'Bruto Pagado' FROM Detalles