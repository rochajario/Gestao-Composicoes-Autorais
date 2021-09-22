## Gestão de Direitos Autorais
### Tabela de Conteúdos

 1. [Visão Geral](#overview)
 2. [Execução do Projeto](#passos-de-execucao-do-projeto)
 4. [Desenvolvedor](#desenvolvido-por)

### Overview
Desenvolvido com linguagem Javascript e Vue.js utilizando os plugins:

 - Plugins:
	 - vuex;
	 - axios;

### Executando em Ambiente Local

Este projeto está configurado atualmente para consumir uma [API-Backend](https://composicoes-autorais-api.herokuapp.com/swagger/index.html) publicada para demonstração.
Caso opte-se por executar localmente a API, será necessário realizar os passos de configuração indicados na sessão ['Executando em Ambiente Local'](https://github.com/rochajario/Gestao-Composicoes-Autorais/tree/main/Gestao-Composicoes-Autorais-Api) do projeto de Backend.
Também será necessário alterar o arquivo *Gestao-Composicoes-Autorais/Gestao-Composicoes-Autorais-Ui/src/store/constantes.js* da seguinte maneira:

```javascript
const  ambiente={
  SERVER_URL:"https://localhost:5001",
};
export  default  ambiente;
```

Obs.: Prefira executar o projeto pelo próprio binário localmente.
Caso opte-se por verificar o funcionamento da aplicação através da API préviamente publicada os passos à baixo devem ser suficientes.
### Passos de Execucao do Projeto
##### Instalar
```
npm install
```
##### Complilar em Ambiente de Desenvolvimento
```
npm run serve
```
##### Compilar para para Ambiente Produtivo
```
npm run build
```
##### Lints
```
npm run lint
```

### Desenvolvido por:
Jario Rocha dos Santos Junior - 2021  
[![Linkedin Badge](https://img.shields.io/badge/-rochajario-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/rochajario/?locale=en_US)](https://www.linkedin.com/in/rochajario/) [![Gmail Badge](https://img.shields.io/badge/-rochajario-c14438?style=flat-square&logo=Gmail&logoColor=white&link=mailto:rochajario@gmail.com)](mailto:rochajario@gmail.com)
##### Licença MIT.
