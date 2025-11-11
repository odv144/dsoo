
-- Base de datos: `proyecto`
--
CREATE DATABASE IF NOT EXISTS `proyecto` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `proyecto`;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `actividad`
--

CREATE TABLE `actividad` (
  `idactividad` int(11) NOT NULL,
  `nombre` varchar(50) DEFAULT NULL,
  `descripcion` varchar(60) DEFAULT NULL,
  `tarifasocio` double DEFAULT NULL,
  `tarifanosocio` double DEFAULT NULL,
  `cupomaximo` int(11) DEFAULT NULL,
  `turno` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `credencial`
--

CREATE TABLE `credencial` (
  `codusu` int(11) NOT NULL,
  `nombreusu` varchar(20) DEFAULT NULL,
  `passusu` varchar(15) DEFAULT NULL,
  `rolusu` int(11) DEFAULT NULL,
  `activo` tinyint(1) DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `credencial`
--

INSERT INTO `credencial` (`codusu`, `nombreusu`, `passusu`, `rolusu`, `activo`) VALUES
(1, 'omar', '1234', 1, 1),
(2, 'cynthia', '1234', 1, 1),
(3, 'cristian', '1234', 1, 1),
(4, 'analia', '1234', 1, 1),
(5, 'jairo', '1234', 1, 1),
(6, 'admin', '1234', 1, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cuota`
--

CREATE TABLE `cuota` (
  `idcuota` int(11) NOT NULL,
  `nrosocio` int(11) DEFAULT NULL,
  `mes` int(11) DEFAULT NULL,
  `anio` int(11) DEFAULT NULL,
  `monto` double DEFAULT NULL,
  `fechavencimiento` date DEFAULT NULL,
  `fechapago` date DEFAULT NULL,
  `metodopago` varchar(20) DEFAULT NULL,
  `estadopago` tinyint(1) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `cuota`
--

INSERT INTO `cuota` (`idcuota`, `nrosocio`, `mes`, `anio`, `monto`, `fechavencimiento`, `fechapago`, `metodopago`, `estadopago`) VALUES
(1, 1, 10, 2025, 5500, '2025-10-20', '2025-11-10', 'Efectivo', 0),
(2, 2, 10, 2025, 4800, '2025-10-25', NULL, 'Transferencia', 0),
(3, 3, 10, 2025, 6000, '2025-10-22', NULL, 'Efectivo', 0),
(4, 4, 10, 2025, 7000, '2025-10-18', NULL, 'Efectivo', 0),
(5, 5, 10, 2025, 5300, '2025-10-30', NULL, 'Transferencia', 0),
(6, 6, 10, 2025, 5900, '2025-10-28', NULL, 'Efectivo', 0),
(7, 7, 10, 2025, 6200, '2025-10-15', '2025-11-10', 'Efectivo', 1),
(8, 8, 11, 2025, 4500, '2025-11-10', NULL, 'Efectivo', 0),
(9, 9, 11, 2025, 6800, '2025-11-11', NULL, 'Transferencia', 0),
(10, 10, 11, 2025, 4700, '2025-11-12', NULL, 'Efectivo', 0),
(11, 11, 11, 2025, 5100, '2025-11-14', NULL, 'Efectivo', 0),
(12, 12, 11, 2025, 5600, '2025-11-15', NULL, 'Transferencia', 0),
(13, 13, 11, 2025, 4900, '2025-11-16', NULL, 'Efectivo', 0),
(14, 14, 11, 2025, 5800, '2025-11-20', '2025-11-05', 'Transferencia', 1),
(15, 15, 11, 2025, 6300, '2025-11-25', NULL, 'Efectivo', 0),
(16, 16, 11, 2025, 5200, '2025-11-30', NULL, 'Transferencia', 0),
(17, 17, 11, 2025, 5400, '2025-12-02', NULL, 'Efectivo', 0),
(18, 18, 11, 2025, 6100, '2025-12-10', '2025-11-05', 'Transferencia', 1),
(19, 19, 11, 2025, 4900, '2025-12-15', NULL, 'Efectivo', 0),
(20, 20, 11, 2025, 5600, '2025-12-20', '2025-11-06', 'Efectivo', 1),
(21, 7, 11, 2025, 6200, '2025-12-10', '0001-01-01', 'Efectivo', 0);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `nosocio`
--

CREATE TABLE `nosocio` (
  `nronosocio` int(11) NOT NULL,
  `idusuario` int(11) DEFAULT NULL,
  `observacion` varchar(150) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `nosocio`
--

INSERT INTO `nosocio` (`nronosocio`, `idusuario`, `observacion`) VALUES
(11, 21, 'Participa en natación ocasionalmente'),
(12, 22, 'Clases de spinning mensuales'),
(13, 23, 'Asiste a yoga los fines de semana'),
(14, 24, 'Uso libre del gimnasio'),
(15, 25, 'Participa en torneos de pádel');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `nosocio_actividad`
--

CREATE TABLE `nosocio_actividad` (
  `idinscripcion` int(11) NOT NULL,
  `nronosocio` int(11) NOT NULL,
  `idactividad` int(11) NOT NULL,
  `fechainscripcion` datetime NOT NULL,
  `estado` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `roles`
--

CREATE TABLE `roles` (
  `rolusu` int(11) NOT NULL,
  `nomrol` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `roles`
--

INSERT INTO `roles` (`rolusu`, `nomrol`) VALUES
(1, 'Administrador'),
(2, 'Empleado');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `socio`
--

CREATE TABLE `socio` (
  `nrosocio` int(11) NOT NULL,
  `idusuario` int(11) DEFAULT NULL,
  `estadohabilitacion` enum('activo','suspendido','vencido') NOT NULL DEFAULT 'activo',
  `cuotamensual` double DEFAULT NULL,
  `carnetentregado` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `socio`
--

INSERT INTO `socio` (`nrosocio`, `idusuario`, `estadohabilitacion`, `cuotamensual`, `carnetentregado`) VALUES
(1, 1, 'activo', 5500, 1),
(2, 2, 'activo', 4800, 1),
(3, 3, 'activo', 6000, 1),
(4, 4, 'activo', 7000, 1),
(5, 5, 'activo', 5300, 1),
(6, 6, 'activo', 5900, 1),
(7, 7, 'activo', 6200, 1),
(8, 8, 'activo', 4500, 1),
(9, 9, 'activo', 6800, 1),
(10, 10, 'activo', 4700, 1),
(11, 11, 'activo', 5100, 1),
(12, 12, 'activo', 5600, 1),
(13, 13, 'activo', 4900, 1),
(14, 14, 'activo', 5800, 1),
(15, 15, 'activo', 6300, 1),
(16, 16, 'activo', 5200, 1),
(17, 17, 'activo', 5400, 1),
(18, 18, 'activo', 6100, 1),
(19, 19, 'activo', 4900, 1),
(20, 20, 'activo', 5600, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `socio_actividad`
--

CREATE TABLE `socio_actividad` (
  `idinscripcion` int(11) NOT NULL,
  `nrosocio` int(11) NOT NULL,
  `idactividad` int(11) NOT NULL,
  `fechainscripcion` datetime NOT NULL,
  `estado` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuario`
--

CREATE TABLE `usuario` (
  `idusuario` int(11) NOT NULL,
  `nombre` varchar(20) DEFAULT NULL,
  `apellido` varchar(15) DEFAULT NULL,
  `dni` varchar(8) DEFAULT NULL,
  `telefono` varchar(15) DEFAULT NULL,
  `email` varchar(60) DEFAULT NULL,
  `fecharegistro` date DEFAULT NULL,
  `certificadomedico` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `usuario`
--

INSERT INTO `usuario` (`idusuario`, `nombre`, `apellido`, `dni`, `telefono`, `email`, `fecharegistro`, `certificadomedico`) VALUES
(1, 'Juan', 'Pérez', '12345678', '381111111', 'juanperez@mail.com', '2025-11-01', 1),
(2, 'Ana', 'Gómez', '22345678', '381222222', 'anagomez@mail.com', '2025-11-02', 1),
(3, 'Carlos', 'López', '32345678', '381333333', 'carloslopez@mail.com', '2025-11-03', 0),
(4, 'Laura', 'Martínez', '42345678', '381444444', 'lauramartinez@mail.com', '2025-11-04', 1),
(5, 'Marcos', 'Rivas', '52345678', '381555555', 'marcosrivas@mail.com', '2025-11-05', 1),
(6, 'Elena', 'Torres', '62345678', '381666666', 'elenatorres@mail.com', '2025-11-06', 1),
(7, 'Diego', 'Ruiz', '72345678', '381777777', 'diegoruiz@mail.com', '2025-11-07', 0),
(8, 'Lucía', 'Fernández', '82345678', '381888888', 'luciafernandez@mail.com', '2025-11-08', 1),
(9, 'Pablo', 'Acosta', '92345678', '381999999', 'pabloacosta@mail.com', '2025-11-09', 1),
(10, 'Sofía', 'Molina', '10345678', '381101010', 'sofiamolina@mail.com', '2025-11-10', 1),
(11, 'Andrés', 'Castro', '11345678', '381202020', 'andrescastro@mail.com', '2025-11-01', 1),
(12, 'Rosa', 'Vega', '12345679', '381303030', 'rosavega@mail.com', '2025-11-02', 1),
(13, 'Jorge', 'Silva', '13345678', '381404040', 'jorgesilva@mail.com', '2025-11-03', 1),
(14, 'Camila', 'Benítez', '14345678', '381505050', 'camilabenitez@mail.com', '2025-11-04', 1),
(15, 'Tomás', 'Flores', '15345678', '381606060', 'tomasflores@mail.com', '2025-11-05', 1),
(16, 'Nadia', 'Herrera', '16345678', '381707070', 'nadiaherrera@mail.com', '2025-11-06', 1),
(17, 'Martín', 'Ortega', '17345678', '381808080', 'martinortega@mail.com', '2025-11-07', 0),
(18, 'Paula', 'Navarro', '18345678', '381909090', 'paulanavarro@mail.com', '2025-11-08', 1),
(19, 'Ignacio', 'Campos', '19345678', '381111222', 'ignaciocampos@mail.com', '2025-11-09', 1),
(20, 'Valeria', 'Suárez', '20345678', '381222333', 'valeriasuarez@mail.com', '2025-11-10', 1),
(21, 'Luis', 'Carrizo', '30345678', '381100000', 'luiscarrizo@mail.com', '2025-11-01', 1),
(22, 'Patricia', 'Medina', '31345678', '381200000', 'patriciamedina@mail.com', '2025-11-02', 1),
(23, 'Héctor', 'Salas', '32345679', '381300000', 'hectorsalas@mail.com', '2025-11-03', 1),
(24, 'Brenda', 'Aguilar', '33345678', '381400000', 'brendaaguilar@mail.com', '2025-11-04', 1),
(25, 'Felipe', 'Cabrera', '34345678', '381500000', 'felipecabrera@mail.com', '2025-11-05', 1),
(26, 'Tamara', 'Juárez', '35345678', '381600000', 'tamarajuarez@mail.com', '2025-11-06', 1),
(27, 'Santiago', 'Maidana', '36345678', '381700000', 'santiagomaidana@mail.com', '2025-11-07', 1),
(28, 'Gabriela', 'Olivera', '37345678', '381800000', 'gabrielaolivera@mail.com', '2025-11-08', 1),
(29, 'Matías', 'Peralta', '38345678', '381900000', 'matiasperalta@mail.com', '2025-11-09', 1),
(30, 'Florencia', 'Quiroga', '39345678', '381999000', 'florenciaquiroga@mail.com', '2025-11-10', 1);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `actividad`
--
ALTER TABLE `actividad`
  ADD PRIMARY KEY (`idactividad`);

--
-- Indices de la tabla `credencial`
--
ALTER TABLE `credencial`
  ADD PRIMARY KEY (`codusu`),
  ADD KEY `fk_credencial_rol` (`rolusu`);

--
-- Indices de la tabla `cuota`
--
ALTER TABLE `cuota`
  ADD PRIMARY KEY (`idcuota`),
  ADD KEY `fk_cuota_socio` (`nrosocio`);

--
-- Indices de la tabla `nosocio`
--
ALTER TABLE `nosocio`
  ADD PRIMARY KEY (`nronosocio`),
  ADD KEY `fk_nosocio_usuario` (`idusuario`);

--
-- Indices de la tabla `nosocio_actividad`
--
ALTER TABLE `nosocio_actividad`
  ADD PRIMARY KEY (`idinscripcion`),
  ADD UNIQUE KEY `uk_nosocio_actividad` (`nronosocio`,`idactividad`),
  ADD KEY `idactividad` (`idactividad`);

--
-- Indices de la tabla `roles`
--
ALTER TABLE `roles`
  ADD PRIMARY KEY (`rolusu`);

--
-- Indices de la tabla `socio`
--
ALTER TABLE `socio`
  ADD PRIMARY KEY (`nrosocio`),
  ADD KEY `fk_socio_usuario` (`idusuario`);

--
-- Indices de la tabla `socio_actividad`
--
ALTER TABLE `socio_actividad`
  ADD PRIMARY KEY (`idinscripcion`),
  ADD UNIQUE KEY `uk_socio_actividad` (`nrosocio`,`idactividad`),
  ADD KEY `idactividad` (`idactividad`);

--
-- Indices de la tabla `usuario`
--
ALTER TABLE `usuario`
  ADD PRIMARY KEY (`idusuario`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `actividad`
--
ALTER TABLE `actividad`
  MODIFY `idactividad` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `credencial`
--
ALTER TABLE `credencial`
  MODIFY `codusu` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT de la tabla `cuota`
--
ALTER TABLE `cuota`
  MODIFY `idcuota` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT de la tabla `nosocio`
--
ALTER TABLE `nosocio`
  MODIFY `nronosocio` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT de la tabla `nosocio_actividad`
--
ALTER TABLE `nosocio_actividad`
  MODIFY `idinscripcion` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `socio`
--
ALTER TABLE `socio`
  MODIFY `nrosocio` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT de la tabla `socio_actividad`
--
ALTER TABLE `socio_actividad`
  MODIFY `idinscripcion` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `usuario`
--
ALTER TABLE `usuario`
  MODIFY `idusuario` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `credencial`
--
ALTER TABLE `credencial`
  ADD CONSTRAINT `fk_credencial_rol` FOREIGN KEY (`rolusu`) REFERENCES `roles` (`rolusu`);

--
-- Filtros para la tabla `cuota`
--
ALTER TABLE `cuota`
  ADD CONSTRAINT `fk_cuota_socio` FOREIGN KEY (`nrosocio`) REFERENCES `socio` (`nrosocio`);

--
-- Filtros para la tabla `nosocio`
--
ALTER TABLE `nosocio`
  ADD CONSTRAINT `fk_nosocio_usuario` FOREIGN KEY (`idusuario`) REFERENCES `usuario` (`idusuario`);

--
-- Filtros para la tabla `nosocio_actividad`
--
ALTER TABLE `nosocio_actividad`
  ADD CONSTRAINT `nosocio_actividad_ibfk_1` FOREIGN KEY (`nronosocio`) REFERENCES `nosocio` (`nronosocio`),
  ADD CONSTRAINT `nosocio_actividad_ibfk_2` FOREIGN KEY (`idactividad`) REFERENCES `actividad` (`idactividad`);

--
-- Filtros para la tabla `socio`
--
ALTER TABLE `socio`
  ADD CONSTRAINT `fk_socio_usuario` FOREIGN KEY (`idusuario`) REFERENCES `usuario` (`idusuario`);

--
-- Filtros para la tabla `socio_actividad`
--
ALTER TABLE `socio_actividad`
  ADD CONSTRAINT `socio_actividad_ibfk_1` FOREIGN KEY (`nrosocio`) REFERENCES `socio` (`nrosocio`),
  ADD CONSTRAINT `socio_actividad_ibfk_2` FOREIGN KEY (`idactividad`) REFERENCES `actividad` (`idactividad`);
--

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