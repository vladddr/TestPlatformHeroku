using TestPlatform.Core.Base;

namespace TestPlatform.Core.Entities
{
    public class Teacher : BaseEntity
    {
        public virtual User User { get; set; }

        // Represents the Teacher's created tests
        public virtual ICollection<Test> Tests { get; set; }
    }
}
