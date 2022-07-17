using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TestPlatform.API.DataTransfer;
using TestPlatform.API.Services;

namespace TestPlatform.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestQuestionController : ControllerBase
    {
        private readonly ITestQuestionService _testQuestionService;

        public TestQuestionController(ITestQuestionService testQuestionService)
        {
            _testQuestionService = testQuestionService;
        }

        [HttpPut("ExcludeQuestions")]
        public async Task<IActionResult> UpdateTestQuestions([FromQuery] int testId, [Required] List<int> questionsIds)
        {
            var updatedTest = await _testQuestionService.ExcludeQuestions(testId, questionsIds);

            if(updatedTest is null)
            {
                return NotFound($"Test {testId} was not found");
            }

            return Ok(updatedTest);
        }

        [HttpPut("IncludeQuestions")]
        public async Task<IActionResult> UpdateTestQuestions([FromQuery] int testId, [Required] List<TestQuestionDto> testQuestions)
        {
            var updatedTest = await _testQuestionService.IncludeQuestions(testId, testQuestions);

            if (updatedTest is null)
            {
                return NotFound($"Test {testId} was not found");
            }

            return Ok(updatedTest);
        }
    }
}
