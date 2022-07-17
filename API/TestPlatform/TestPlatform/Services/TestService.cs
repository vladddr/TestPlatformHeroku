using AutoMapper;
using TestPlatform.API.DataTransfer;
using TestPlatform.Core.Entities;
using TestPlatform.DAL.Repositories;

namespace TestPlatform.API.Services
{
    public class TestService : GenericService<Test, TestCreateDto, TestCreateDto, TestReadDto>, ITestService
    {
        public readonly IGenericRepository<Test> _testRepository;
        public readonly IMapper _mapper;

        public TestService(IGenericRepository<Test> testRepository, IMapper mapper) : base(testRepository, mapper)
        {
            _mapper = mapper;
            _testRepository = testRepository;
        }
    }
}
