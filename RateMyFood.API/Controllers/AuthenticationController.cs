using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RateMyFood.API.Dtos;
using RateMyFood.API.Entities;
using RateMyFood.API.Models;
using RateMyFood.API.Services;
using Serilog;

namespace RateMyFood.API.Controllers
{
    [Route("api/authentication")]
    public class AuthenticationController : ApiBaseController
    {
        #region fields
        private readonly IConfiguration _configuration;
        private readonly IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;
        #endregion

        #region constructor
        public AuthenticationController(IConfiguration configuration, 
            IAuthenticationService authenticationService,
            IMapper mapper)
        {
            _configuration = configuration;
            _authenticationService = authenticationService;
            _mapper = mapper;
        }
        #endregion

        #region register
        [HttpPost("register")]
        public async Task<IActionResult> Register(User user)
        {
            var res =await  _authenticationService.RegisterUserAsync(user);
            Log.Information("User created with id : " + user.Id); 
            return Ok("User Created");
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
            Log.Information("Authenticating user with credentials : "
                + authenticationRequest);

            return Ok(user);
        }
        #endregion

        #region get all users
        //[Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var users = await _authenticationService.GetAllUsersAsync();
            Log.Information("Getting all users");

            return Ok(_mapper.Map<IEnumerable<UserDto>>(users));

        }
        #endregion

        #region get single user
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await _authenticationService.GetUserAsync(id);
            Log.Information("Getting user with id " + id);

            return Ok(_mapper.Map<UserDto>(user));

        }
        #endregion

        #region update
        [HttpPut("udpate")]
        public async Task<IActionResult> Update(UserToUpdate userToUpdate, string id)
        {
            var res = await _authenticationService.UpdateUserAsync(userToUpdate, id);
            Log.Information("Updating User with id : " + id);
            return Ok();
        }
        #endregion

        #region delete
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
             _authenticationService.DeleteUser(id);
            Log.Information("Deleted User with Id : " + id);
            return Ok();
        }
        #endregion
    }
}
