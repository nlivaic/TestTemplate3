using MassTransit;
using Microsoft.EntityFrameworkCore;
using TestTemplate3.Core.Entities;

namespace TestTemplate3.Data
{
    public class TestTemplate3DbContext : DbContext
    {
        public TestTemplate3DbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Foo> Foos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddInboxStateEntity();
            modelBuilder.AddOutboxMessageEntity();
            modelBuilder.AddOutboxStateEntity();
        }
    }
}
