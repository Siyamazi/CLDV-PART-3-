using System.ComponentModel.DataAnnotations;

namespace CLDV_Part2.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Stock quantity must be a non-negative value")]
        public int StockQuantity { get; set; }

        [Url(ErrorMessage = "Invalid URL format")]
        public string? ImageUrl { get; set; }
    }
}
