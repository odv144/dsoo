CREATE DATABASE  IF NOT EXISTS `proyecto` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `proyecto`;
-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: proyecto
-- ------------------------------------------------------
-- Server version	8.1.0

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `actividad`
--

DROP TABLE IF EXISTS `actividad`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `actividad` (
  `idactividad` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) DEFAULT NULL,
  `descripcion` varchar(60) DEFAULT NULL,
  `tarifasocio` double DEFAULT NULL,
  `tarifanosocio` double DEFAULT NULL,
  `cupomaximo` int DEFAULT NULL,
  `turno` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`idactividad`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;
INSERT INTO actividad (nombre, descripcion, tarifasocio, tarifanosocio, cupomaximo, turno) VALUES
('Fútbol 5', 'Partidos de fútbol 5 con árbitro', 1500.00, 2500.00, 10, 'Mañana'),
('Natación Adultos', 'Clases de natación para adultos principiantes', 2000.00, 3500.00, 15, 'Tarde'),
('Yoga', 'Sesiones de yoga y meditación', 1800.00, 3000.00, 20, 'Mañana'),
('Tenis', 'Clases de tenis individuales y grupales', 2500.00, 4000.00, 8, 'Tarde'),
('Gimnasio', 'Acceso a sala de musculación y máquinas', 3000.00, 5000.00, 30, 'Noche'),
('Pilates', 'Clases de pilates con instructora certificada', 2200.00, 3800.00, 12, 'Mañana'),
('Paddle', 'Alquiler de cancha de paddle por hora', 1200.00, 2000.00, 4, 'Tarde'),
('Zumba', 'Clases de baile fitness con música latina', 1500.00, 2800.00, 25, 'Noche'),
('Natación Niños', 'Clases de natación para niños de 6 a 12 años', 1800.00, 3200.00, 12, 'Tarde'),
('Básquet', 'Entrenamientos y partidos de básquetbol', 1600.00, 2600.00, 12, 'Noche');
--
-- Dumping data for table `actividad`
--

LOCK TABLES `actividad` WRITE;
/*!40000 ALTER TABLE `actividad` DISABLE KEYS */;
/*!40000 ALTER TABLE `actividad` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `credencial`
--

DROP TABLE IF EXISTS `credencial`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `credencial` (
  `codusu` int NOT NULL AUTO_INCREMENT,
  `nombreusu` varchar(20) DEFAULT NULL,
  `passusu` varchar(15) DEFAULT NULL,
  `rolusu` int DEFAULT NULL,
  `activo` tinyint(1) DEFAULT '1',
  PRIMARY KEY (`codusu`),
  KEY `fk_credencial_rol` (`rolusu`),
  CONSTRAINT `fk_credencial_rol` FOREIGN KEY (`rolusu`) REFERENCES `roles` (`rolusu`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `credencial`
--

LOCK TABLES `credencial` WRITE;
/*!40000 ALTER TABLE `credencial` DISABLE KEYS */;
INSERT INTO `credencial` VALUES (1,'omar','1234',1,1),(2,'cynthia','1234',1,1),(3,'cristian','1234',1,1),(4,'analia','1234',1,1),(5,'jairo','1234',1,1),(6,'admin','1234',1,1);
/*!40000 ALTER TABLE `credencial` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cuota`
--

DROP TABLE IF EXISTS `cuota`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cuota` (
  `idcuota` int NOT NULL AUTO_INCREMENT,
  `nrosocio` int DEFAULT NULL,
  `mes` int DEFAULT NULL,
  `anio` int DEFAULT NULL,
  `monto` double DEFAULT NULL,
  `fechavencimiento` date DEFAULT NULL,
  `fechapago` date DEFAULT NULL,
  `metodopago` varchar(20) DEFAULT NULL,
  `estadopago` tinyint(1) DEFAULT '0',
  PRIMARY KEY (`idcuota`),
  KEY `fk_cuota_socio` (`nrosocio`),
  CONSTRAINT `fk_cuota_socio` FOREIGN KEY (`nrosocio`) REFERENCES `socio` (`nrosocio`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cuota`
--

LOCK TABLES `cuota` WRITE;
/*!40000 ALTER TABLE `cuota` DISABLE KEYS */;
INSERT INTO `cuota` VALUES (1,1,10,2025,5500,'2025-10-20',NULL,'Efectivo',0),(2,2,10,2025,4800,'2025-10-25',NULL,'Transferencia',0),(3,3,10,2025,6000,'2025-10-22',NULL,'Efectivo',0),(4,4,10,2025,7000,'2025-10-18',NULL,'Efectivo',0),(5,5,10,2025,5300,'2025-10-30',NULL,'Transferencia',0),(6,6,10,2025,5900,'2025-10-28',NULL,'Efectivo',0),(7,7,10,2025,6200,'2025-10-15',NULL,'Efectivo',0),(8,8,11,2025,4500,'2025-11-10',NULL,'Efectivo',0),(9,9,11,2025,6800,'2025-11-11',NULL,'Transferencia',0),(10,10,11,2025,4700,'2025-11-12',NULL,'Efectivo',0),(11,11,11,2025,5100,'2025-11-14',NULL,'Efectivo',0),(12,12,11,2025,5600,'2025-11-15',NULL,'Transferencia',0),(13,13,11,2025,4900,'2025-11-16',NULL,'Efectivo',0),(14,14,11,2025,5800,'2025-11-20','2025-11-05','Transferencia',1),(15,15,11,2025,6300,'2025-11-25',NULL,'Efectivo',0),(16,16,11,2025,5200,'2025-11-30',NULL,'Transferencia',0),(17,17,11,2025,5400,'2025-12-02',NULL,'Efectivo',0),(18,18,11,2025,6100,'2025-12-10','2025-11-05','Transferencia',1),(19,19,11,2025,4900,'2025-12-15',NULL,'Efectivo',0),(20,20,11,2025,5600,'2025-12-20','2025-11-06','Efectivo',1);
/*!40000 ALTER TABLE `cuota` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `nosocio`
--

DROP TABLE IF EXISTS `nosocio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `nosocio` (
  `nronosocio` int NOT NULL AUTO_INCREMENT,
  `idusuario` int DEFAULT NULL,
  `observacion` varchar(150) DEFAULT NULL,
  PRIMARY KEY (`nronosocio`),
  KEY `fk_nosocio_usuario` (`idusuario`),
  CONSTRAINT `fk_nosocio_usuario` FOREIGN KEY (`idusuario`) REFERENCES `usuario` (`idusuario`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `nosocio`
--

LOCK TABLES `nosocio` WRITE;
/*!40000 ALTER TABLE `nosocio` DISABLE KEYS */;
INSERT INTO `nosocio` VALUES (1,21,'Participa en natación ocasionalmente'),(2,22,'Clases de spinning mensuales'),(3,23,'Asiste a yoga los fines de semana'),(4,24,'Uso libre del gimnasio'),(5,25,'Participa en torneos de pádel'),(6,26,'Prueba de funcional por un mes'),(7,27,'Inscripto en zumba semanal'),(8,28,'Pilates dos veces por semana'),(9,29,'Clases libres de boxeo'),(10,30,'Uso eventual de canchas');
/*!40000 ALTER TABLE `nosocio` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `nosocio_actividad`
--

DROP TABLE IF EXISTS `nosocio_actividad`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `nosocio_actividad` (
  `idinscripcion` int NOT NULL AUTO_INCREMENT,
  `nronosocio` int NOT NULL,
  `idactividad` int NOT NULL,
  `fechainscripcion` datetime NOT NULL,
  `estado` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`idinscripcion`),
  UNIQUE KEY `uk_nosocio_actividad` (`nronosocio`,`idactividad`),
  KEY `idactividad` (`idactividad`),
  CONSTRAINT `nosocio_actividad_ibfk_1` FOREIGN KEY (`nronosocio`) REFERENCES `nosocio` (`nronosocio`),
  CONSTRAINT `nosocio_actividad_ibfk_2` FOREIGN KEY (`idactividad`) REFERENCES `actividad` (`idactividad`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `nosocio_actividad`
--

LOCK TABLES `nosocio_actividad` WRITE;
/*!40000 ALTER TABLE `nosocio_actividad` DISABLE KEYS */;
/*!40000 ALTER TABLE `nosocio_actividad` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roles`
--

DROP TABLE IF EXISTS `roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `roles` (
  `rolusu` int NOT NULL,
  `nomrol` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`rolusu`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roles`
--

LOCK TABLES `roles` WRITE;
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
INSERT INTO `roles` VALUES (1,'Administrador'),(2,'Empleado');
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `socio`
--

DROP TABLE IF EXISTS `socio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `socio` (
  `nrosocio` int NOT NULL AUTO_INCREMENT,
  `idusuario` int DEFAULT NULL,
  `estadohabilitacion` enum('activo','suspendido','vencido') NOT NULL DEFAULT 'activo',
  `cuotamensual` double DEFAULT NULL,
  `carnetentregado` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`nrosocio`),
  KEY `fk_socio_usuario` (`idusuario`),
  CONSTRAINT `fk_socio_usuario` FOREIGN KEY (`idusuario`) REFERENCES `usuario` (`idusuario`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `socio`
--

LOCK TABLES `socio` WRITE;
/*!40000 ALTER TABLE `socio` DISABLE KEYS */;
INSERT INTO `socio` VALUES (1,1,'activo',5500,1),(2,2,'activo',4800,1),(3,3,'activo',6000,1),(4,4,'activo',7000,1),(5,5,'activo',5300,1),(6,6,'activo',5900,1),(7,7,'activo',6200,1),(8,8,'activo',4500,1),(9,9,'activo',6800,1),(10,10,'activo',4700,1),(11,11,'activo',5100,1),(12,12,'activo',5600,1),(13,13,'activo',4900,1),(14,14,'activo',5800,1),(15,15,'activo',6300,1),(16,16,'activo',5200,1),(17,17,'activo',5400,1),(18,18,'activo',6100,1),(19,19,'activo',4900,1),(20,20,'activo',5600,1);
/*!40000 ALTER TABLE `socio` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `socio_actividad`
--

DROP TABLE IF EXISTS `socio_actividad`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `socio_actividad` (
  `idinscripcion` int NOT NULL AUTO_INCREMENT,
  `nrosocio` int NOT NULL,
  `idactividad` int NOT NULL,
  `fechainscripcion` datetime NOT NULL,
  `estado` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`idinscripcion`),
  UNIQUE KEY `uk_socio_actividad` (`nrosocio`,`idactividad`),
  KEY `idactividad` (`idactividad`),
  CONSTRAINT `socio_actividad_ibfk_1` FOREIGN KEY (`nrosocio`) REFERENCES `socio` (`nrosocio`),
  CONSTRAINT `socio_actividad_ibfk_2` FOREIGN KEY (`idactividad`) REFERENCES `actividad` (`idactividad`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `socio_actividad`
--

LOCK TABLES `socio_actividad` WRITE;
/*!40000 ALTER TABLE `socio_actividad` DISABLE KEYS */;
/*!40000 ALTER TABLE `socio_actividad` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuario` (
  `idusuario` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(20) DEFAULT NULL,
  `apellido` varchar(15) DEFAULT NULL,
  `dni` varchar(8) DEFAULT NULL,
  `telefono` varchar(15) DEFAULT NULL,
  `email` varchar(60) DEFAULT NULL,
  `fecharegistro` date DEFAULT NULL,
  `certificadomedico` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`idusuario`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES (1,'Juan','Pérez','12345678','381111111','juanperez@mail.com','2025-11-01',1),(2,'Ana','Gómez','22345678','381222222','anagomez@mail.com','2025-11-02',1),(3,'Carlos','López','32345678','381333333','carloslopez@mail.com','2025-11-03',0),(4,'Laura','Martínez','42345678','381444444','lauramartinez@mail.com','2025-11-04',1),(5,'Marcos','Rivas','52345678','381555555','marcosrivas@mail.com','2025-11-05',1),(6,'Elena','Torres','62345678','381666666','elenatorres@mail.com','2025-11-06',1),(7,'Diego','Ruiz','72345678','381777777','diegoruiz@mail.com','2025-11-07',0),(8,'Lucía','Fernández','82345678','381888888','luciafernandez@mail.com','2025-11-08',1),(9,'Pablo','Acosta','92345678','381999999','pabloacosta@mail.com','2025-11-09',1),(10,'Sofía','Molina','10345678','381101010','sofiamolina@mail.com','2025-11-10',1),(11,'Andrés','Castro','11345678','381202020','andrescastro@mail.com','2025-11-01',1),(12,'Rosa','Vega','12345679','381303030','rosavega@mail.com','2025-11-02',1),(13,'Jorge','Silva','13345678','381404040','jorgesilva@mail.com','2025-11-03',1),(14,'Camila','Benítez','14345678','381505050','camilabenitez@mail.com','2025-11-04',1),(15,'Tomás','Flores','15345678','381606060','tomasflores@mail.com','2025-11-05',1),(16,'Nadia','Herrera','16345678','381707070','nadiaherrera@mail.com','2025-11-06',1),(17,'Martín','Ortega','17345678','381808080','martinortega@mail.com','2025-11-07',0),(18,'Paula','Navarro','18345678','381909090','paulanavarro@mail.com','2025-11-08',1),(19,'Ignacio','Campos','19345678','381111222','ignaciocampos@mail.com','2025-11-09',1),(20,'Valeria','Suárez','20345678','381222333','valeriasuarez@mail.com','2025-11-10',1),(21,'Luis','Carrizo','30345678','381100000','luiscarrizo@mail.com','2025-11-01',1),(22,'Patricia','Medina','31345678','381200000','patriciamedina@mail.com','2025-11-02',1),(23,'Héctor','Salas','32345679','381300000','hectorsalas@mail.com','2025-11-03',1),(24,'Brenda','Aguilar','33345678','381400000','brendaaguilar@mail.com','2025-11-04',1),(25,'Felipe','Cabrera','34345678','381500000','felipecabrera@mail.com','2025-11-05',1),(26,'Tamara','Juárez','35345678','381600000','tamarajuarez@mail.com','2025-11-06',1),(27,'Santiago','Maidana','36345678','381700000','santiagomaidana@mail.com','2025-11-07',1),(28,'Gabriela','Olivera','37345678','381800000','gabrielaolivera@mail.com','2025-11-08',1),(29,'Matías','Peralta','38345678','381900000','matiasperalta@mail.com','2025-11-09',1),(30,'Florencia','Quiroga','39345678','381999000','florenciaquiroga@mail.com','2025-11-10',1);
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'proyecto'
--
/*!50003 DROP PROCEDURE IF EXISTS `ingresologin` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `ingresologin`(IN usu VARCHAR(20), IN pass VARCHAR(15))
BEGIN
    SELECT nomrol
    FROM credencial c
    INNER JOIN roles r ON c.rolusu = r.rolusu
    WHERE c.nombreusu = usu
      AND c.passusu = pass
      AND c.activo = 1;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-11-09 22:32:13
