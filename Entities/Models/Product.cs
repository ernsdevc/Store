using System.ComponentModel.DataAnnotations;

namespace Entities.Models;
public class Product
{
    public int ProductId { get; set; }
    [Required(ErrorMessage = "ProductName is required.")]
    public String? ProductName { get; set; } = string.Empty;
    [Required(ErrorMessage = "Price is required.")]
    public decimal Price { get; set; }
    public String? Summary { get; set; } = String.Empty;
    public String? ImageUrl { get; set; }
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }
    public bool ShowCase { get; set; }
}
