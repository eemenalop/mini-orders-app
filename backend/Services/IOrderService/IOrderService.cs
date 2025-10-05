namespace backend.Services;

using System;
using System.Collections.Generic;
using backend.Models;
using backend.Dtos;
using backend.Helpers;

public interface IOrderService
{
    PagedResult<Order> GetAllOrders(int pageNumber = 1, int pageSize = 5);
    Order? GetOrderById(Guid Id);
    Order CreateOrder(CreateOrderDto createdOrderDto);
    Order? UpdateOrder(Guid Id, UpdateOrderDto updatedOrderDto);
    bool DeteleOrder(Guid Id);

}