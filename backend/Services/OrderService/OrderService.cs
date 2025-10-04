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

    public Order CreateOrder(CreateOrderDto newOrder)
    {
        if (string.IsNullOrEmpty(newOrder.CustomerName))
        {
            throw new ArgumentException("Customer name is required.");
        }

        if (newOrder.CustomerName.Length < 3)
        {
            throw new ArgumentException("Customer name must be over 2 characters.");
        }

        if (newOrder.TotalAmount <= 0)
        {
            throw new ArgumentException("Total amount must be grater than 0");
        }

        var order = new Order
        {
            Id = Guid.NewGuid(),
            OrderDate = DateTime.UtcNow,
            CustomerName = newOrder.CustomerName,
            TotalAmount = newOrder.TotalAmount
        };
        _orders.Add(order);
        return order;
    }

    public Order? UpdateOrder(Guid Id, UpdateOrder updatedOrder)
    {
        if (string.IsNullOrEmpty(updatedOrder.CustomerName))
        {
            throw new ArgumentException("Customer name can not be empty.");
        }

        if (updatedOrder.CustomerName.Length < 3)
        {
            throw new ArgumentException("Customer Name must be over 2 characters.");
        }

        if (updatedOrder.TotalAmount <= 0)
        {
            throw new ArgumentException("Total amount must be grater than 0");
        }

        var existingOrder = GetOrderById(Id);

        if (existingOrder == null)
        {
            return null;
        }

        existingOrder.CustomerName = updatedOrder.CustomerName;
        existingOrder.TotalAmount = updatedOrder.TotalAmount;

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