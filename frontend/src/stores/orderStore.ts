import {defineStore} from 'pinia';
import type { Order, CreateOrderDto, UpdateOrderDto } from '@/Models/Order';

const API_URL = 'http://localhost:5150/Orders';

interface OrderState{
    orders: Order[];
    currentOrder: Order | null;
    isLoading: boolean;
    error: string | null;
    currentPage: number;
    pageSize: number;
    totalCount: number;
}

export const useOrderStore = defineStore('orders', {
    state: (): OrderState => ({
        orders: [],
        currentOrder: null,
        isLoading: false,
        error: null,
        currentPage: 1,
        pageSize: 5,
        totalCount: 0,
    }),

    getters: {
        totalPages: (state) => Math.ceil(state.totalCount / state.pageSize),
    },

    actions: {
        async fetchOrders(page = 1){
            this.isLoading = true;
            this.error = null;
            try {
                const response = await fetch(`${API_URL}?pageNumber=${page}&pageSize=${this.pageSize}`);
                if(!response.ok) throw new Error('Error getting orders.')
                const data = await response.json();
                this.orders = data.items;
                this.totalCount = data.totalCount;
                this.currentPage = page;
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

