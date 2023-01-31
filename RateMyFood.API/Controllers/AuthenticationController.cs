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
        /// <summary>
        /// Register a User
        /// </summary>
        /// <param name="user">The object user to post</param>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns a string</response>
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(User user)
        {
            var res =await  _authenticationService.RegisterUserAsync(user);
            Log.Information("User created with id : " + user.Id); 
            return CreatedAtRoute("GetSingleUser", new
            {
                V = user.Id.ToString()
            }, user);
        }
        #endregion

        #region authenticate
        /// <summary>
        /// Authenticate a User (Sign In)
        /// </summary>
        /// <param name="authenticationRequest">The object that 
        /// contains login credentials</param>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns a user object</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        /// <summary>
        /// Get all users (Admin)
        /// </summary>
        /// <returns>An IActionResult containing the users</returns>
        /// <response code="200">Returns list of users</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var users = await _authenticationService.GetAllUsersAsync();
            Log.Information("Getting all users");

            return Ok(_mapper.Map<IEnumerable<UserDto>>(users));

        }
        #endregion

        #region get single user
        /// <summary>
        /// Get a User
        /// </summary>
        /// <param name="id">The string that 
        /// contains id</param>
        /// <returns>An IActionResult with user oject</returns>
        /// <response code="200">Returns a user object</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}", Name = "GetSingleUser")]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await _authenticationService.GetUserAsync(id);
            Log.Information("Getting user with id " + id);

            return Ok(_mapper.Map<UserDto>(user));

        }
        #endregion

        #region update
        /// <summary>
        /// Update an user
        /// </summary>
        /// <param name="userToUpdate">Updated user object</param>
        /// <param name="id">Id of user to update</param>
        /// <returns>No Content</returns>
        /// <response code="204">Returns No Content</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("update")]
        public async Task<IActionResult> Update(UserToUpdate userToUpdate, string id)
        {
            var res = await _authenticationService.UpdateUserAsync(userToUpdate, id);
            Log.Information("Updating User with id : " + id);
            return NoContent();
        }
        #endregion

        #region delete
        /// <summary>
        /// Delete a User
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>An IActionResult</returns>
        /// <response code="204">Returns no content</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
             _authenticationService.DeleteUser(id);
            Log.Information("Deleted User with Id : " + id);
            return NoContent();
        }
        #endregion
    }
}
