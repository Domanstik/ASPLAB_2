using ASPLAB_2.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPLAB_2.Data
{
    public class StationeryContext : DbContext
    {
        public DbSet<Stationery> Stationeries { get; set; } = null!;
        public StationeryContext(DbContextOptions<StationeryContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stationery>().HasData(
                    new Stationery { Id = 1,    Name = "Pen",      Type = "sdf" },
                    new Stationery { Id = 2,    Name = "Pensil",   Type = "sdf" },
                    new Stationery { Id = 3,    Name = "Сopybook", Type = "sdf" }
            );
        }
    }
}
