using Cleverbit.CodingTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cleverbit.CodingTask.Data.EntityConfig
{
    public class MatchConfig : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder.HasKey(u => u.Id);

            builder.HasOne(d => d.MatchType)
                .WithMany()
                .HasForeignKey(x => x.MatchTypeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}