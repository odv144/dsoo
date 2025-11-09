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
DELIMITER //
CREATE PROCEDURE ingresologin(IN usu VARCHAR(20), IN pass VARCHAR(15))
BEGIN
    SELECT nomrol
    FROM credencial c
    INNER JOIN roles r ON c.rolusu = r.rolusu
    WHERE c.nombreusu = usu
      AND c.passusu = pass
      AND c.activo = 1;
END //
DELIMITER //


-- ======= INSERTAR USUARIOS SOCIOS =======
INSERT INTO usuario (nombre, apellido, dni, telefono, email, fecharegistro, certificadomedico) VALUES
('Juan', 'Pérez', '12345678', '381111111', 'juanperez@mail.com', '2025-11-01', TRUE),
('Ana', 'Gómez', '22345678', '381222222', 'anagomez@mail.com', '2025-11-02', TRUE),
('Carlos', 'López', '32345678', '381333333', 'carloslopez@mail.com', '2025-11-03', FALSE),
('Laura', 'Martínez', '42345678', '381444444', 'lauramartinez@mail.com', '2025-11-04', TRUE),
('Marcos', 'Rivas', '52345678', '381555555', 'marcosrivas@mail.com', '2025-11-05', TRUE),
('Elena', 'Torres', '62345678', '381666666', 'elenatorres@mail.com', '2025-11-06', TRUE),
('Diego', 'Ruiz', '72345678', '381777777', 'diegoruiz@mail.com', '2025-11-07', FALSE),
('Lucía', 'Fernández', '82345678', '381888888', 'luciafernandez@mail.com', '2025-11-08', TRUE),
('Pablo', 'Acosta', '92345678', '381999999', 'pabloacosta@mail.com', '2025-11-09', TRUE),
('Sofía', 'Molina', '10345678', '381101010', 'sofiamolina@mail.com', '2025-11-10', TRUE),
('Andrés', 'Castro', '11345678', '381202020', 'andrescastro@mail.com', '2025-11-01', TRUE),
('Rosa', 'Vega', '12345679', '381303030', 'rosavega@mail.com', '2025-11-02', TRUE),
('Jorge', 'Silva', '13345678', '381404040', 'jorgesilva@mail.com', '2025-11-03', TRUE),
('Camila', 'Benítez', '14345678', '381505050', 'camilabenitez@mail.com', '2025-11-04', TRUE),
('Tomás', 'Flores', '15345678', '381606060', 'tomasflores@mail.com', '2025-11-05', TRUE),
('Nadia', 'Herrera', '16345678', '381707070', 'nadiaherrera@mail.com', '2025-11-06', TRUE),
('Martín', 'Ortega', '17345678', '381808080', 'martinortega@mail.com', '2025-11-07', FALSE),
('Paula', 'Navarro', '18345678', '381909090', 'paulanavarro@mail.com', '2025-11-08', TRUE),
('Ignacio', 'Campos', '19345678', '381111222', 'ignaciocampos@mail.com', '2025-11-09', TRUE),
('Valeria', 'Suárez', '20345678', '381222333', 'valeriasuarez@mail.com', '2025-11-10', TRUE);

-- ======= INSERTAR SOCIOS =======
INSERT INTO socio (idusuario, estadohabilitacion, cuotamensual, carnetentregado) VALUES
(1, 'activo', 5500, TRUE),
(2, 'activo', 4800, TRUE),
(3, 'activo', 6000, TRUE),
(4, 'activo', 7000, TRUE),
(5, 'activo', 5300, TRUE),
(6, 'activo', 5900, TRUE),
(7, 'activo', 6200, TRUE),
(8, 'activo', 4500, TRUE),
(9, 'activo', 6800, TRUE),
(10, 'activo', 4700, TRUE),
(11, 'activo', 5100, TRUE),
(12, 'activo', 5600, TRUE),
(13, 'activo', 4900, TRUE),
(14, 'activo', 5800, TRUE),
(15, 'activo', 6300, TRUE),
(16, 'activo', 5200, TRUE),
(17, 'activo', 5400, TRUE),
(18, 'activo', 6100, TRUE),
(19, 'activo', 4900, TRUE),
(20, 'activo', 5600, TRUE);

-- ======= INSERTAR CUOTAS =======
-- 7 vencidas (antes del 2025-11-01)
INSERT INTO cuota (nrosocio, mes, anio, monto, fechavencimiento, fechapago, metodopago, estadopago) VALUES
(1, 10, 2025, 5500, '2025-10-20', NULL, 'Efectivo', 0),
(2, 10, 2025, 4800, '2025-10-25', NULL, 'Transferencia', 0),
(3, 10, 2025, 6000, '2025-10-22', NULL, 'Efectivo', 0),
(4, 10, 2025, 7000, '2025-10-18', NULL, 'Efectivo', 0),
(5, 10, 2025, 5300, '2025-10-30', NULL, 'Transferencia', 0),
(6, 10, 2025, 5900, '2025-10-28', NULL, 'Efectivo', 0),
(7, 10, 2025, 6200, '2025-10-15', NULL, 'Efectivo', 0);

-- 6 próximas a vencer (entre 2025-11-09 y 2025-11-16)
INSERT INTO cuota (nrosocio, mes, anio, monto, fechavencimiento, fechapago, metodopago, estadopago) VALUES
(8, 11, 2025, 4500, '2025-11-10', NULL, 'Efectivo', 0),
(9, 11, 2025, 6800, '2025-11-11', NULL, 'Transferencia', 0),
(10, 11, 2025, 4700, '2025-11-12', NULL, 'Efectivo', 0),
(11, 11, 2025, 5100, '2025-11-14', NULL, 'Efectivo', 0),
(12, 11, 2025, 5600, '2025-11-15', NULL, 'Transferencia', 0),
(13, 11, 2025, 4900, '2025-11-16', NULL, 'Efectivo', 0);

-- 7 al día (pagadas o vencen después del 2025-11-17)
INSERT INTO cuota (nrosocio, mes, anio, monto, fechavencimiento, fechapago, metodopago, estadopago) VALUES
(14, 11, 2025, 5800, '2025-11-20', '2025-11-05', 'Transferencia', 1),
(15, 11, 2025, 6300, '2025-11-25', NULL, 'Efectivo', 0),
(16, 11, 2025, 5200, '2025-11-30', NULL, 'Transferencia', 0),
(17, 11, 2025, 5400, '2025-12-02', NULL, 'Efectivo', 0),
(18, 11, 2025, 6100, '2025-12-10', '2025-11-05', 'Transferencia', 1),
(19, 11, 2025, 4900, '2025-12-15', NULL, 'Efectivo', 0),
(20, 11, 2025, 5600, '2025-12-20', '2025-11-06', 'Efectivo', 1);

-- ======= INSERTAR USUARIOS NO SOCIOS =======
INSERT INTO usuario (nombre, apellido, dni, telefono, email, fecharegistro, certificadomedico) VALUES
('Luis', 'Carrizo', '30345678', '381100000', 'luiscarrizo@mail.com', '2025-11-01', TRUE),
('Patricia', 'Medina', '31345678', '381200000', 'patriciamedina@mail.com', '2025-11-02', TRUE),
('Héctor', 'Salas', '32345679', '381300000', 'hectorsalas@mail.com', '2025-11-03', TRUE),
('Brenda', 'Aguilar', '33345678', '381400000', 'brendaaguilar@mail.com', '2025-11-04', TRUE),
('Felipe', 'Cabrera', '34345678', '381500000', 'felipecabrera@mail.com', '2025-11-05', TRUE),
('Tamara', 'Juárez', '35345678', '381600000', 'tamarajuarez@mail.com', '2025-11-06', TRUE),
('Santiago', 'Maidana', '36345678', '381700000', 'santiagomaidana@mail.com', '2025-11-07', TRUE),
('Gabriela', 'Olivera', '37345678', '381800000', 'gabrielaolivera@mail.com', '2025-11-08', TRUE),
('Matías', 'Peralta', '38345678', '381900000', 'matiasperalta@mail.com', '2025-11-09', TRUE),
('Florencia', 'Quiroga', '39345678', '381999000', 'florenciaquiroga@mail.com', '2025-11-10', TRUE);

INSERT INTO nosocio (idusuario, observacion) VALUES
(21, 'Participa en natación ocasionalmente'),
(22, 'Clases de spinning mensuales'),
(23, 'Asiste a yoga los fines de semana'),
(24, 'Uso libre del gimnasio'),
(25, 'Participa en torneos de pádel'),
(26, 'Prueba de funcional por un mes'),
(27, 'Inscripto en zumba semanal'),
(28, 'Pilates dos veces por semana'),
(29, 'Clases libres de boxeo'),
(30, 'Uso eventual de canchas');

