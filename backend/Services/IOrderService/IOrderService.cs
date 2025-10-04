namespace backend.Services;

using backend.Models;
using backend.Dtos;

public interface IOrderService
{
    List<Order> GetAllOrders();
    Order? GetOrderById(Guid Id);
    Order CreateOrder(CreateOrderDto order);
    Order? UpdateOrder(Guid Id, UpdateOrder Order);
    bool DeteleOrder(Guid Id);

}