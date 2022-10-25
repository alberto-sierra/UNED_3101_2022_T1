CREATE DATABASE universidad
CREATE LOGIN tarea1 WITH password = '_Tarea1_'

USE universidad

CREATE USER tarea1 FOR LOGIN tarea1
exec sp_addrolemember 'db_datareader', 'tarea1'
exec sp_addrolemember 'db_datawriter', 'tarea1'


CREATE TABLE estudiante (
	id bigint IDENTITY(1,1) PRIMARY KEY NOT NULL,
	identificacion varchar(9) UNIQUE NOT NULL,
	nombre varchar(50) NOT NULL,
	primerApellido varchar(50) NOT NULL,
	segundoApellido varchar(50) NOT NULL,
	fechaNacimiento datetime NOT NULL,
	fechaIngreso datetime NOT NULL
);

CREATE TABLE escuela (
	id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	codigo varchar(5) UNIQUE NOT NULL,
	nombre varchar(100) NOT NULL,
);

CREATE TABLE carrera (
	id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	codigo varchar(5) UNIQUE NOT NULL,
	idEscuela int NOT NULL FOREIGN KEY REFERENCES escuela(id),
	nombre varchar(100) NOT NULL,
);

CREATE TABLE curso (
	id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	codigo varchar(5) UNIQUE NOT NULL,
	nombre varchar(100) NOT NULL,
	descripcion varchar(255) NULL,
	idCarrera int NOT NULL FOREIGN KEY REFERENCES carrera(id),
	precio money NOT NULL
);

CREATE TABLE matricula (
	id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	idEstudiante bigint NOT NULL FOREIGN KEY REFERENCES estudiante(id),
	fecha datetime NOT NULL,
);

CREATE TABLE matricula_detalle (
	id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	idMatricula int NOT NULL FOREIGN KEY REFERENCES matricula(id),
	idCurso int NOT NULL FOREIGN KEY REFERENCES curso(id)
);

