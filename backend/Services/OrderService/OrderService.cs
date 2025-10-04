using backend.Models;
using backend.Dtos;
using backend.Services;

public class OrderService : IOrderService
{
    private static readonly List<Order> _orders = new List<Order>();
    public List<Order> GetAllOrders()
    {
        return _orders;
    }

    public Order? GetOrderById(Guid Id)
    {
        return _orders.FirstOrDefault(o => o.Id == Id);
    }

    public Order CreateOrder(CreateOrderDto createdOrderDto)
    {
        if (string.IsNullOrEmpty(createdOrderDto.CustomerName))
        {
            throw new ArgumentException("Customer name is required.");
        }

        if (createdOrderDto.CustomerName.Length < 3)
        {
            throw new ArgumentException("Customer name must be over 2 characters.");
        }

        if (createdOrderDto.TotalAmount <= 0)
        {
            throw new ArgumentException("Total amount must be grater than 0");
        }

        var order = new Order
        {
            Id = Guid.NewGuid(),
            CustomerName = createdOrderDto.CustomerName,
            TotalAmount = createdOrderDto.TotalAmount,
            OrderDate = DateTime.UtcNow,
        };
        _orders.Add(order);
        return order;
    }

    public Order? UpdateOrder(Guid Id, UpdateOrderDto updatedOrderDto)
    {
        if (string.IsNullOrEmpty(updatedOrderDto.CustomerName))
        {
            throw new ArgumentException("Customer name can not be empty.");
        }

        if (updatedOrderDto.CustomerName.Length < 3)
        {
            throw new ArgumentException("Customer Name must be over 2 characters.");
        }

        if (updatedOrderDto.TotalAmount <= 0)
        {
            throw new ArgumentException("Total amount must be grater than 0");
        }

        var existingOrder = GetOrderById(Id);

        if (existingOrder == null)
        {
            return null;
        }

        existingOrder.CustomerName = updatedOrderDto.CustomerName;
        existingOrder.TotalAmount = updatedOrderDto.TotalAmount;

        return existingOrder;
    }
    public bool DeteleOrder(Guid Id)
    {
        var existingOrder = GetOrderById(Id);
        if (existingOrder == null)
        {
            return false;
        }

        _orders.Remove(existingOrder);
        return true;
    }
}