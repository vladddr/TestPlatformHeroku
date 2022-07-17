using TestPlatform.API.DataTransfer;

namespace TestPlatform.API.Services
{
    public interface ITestQuestionService
    {
        Task<TestReadDto> ExcludeQuestions(int testId, List<int> qestionsIds);

        Task<TestReadDto> IncludeQuestions(int testId, List<TestQuestionDto> testQuestions);
    }
}
