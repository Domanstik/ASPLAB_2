using ASPLAB_2.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPLAB_2.Data
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; } = null!;
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                    new Product { Id = 1, Name = "Tomato", Prise = 100 },
                    new Product { Id = 2, Name = "Potato", Prise = 120 },
                    new Product { Id = 3, Name = "Cucumber", Prise = 150 }
            );
        }
    }
}
