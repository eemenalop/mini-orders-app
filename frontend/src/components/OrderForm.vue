<script setup lang="ts">
import { ref } from 'vue';
import { useOrderStore } from '@/stores/orderStore';

const store = useOrderStore();

const customerName = ref('');
const totalAmount = ref(0);
const error = ref<string | null>(null);

async function handleSubmit() {
  error.value = null;
  try {
    await store.createOrder({ 
      customerName: customerName.value, 
      totalAmount: totalAmount.value 
    });
    customerName.value = '';
    totalAmount.value = 0;
  } catch (err) {
    error.value = (err as Error).message;
  }
}
</script>

<template>
  <div>
    <h2 class="text-2xl font-bold mb-4">Crear Nueva Orden</h2>
    <form @submit.prevent="handleSubmit" class="p-4 bg-slate-800 rounded-lg shadow-md">
      <div class="mb-4">
        <label for="name" class="block mb-1 font-medium">Nombre del Cliente</label>
        <input v-model="customerName" type="text" id="name" class="w-full p-2 rounded bg-slate-700 border border-slate-600 focus:outline-none focus:ring-2 focus:ring-cyan-500"/>
      </div>
      <div class="mb-4">
        <label for="total" class="block mb-1 font-medium">Monto Total</label>
        <input v-model.number="totalAmount" type="number" id="total" step="0.01" class="w-full p-2 rounded bg-slate-700 border border-slate-600 focus:outline-none focus:ring-2 focus:ring-cyan-500"/>
      </div>
      <div v-if="error" class="text-red-500 mb-2 text-sm">{{ error }}</div>
      <button type="submit" :disabled="store.isLoading" class="w-full bg-cyan-600 hover:bg-cyan-700 text-white font-bold py-2 px-4 rounded transition-colors disabled:bg-slate-600">
        {{ store.isLoading ? 'Guardando...' : 'Guardar Orden' }}
      </button>
    </form>
  </div>
</template>