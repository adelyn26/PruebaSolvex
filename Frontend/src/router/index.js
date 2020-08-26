import Vue from 'vue'
import Router from 'vue-router'

import Default from '@/components/Default'
import ExampleIndex from '@/components/example/Index'
import ExampleView from '@/components/example/View'
import ClienteIndex from '@/components/cliente/Index'
import ClienteCreateOrUpdate from '@/components/cliente/CreateOrUpdate'

Vue.use(Router)

const routes = [
  { path: '/', name: 'Default', component: Default },
  { path: '/example', name: 'ExampleIndex', component: ExampleIndex },
  { path: '/example/:id', name: 'ExampleView', component: ExampleView },
  { path: '/cliente', name: 'ClienteIndex', component: ClienteIndex },
  { path: '/cliente/add', name: 'ClienteCreate', component: ClienteCreateOrUpdate },
  { path: '/cliente/:id/edit', name: 'ClienteEdit', component: ClienteCreateOrUpdate },
]

export default new Router({
  routes
})
