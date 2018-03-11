using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data
{
    public class DronesContext : DbContext
    {        
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }

        public DronesContext(DbContextOptions<DronesContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Player>().HasIndex(p => p.Name).IsUnique();
            //modelBuilder.Entity<Game>()
            //    .HasOne(g => g.Player1)
            //    .WithMany(p => p.Games)
            //    .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
