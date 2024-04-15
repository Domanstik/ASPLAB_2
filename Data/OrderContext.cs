using ASPLAB_2.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPLAB_2.Data
{
    public class OrderContext : DbContext
    {
        public DbSet<Order> Orders { get; set; } = null!;
        public OrderContext(DbContextOptions<OrderContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasData(
                    new Order { Id = 1, User = "Tom", ProductsCost = 100 },
                    new Order { Id = 2, User = "Bob", ProductsCost = 120 },
                    new Order { Id = 3, User = "Sam", ProductsCost = 150 }
            );
        }
    }
}
