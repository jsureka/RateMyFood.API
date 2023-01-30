using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RateMyFood.API.Entities
{
    public class Review
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Range(0, 10)]
        public double Rating { get; set;}

        [MaxLength(200)]
        public string? Description { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public string UserId { get; set; }

        [Required]
        [ForeignKey("MenuItemId")]
        public string MenuItemId { get; set; }

    }
}
