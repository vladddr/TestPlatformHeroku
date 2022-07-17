using TestPlatform.Core.DataTransfer.SearchParamethers;
using TestPlatform.Core.Entities;
using TestPlatform.Core.Enums;

namespace TestPlatform.Core.Specifications
{
    public class StudentBaseSpecification : BaseSpecification<Student>
    {
        public StudentBaseSpecification(StudentSearchParameters search) :
               base(s => 
               ((search.Login   == null) || s.User.Login == search.Login)   &&
               ((search.GroupId == null) || s.GroupId    == search.GroupId) &&
               ((search.Id      == null) || s.Id == search.Id) &&
               s.User.UserRole == Role.Student)
        {
            AddInclude(s => s.Group);
            AddInclude(s => s.User);
        }
    }
}
