using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RateMyFood.API.Entities
{
    public class MenuItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        
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