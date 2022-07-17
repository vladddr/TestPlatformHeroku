namespace TestPlatform.API.DataTransfer
{
    public class TestQuestionDto
    {
        public string Title { get; set; }

        public bool IsMultiselect { get; set; }

        public virtual ICollection<QuestionOptionCreateDto> 
            QuestionOptions { get; set; }
    }
}
