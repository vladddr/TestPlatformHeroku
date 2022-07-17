using TestPlatform.Core.Base;
using TestPlatform.Core.Enums;

namespace TestPlatform.Core.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
            UserRole = Role.Administrator;
        }

        // Unique User Login
        public string Login { get; set; }

        // User Password
        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        // User Role
        public Role UserRole { get; set; }

        public Student? Student { get; set; }

        public Teacher? Teacher { get; set; }
    }
}
