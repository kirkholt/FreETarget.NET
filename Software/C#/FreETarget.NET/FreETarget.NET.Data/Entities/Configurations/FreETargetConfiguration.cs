using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreETarget.NET.Data.Entities.Configurations
{
    internal class FreETargetConfiguration : IEntityTypeConfiguration<FreETarget>
    {
        private readonly DatabaseFacade _database;

        public FreETargetConfiguration(DatabaseFacade database)
        {
            _database = database;
        }
        public void Configure(EntityTypeBuilder<FreETarget> builder)
        {

            builder.ToTable(typeof(FreETarget).Name);
            //builder.Property(b => b.Name).IsRequired().HasMaxLength(100);

        }
    }
}