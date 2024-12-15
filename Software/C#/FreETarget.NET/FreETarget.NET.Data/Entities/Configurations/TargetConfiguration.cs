using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreETarget.NET.Data.Entities.Configurations
{
    internal class TargetConfiguration : IEntityTypeConfiguration<Target>
    {
        private readonly DatabaseFacade _database;

        public TargetConfiguration(DatabaseFacade database)
        {
            _database = database;
        }
        public void Configure(EntityTypeBuilder<Target> builder)
        {
            builder.ToTable(typeof(Target).Name);
            builder.Property(b => b.Name).IsRequired(true).HasMaxLength(100);
            builder.Property(b => b.Description).IsRequired(false).HasMaxLength(500);
            builder.Property(b => b.IpAddress).IsRequired(false).HasMaxLength(50);
        }
    }
}