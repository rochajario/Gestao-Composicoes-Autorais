<template>
  <div class="novo-autor">
    <table>
      <tr>
        <th>Nome do Autor</th>
        <td><input type="text" placeholder="Nome" v-model="autor.nome" /></td>
      </tr>
      <tr>
        <th>Categoria Autoral</th>
        <td>
          <select v-model="autor.categoria">
            <option value="autor">Autor</option>
            <option value="compositor">Compositor</option>
            <option value="interprete">Intérprete</option>
            <option value="musicista">Musicista</option>
          </select>
        </td>
      </tr>
    </table>
    <div>
      <button @click="cadastrarNovoAutor()">Cadastrar</button>
    </div>
  </div>
</template>

<script>
import axios from "axios";

export default {
  data() {
    return {
      autor: {
        nome: "",
        categoria: "",
      },
    };
  },
  methods: {
    cadastrarNovoAutor() {
      axios
        .post("https://localhost:5001/autores", this.autor)
        .then(function (response) {
          this.$store.commit("adicionarAutor", response.data);
          window.alert("Autor "+response.data.nome+" adicionado com sucesso!");
        })
        .catch(function () {
          window.alert("Falha ao adicionar autor");
        });
    },
  }
};
</script>

<style scoped>
.novo-autor {
  display: flex;
  flex-direction: column;
  align-items: center;
}
.novo-autor th,
td {
  border: transparent;
  border-radius: 5px;
  text-align: left;
  padding: 8px;
  font-size: 10pt;
  align-self: center;
  width: inherit;
}

.novo-autor tr:nth-child(even) {
  background-color: transparent;
}
</style>