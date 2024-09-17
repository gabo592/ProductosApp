CREATE DATABASE BDEmpresa
GO

USE BDEmpresa;

CREATE TABLE Categorias(
	NoCategoria INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Nombre VARCHAR(50) NOT NULL,
	Descripcion VARCHAR(200),
)
GO

CREATE TABLE Productos(
	NoProducto INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Nombre VARCHAR(50) NOT NULL,
	Descripcion VARCHAR(200),
	Stock INT NOT NULL,
	Precio MONEY NOT NULL,
	NoCategoria INT FOREIGN KEY REFERENCES Categorias(NoCategoria) NOT NULL,
)
GO

INSERT INTO Categorias(Nombre, Descripcion) VALUES ('Categoria 1', 'Descripcion 1')
INSERT INTO Categorias(Nombre, Descripcion) VALUES ('Categoria 2', 'Descripcion 2')
INSERT INTO Categorias(Nombre, Descripcion) VALUES ('Categoria 3', 'Descripcion 3')
