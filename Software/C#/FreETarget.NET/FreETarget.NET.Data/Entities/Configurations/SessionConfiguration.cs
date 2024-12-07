using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreETarget.NET.Data.Entities.Configurations
{
    internal class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        private readonly DatabaseFacade _database;

        public SessionConfiguration(DatabaseFacade database)
        {
            _database = database;
        }
        public void Configure(EntityTypeBuilder<Session> builder)
        {

            builder.ToTable(typeof(Session).Name);
            //builder.Property(b => b.Name).IsRequired().HasMaxLength(100);

        }
    }
}