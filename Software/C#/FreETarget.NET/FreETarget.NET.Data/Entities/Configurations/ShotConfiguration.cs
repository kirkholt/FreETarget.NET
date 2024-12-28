using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

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

            builder.ToTable(typeof(Shot).Name);
            builder.HasKey(b => b.Id).HasName("PK_Shot");
            builder.Property(b => b.Id).ValueGeneratedNever();

            //builder.Property(b => b.Name).IsRequired().HasMaxLength(100);

        }
    }
}