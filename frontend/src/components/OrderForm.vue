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
  <div class="sticky top-8">
    <div class="border-b border-white/10 px-4 py-5 sm:px-6">
      <h2 class="text-base font-semibold leading-7 text-white">Crear Nueva Orden</h2>
    </div>

    <form @submit.prevent="handleSubmit" class="p-6 bg-slate-800/50 rounded-b-lg shadow-lg space-y-4">
      <div>
        <label for="name" class="block text-sm font-medium leading-6 text-slate-400">Nombre del Cliente</label>
        <div class="mt-2">
          <input v-model="customerName" type="text" id="name" placeholder="Ej: John Doe" class="block w-full rounded-md border-0 bg-white/5 py-1.5 px-3 text-white shadow-sm ring-1 ring-inset ring-white/10 focus:ring-2 focus:ring-inset focus:ring-cyan-500 sm:text-sm sm:leading-6" />
        </div>
      </div>
      <div>
        <label for="total" class="block text-sm font-medium leading-6 text-slate-400">Monto Total</label>
        <div class="mt-2">
          <input v-model.number="totalAmount" type="number" id="total" step="0.01" class="block w-full rounded-md border-0 bg-white/5 py-1.5 px-3 text-white shadow-sm ring-1 ring-inset ring-white/10 focus:ring-2 focus:ring-inset focus:ring-cyan-500 sm:text-sm sm:leading-6" />
        </div>
      </div>
      
      <div v-if="error" class="text-red-400 text-sm pt-2">{{ error }}</div>
      
      <div class="pt-4">
        <button type="submit" :disabled="store.isLoading" class="w-full rounded-md bg-cyan-600 px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-cyan-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-cyan-600 disabled:bg-slate-700 disabled:cursor-not-allowed">
          {{ store.isLoading ? 'Guardando...' : 'Guardar Orden' }}
        </button>
      </div>
    </form>
  </div>
</template>