using Cleverbit.CodingTask.Data.EntityConfig;
using Cleverbit.CodingTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cleverbit.CodingTask.Data
{
    public class CodingTaskContext : DbContext
    {
        public CodingTaskContext(DbContextOptions<CodingTaskContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<MatchType> MatchTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new MatchConfig());
            modelBuilder.ApplyConfiguration(new MatchTypeConfig());
            modelBuilder.ApplyConfiguration(new UserMatchConfig());
        }
    }
}
