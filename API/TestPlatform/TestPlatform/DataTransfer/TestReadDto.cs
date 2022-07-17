namespace TestPlatform.API.DataTransfer
{
    public class TestReadDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public ICollection<TestQuestionReadDto>
            Questions { get; set; }

        public ICollection<GroupReadDto>
            AssignedGroups { get; set; }
    }
}
