using Microsoft.AspNetCore.Mvc;
using RateMyFood.API.Dtos;

namespace RateMyFood.API.Controllers
{
    [Route("api/authentication")]
    public class AuthenticationController : ApiBaseController
    {
        #region fields
        private readonly IConfiguration _configuration;
        #endregion

        public AuthenticationController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        //[HttpPost("authenticate")]
        //public async IActionResult Authenticate(
        //    AuthenticationRequest authenticationRequest)
        //{
        //    var user = await _authenticationService.AuthenticateUser(authenticationRequest);
        //    if(user == null)
        //    {
        //        return Unauthorized();
        //    }
        //    return Ok(user);
        //}
    }
}
