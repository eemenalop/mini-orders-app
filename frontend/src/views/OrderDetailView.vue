<script setup lang="ts">
import { useRoute } from 'vue-router';
import { useOrderStore } from '@/stores/orderStore';
import { onMounted } from 'vue';
import { RouterLink } from 'vue-router';

const route = useRoute();
const store = useOrderStore();
const orderId = route.params.id as string;

onMounted(() => {
  store.fetchOrderById(orderId);
});
</script>
<template>
  <div class="bg-slate-900 text-slate-300 min-h-screen font-sans p-4 sm:p-8">
    <div class="container mx-auto max-w-2xl">
      <RouterLink to="/" class="text-cyan-400 hover:text-cyan-300 mb-4 inline-block">&larr; Back to List</RouterLink>

      <div v-if="store.isLoading">Loading...</div>
      <div v-else-if="store.error">{{ store.error }}</div>
      <div v-else-if="store.currentOrder" class="p-6 bg-slate-800 rounded-lg shadow-lg">
        <h1 class="text-3xl font-bold text-white mb-4">{{ store.currentOrder.customerName }}</h1>
        <p><strong class="text-slate-400">Order ID:</strong> {{ store.currentOrder.id }}</p>
        <p><strong class="text-slate-400">Date:</strong> {{ new Date(store.currentOrder.orderDate).toLocaleString() }}</p>
        <p class="mt-4 text-2xl font-semibold text-cyan-400">Total: ${{ store.currentOrder.totalAmount.toFixed(2) }}</p>
      </div>
    </div>
  </div>
</template>