using System.ComponentModel.DataAnnotations;

namespace RateMyFood.API.Dtos
{
    public class AuthenticationRequest
    {


        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        public AuthenticationRequest(string username, string password)
        {
            UserName = username;
            Password = password;
        }
    }
}
