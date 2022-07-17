using TestPlatform.Core.Entities;

namespace TestPlatform.Core.Specifications
{
    public class TestEntitySpecification : BaseSpecification<Test>
    {
        public TestEntitySpecification(int identifier) : base(test => test.Id == identifier)
        {
            AddInclude($"{nameof(Test.Questions)}.{nameof(TestQuestion.QuestionOptions)}");
            AddInclude($"{nameof(Test.AssignedGroups)}");
        }
    }
}
