using Microsoft.EntityFrameworkCore;
using Zoe.MsSample.Domain.AggregatesModel.CustomerAggregate;

namespace Zoe.MsSample.Infrastructure.Data.Context
{
    public class MsSampleDbContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }

        public MsSampleDbContext(DbContextOptions<MsSampleDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("MsSample");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MsSampleDbContext).Assembly);
        }
    }
}
