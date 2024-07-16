using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProductManagementSystem.Models
{
    public class Product
    {
        
        public int Id { get; set; }//product id
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int AvailableStock { get; set; }
        public string Brand { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
        public bool IsFeatured { get; set; }
    }
}
