using ASPLAB_2.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPLAB_2.Data
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                    new User { Id = 1, Name = "Tom", Email = "random1@gmail.com" },
                    new User { Id = 2, Name = "Bob", Email = "random2@gmail.com" },
                    new User { Id = 3, Name = "Sam", Email = "random3@gmail.com" }
            );
        }
    }
}
