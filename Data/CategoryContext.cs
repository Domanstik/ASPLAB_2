using ASPLAB_2.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPLAB_2.Data
{
    public class CategoryContext : DbContext
    {
        public DbSet<Category> Categories { get; set; } = null!;
        public CategoryContext(DbContextOptions<CategoryContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                    new Category { Id = 1, Name = "Vegetables", Description = "Vegetables" },
                    new Category { Id = 2, Name = "Fruits",     Description = "Fruits" },
                    new Category { Id = 3, Name = "Drinks",     Description = "Drinks" }
            );
        }
    }
}
