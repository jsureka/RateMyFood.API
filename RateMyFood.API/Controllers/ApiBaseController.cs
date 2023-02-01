using Microsoft.AspNetCore.Mvc;
using RateMyFood.API.Models;

namespace RateMyFood.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest, type: typeof(ErrorObject))]
    [ProducesResponseType(statusCode: StatusCodes.Status401Unauthorized, type: typeof(ErrorObject))]
    [ProducesResponseType(statusCode : StatusCodes.Status500InternalServerError, type: typeof(ErrorObject))]
    public class ApiBaseController : ControllerBase
    {

    }
}
