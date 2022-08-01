namespace Project.Models;
public class Property
{
    public Guid Id { get; set; }
    public string Category { get; set; } = null!;
    public string? Details { get; set; }
    public decimal Price { get; set; }
    public decimal? rate { get; set; }
}