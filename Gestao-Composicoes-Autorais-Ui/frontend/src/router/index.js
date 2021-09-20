import Vue from 'vue'
import VueRouter from 'vue-router'
import Listagem from '../views/Listagem.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Listagem',
    component: Listagem
  },
  {
    path: '/cadastro',
    name: 'Cadastro',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/Cadastro.vue')
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
