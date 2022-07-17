using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using TestPlatform.API.DataTransfer;
using TestPlatform.API.Services;
using TestPlatform.Core.Entities;

namespace TestPlatform.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController : Controller
    {
        private readonly IGenericService
            <Group, GroupBaseDto, GroupBaseDto, GroupReadDto> _groupService;

        public GroupController(IGenericService<Group, GroupBaseDto, GroupBaseDto, GroupReadDto> groupService)
        {
            _groupService = groupService;
        }

        /// <summary>
        /// Student register
        /// </summary>
        /// <param name="groupName"></param>
        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(GroupBaseDto))]
        public async Task<IActionResult> CreateGroup(string groupName)
        {
            var groupDto = new GroupBaseDto(groupName);

            if (ModelState.IsValid)
            {
                return Ok(await _groupService.CreateAsync(groupDto));
            }

            return BadRequest($"Group is not valid!");
        }

        /// <summary>
        /// Student register
        /// </summary>
        /// <param name="groupName"></param>
        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(GroupBaseDto))]
        public async Task<IActionResult> UpdateGroup([Required][FromQuery]int groupId, string groupName)
        {
            var groupDto = new GroupBaseDto(groupName);

            if (ModelState.IsValid)
            {
                return Ok(await _groupService.UpdateAsync(groupId, groupDto));
            }

            return BadRequest($"Group is not valid!");
        }

    }
}
