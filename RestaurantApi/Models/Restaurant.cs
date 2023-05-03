using Kapow.Models;
using System.ComponentModel.DataAnnotations;

namespace RestaurantApi.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Url { get; set; }
        [Required]
        public string? Location { get; set; }
        [Required]
        public FoodTag FoodTag { get; set; }
        public ICollection<Profile>? Profiles { get; set; }
        public Restaurant(){}
    }
    public enum FoodTag
    {
        Mexican,
        Mediterranean,
        Thai,
        Vegan,
        Persian,
        Pizza,
        Vietnamese,
        American,
        Steak,
        Seafood,
        Barbecue,
        Greek,
        Breakfast,
        Brazillian
    }
}
