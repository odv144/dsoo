SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;
CREATE DATABASE IF NOT EXISTS `proyecto2`;
USE `proyecto2`;
-- ----------------------------
-- Table structure for roles
-- ----------------------------
DROP TABLE IF EXISTS `roles`;
CREATE TABLE `roles`  (
  `RolUsu` int NOT NULL,
  `NomRol` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  PRIMARY KEY (`RolUsu`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of roles
-- ----------------------------
INSERT INTO `roles` VALUES (1, 'Administrador');
INSERT INTO `roles` VALUES (2, 'Empleado');

-- ----------------------------
-- Table structure for usuario
-- ----------------------------
DROP TABLE IF EXISTS `usuario`;
CREATE TABLE `usuario`  (
  `CodUsu` int NOT NULL AUTO_INCREMENT,
  `NombreUsu` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `PassUsu` varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `RolUsu` int NULL DEFAULT NULL,
  `Activo` tinyint(1) NULL DEFAULT 1,
  PRIMARY KEY (`CodUsu`) USING BTREE,
  INDEX `fk_usuario`(`RolUsu` ASC) USING BTREE,
  CONSTRAINT `fk_usuario` FOREIGN KEY (`RolUsu`) REFERENCES `roles` (`RolUsu`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 2 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of usuario
-- ----------------------------
INSERT INTO `usuario` VALUES (1, 'Omar2025', '1234', 1, 1);

-- ----------------------------
-- Procedure structure for IngresoLogin
-- ----------------------------
DROP PROCEDURE IF EXISTS `IngresoLogin`;
delimiter ;;
CREATE PROCEDURE `IngresoLogin`(in Usu varchar(20),in Pass varchar(15))
BEGIN
select NomRol
	from usuario u inner join roles r on u.RolUsu = r.RolUsu
		where NombreUsu = Usu and PassUsu = Pass /* se compara con los parametros */
			and Activo = 1; /* el usuario debe estar activo */

END
;;
delimiter ;

SET FOREIGN_KEY_CHECKS = 1;
