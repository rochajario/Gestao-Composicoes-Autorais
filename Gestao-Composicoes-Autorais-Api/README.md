## Gestão de Direitos Autorais
### Tabela de Conteúdos

 1. [Visão Geral](#overview)
 2. [Modelagem de Dados](#modelagem-de-dados)
 3. [Executando em Ambiente Local](#executando-em-ambiente-local)
 4. [Desenvolvedor](#desenvolvido-por)

### Overview
Desenvolvido com linguagem C# e Entity Framework Core com o mínimo possível de comentários prezando por um código limpo e de fácil compreensão.
Observando as seguintes premissas:

 - Padrões Arquiteturais:
	 - **SOLID**;
	 - Desenvolvimento Orientado à Testes (**TDD**);
	 - **GoF** Pattern *'Strategy'*;
	 - **GoF** Pattern *'Decorator'*;
	 - **Gof** Pattern *'Template Method'*;

### Modelagem de Dados
![Diagrama-ER](https://user-images.githubusercontent.com/56648231/134039582-d135ffbf-d108-470a-b17f-03809c60d233.PNG)

##### Script Data Definition Language
```sql
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
```
##### Consumindo relacionamento entre tabelas Musicas e Autores manualmente:
*Comando SQL que realiza Seleção de Autores à partir da tabela de junção obtendo apenas aqueles que estão relacionados com id de uma música em específico.*
```sql
    SELECT autores.Id, autores.Nome, autores.Categoria FROM autores INNER JOIN autormusica ON autores.Id = autormusica.AutoresID WHERE autormusica.Musicasid =<'id_da_musica'>;
```

### Executando em Ambiente Local
Pré requisito:

 - Possuir na máquina local o serviço do MySql na versão 8.15 ou maior

Após baixar o conteúdo do repositório é necessário configurar o acesso ao banco de dados através do arquivo:
> Gestao-Composicoes-Autorais/Gestao-Composicoes-Autorais-Api/Gestao-Composicoes-Autorais-Src/launchSettings.json
```json
    "Docker": {
        "commandName": "Docker",
    	"launchBrowser": true,
    	"launchUrl": "{Scheme}://{ServiceHost}:{ServicePort}/swagger",
    	"publishAllPorts": true,
    	"useSSL": true,
    	"environmentVariables": {
		    "DB_CONNECTION_STRING": "server=<endereço-do-seu-host>;user=<seu-usuario>;password=<sua-senha>;database=<sua-base-de-dados>",
			"ASPNETCORE_ENVIRONMENT": "Development"
		}
    }
 ```       
Após preparar o arquivo com as definições de variáveis locais necessárias para que o Docker seja capaz de identificar sua base de dados será necessário executar o [Script DDL](#script-data-definition-language) documentado na seção [Modelagem de Dados](#modelagem-de-dados)

Realizados os passos acima a aplicação está preparada para ser iniciada.
Navegue até a pasta no caminho à baixo e Inicialize o container pelo arquivo Dockerfile.

> Gestao-Composicoes-Autorais/Gestao-Composicoes-Autorais-Api/


### Desenvolvido por:
Jario Rocha dos Santos Junior - 2021  
https://www.linkedin.com/in/rochajario/  
rochajario@gmail.com  
##### Licença MIT.
