using Cleverbit.CodingTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cleverbit.CodingTask.Data.EntityConfig
{
    public class UserMatchConfig : IEntityTypeConfiguration<UserMatch>
    {
        public void Configure(EntityTypeBuilder<UserMatch> builder)
        {
            builder.HasKey(k => new { k.MatchId, k.UserId });

            builder.HasOne(d => d.Match)
                .WithMany()
                .HasForeignKey(x => x.MatchId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(d => d.User)
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}