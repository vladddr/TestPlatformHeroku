using TestPlatform.Core.Base;

namespace TestPlatform.Core.Entities
{
    /* 
    Specific table with Student Users only
    The necessary is to separate Students and other Users
    We need separation because in order with Groups in what User is assigned
    */
    public class Student : BaseEntity
    {
        // The student study group
        public virtual Group Group { get; set; }

        public int GroupId { get; set; }

        public virtual User User { get; set; }
    }
}
