<script setup lang="ts">
import { onMounted } from 'vue';
import { useOrderStore } from '@/stores/orderStore';
import { RouterLink } from 'vue-router';

const store = useOrderStore();
onMounted(() => {
  store.fetchOrders();
});
</script>

<template>
  <div>
    <div class="border-b border-white/10 px-4 py-5 sm:px-6">
      <h2 class="text-base font-semibold leading-7 text-white">Recent Orders</h2>
    </div>

    <div v-if="store.isLoading" class="text-center p-10 text-slate-400">Loading...</div>
    <div v-else-if="store.error" class="mt-4 p-4 bg-red-900/50 text-red-300 rounded-lg">
      <strong>Error:</strong> {{ store.error }}
    </div>
    <div v-else-if="store.orders.length === 0" class="mt-4 p-10 text-center text-slate-400 bg-slate-800/50 rounded-b-lg">
      No orders yet. Create the first one!
    </div>

    <ul v-else role="list" class="divide-y divide-white/5">
      <li v-for="order in store.orders" :key="order.id" class="relative flex items-center space-x-4 px-4 py-4 sm:px-6">
        <div class="min-w-0 flex-auto">
          <div class="flex items-center gap-x-3">
            <h2 class="min-w-0 text-sm font-semibold leading-6 text-white">
              {{ order.customerName }}
            </h2>
          </div>
          <div class="mt-3 flex items-center gap-x-2.5 text-xs leading-5 text-slate-400">
            <p>{{ new Date(order.orderDate).toLocaleString() }}</p>
          </div>
        </div>
        <div class="flex flex-col items-end space-y-1">
          <p class="text-lg font-semibold text-cyan-400">${{ order.totalAmount.toFixed(2) }}</p>
          <div class="flex items-center space-x-2">
            <RouterLink :to="`/orders/${order.id}`" class="text-xs text-cyan-400 hover:text-cyan-300">
              View Details
            </RouterLink>
            <span class="text-slate-600">|</span>
            <button @click="store.deleteOrder(order.id)" class="text-xs text-red-500 hover:text-red-400">
              Delete
            </button>
          </div>
        </div>
      </li>
    </ul>
  </div>
</template>