<script setup lang="ts">
import { ref } from 'vue';
import { useOrderStore } from '@/stores/orderStore';
import { CreateOrderSchema } from '@/schemas/orderSchemas';
import { useToast } from "vue-toastification";
import router from '@/router';

const store = useOrderStore();
const toast = useToast();
const customerName = ref('');
const totalAmount = ref(0);
const error = ref<string | null>(null);

async function handleSubmit() {
  error.value = null;
  const result = CreateOrderSchema.safeParse({
    customerName: customerName.value,
    totalAmount: totalAmount.value,
  });
  if (!result.success) {
    error.value = result.error.issues[0]?.message ?? 'Invalid input';
    return;
  }
  try {
    await store.createOrder(result.data);
    toast.success("Order created successfully!");
    router.push('/');
    customerName.value = '';
    totalAmount.value = 0;
  } catch (err) {
    error.value = (err as Error).message;
  }
}
</script>

<template>
  <div>
    <div class="border-b border-white/10 px-4 py-5 sm:px-6">
      <h2 class="text-base font-semibold leading-7 text-white">Create New Order</h2>
    </div>

    <form @submit.prevent="handleSubmit" class="p-6 bg-slate-800/50 rounded-b-lg shadow-lg space-y-4">
      <div>
        <label for="name" class="block text-sm font-medium leading-6 text-slate-400">Customer Name</label>
        <div class="mt-2">
          <input v-model="customerName" type="text" id="name" placeholder="Ej: John Doe" class="block w-full rounded-md border-0 bg-white/5 py-1.5 px-3 text-white shadow-sm ring-1 ring-inset ring-white/10 focus:ring-2 focus:ring-inset focus:ring-cyan-500 sm:text-sm sm:leading-6" />
        </div>
      </div>
      <div>
        <label for="total" class="block text-sm font-medium leading-6 text-slate-400">Total Amount</label>
        <div class="mt-2">
          <input v-model.number="totalAmount" type="number" id="total" step="0.01" class="block w-full rounded-md border-0 bg-white/5 py-1.5 px-3 text-white shadow-sm ring-1 ring-inset ring-white/10 focus:ring-2 focus:ring-inset focus:ring-cyan-500 sm:text-sm sm:leading-6" />
        </div>
      </div>

      <div v-if="error" class="text-red-400 text-sm pt-2">{{ error }}</div>

      <div class="pt-4">
        <button type="submit" :disabled="store.isLoading" class="w-full rounded-md bg-cyan-600 px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-cyan-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-cyan-600 disabled:bg-slate-700 disabled:cursor-not-allowed">
          {{ store.isLoading ? 'Saving...' : 'Save Order' }}
        </button>
      </div>
    </form>
  </div>
</template>