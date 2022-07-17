using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestPlatform.Core.Entities;

namespace TestPlatform.DAL.EntitiesConfigurations
{
    internal class TestQuestioneEntiryConfigurator : BaseEntityConfigurator<TestQuestion>
    {
        public override void Configure(EntityTypeBuilder<TestQuestion> testQuestion)
        {
            base.Configure(testQuestion);

            testQuestion.ToTable("test_question")
                .HasKey(t => t.Id);

            testQuestion.Property(tq => tq.IsMultiselect)
                .HasColumnName("is_multiselect")
                .HasDefaultValue(false)
                .IsRequired();

            testQuestion.Property(tq => tq.Title)
                .HasColumnName("title")
                .HasMaxLength(30)
                .IsRequired();

            testQuestion.HasMany(tq => tq.QuestionOptions)
                .WithOne(to => to.TestQuestion)
                .HasForeignKey(tq => tq.TestQuestionId);

            testQuestion.HasOne(tq => tq.Test)
                .WithMany(t => t.Questions)
                .HasForeignKey(t => t.TestId);
        }
    }
}
