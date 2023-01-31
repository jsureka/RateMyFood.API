using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RateMyFood.API.Entities;

namespace RateMyFood.API.DbContexts
{
    public class RateMyFoodContext : DbContext
    {

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Restaurant> Restaurants { get; set; } = null!;
        public DbSet<MenuItem> MenuItems { get; set; } = null;
        public DbSet<Review> Reviews { get; set; } = null;


        public RateMyFoodContext(DbContextOptions<RateMyFoodContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    UserName = "jsureka",
                    Password = "password",
                    Email = "jitesh@provider.com",

                    FirstName = "Jitesh",
                    LastName = "Sureka",
                    Role = "Admin"
                },
                new User()
                {
                    Id = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    UserName = "david",
                    Password = "password",
                    Email = "david@provider.com",

                    FirstName = "David",
                    LastName = "Reigns",
                    Role = "General"
                },
                new User()
                {
                    Id = Guid.Parse("24810dfc-2d94-4cc7-aab5-cdf98b83f0c9"),
                    UserName = "emma",
                    Password = "password",
                    Email = "emma@provider.com",
                    FirstName = "Emma",
                    LastName = "Flagg",
                    Role = "General"
                }
                );
            modelBuilder.Entity<MenuItem>().HasIndex(c => c.Name).HasDatabaseName("IDX_NAME");
            modelBuilder.Entity<Restaurant>().HasIndex(c => c.Name).HasDatabaseName("IDX_NAME");
            base.OnModelCreating(modelBuilder);
        }

    }
}
