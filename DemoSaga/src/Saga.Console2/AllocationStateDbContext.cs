using Microsoft.EntityFrameworkCore;
using Saga.Console2.StateMachines;

namespace Saga.Console2
{
    public class AllocationStateDbContext :
        DbContext
    {
        public AllocationStateDbContext(DbContextOptions options)
            : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AllocationStateEntityConfiguration());
        }

        public DbSet<AllocationState> AllocationStates { get; set; }
    }
}