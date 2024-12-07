using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreETarget.NET.Data.Entities.Configurations
{
    internal class TrackConfiguration : IEntityTypeConfiguration<Track>
    {
        private readonly DatabaseFacade _database;

        public TrackConfiguration(DatabaseFacade database)
        {
            _database = database;
        }
        public void Configure(EntityTypeBuilder<Track> builder)
        {

            builder.ToTable(typeof(Track).Name);
            //builder.Property(b => b.Name).IsRequired().HasMaxLength(100);
        }
    }
}