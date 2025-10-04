namespace backend.Services;

using System;
using System.Collections.Generic;
using backend.Models;
using backend.Dtos;

public interface IOrderService
{
    List<Order> GetAllOrders();
    Order? GetOrderById(Guid Id);
    Order CreateOrder(CreateOrderDto newOrder);
    Order? UpdateOrder(Guid Id, UpdateOrder updatedOrder);
    bool DeteleOrder(Guid Id);

}