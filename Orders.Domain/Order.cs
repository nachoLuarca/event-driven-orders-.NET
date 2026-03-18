namespace Orders.Domain;

public class Order
{
    public int Id { get; set; }
    public required string Product { get; set; }
    public decimal Price { get; set; }
}