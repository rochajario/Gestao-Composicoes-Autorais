<template>
  <div>
    <div v-if="this.getAutores.length > 0">
      <div class="nova-musica">
        <table>
          <tr>
            <th>Nome da Música</th>
            <td>
              <input
                type="text"
                placeholder="Nome"
                v-model="musica.nome"
                v-on:input="this.setMusica"
              />
            </td>
          </tr>
          <tr>
            <th>Gênero Musical</th>
            <td>
              <select v-model="musica.genero" v-on:change="this.setMusica">
                <option value="rock">Rock</option>
                <option value="sertanejo">Sertanejo</option>
                <option value="gospel">Gospel</option>
                <option value="pop">Pop</option>
                <option value="rap">Rap</option>
                <option value="eletronica">Eletrônica</option>
              </select>
            </td>
          </tr>
          <tr>
            <th>Autores</th>
            <td>
              <input type="text" placeholder="Pesquisar por Nome" />
            </td>
          </tr>
        </table>
      </div>
      <div>
        <table style="width: 100%" class="tabela-multicor">
          <tr class="tabela-multicor">
            <th class="tabela-multicor">Seleção</th>
            <th class="tabela-multicor">Código</th>
            <th class="tabela-multicor">Nome</th>
            <th class="tabela-multicor">Categoria Autoral</th>
            <th class="tabela-multicor">Opções</th>
          </tr>
          <tr
            v-for="autor in this.getAutores"
            :key="autor.codAutor"
            class="tabela-multicor"
          >
            <td class="tabela-multicor">
              <span
                ><input
                  type="checkbox"
                  v-bind:id="autor.codAutor"
                  v-bind:value="autor.codAutor"
                  style="width: 20px"
              /></span>
            </td>

            <td>
              <span>{{ autor.codAutor }}</span>
            </td>
            <td>
              <span>{{ autor.nome }}</span>
            </td>
            <td>
              <span>{{ autor.categoria }}</span>
            </td>
            <td>
              <a @click="removerAutor(autor.codAutor)">Apagar</a>
            </td>
          </tr>
        </table>
        <div>
          <button @click="enviarFormulario()">Editar</button>
        </div>
      </div>
    </div>
    <div v-else>
      <em
        >Para Editar Músicas é Necessário que hajam autores Pré Cadastrados</em
      >
    </div>
  </div>
</template>

<script>
import { mapActions, mapGetters } from "vuex";
import axios from "axios";
import ambiente from "../store/constantes";

export default {
  props: {
    musica: {
      type: Object,
      required: true,
    },
  },
  methods: {
    ObterIdsDeAutores() {
      var array = [];
      var checkboxes = document.querySelectorAll(
        "input[type=checkbox]:checked"
      );

      for (var i = 0; i < checkboxes.length; i++) {
        array.push(parseInt(checkboxes[i].value));
      }

      return array;
    },
    setMusica() {
      this.musica.codAutores = this.ObterIdsDeAutores();
    },
    enviarFormulario() {
      this.setMusica();
      axios
        .put(
          ambiente.SERVER_URL+"/musicas/" + this.musica.codMusica,
          this.musica
        )
        .then(function () {
          window.alert("Música Editada com Sucesso!");
        })
        .catch(function (erro) {
          window.alert(erro.response.data.erro);
        });
    },
    removerAutor(codAutor) {
      axios
        .delete(ambiente.SERVER_URL+"/autores/" + codAutor)
        .then(function () {
          window.alert("Autor deletado com sucesso!");
        })
        .catch(function (res) {
          window.alert(res.response.data.erro);
        });
    },
  },
  computed: {
    ...mapGetters({
      getAutores: "getAutores",
    }),
    ...mapActions({
      requestListaDeAutores: "requestListaDeAutores",
    }),
  },
};
</script>

<style scoped>
.nova-musica {
  display: flex;
  flex-direction: column;
  align-items: center;
}
.nova-musica table {
  text-align: left;
}
.nova-musica th,
td {
  border: transparent;
  border-radius: 5px;
  text-align: left;
  padding: 8px;
  font-size: 10pt;
  align-self: center;
  width: inherit;
}

.nova-musica tr:nth-child(even) {
  background-color: transparent;
}
</style>