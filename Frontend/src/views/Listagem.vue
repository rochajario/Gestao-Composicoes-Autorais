<template>
  <div class="home">
    <lista-musicas />
  </div>
</template>

<script>
import ListaMusicas from '../components/ListaMusicas.vue';

export default {
  name: "Listagem",
  components: {
    "lista-musicas":ListaMusicas
  }
}
</script>

<style scoped>
.home{
  display: flex;
  flex-direction: column;
  align-items: center;
}
</style>


