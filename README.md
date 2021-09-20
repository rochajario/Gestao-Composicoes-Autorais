## Gestão de Direitos Autorais
### Visão Geral - Aplicação Back-End
Desenvolvido com linguagem C# e Entity Framework Core com o mínimo possível de comentários prezando por um código limpo e de fácil compreensão.
Observando as seguintes premissas:

 - Padrões Arquiteturais:
	 - **SOLID**;
	 - Desenvolvimento Orientado à Testes (**TDD**);
	 - **GoF** Pattern *'Strategy'*;
	 - **GoF** Pattern *'Decorator'*;
	 - **Gof** Pattern *'Template Method'*;

### Modelagem de Dados
IMAGEM_AQUI

##### Script Data Definition Language (DDL)

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

##### Consumindo relacionamento entre tabelas Musicas e Autores manualmente:
*Comando SQL que realiza Seleção de Autores à partir da tabela de junção obtendo apenas aqueles que estão relacionados com id de uma música em específico.*

    SELECT autores.Id, autores.Nome, autores.Categoria FROM autores INNER JOIN autormusica ON autores.Id = autormusica.AutoresID WHERE autormusica.Musicasid =<'id_da_musica'>;

##### Desenvolvido por
Jario Rocha dos Santos Junior - 2021 
https://www.linkedin.com/in/rochajario/
rochajario@gmail.com
##### Licença MIT.