using TestPlatform.Core.Base;

namespace TestPlatform.Core.Entities
{
    public class Group : BaseEntity
    {
        // Study Group Name
        public string Name { get; set; }

        // All students that are assigned to group
        public virtual ICollection<Student> Students { get; set; }

        // Assigned test to group
        public virtual ICollection<Test> AssignedTests { get; set; }
    }
}
