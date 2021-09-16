CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `Autores` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Nome` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Categoria` longtext CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_Autores` PRIMARY KEY (`Id`)
) CHARACTER SET utf8mb4;

CREATE TABLE `Musicas` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Nome` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Genero` longtext CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_Musicas` PRIMARY KEY (`Id`)
) CHARACTER SET utf8mb4;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20210916021759_Mysql_Configuration', '5.0.10');

COMMIT;

