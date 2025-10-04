export interface Order{
    id: string;
    customerName: string;
    totalAmount: number;
    orderDate: string;
}

export type CreateOrderDto = Omit<Order, 'id' | 'orderDate'>;