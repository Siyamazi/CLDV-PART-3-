using System.ComponentModel.DataAnnotations;

namespace CLDV_Part2.Models
{
    public class CartHistory
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value")]
        public decimal Price { get; set; }

        public DateTime Date { get; set; }

        

        
    }
}
