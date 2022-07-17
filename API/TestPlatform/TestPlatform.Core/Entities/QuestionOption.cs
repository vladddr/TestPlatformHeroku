using TestPlatform.Core.Base;

namespace TestPlatform.Core.Entities
{
    public class QuestionOption : BaseEntity
    {
        public string Content { get; set; }

        public decimal Points { get; set; }

        public virtual TestQuestion TestQuestion { get; set; }

        public int TestQuestionId { get; set; }
    }
}
