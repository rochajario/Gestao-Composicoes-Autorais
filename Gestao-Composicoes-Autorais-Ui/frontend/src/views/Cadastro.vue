<template>
  <div class="container-horizontal">
    <div class="container-vertical">
      <div class="cadastro">
        <fieldset>
          <legend align="center">
            <a @click="this.toggleFeature">Nova Música </a>|
            <a @click="this.toggleFeature">Novo Autor</a>
          </legend>
          <cadastro-musica v-if="this.visibilidade.musica" />
          <cadastro-autor v-if="this.visibilidade.autor" />
          <edicao-musica :musica="this.musica" />
        </fieldset>
      </div>
    </div>
  </div>
</template>
<script>
import CadastroMusica from "../components/CadastroMusica.vue";
import CadastroAutor from "../components/CadastroAutor.vue";
import EdicaoMusica from "../components/EdicaoMusica.vue";

import { mapGetters, mapActions } from "vuex";

export default {
  components: {
    "cadastro-musica": CadastroMusica,
    "cadastro-autor": CadastroAutor,
    "edicao-musica": EdicaoMusica
  },
  data() {
    return {
      visibilidade: {
        musica: true,
        autor: false,
      },
      edicaoMusica: {},
    };
  },
  methods: {
    toggleFeature() {
      this.visibilidade.musica = !this.visibilidade.musica;
      this.visibilidade.autor = !this.visibilidade.autor;
    },
    configuraMusicaParaEdicao(musica){
      this.edicaoMusica = musica;
      console.log(this.edicaoMusica);
    }
  },
  computed: {
    ...mapActions({
      requestListaDeAutores: "requestListaDeAutores",
    }),
    ...mapGetters({
      getAlerta: "getAlerta",
    }),
  },
  mounted() {
    this.requestListaDeAutores;
  },
};
</script>

<style scoped>
.container-horizontal {
  display: flex;
  flex-direction: row;
  flex-wrap: nowrap;
}
.container-vertical {
  display: flex;
  flex-direction: column;
  flex-wrap: wrap;
  align-items: center;
}
.cadastro {
  width: 300px;
  display: flex;
  flex-direction: column;
  align-items: center;
}
fieldset {
  width: 450px;
}
</style>