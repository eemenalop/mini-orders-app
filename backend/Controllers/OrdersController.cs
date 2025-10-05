using Microsoft.AspNetCore.Mvc;
using backend.Models;
using backend.Dtos;
using backend.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]

public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }
    [HttpGet]
    public IActionResult GetAllOrders([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 5)
    {
        var pagedResult = _orderService.GetAllOrders(pageNumber, pageSize);
        return Ok(pagedResult);
    }

    [HttpGet("{id}")]
    public IActionResult GetOrderById(Guid id)
    {
        var order = _orderService.GetOrderById(id);
        if (order == null)
        {
            return NotFound();
        }

        return Ok(order);
    }

    [HttpPost]
    public IActionResult CreateOrder(CreateOrderDto createOrderDto)
    {
        try
        {
            var newOrder = _orderService.CreateOrder(createOrderDto);
            return CreatedAtAction(nameof(GetOrderById), new { id = newOrder.Id }, newOrder);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult UpdateOrder(Guid id, UpdateOrderDto updatedOrderDto)
    {
        try
        {
            var updatedOrder = _orderService.UpdateOrder(id, updatedOrderDto);
            if (updatedOrder == null)
            {
                return NotFound();
            }
            return Ok(updatedOrder);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeteleOrder(Guid id)
    {
        var deletedOrder = _orderService.DeteleOrder(id);
        if (!deletedOrder)
        {
            return NotFound();
        }
        return NoContent();
    }
}