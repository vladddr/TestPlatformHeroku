namespace TestPlatform.API.DataTransfer
{
    public class TestQuestionReadDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public bool IsMultiselect { get; set; }

        public virtual ICollection<QuestionOptionReadDto> 
            QuestionOptions { get; set; }
    }
}
