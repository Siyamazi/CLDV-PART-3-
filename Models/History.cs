using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;

namespace CLDV_Part2.Models
{
    public class History
    {
        [Key]
        //public string Description { get; set; }
        public int OrderId { get; set; }
        public string Email { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public DateTime Date { get; set; }
    }
}
