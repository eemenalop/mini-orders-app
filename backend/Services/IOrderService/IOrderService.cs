namespace backend.Services;

using System;
using System.Collections.Generic;
using backend.Models;
using backend.Dtos;

public interface IOrderService
{
    List<Order> GetAllOrders();
    Order? GetOrderById(Guid Id);
    Order CreateOrder(CreateOrderDto createdOrderDto);
    Order? UpdateOrder(Guid Id, UpdateOrderDto updatedOrderDto);
    bool DeteleOrder(Guid Id);

}