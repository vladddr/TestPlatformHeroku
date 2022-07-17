using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using TestPlatform.API.DataTransfer;
using TestPlatform.API.Services;
using TestPlatform.Core.Enums;
using TestPlatform.Core.Specifications;

namespace TestPlatform.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// User login
        /// </summary>
        /// <response code="200">Succesfully login</response>
        /// <response code="400">Invalid credentials</response>
        [HttpGet("login")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(UserCreateDto))]
        public async Task<IActionResult> Get([Required] string login, 
            [Required] string password)
        {
            var specification = new UserLoginSpecification(login, password);

            var user = await _userService.SearchAsync(specification);

            if (user == null)
            {
                return NotFound("Password or login is not correct");
            }

            return Ok(user);
        }

        /// <summary>
        /// Users search
        /// </summary>
        /// <response code="200">Succesfully login</response>
        /// <response code="400">Invalid credentials</response>
        [HttpGet("search")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(UserCreateDto))]
        public async Task<IActionResult> Search(Role? role, string? login, string? lastName, string? firstName)
        {
            var specification = new UserSearchSpecification(role, login, lastName, firstName);

            var users = await _userService.SearchAsync(specification);

            if(users == null)
            {
                return NotFound($"Can't found users by the given parameters ");
            }

            return Ok(users);
        }

        /// <summary>
        /// Users search
        /// </summary>
        /// <response code="200">Succesfully login</response>
        /// <response code="400">Invalid credentials</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(UserCreateDto))]
        public async Task<IActionResult> Get(int id)
        {
            var specification = new UserEntitySpecification(id);

            var user = await _userService.ReadSpecefiedAsync(specification);

            if (user is null)
            {
                return NotFound($"User with identifier {id} not found");
            }

            return Ok(user);
        }
    }
}
