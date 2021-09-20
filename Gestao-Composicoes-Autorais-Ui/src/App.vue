<template>
  <div id="app">
    <div id="nav">
      <router-link to="/">Listagem</router-link> |
      <router-link to="/cadastro">Cadastro</router-link>
    </div>
    <div class="view-container">
      <router-view />
    </div>
  </div>
</template>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

#nav {
  padding: 30px;
}

#nav a {
  font-weight: bold;
  color: #2c3e50;
}

#nav a.router-link-exact-active {
  color: #42b983;
}
.view-container{
  display: flex;
  flex-direction: row;
  justify-content: center;
  flex-wrap: nowrap;
}

button{
  margin-top: 15px;
  margin-bottom: 5px;
  padding: 5px;
}

input,
select {
  padding: 5px;
  border-radius: 5px;
  margin: 5px;
}
input {
  width: 250px;
}
select {
  width: 262px;
}

.tabela-multicor table {
  border-collapse:collapse;
  border: transparent;
  text-align: center;
}

.tabela-multicor th,
td {
  text-align: center;
  border: none;
  text-align: center;
  padding: 8px;
}

.tabela-multicor tr:nth-child(even) {
  background-color: #dddddd;
}

fieldset{
  border-radius: 10px;
  min-width: 400px;
  min-height: 200px;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
}

legend{
  font-weight: bolder;
  font-size: larger;
}
</style>
