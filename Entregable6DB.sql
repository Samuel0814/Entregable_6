Create database Entregable6;
go
use Entregable6
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