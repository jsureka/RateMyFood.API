using RateMyFood.API.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RateMyFood.API.Entities
{
    public class MenuItem : BaseEntity
    {    
        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }
        
        [ForeignKey("RestaurantId")]
        [Required]
        public string RestaurantId { get; set; }
        
        public MenuItem(string name)
        {
            Name = name;
        }
    }
}