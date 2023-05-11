using System;
using Kapow.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Kapow.Data
{
    public class ProfileDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Profile>? Profiles { get; set; }
        public DbSet<RestaurantDto>? Restaurants { get; set; }
     

        public ProfileDbContext(DbContextOptions<ProfileDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Profile>()
            //    .HasMany(p => p.Restaurants);


            ////set up your connection for many to many (skills to jobs)
            //modelBuilder.Entity<Profile>()
            //    .HasMany(e => e.Restaurants)
            //    .WithMany(e => e.Profiles)
            //    .UsingEntity(j => j.ToTable("ProfileRestaurants"));

            base.OnModelCreating(modelBuilder);
            SeedRoles(modelBuilder);
        }

        private void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData
                (
                new IdentityRole() { Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole() { Name = "User", ConcurrencyStamp = "2", NormalizedName = "User" }
                );
        }
    }
}
