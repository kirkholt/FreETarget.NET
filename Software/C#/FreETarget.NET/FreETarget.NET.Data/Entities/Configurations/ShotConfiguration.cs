using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreETarget.NET.Data.Entities.Configurations
{
    internal class ShotConfiguration : IEntityTypeConfiguration<Shot>
    {
        private readonly DatabaseFacade _database;

        public ShotConfiguration(DatabaseFacade database)
        {
            _database = database;
        }
        public void Configure(EntityTypeBuilder<Shot> builder)
        {

            builder.ToTable("Shot");
            builder.HasKey(b => b.Id).HasName("PK_Shot");
            //builder.Property(b => b.Name).IsRequired().HasMaxLength(100);

        }
    }
}