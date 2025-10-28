drop database if exists proyecto;
create database proyecto;
use proyecto;

create table roles(
RolUsu int,
NomRol varchar(30),
constraint primary key(RolUsu)
);

insert into roles values
(1,'Administrador'),
(2,'Empleado');

create table credencial(
CodUsu int auto_increment,
NombreUsu varchar (20),
PassUsu varchar (15),
RolUsu int,
Activo boolean default true,
constraint pk_credencial primary key (CodUsu),
constraint fk_credencial foreign key(RolUsu) references roles(RolUsu)
);

insert into credencial(NombreUsu,PassUsu,RolUsu) values
('omar','1234',1),
('cynthia','1234',1),
('cristian','1234',1),
('analia','1234',1),
('jairo','1234',1),
('admin','1234',1);


create table Usuario(
IdUsuario int auto_increment,
Nombre varchar (20),
Apellido varchar (15),
Dni varchar(8),
Telefono varchar(15),
Email varchar(60),
Fecharegistro date,
CertificadoMedico boolean,
constraint pk_IdUsuario primary key (IdUsuario)
);

create table Socio(
	NroSocio int auto_increment,
    EstadoHabilitacion enum('activo', 'suspendido', 'vencido') NOT NULL DEFAULT 'activo',
    CuotaMensual double,
    CarnetEntregado boolean,
    constraint pk_NroSocio primary key (NroSocio),
    constraint fk_Usuario foreign key(NroSocio) references Usuario(IdUsuario)
);
create table NoSocio(
	NroNoSocio int auto_increment,
    Observacion varchar(150),
    constraint pk_NroNoSocio primary key (NroNoSocio),
    constraint fk_NroNoSocio foreign key(NroNoSocio) references Usuario(IdUsuario)
);
create table Cuota(
	IdCuota int auto_increment,
    NroSocio int,
    Mes int,
    Anio int,
    Monto double,
    FechaVencimiento date,
    FechaPago date,
    MetodoPago enum('Efectivo','Tarjeta 3','Tarjeta 6'),
    EstadoPago enum('Pagada','Vencida'),
    constraint pk_IdCuota primary key (IdCuota),
    constraint fk_Cuota_Socio foreign key (NroSocio) references Socio(NroSocio)
    
);
create table Actividad (
	IdActividad int auto_increment,
    NroSocio int,
    Nombre varchar(50),
    Descripcion varchar(60),
    TarifaSocio double,
    TarifaNoSocio double,
    CupoMaximo int,
    Turno varchar(20),
    constraint pk_IdAct primary key (IdActividad),
    constraint fk_Act_Socio foreign key (NroSocio) references Socio(NroSocio),
    constraint fk_Act_NoSocio foreign key (NroSocio) references NoSocio(NroNoSocio)
);
-- Tabla intermedia para relacionar socios y no socios con actividad
CREATE TABLE Socio_Actividad (
    IdInscripcion INT PRIMARY KEY AUTO_INCREMENT,
    NroSocio INT ,
    NroNoSocio INT,
    IdActividad INT NOT NULL,
    FechaInscripcion DATETIME NOT NULL,
    Estado VARCHAR(20), -- 'Activo', 'Cancelado', 'Completado'
    FOREIGN KEY (NroSocio) REFERENCES Socio(NroSocio),
    FOREIGN KEY (NroNoSocio) REFERENCES nosocio(NroNoSocio),
    FOREIGN KEY (IdActividad) REFERENCES Actividad(IdActividad),
    UNIQUE KEY (NroSocio, IdActividad), -- Un socio no puede inscribirse 2 veces en la misma actividad
    UNIQUE KEY (NroNoSocio, IdActividad) -- Un No socio no puede inscribirse 2 veces en la misma actividad
);



DROP PROCEDURE IF EXISTS `IngresoLogin`;
delimiter ;;
CREATE PROCEDURE `IngresoLogin`(in Usu varchar(20),in Pass varchar(15))
BEGIN
select NomRol
	from credencial u inner join roles r on u.RolUsu = r.RolUsu
		where NombreUsu = Usu and PassUsu = Pass /* se compara con los parametros */
			and Activo = 1; /* el usuario debe estar activo */

END
;;
delimiter ;
