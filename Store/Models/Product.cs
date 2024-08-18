using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string? Name { get; set; }
        [MaxLength(100)]
        public string? Brend { get; set; }
        [MaxLength(100)]
        public string? Category { get; set; }
        [Precision(16,2)]
        public int Price { get; set; }
        [MaxLength(1000)]
        public string? Description { get; set; }
        [MaxLength(100)]
        public string? ImageFileName { get; set; }

        public DateTime CreatedAt { get; set; } 


    }
}
