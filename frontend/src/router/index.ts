import { createRouter, createWebHistory } from 'vue-router'
import OrdersListView from '@/views/OrdersListView.vue'
import OrderCreateView from '@/views/OrderCreateView.vue'
import OrderDetailView from '@/views/OrderDetailView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'orders-list',
      component: OrdersListView
    },
    {
      path: '/orders/new',
      name: 'order-create',
      component: OrderCreateView
    },
    {
      path: '/orders/:id',
      name: 'order-details',
      component: OrderDetailView
    }
  ]
})

export default router
