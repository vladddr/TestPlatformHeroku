using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using TestPlatform.API.DataTransfer;
using TestPlatform.API.Services;

namespace TestPlatform.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        /// <summary>
        /// Student register
        /// </summary>
        /// <param name="studentDto"></param>
        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(StudentCreateDto))]
        public async Task<IActionResult> CreateUser([FromBody]StudentCreateDto studentDto)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _studentService.RegisterStudentAsync(studentDto));
            }

            return BadRequest($"Student is not valid!");
        }

        /// <summary>
        /// Students group change
        /// </summary>
        /// <response code="200">Succesfully changed</response>
        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(StudentUserReadDto))]
        public async Task<IActionResult> GroupChange([Required][FromQuery] int studentId, int groupId)
        {
            var updatedStudent = await _studentService.UpdateGroupAsync(groupId, studentId);
            
            if (updatedStudent == null)
            {
                return NotFound("User Not Updated!");
            }

            return Ok(updatedStudent);
        }
    }
}
