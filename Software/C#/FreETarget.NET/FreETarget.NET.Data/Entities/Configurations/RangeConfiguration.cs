using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreETarget.NET.Data.Entities.Configurations
{
    internal class RangeConfiguration : IEntityTypeConfiguration<Range>
    {
        private readonly DatabaseFacade _database;

        public RangeConfiguration(DatabaseFacade database)
        {
            _database = database;
        }
        public void Configure(EntityTypeBuilder<Range> builder)
        {

            builder.ToTable(typeof(Range).Name);
            builder.Property(b => b.Name).IsRequired().HasMaxLength(100);
        }
    }
}