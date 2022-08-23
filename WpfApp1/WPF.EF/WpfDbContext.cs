using Microsoft.EntityFrameworkCore;
using System;
using WPF.domain.Models;

namespace WPF.EF
{
    public class WpfDbContext : DbContext
    {
        private readonly string connectionString = "Server=.;Database=SensorSystem;Trusted_Connection=True;MultipleActiveResultSets=true";

        public WpfDbContext()
        {

        }

        public DbSet<Sensor> Sensors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sensor>().HasKey(x => x.Id);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
