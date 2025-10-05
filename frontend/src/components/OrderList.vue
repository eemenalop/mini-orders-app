<script setup lang="ts">
import { onMounted } from 'vue';
import { useOrderStore } from '@/stores/orderStore';
const store = useOrderStore();
onMounted(() => {
  store.fetchOrders();
});
</script>

<template>
  <div class="mt-8">
    <h2 class="text-2xl font-bold mb-4">Órdenes Recientes</h2>

    <div v-if="store.isLoading" class="text-center">Cargando...</div>

    <div v-else-if="store.error" class="p-4 bg-red-900 text-red-200 rounded-lg">{{ store.error }}</div>

    <table v-else-if="store.orders.length > 0" class="w-full text-left table-auto">
      <thead>
        <tr class="bg-slate-800">
          <th class="p-2">Cliente</th>
          <th class="p-2">Fecha</th>
          <th class="p-2 text-right">Total</th>
          <th class="p-2">Acciones</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="order in store.orders" :key="order.id" class="border-b border-slate-800">
          <td class="p-2">{{ order.customerName }}</td>
          <td class="p-2">{{ new Date(order.orderDate).toLocaleDateString() }}</td>
          <td class="p-2 text-right">${{ order.totalAmount.toFixed(2) }}</td>
          <td class="p-2">
            <button @click="store.deleteOrder(order.id)" class="text-red-500 hover:text-red-400">Eliminar</button>
          </td>
        </tr>
      </tbody>
    </table>

    <div v-else class="p-4 bg-slate-800 rounded-lg text-center">No hay órdenes para mostrar.</div>
  </div>
</template>