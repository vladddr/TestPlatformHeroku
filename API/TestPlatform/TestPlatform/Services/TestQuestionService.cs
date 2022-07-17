using AutoMapper;
using TestPlatform.API.DataTransfer;
using TestPlatform.Core.Entities;
using TestPlatform.Core.Specifications;
using TestPlatform.DAL.Repositories;

namespace TestPlatform.API.Services
{
    public class TestQuestionService : ITestQuestionService
    {
        public readonly IGenericRepository<Test> _testRepository;
        public readonly IMapper _mapper;

        public TestQuestionService(IGenericRepository<Test> testRepository, IMapper mapper)
        {
            _mapper = mapper;
            _testRepository = testRepository;
        }

        public async Task<TestReadDto> ExcludeQuestions(int testId, List<int> questionsIds)
        {
            var test = await _testRepository.GetEntityAsync(new TestEntitySpecification(testId));

            if(test is not null)
            {
                foreach(var id in questionsIds)
                {
                    test.Questions = test.Questions.Where(tq => tq.Id != id).ToList();
                }

                var updated = await _testRepository.UpdateAsync(test);

                return _mapper.Map<TestReadDto>(updated);
            }

            return _mapper.Map<TestReadDto>(test);
        }

        public async Task<TestReadDto> IncludeQuestions(int testId, List<TestQuestionDto> testQuestions)
        {
            var test = await _testRepository.GetEntityAsync(new TestEntitySpecification(testId));

            // Insert added range
            test.Questions.AddRange(_mapper.Map<IEnumerable<TestQuestion>>(testQuestions));

            // Update entity
            var updated = await _testRepository.UpdateAsync(test);

            return _mapper.Map<TestReadDto>(updated);
        }

    }
}
