using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestPlatform.Core.Entities;

namespace TestPlatform.DAL.EntitiesConfigurations
{
    internal class QuestionOptionEntityConfigurator : BaseEntityConfigurator<QuestionOption>
    {
        public override void Configure(EntityTypeBuilder<QuestionOption> questionOption)
        {
            base.Configure(questionOption);

            questionOption.ToTable("question_option")
                .HasKey(s => s.Id);

            questionOption.Property(to => to.Points)
                .HasColumnName("points")
                .HasDefaultValue(0);

            questionOption.Property(to => to.TestQuestionId)
                .HasColumnName("test_question_id");

            questionOption.Property(to => to.Content)
                .HasColumnName("content")
                .HasMaxLength(30);

            questionOption.HasOne(to => to.TestQuestion)
                .WithMany(tq => tq.QuestionOptions)
                .HasForeignKey(k => k.TestQuestionId);
        }
    }
}
