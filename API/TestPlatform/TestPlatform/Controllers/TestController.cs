using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestPlatform.API.DataTransfer;
using TestPlatform.API.MappingProfiles;
using TestPlatform.API.Services;
using TestPlatform.Core.Entities;
using TestPlatform.Core.Specifications;
using TestPlatform.DAL.Repositories;

namespace TestPlatform.API.Controllers
{
    public class TestController : Controller
    {
        private readonly ITestService _testService;
        private readonly ITestRepository _testRepository;
        private readonly IMapper _mapper;

        public TestController(ITestService testService, ITestRepository testRepository)
        {
            _testService = testService;
            _testRepository = testRepository;

            var mapperConfiguration = new MapperConfiguration(configuration => configuration.AddProfiles(
                new Profile[]
                {
                                new TestMappingProfile(),
                                new GroupMappingProfiles()
                }));
            _mapper = new Mapper(mapperConfiguration);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] TestCreateDto testDto)
        {
            if (ModelState.IsValid)
            {
                var test = _mapper.Map<Test>(testDto);
                var createdTest = await _testRepository.AddTestsWithGroupsAsync(test);

                return Ok(_mapper.Map<TestReadDto>(createdTest));
            }

            return BadRequest($"Test is not valid!");
        }

        [HttpGet("Search")]
        public async Task<IActionResult> Search(int assignedGroup)
        {
            var specification = new TestSearchSpecification(false, assignedGroup);

            var users = await _testService.ReadAllAsync(specification);

            if (users == null)
            {
                return NotFound($"Can't found users by the given parameters");
            }

            return Ok(users);
        }
    }
}
