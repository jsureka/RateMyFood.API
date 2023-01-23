using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RateMyFood.API.Entities;

namespace RateMyFood.API.DbContexts
{
    public class RateMyFoodContext : DbContext
    {
        private readonly IPasswordHasher<User> _passwordHasher;

        public DbSet<User> Users { get; set; } = null!;
        //public DbSet<Restaurants> PointsOfInterest { get; set; } = null!;

        public RateMyFoodContext(DbContextOptions<RateMyFoodContext> options, IPasswordHasher<User> passwordHasher)
            : base(options)
        {
            this._passwordHasher = passwordHasher;
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
            //modelBuilder.Entity<PointOfInterest>().HasData(
            //    new PointOfInterest("Central Park")
            //    {
            //        Id = 1,
            //        CityId = 1,
            //        Description = "The most visited urban park in United States"
            //    },
            //    new PointOfInterest("Cathedral")
            //    {
            //        Id = 2,
            //        CityId = 2,
            //        Description = "A 102-story skyscraper located in Midtown Manhattan"
            //    },
            //    new PointOfInterest("Empire State Building")
            //    {
            //        Id = 3,
            //        CityId = 2,
            //        Description = "The tallest bulding of the new york"
            //    },
            //    new PointOfInterest("The Louvre")
            //    {
            //        Id = 4,
            //        CityId = 1,
            //        Description = "The world's largest museum"
            //    }
            //    );
            base.OnModelCreating(modelBuilder);
        }

    }
}
