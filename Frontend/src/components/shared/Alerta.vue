<template>
  <div v-bind:class="this.tipo">
    <div class="titulo">
      <div>
        <strong>{{ this.tipo }}</strong>
      </div>
    </div>
    <div class="mensagem">
      Lorem ipsum dolor sit amet consectetur adipisicing elit. Enim corporis
      saepe et. Ex recusandae culpa aliquam fuga tempora nostrum incidunt,
      deleniti.
    </div>
  </div>
</template>

<script>
export default {
  props: {
    tipo: {
      type: String,
      required: true,
    },
  },
};
</script>

<style scoped>
.titulo {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: flex-start;
  font-size: larger;
  font-weight: bold;
  padding: 15px;
}
.mensagem {
  padding-left: 15px;
  padding-right: 15px;
  padding-bottom: 15px;
  font-weight: lighter;
}
.info {
  background-color: #39b98e;
  color: rgba(240, 255, 244, 0.795);
  width: 350px;
  height: 150px;
  border-radius: 8px;
  box-shadow: 1px 1px 2px rgba(0, 0, 0, 0.4);
  margin: 20px;
}
.erro {
  background-color: #d35252;
  color: rgba(233, 236, 217, 0.952);
  width: 350px;
  height: 150px;
  border-radius: 8px;
  box-shadow: 1px 1px 2px rgba(0, 0, 0, 0.4);
  margin: 20px;
}
</style>