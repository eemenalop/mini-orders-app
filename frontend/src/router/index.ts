import { createRouter, createWebHistory } from 'vue-router'
import OrdersListView from '@/views/OrdersListView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'orders',
      component: OrdersListView
    }
  ]
})

export default router
