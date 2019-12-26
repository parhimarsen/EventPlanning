

using EventPlanning.Infrastructure.Models;
using EventPlanning.InfrastructureServices.Configurations;
using Microsoft.EntityFrameworkCore;

namespace EventPlanning.InfrastructureServices.Contexts
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }

        public virtual DbSet<InfrastructureUser> Users { get; set; }

        public virtual DbSet<InfrastructureEvent> Events { get; set; }

        public virtual  DbSet<InfrastructureField> Fields { get; set; }

        public virtual DbSet<InfrastructureEventFields> EventsFields { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder.ApplyConfiguration(new UsersConfiguration()));
            base.OnModelCreating(builder.ApplyConfiguration(new EventsConfiguration()));
            base.OnModelCreating(builder.ApplyConfiguration(new FieldsConfiguration()));
            base.OnModelCreating(builder.ApplyConfiguration(new EventFieldsConfiguration()));
        }
    }
}
