<script setup lang="ts">
import OrderList from '@/components/OrderList.vue';
import { RouterLink } from 'vue-router';
</script>

<template>
  <div class="bg-slate-900 text-slate-300 min-h-screen font-sans">
    <div class="container mx-auto max-w-4xl p-4 sm:p-8">
      <header class="text-center mb-10">
        <h1 class="text-4xl sm:text-5xl font-bold text-white tracking-tight">
          Mini <span class="text-cyan-400">Orders</span> App
        </h1>
      </header>
      <div class="flex justify-between items-center mb-6">
        <h2 class="text-2xl font-bold text-white">Existing Orders</h2>
        <RouterLink to="/orders/new" class="rounded-md bg-cyan-600 px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-cyan-500">
          Create New Order
        </RouterLink>
      </div>
      <OrderList />
    </div>
  </div>
</template>