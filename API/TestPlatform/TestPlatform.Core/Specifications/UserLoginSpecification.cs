using TestPlatform.Core.Entities;
using TestPlatform.Core.Enums;

namespace TestPlatform.Core.Specifications
{
    // User Specification to retreive nesessary data
    public class UserLoginSpecification : BaseSpecification<User>
    {
        public UserLoginSpecification(string login, string password) :
            base(user => user.Login == login && user.Password == password)
        {
            AddInclude(s => s.Student);
            AddInclude(s => s.Student.Group);
            AddInclude(s => s.Teacher);
        }
    }
}
