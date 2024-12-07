﻿using FreETarget.NET.Data.Entities.Configurations;
using Microsoft.EntityFrameworkCore;

namespace FreETarget.NET.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<Entities.FreETarget> FreETargetDbSet { get; set; }
        public DbSet<Entities.Range> RangeDbSet { get; set; }
        public DbSet<Entities.Session> SessiondDbSet  { get; set; }
        public DbSet<Entities.Shot> ShotDbSet { get; set; }
        public DbSet<Entities.Track> TrackDbSet { get; set; }

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
