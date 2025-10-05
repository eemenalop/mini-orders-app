// src/components/Pagination.vue
<script setup lang="ts">
import { ArrowLongLeftIcon, ArrowLongRightIcon } from '@heroicons/vue/20/solid'
import { useOrderStore } from '@/stores/orderStore';

const store = useOrderStore();

function changePage(page: number) {
  if (page > 0 && page <= store.totalPages) {
    store.fetchOrders(page);
  }
}
</script>

<template>
  <nav class="flex items-center justify-between border-t border-white/10 px-4 sm:px-0 mt-8">
    <div class="-mt-px flex w-0 flex-1">
      <button
        @click="changePage(store.currentPage - 1)"
        :disabled="store.currentPage === 1"
        class="inline-flex items-center border-t-2 border-transparent pr-1 pt-4 text-sm font-medium text-slate-400 hover:border-white/20 hover:text-slate-200 disabled:text-slate-600 disabled:hover:border-transparent"
      >
        <ArrowLongLeftIcon class="mr-3 h-5 w-5 text-slate-500" aria-hidden="true" />
        Previous
      </button>
    </div>
    <div class="hidden md:-mt-px md:flex">
      <span v-for="page in store.totalPages" :key="page">
        <button
          @click="changePage(page)"
          :class="[
            'inline-flex items-center border-t-2 px-4 pt-4 text-sm font-medium',
            page === store.currentPage 
              ? 'border-cyan-400 text-cyan-400' 
              : 'border-transparent text-slate-400 hover:border-white/20 hover:text-slate-200'
          ]"
        >
          {{ page }}
        </button>
      </span>
    </div>
    <div class="-mt-px flex w-0 flex-1 justify-end">
      <button
        @click="changePage(store.currentPage + 1)"
        :disabled="store.currentPage === store.totalPages"
        class="inline-flex items-center border-t-2 border-transparent pl-1 pt-4 text-sm font-medium text-slate-400 hover:border-white/20 hover:text-slate-200 disabled:text-slate-600 disabled:hover:border-transparent"
      >
        Next
        <ArrowLongRightIcon class="ml-3 h-5 w-5 text-slate-500" aria-hidden="true" />
      </button>
    </div>
  </nav>
</template>