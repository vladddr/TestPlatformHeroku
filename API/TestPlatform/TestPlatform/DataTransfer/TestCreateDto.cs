namespace TestPlatform.API.DataTransfer
{
    public class TestCreateDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int TeacherId { get; set; }

        public ICollection<TestQuestionDto> 
            Questions { get; set; }

        public ICollection<BaseEntityDto>
            AssignedGroups { get; set; }
    }
}
