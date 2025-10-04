import {defineStore} from 'pinia';
import type { Order, CreateOrderDto, UpdateOrderDto } from '@/Models/Order';

const API_URL = 'http://localhost:5150/Orders';

interface OrderState{
    orders: Order[];
    currentOrder: Order | null;
    isLoading: boolean;
    error: string | null;
}

export const useOrderStore = defineStore('orders', {
    state: (): OrderState => ({
        orders: [],
        currentOrder: null,
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
                const response = await fetch(API_URL);
                if(!response.ok) throw new Error('Error getting orders.')
                    this.orders = await response.json();
            } catch (err) {
                this.error = (err as Error).message;
            } finally{
                this.isLoading = false;
            }
        },

        async fetchOrderById(id: string){
            this.isLoading = true;
            this.error = null;
            this.currentOrder = null;
            try {
                const response = await fetch(`${API_URL}/${id}`);
                if(!response.ok) throw new Error('Order not found.');
                this.currentOrder = await response.json();
            } catch (err) {
                this.error = (err as Error).message;
            }finally{
                this.isLoading = false;
            }
        },

        async createOrder(newOrder: CreateOrderDto){
            this.isLoading = true;
            this.error = null;
            try {
                const response = await fetch(API_URL, {
                    method: 'POST',
                    headers: {'Content-Type': 'application/json'},
                    body: JSON.stringify(newOrder),
                });
                if (!response.ok) {
                    const errorData = await response.json();
                    throw new Error(errorData.message || 'Cannot create the order.');
                }
                await this.fetchOrders();
            } catch (err) {
                this.error = (err as Error).message;
                throw err;
            }finally{
                this.isLoading = false;
            }
        },

        async updateOrder(id: string, updatedOrder: UpdateOrderDto) {
            this.isLoading = true;
            this.error = null;
            try {
                const response = await fetch(`${API_URL}/${id}`, {
                    method: 'PUT',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify(updatedOrder),
                });
                if (!response.ok) throw new Error('Cannot update the order.');
                await this.fetchOrders();
            } catch (err) {
                this.error = (err as Error).message;
                throw err;
            } finally {
                this.isLoading = false;
            }
        },

        async deleteOrder(id: string) {
            this.isLoading = true;
            this.error = null;
            try {
                const response = await fetch(`${API_URL}/${id}`, {
                    method: 'DELETE',
                });
                if (!response.ok) throw new Error('Cannot delete the order.');
                this.orders = this.orders.filter(order => order.id !== id);
            } catch (err) {
                this.error = (err as Error).message;
            } finally {
                this.isLoading = false;
            }
        }
    }
})

