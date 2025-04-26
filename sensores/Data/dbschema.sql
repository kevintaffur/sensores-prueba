create database sensores;

use sensores;

create table Ubicaciones(
	Id int primary key identity(1,1),
	Nombre varchar(20),
	Estado varchar(1),
);


create table Sensores(
	Id int primary key identity(1,1),
	UbicacionId int,
	Metrica varchar(20), -- temperatura, humedad o presion.
	Estado varchar(1),

	constraint sensores_ubicaciones_fk foreign key(UbicacionId) references Ubicaciones(Id)
);


create table Lecturas(
	Id int primary key identity(1,1),
	SensorId int,
	Valor decimal(10,2),
	Estado varchar(1),

	constraint lecturas_sensores_fk foreign key(SensorId) references Sensores(Id)
);

alter table Lecturas add Fecha date;
alter table Lecturas alter column Fecha datetime;

