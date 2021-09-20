import axios from 'axios';
import ambiente from './constantes';
import Vue from 'vue';
import Vuex from 'vuex';

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    musicas: [],
    autores: [],
    alerta:{
      tipo:"erro",
      descricao:"",
      visivel:false
    }
  },
  getters: {
    getMusicas(state) {
      return state.musicas;
    },
    getAutores(state) {
      return state.autores;
    },
    getAlerta(state){
      return state.alerta;
    }
  },
  mutations: {
    setMusicas(state, value) {
      state.musicas = value;
    },
    setAutores(state, value) {
      state.autores = value;
    },
    adicionarAutor(state, value){
      state.autores.push(value);
    },
    setTipoAlerta(state, value){
      state.alerta.tipo = value;
    },
    setDescricaoAlerta(state,value){
      state.alerta.descricao = value;
    },
    setVisibilidadeAlerta(state,value){
      state.alerta.visivel = value;
    }
  },
  actions: {

    //Alerta
    configurarAlerta(state,tipo,descricao){
      state.commit("setTipoAlerta",tipo);
      state.commit("setDescricaoAlerta",descricao);
    },
    async exibirAlerta(state){
      state.commit("setVisibilidadeAlerta",true);
      setTimeout(function(){
        state.commit("setVisibilidadeAlerta",false);
        state.commit("setTipoAlerta","");
        state.commit("setDescricaoAlerta","");
      },5000);
      
    },

    //Musicas
    requestListaDeMusicas(state) {
      axios.get(ambiente.SERVER_URL+"/musicas")
        .then(function (response) {
          state.commit("setMusicas", response.data)
        })
        .catch(function (error) {
          console.log(error.response.data);
        });
    },
    
    //Videos
    requestListaDeAutores(state) {
      axios.get(ambiente.SERVER_URL+"/autores")
        .then(function (response) {
          state.commit("setAutores", response.data)
        })
        .catch(function (error) {
          console.log(error.response.data);
        });
      }
    }
  })
