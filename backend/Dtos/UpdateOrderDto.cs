namespace backend.Dtos;
public class UpdateOrderDto
{
    public string CustomerName { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
}