using TestPlatform.Core.Entities;

namespace TestPlatform.Core.Specifications
{
    public class UserEntitySpecification : BaseSpecification<User>
    {
        public UserEntitySpecification(int identifier) : base(user => user.Id == identifier)
        {
            AddInclude(s => s.Student);
            AddInclude(s => s.Student.Group);
            AddInclude(s => s.Teacher);
        }
    }
}
