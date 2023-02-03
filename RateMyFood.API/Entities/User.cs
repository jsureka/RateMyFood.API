using RateMyFood.API.Models;
using System.ComponentModel.DataAnnotations;

namespace RateMyFood.API.Entities
{
    public class User : BaseEntity
    {
        [MaxLength(200)]
        public string? UserName { get; set; }

        [MaxLength(200)]
        public string Password { get; set; }

        [MaxLength(200)]
        public string Email { get; set; }

        [MaxLength(200)]
        public string? FirstName { get; set; }

        [MaxLength(200)]
        public string? LastName { get; set; }

        public string? Role { get; set; }

        public User()
        {
   
        }
    }
}
