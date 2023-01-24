using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RateMyFood.API.Entities
{
    public class Restaurant
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Address { get; set; }

        [ForeignKey("OwnerId")]
        [Required]
        public string OwnerId { get; set; }

        public Restaurant(string name)
        {
            Name = name;
        }
    }
}