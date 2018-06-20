Create database Entregable6Db;
go
use Entregable6Db
go
CREATE TABLE Articulos
 (
 ArticuloID int primary key identity(1,1),
 Descripcion varchar(max),
 Precio money,
 ArticulosCotizados int null
 
 );


 CREATE TABLE Cotizaciones
 (
 ID int primary key identity(1,1),
 Fecha date,
 Comentario varchar(max),
 Monto money
 
 );

 
 CREATE TABLE CotizacionesDetalles
 (
 ID int primary key identity(1,1),
 CotizacionesID int,
 ArticuloID int,
 Cantidad int,
 Precio Money
 
 );

 CREATE TABLE Personas
(
	Id int primary key identity(1,1),
	Nombre varchar(30),
	Telefono varchar(13),
	Cedula varchar(13),
	Direccion varchar(max)
);