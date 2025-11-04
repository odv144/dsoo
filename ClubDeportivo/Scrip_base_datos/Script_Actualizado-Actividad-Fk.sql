DROP DATABASE IF EXISTS proyecto;
CREATE DATABASE proyecto;
USE proyecto;

CREATE TABLE roles (
    rolusu INT,
    nomrol VARCHAR(30),
    CONSTRAINT pk_roles PRIMARY KEY (rolusu)
);

INSERT INTO roles VALUES
(1,'Administrador'),
(2,'Empleado');

CREATE TABLE credencial (
    codusu INT AUTO_INCREMENT,
    nombreusu VARCHAR(20),
    passusu VARCHAR(15),
    rolusu INT,
    activo BOOLEAN DEFAULT TRUE,
    CONSTRAINT pk_credencial PRIMARY KEY (codusu),
    CONSTRAINT fk_credencial_rol FOREIGN KEY (rolusu) REFERENCES roles(rolusu)
);

INSERT INTO credencial(nombreusu, passusu, rolusu) VALUES
('omar','1234',1),
('cynthia','1234',1),
('cristian','1234',1),
('analia','1234',1),
('jairo','1234',1),
('admin','1234',1);

CREATE TABLE usuario (
    idusuario INT AUTO_INCREMENT,
    nombre VARCHAR(20),
    apellido VARCHAR(15),
    dni VARCHAR(8),
    telefono VARCHAR(15),
    email VARCHAR(60),
    fecharegistro DATE,
    certificadomedico BOOLEAN,
    CONSTRAINT pk_usuario PRIMARY KEY (idusuario)
);

CREATE TABLE socio (
    nrosocio INT AUTO_INCREMENT,
    idusuario INT,
    estadohabilitacion ENUM('activo', 'suspendido', 'vencido') NOT NULL DEFAULT 'activo',
    cuotamensual DOUBLE,
    carnetentregado BOOLEAN,
    CONSTRAINT pk_socio PRIMARY KEY (nrosocio),
    CONSTRAINT fk_socio_usuario FOREIGN KEY (idusuario) REFERENCES usuario(idusuario)
);

CREATE TABLE nosocio (
    nronosocio INT AUTO_INCREMENT,
    idusuario INT,
    observacion VARCHAR(150),
    CONSTRAINT pk_nosocio PRIMARY KEY (nronosocio),
    CONSTRAINT fk_nosocio_usuario FOREIGN KEY (idusuario) REFERENCES usuario(idusuario)
);

CREATE TABLE cuota (
    idcuota INT AUTO_INCREMENT,
    nrosocio INT,
    mes INT,
    anio INT,
    monto DOUBLE,
    fechavencimiento DATE,
    fechapago DATE NULL,
    metodopago VARCHAR(20),
    estadopago BOOLEAN DEFAULT 0,
    CONSTRAINT pk_cuota PRIMARY KEY (idcuota),
    CONSTRAINT fk_cuota_socio FOREIGN KEY (nrosocio) REFERENCES socio(nrosocio)
);
-- Necesito que la tabla actividades no tenga ID de soscios porque es independiente
CREATE TABLE actividad (
    idactividad INT AUTO_INCREMENT,
    -- nrosocio INT NULL,
    -- nronosocio INT NULL,
    nombre VARCHAR(50),
    descripcion VARCHAR(60),
    tarifasocio DOUBLE,
    tarifanosocio DOUBLE,
    cupomaximo INT,
    turno VARCHAR(20),
    CONSTRAINT pk_actividad PRIMARY KEY (idactividad)
    -- CONSTRAINT fk_actividad_socio FOREIGN KEY (nrosocio) REFERENCES socio(nrosocio),
    -- CONSTRAINT fk_actividad_nosocio FOREIGN KEY (nronosocio) REFERENCES nosocio(nronosocio)
);

CREATE TABLE socio_actividad (
    idinscripcion INT AUTO_INCREMENT,
    nrosocio INT NOT NULL,
    idactividad INT NOT NULL,
    fechainscripcion DATETIME NOT NULL,
    estado VARCHAR(20),
    PRIMARY KEY (idinscripcion),
    FOREIGN KEY (nrosocio) REFERENCES socio(nrosocio),
    FOREIGN KEY (idactividad) REFERENCES actividad(idactividad),
    UNIQUE KEY uk_socio_actividad (nrosocio, idactividad)
);

CREATE TABLE nosocio_actividad (
    idinscripcion INT AUTO_INCREMENT,
    nronosocio INT NOT NULL,
    idactividad INT NOT NULL,
    fechainscripcion DATETIME NOT NULL,
    estado VARCHAR(20),
    PRIMARY KEY (idinscripcion),
    FOREIGN KEY (nronosocio) REFERENCES nosocio(nronosocio),
    FOREIGN KEY (idactividad) REFERENCES actividad(idactividad),
    UNIQUE KEY uk_nosocio_actividad (nronosocio, idactividad)
);


DROP PROCEDURE IF EXISTS ingresologin;
DELIMITER ;;
CREATE PROCEDURE ingresologin(IN usu VARCHAR(20), IN pass VARCHAR(15))
BEGIN
    SELECT nomrol
    FROM credencial c
    INNER JOIN roles r ON c.rolusu = r.rolusu
    WHERE c.nombreusu = usu
      AND c.passusu = pass
      AND c.activo = 1;
END ;;
DELIMITER ;
