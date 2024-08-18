using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class ProductCreate
    {
        [Required, MaxLength(100)]
        public string Name { get; set; } = "";
        [Required, MaxLength(100)]
        public string Brend { get; set; } = "";
        [Required, MaxLength(100)]
        public string Category { get; set; } = "";
        [Required]
        public int Price { get; set; }
        [Required, MaxLength(100)]
        public string Description { get; set; } = "";
        
        public IFormFile? ImageFileName { get; set; }

    }
}
