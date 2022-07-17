using TestPlatform.Core.Enums;

namespace TestPlatform.API.DataTransfer
{
    public class UserReadDto : UserUpdateDto
    {
        public int Id { get; set; }

        public Role UserRole { get; set; }
    }
}
