using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TestPlatform.API.DataTransfer;
using TestPlatform.API.Services;

namespace TestPlatform.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        /// <summary>
        /// Teacher register
        /// </summary>
        /// <param name="teacherDto"></param>
        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(TeacherBaseDto))]
        public async Task<IActionResult> CreateTeacher([FromBody] TeacherBaseDto teacherDto)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _teacherService.RegisterTeacherAsync(teacherDto));
            }

            return BadRequest($"Teacher is not valid!");
        }
    }
}
