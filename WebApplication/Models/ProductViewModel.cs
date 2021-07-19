using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class ProductViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Sku { get; set; }
    }
}
