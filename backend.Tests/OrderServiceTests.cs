using Xunit;
using backend.Services;
using backend.Dtos;
using System;

namespace backend.Tests;

public class OrderServiceTests
{
    [Fact]
    public void CreateOrder_ShouldCreateOrder_WhenDataIsValid()
    {
        var service = new OrderService();
        var orderDto = new CreateOrderDto
        {
            CustomerName = "Test customer",
            TotalAmount = 100m
        };

        var result = service.CreateOrder(orderDto);
        Assert.NotNull(result);
        Assert.Equal("Test customer", result.CustomerName);
        Assert.NotEqual(Guid.Empty, result.Id);
    }

    [Fact]
    public void Create_ShouldThrowException_WhenTotalIsZero()
    {
        var service = new OrderService();
        var orderDtoWithZeroTotal = new CreateOrderDto
        {
            CustomerName = "Invalid Client",
            TotalAmount = 0
        };

        Assert.Throws<ArgumentException>(() => service.CreateOrder(orderDtoWithZeroTotal));
    }

    [Fact]
    public void GetById_ShouldReturnNull_WhenOrderDoesNotExist()
    {
        var service = new OrderService();
        var nonExistentId = Guid.NewGuid();
        var result = service.GetOrderById(nonExistentId);
        Assert.Null(result);
    }

    [Fact]
    public void UpdateOrder_ShouldModifyOrder_WhenOrderExists()
    {
        var service = new OrderService();
        var initialOrder = service.CreateOrder(new CreateOrderDto { CustomerName = "Test customer", TotalAmount = 100m });

        var updateDto = new UpdateOrderDto
        {
            CustomerName = "Customer Updated",
            TotalAmount = 250m
        };
        var result = service.UpdateOrder(initialOrder.Id, updateDto);
        Assert.NotNull(result);
        Assert.Equal("Customer Updated", result.CustomerName);
        Assert.Equal(250m, result.TotalAmount);
        Assert.Equal(initialOrder.Id, result.Id);
    }

    [Fact]
    public void UpdateOrder_ShouldReturnNull_WhenOrderDoesNotExist()
    {
        var service = new OrderService();
        var nonExistentId = Guid.NewGuid();
        var updateDto = new UpdateOrderDto { CustomerName = "Test customer", TotalAmount = 100m };
        var result = service.UpdateOrder(nonExistentId, updateDto);
        Assert.Null(result);
    }

    [Fact]
    public void DeleteOrder_ShouldRemoveOrder_WhenOrderExists()
    {
        var service = new OrderService();
        var orderToDelete = service.CreateOrder(new CreateOrderDto { CustomerName = "Test customer", TotalAmount = 100m });
        var wasDeleted = service.DeteleOrder(orderToDelete.Id);
        Assert.True(wasDeleted);
        var result = service.GetOrderById(orderToDelete.Id);
        Assert.Null(result);
    }

    [Fact]
    public void DeleteOrder_ShouldReturnFalse_WhenOrderDoesNotExist()
    {
        var service = new OrderService();
        var nonExistentId = Guid.NewGuid();
        var result = service.DeteleOrder(nonExistentId);
        Assert.False(result);
    }
}