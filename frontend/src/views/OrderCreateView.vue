<script setup lang="ts">
import OrderForm from '@/components/OrderForm.vue';
import { RouterLink } from 'vue-router';
</script>
<template>
  <div class="bg-slate-900 text-slate-300 min-h-screen font-sans">
    <div class="container mx-auto max-w-2xl p-4 sm:p-8">
       <RouterLink to="/" class="text-cyan-400 hover:text-cyan-300 mb-6 inline-block">&larr; Back to List</RouterLink>
       <OrderForm />
    </div>
  </div>
</template>