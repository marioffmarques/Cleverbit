using Cleverbit.CodingTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cleverbit.CodingTask.Data.EntityConfig
{
    public class MatchTypeConfig : IEntityTypeConfiguration<MatchType>
    {
        public void Configure(EntityTypeBuilder<MatchType> builder)
        {
            builder.ToTable("MatchType");
            builder.HasKey(u => u.Id);
            builder.Property(m => m.Name).HasMaxLength(60);
        }
    }
}