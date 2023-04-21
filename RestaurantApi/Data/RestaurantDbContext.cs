using Microsoft.EntityFrameworkCore;
using RestaurantApi.Models;
using System.Collections.Generic;

namespace RestaurantApi.Data
{
    public class RestaurantDbContext: DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options) { }
        public DbSet<Restaurant> Issues { get; set; }
    }
}
