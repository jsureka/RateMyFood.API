using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RateMyFood.API.Dtos;
using RateMyFood.API.Entities;
using RateMyFood.API.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RateMyFood.API.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        #region fields
        private readonly IConfiguration _configuration;
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        #endregion

        #region constructor
        public AuthenticationService(IConfiguration configuration, 
            IAuthenticationRepository authenticationRepository,
            IPasswordHasher<User> passwordHasher)
        {
            this._configuration = configuration;
            this._authenticationRepository = authenticationRepository;
            this._passwordHasher = passwordHasher;
        }
        #endregion

        #region authenticateUser
        public async Task<string> AuthenticateUserAsync(string username, string password)
        {
            var user = await _authenticationRepository.Get(username);
            if(user == null)
            {
                throw new Exception("User Not Found");
            }
            var verificationResult = _passwordHasher.VerifyHashedPassword(
                user, user.Password, password);
            if (verificationResult != PasswordVerificationResult.Success)
            {
                throw new Exception("Password Not Matching");
            }
            var securityKey = new SymmetricSecurityKey(
             Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));
            var signingCredentials = new SigningCredentials(
                securityKey, SecurityAlgorithms.HmacSha256);
            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub", user.Id.ToString()));
            claimsForToken.Add(new Claim("given_name", user.FirstName));
            claimsForToken.Add(new Claim("family_name", user.LastName));
            claimsForToken.Add(new Claim("role", user.Role));

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
        #endregion

        #region deleteUser
        public void DeleteUser(string id)
        {
            _authenticationRepository.Delete(id);
        }
        #endregion

        #region get all users
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _authenticationRepository.Get();
        }
        #endregion

        #region get single user
        public async Task<User> GetUserAsync(string id)
        {
            return await _authenticationRepository.GetById(id);
        }
        #endregion

        #region registerUser
        public async Task<bool> RegisterUserAsync(User user)
        {
         
            if(user == null)
            {
                throw new BadHttpRequestException("user value is null");
            }

            if (_authenticationRepository.UserExists(
                user.Email, user.UserName))
            {
                throw new BadHttpRequestException("User already Exists");
            }
            user.Password =
                _passwordHasher.HashPassword(user, user.Password);
            _authenticationRepository.Add(user);
            await _authenticationRepository.SaveChangesAsync();
            return true;
        }
        #endregion

        #region savechanges
        public async Task<bool> SaveChangesAsync()
        {
            return await _authenticationRepository.SaveChangesAsync();
        }
        #endregion

        #region updateUser
        public async Task<bool> UpdateUserAsync(UserToUpdate userToUpdate, string id)
        {
            if( _authenticationRepository.UserExists(userToUpdate.Email, 
                userToUpdate.UserName))
            {
                throw new Exception("Username or Email not Unique");
            }
            await _authenticationRepository.Update(userToUpdate, id);
            await SaveChangesAsync();
            return true;
        }
        #endregion
    }
}
