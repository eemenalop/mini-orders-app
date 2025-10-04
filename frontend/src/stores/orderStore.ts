import {defineStore} from 'pinia';
import type { Order, CreateOrderDto } from '@/Models/Order';

interface OrderState{
    orders: Order[];
    isLoading: boolean;
    error: string | null;
}

export const useOrderStore = defineStore('orders', {
    state: (): OrderState => ({
        orders: [],
        isLoading: false,
        error: null,
    }),

    getters: {
        totalOrders: (state) => state.orders.length,
    },

    actions: {
        async fetchOrders(){
            this.isLoading = true;
            this.error = null;
            try {
                const response = await fetch('http://localhost:5150/Orders');
                if(!response.ok) throw new Error('Error getting orders.')
                    this.orders = await response.json();
            } catch (err) {
                this.error = (err as Error).message;
            } finally{
                this.isLoading = false;
            }
        },

        async createOrder(newOrder: CreateOrderDto){
            try {
                const response = await fetch('http://localhost:5150/Orders', {
                    method: 'POST',
                    headers: {'Content-Type': 'application/json'},
                    body: JSON.stringify(newOrder),
                });
                if (!response.ok) throw new Error('Cannot create the order.');
                await this.fetchOrders();
            } catch (err) {
                this.error = (err as Error).message;
            }
        }
    }
})

