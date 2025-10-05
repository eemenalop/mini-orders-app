<script setup lang="ts">
import OrderForm from '@/components/OrderForm.vue';
import OrderList from '@/components/OrderList.vue';
</script>

<template>
  <div class="bg-slate-900 text-slate-300 min-h-screen font-sans">
    <div class="container mx-auto max-w-7xl p-4 sm:p-8">
      <header class="text-center mb-10">
        <h1 class="text-4xl sm:text-5xl font-bold text-white tracking-tight">
          Mini <span class="text-cyan-400">Orders</span> App
        </h1>
      </header>

      <main class="grid grid-cols-1 lg:grid-cols-5 gap-12">
        <div class="lg:col-span-2">
          <OrderForm />
        </div>
        <div class="lg:col-span-3">
          <OrderList />
        </div>
      </main>
    </div>
  </div>
</template>