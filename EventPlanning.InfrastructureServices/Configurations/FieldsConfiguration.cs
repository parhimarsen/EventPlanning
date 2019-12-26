
using EventPlanning.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventPlanning.InfrastructureServices.Configurations
{
    public class FieldsConfiguration : IEntityTypeConfiguration<InfrastructureField>
    {
        public void Configure(EntityTypeBuilder<InfrastructureField> builder)
        {
            builder.ToTable("Fields");
            builder.HasKey(_ => _.Id);
        }
    }
}
