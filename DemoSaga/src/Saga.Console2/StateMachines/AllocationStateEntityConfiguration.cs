using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Saga.Console2.StateMachines
{
    class AllocationStateEntityConfiguration :
        IEntityTypeConfiguration<AllocationState>
    {
        public void Configure(EntityTypeBuilder<AllocationState> builder)
        {
            builder.HasKey(c => c.CorrelationId);

            builder.Property(c => c.CorrelationId)
                .ValueGeneratedNever()
                .HasColumnName("CorrelationId");

            builder.Property(c => c.CurrentState).IsRequired();

           
        }
    }
}