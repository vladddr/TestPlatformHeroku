using TestPlatform.Core.Base;

namespace TestPlatform.Core.Entities
{
    public class Test : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsClosed { get; set; }

        // The id of teacher who creates the test
        public int TeacherId { get; set; }

        public virtual Teacher CreatedBy { get; set; }

        public virtual List<TestQuestion> Questions { get; set; }

        public virtual List<Group> AssignedGroups { get; set; }
    }
}
