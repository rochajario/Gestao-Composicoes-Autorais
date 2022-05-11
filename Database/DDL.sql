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
    
    CREATE TABLE `AutorMusica` (
        `AutoresId` bigint NOT NULL,
        `MusicasId` bigint NOT NULL,
        CONSTRAINT `PK_AutorMusica` PRIMARY KEY (`AutoresId`, `MusicasId`),
        CONSTRAINT `FK_AutorMusica_Autores_AutoresId` FOREIGN KEY (`AutoresId`) REFERENCES `Autores` (`Id`) ON DELETE CASCADE,
        CONSTRAINT `FK_AutorMusica_Musicas_MusicasId` FOREIGN KEY (`MusicasId`) REFERENCES `Musicas` (`Id`) ON DELETE CASCADE
    ) CHARACTER SET utf8mb4;
    
    CREATE INDEX `IX_AutorMusica_MusicasId` ON `AutorMusica` (`MusicasId`);
    
    COMMIT;