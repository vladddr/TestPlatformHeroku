using TestPlatform.Core.Entities;
using TestPlatform.Core.Enums;

namespace TestPlatform.Core.Specifications
{
    public class UserSearchSpecification : BaseSpecification<User>
    {
        public UserSearchSpecification(Role? role = null, string? login = null, string? lastName = null, string? firstName = null) : base(user =>
            ((role == null) || user.UserRole == role) &&
            ((login == null) || user.Login == login) &&
            ((lastName == null) || user.LastName == lastName) &&
            (firstName == null) || user.FirstName == firstName)
        {
            AddInclude(s => s.Student);
            AddInclude(s => s.Student.Group);
            AddInclude(s => s.Teacher);
        }
    }
}
