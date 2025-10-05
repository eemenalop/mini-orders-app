import { z } from 'zod';

export const CreateOrderSchema = z.object({
  customerName: z.string().min(3, "Name must be at least 3 characters."),
  totalAmount: z.number().gt(0, "Total amount must be greater than 0."),
});
export interface Order {
  id: string; 
  customerName: string;
  orderDate: string;
  totalAmount: number; 
}
export type CreateOrderDto = z.infer<typeof CreateOrderSchema>;
export type UpdateOrderDto = CreateOrderDto;