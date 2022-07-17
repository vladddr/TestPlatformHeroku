using TestPlatform.Core.Entities;

namespace TestPlatform.Core.Specifications
{
    public class TestSearchSpecification : BaseSpecification<Test>
    {
        public TestSearchSpecification(bool? isClosed, int? groupId) :
               base(s =>
               ((groupId == null) || s.AssignedGroups.Contains(new Group() { Id = groupId.Value })))
        {
            AddInclude($"{nameof(Test.Questions)}.{nameof(TestQuestion.QuestionOptions)}");
            AddInclude($"{nameof(Test.AssignedGroups)}");
        }
    }
}
