using Microsoft.EntityFrameworkCore;
using Saga.Console1.StateMachines;

namespace Saga.Console1
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