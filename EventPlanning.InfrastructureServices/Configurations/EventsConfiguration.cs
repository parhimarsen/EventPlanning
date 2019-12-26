using EventPlanning.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventPlanning.InfrastructureServices.Configurations
{
    public class EventsConfiguration : IEntityTypeConfiguration<InfrastructureEvent>
    {
        public void Configure(EntityTypeBuilder<InfrastructureEvent> builder)
        {
            builder.ToTable("Events");
            builder.HasKey(_ => _.Id);
        }
    }
}
