using System;
using Kapow.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Kapow.Data
{
    public class ProfileDbContext : DbContext
    {
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<FoodTag> FoodTags { get; set; }

        public ProfileDbContext(DbContextOptions<ProfileDbContext> options) : base(options)
        {
        }

    //    public override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
            
    //    }
    }
}
