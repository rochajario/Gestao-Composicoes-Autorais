<template>
  <fieldset>
    <legend align="center">Músicas Cadastradas</legend>
    <div v-if="this.getMusicas.length == 0">
      <loader />
    </div>
    <div v-else>
      <table class="tabela-multicor">
        <tr>
          <th>Código</th>
          <th>Musica</th>
          <th>Gênero Musical</th>
          <th>Autores</th>
          <th>Opções</th>
        </tr>
        <tr v-for="musica in this.getMusicas" :key="musica.codMusica">
          <td>{{ musica.codMusica }}</td>
          <td>{{ musica.nome }}</td>
          <td>{{ musica.genero }}</td>
          <td class="autores">
            <span v-for="autor in musica.autores" :key="autor.codAutor">
              <strong>{{ autor.categoria }}:</strong> cod:
              {{ autor.codAutor }} | {{ autor.nome }}<br />
            </span>
          </td>
          <td>
            Editar |
            <a @click="deletaMusica(musica.codMusica)">Apagar</a>
          </td>
        </tr>
      </table>
    </div>
  </fieldset>
</template>

<script>
import ambiente from "../store/constantes";
import axios from "axios";
import Loader from "./shared/Loader.vue";
import { mapGetters, mapActions } from "vuex";

export default {
  name: "ListaMusicas",
  components: {
    loader: Loader,
  },
  computed: {
    ...mapGetters({
      getMusicas: "getMusicas",
    }),
    ...mapActions({
      requestListaDeMusicas: "requestListaDeMusicas",
    }),
  },
  methods: {
    deletaMusica(codMusica) {
      axios
        .delete(ambiente.SERVER_URL+"/musicas/" + codMusica)
        .then(function () {
          window.alert("Música Removida com sucesso!");
          this.requestListaDeMusicas;
        })
        .catch(function (erro) {
          window.alert(erro.response.data.erro);
        });
    },
  },
  mounted() {
    this.requestListaDeMusicas;
  },
};
</script>

<style scoped>
.autores {
  text-align: left;
  font-size: 8pt;
}
</style>