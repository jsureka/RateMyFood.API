using RateMyFood.API.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RateMyFood.API.Entities
{
    public class Restaurant : BaseEntity
    {
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