using Cleverbit.CodingTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cleverbit.CodingTask.Data.EntityConfig
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.UserName).HasMaxLength(60).IsRequired();
            builder.Property(u => u.Password).IsRequired();
        }
    }
}