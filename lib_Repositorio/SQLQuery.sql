CREATE DATABASE db_TiendaSubastas;
GO
USE db_TiendaSubastas;
GO
CREATE TABLE Clientes (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Cedula NVARCHAR(20) UNIQUE NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    Telefono NVARCHAR(20) NOT NULL
);

CREATE TABLE Categorias (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(255) NOT NULL
);

CREATE TABLE Productos (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(255) NULL,
    PrecioInicial DECIMAL(18,2) NOT NULL,
    CategoriasID INT NOT NULL,
    FOREIGN KEY (CategoriasID) REFERENCES Categorias(ID)
);

CREATE TABLE Vendedores (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Cedula NVARCHAR(20) UNIQUE NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    Telefono NVARCHAR(20) NOT NULL
);

CREATE TABLE Estados (
    ID INT IDENTITY(1,1) PRIMARY KEY,
	Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(100) NOT NULL

);

CREATE TABLE Subastas (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    ProductosID INT NOT NULL,
    VendedoresID INT NOT NULL,
    EstadosID INT NOT NULL,
	CategoriasID INT NOT NULL,
    FechaInicio DATETIME NOT NULL,
    FechaFin DATETIME NOT NULL,
	FOREIGN KEY (CategoriasID) REFERENCES Categorias(ID),
    FOREIGN KEY (ProductosID) REFERENCES Productos(ID),
    FOREIGN KEY (VendedoresID) REFERENCES Vendedores(ID),
    FOREIGN KEY (EstadosID) REFERENCES Estados(ID)
);

CREATE TABLE Pujas (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    ClientesID INT NOT NULL,
    SubastasID INT NOT NULL,
    Monto DECIMAL(18,2) NOT NULL,
    Fecha DATETIME NOT NULL,
    FOREIGN KEY (ClientesID) REFERENCES Clientes(ID),
    FOREIGN KEY (SubastasID) REFERENCES Subastas(ID)
);

CREATE TABLE MetodosPagos (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    TipoPago NVARCHAR(100) NOT NULL,
	Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(100) NOT NULL
);

CREATE TABLE Pagos (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Referencia NVARCHAR(100) UNIQUE NOT NULL,
    ClientesID INT NOT NULL,
    SubastasID INT NOT NULL,
    MetodosPagosID INT NOT NULL,
    FOREIGN KEY (ClientesID) REFERENCES Clientes(ID),
    FOREIGN KEY (SubastasID) REFERENCES Subastas(ID),
    FOREIGN KEY (MetodosPagosID) REFERENCES MetodosPagos(ID)
);

-- Inserción de datos
	INSERT INTO Clientes (Nombre, Cedula, Email, Telefono) VALUES
		('Juan Pérez', '123', 'JuanP@gmail.com', '3101234567'),
		('Ana Torres', '456', 'AnaT@gmail.com', '3152345678'),
		('Carlos Ruiz', '567', 'CarlosR@gmail.com', '3203456789'),
		('Andres Salazar', '945', 'AndresZ@gmail.com', '3185678901'),
		('Rosa Martinez', '347', 'RosaM@gmail.com', '3116789012');

	INSERT INTO Categorias (Nombre, Descripcion) VALUES
		('Electrónica', 'Productos electrónicos'),
		('Hogar', 'Artículos para el hogar'),
		('Moda', 'Ropa y accesorios'),
		('Deportes', 'Equipamiento deportivo'),
		('Juguetes', 'Juegos y juguetes');



	INSERT INTO Vendedores (Nombre, Cedula, Email, Telefono) VALUES
		('Luis Martínez', '111222333', 'luis@example.com', '3123456789'),
		('Ana Gómez', '444555666', 'ana@example.com', '3224567890'),
		('David Fernández', '777888999', 'david@example.com', '3335678901'),
		('Elena Ruiz', '123789456', 'elena@example.com', '3446789012'),
		('Sergio Castro', '987321654', 'sergio@example.com', '3557890123');

	INSERT INTO Estados (Descripcion,Nombre) VALUES
		('Activa','A'),
		('Finalizada','A'),
		('Cancelada','A'),
		('Pendiente','A'),
		('Suspendida','A');

	INSERT INTO MetodosPagos (TipoPago,Nombre,Descripcion) VALUES
		('Tarjeta','A','A'),
		('PayPal','A','A'),
		('Transferencia bancaria','A','A'),
		('Efectivo','A','A'),
		('Criptomonedas','A','A');

		SELECT * FROM Clientes;
		SELECT * FROM Categorias;
		SELECT * FROM MetodosPagos;
		SELECT * FROM Vendedores;
		SELECT * FROM Estados;

		SELECT * FROM Productos;

		SELECT * FROM Subastas;

		SELECT * FROM Pagos; --
		SELECT * FROM Pujas; --
		
		INSERT INTO Productos (Nombre, Descripcion, PrecioInicial,CategoriasID) VALUES
		('¡Phone', 'Teléfono de última generación', 500.00,1),
		('Sofá', 'Sofá de cuero 3 puestos', 800.00,2),
		('Camisa', 'Camisa de algodón para hombre', 30.00,3),
		('Bicicleta', 'Bicicleta de montaña', 300.00,4),
		('Muñeca', 'Muñeca de colección', 25.00,5);

		INSERT INTO Subastas(FechaInicio,FechaFin,CategoriasID,EstadosID,VendedoresID,ProductosID)VALUES
		(GETDATE(),GETDATE(),1,1,1,1)
		--¿?
		INSERT INTO Pujas(Monto,Fecha,ClientesID,SubastasID)VALUES
		(2000,GETDATE(),1,1)
		INSERT INTO Pagos(Referencia,ClientesID,MetodosPagosID,SubastasID) VALUES
		('ABC',1,1,1)
		