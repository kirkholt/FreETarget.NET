using FreETarget.NET.Data.Entities.Configurations;
using Microsoft.EntityFrameworkCore;

namespace FreETarget.NET.Data
{
    internal class AppDbContext: DbContext
    {
        DbSet<Entities.FreETarget> FreETargetDbSet { get; set; }
        DbSet<Entities.Range> RangeDbSet { get; set; }
        DbSet<Entities.Session> SessiondDbSet  { get; set; }
        DbSet<Entities.Shot> ShotDbSet { get; set; }
        DbSet<Entities.Track> TrackDbSet { get; set; }

        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Vi kan ikke bruge denne metode, da vi ikke kan injecte DatabaseFacade
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            modelBuilder.ApplyConfiguration(new FreETargetConfiguration(this.Database));
            modelBuilder.ApplyConfiguration(new RangeConfiguration(this.Database));
            modelBuilder.ApplyConfiguration(new SessionConfiguration(this.Database));
            modelBuilder.ApplyConfiguration(new ShotConfiguration(this.Database));
            modelBuilder.ApplyConfiguration(new TrackConfiguration(this.Database));
        }
    }
}
