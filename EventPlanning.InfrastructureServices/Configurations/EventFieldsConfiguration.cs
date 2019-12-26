using EventPlanning.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventPlanning.InfrastructureServices.Configurations
{
    public class EventFieldsConfiguration : IEntityTypeConfiguration<InfrastructureEventFields>
    {
        public void Configure(EntityTypeBuilder<InfrastructureEventFields> builder)
        {
            builder.ToTable("EventsFields");
            builder.HasKey(_ => new { _.EventId, _.FieldId });

            builder.HasOne(ef => ef.Event)
                .WithMany(e => e.EventsFields)
                .HasForeignKey(ef => ef.EventId);
    
            builder.HasOne(ef => ef.Field)
                .WithMany(e => e.EventsFields)
                .HasForeignKey(ef => ef.FieldId);
        }
    }
}
