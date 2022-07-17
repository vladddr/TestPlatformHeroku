using TestPlatform.Core.Base;

namespace TestPlatform.Core.Entities
{
    public class TestQuestion : BaseEntity
    {
        public string Title { get; set; }

        public bool IsMultiselect { get; set; }

        public virtual List<QuestionOption> QuestionOptions { get; set; }

        public int TestId { get; set; }

        public virtual Test Test { get; set; }
    }
}
