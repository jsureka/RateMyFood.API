using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RateMyFood.API.Dtos;
using RateMyFood.API.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RateMyFood.API.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _configuration;

        public AuthenticationService(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public string AuthenticateUser(AuthenticationRequest authenticationRequest)
        {
 
            var securityKey = new SymmetricSecurityKey(
             Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));
            var signingCredentials = new SigningCredentials(
                securityKey, SecurityAlgorithms.HmacSha256);
            var claimsForToken = new List<Claim>();
            //claimsForToken.Add(new Claim("sub", user.UserId.ToString()));
            //claimsForToken.Add(new Claim("given_name", user.FirstName));
            //claimsForToken.Add(new Claim("family_name", user.LastName));
            //claimsForToken.Add(new Claim("role", user.Role));

            var jwtSecurityToken = new JwtSecurityToken(
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                signingCredentials
                );

            var tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return tokenToReturn;
        }

        public Task<IActionResult> AuthenticateUserAsync(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> RegisterUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
