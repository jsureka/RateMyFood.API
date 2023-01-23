using Microsoft.AspNetCore.Mvc;
using RateMyFood.API.Dtos;
using RateMyFood.API.Entities;
using RateMyFood.API.Services;

namespace RateMyFood.API.Controllers
{
    [Route("api/authentication")]
    public class AuthenticationController : ApiBaseController
    {
        #region fields
        private readonly IConfiguration _configuration;
        private readonly IAuthenticationService _authenticationService;
        #endregion

        #region constructor
        public AuthenticationController(IConfiguration configuration, 
            IAuthenticationService authenticationService)
        {
            this._configuration = configuration;
            this._authenticationService = authenticationService;
        }
        #endregion

        #region register
        [HttpPost("register")]
        public async Task<IActionResult> Register(User user)
        {
            var res = await _authenticationService.RegisterUserAsync(user);

            return Ok();
        }
        #endregion

        #region authenticate
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(
            AuthenticationRequest authenticationRequest)
        {
            var user = await _authenticationService.AuthenticateUserAsync(
                authenticationRequest.UserName, authenticationRequest.Password);
            if (user == null)
            {
                return Unauthorized();
            }

            return Ok(user);
        }
        #endregion

        #region update
        #endregion

        #region delete
        #endregion
    }
}
