public interface IOrderService
{
    List<Order> GetAllOrders();
    Order? GetOrderById(Guid Id);
    Order CreateOrder(Order order);
    Order? UpdateOrder(Guid Id, Order Order);
    bool DeteleOrder(Guid Id);

}