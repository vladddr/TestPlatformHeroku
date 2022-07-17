namespace TestPlatform.API.DataTransfer
{
    public class StudentReadDto : UserReadDto
    {
        public GroupReadDto Group { get; set; }
    }
}
