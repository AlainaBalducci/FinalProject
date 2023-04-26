using System.ComponentModel.DataAnnotations.Schema;

namespace Kapow.Models
{
    public class RestaurantDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }
        public string? Location { get; set; }
        [NotMapped]
        public FoodTag FoodTag { get; set; }

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



  //old resturant class feilds and constructors in case we need to revert 

    //public int Id { get; set; }
    //    public string? Name { get; set; }
    //    public string? Url { get; set; }
    //    public Location? Location { get; set; }
    //    public ICollection<FoodTag>? FoodTags { get; set; }

//    public RestaurantDto(string? name, string? url, Location? location, FoodTag? food)
//    {
//        Name = name;
//        Url = url;
//        Location = location;
//        FoodTags = new List<FoodTag>();
//    }

//    public RestaurantDto() { }

//    public override bool Equals(object? obj)
//    {
//        return obj is RestaurantDto restaurant &&
//               Id == restaurant.Id;
//    }

//    public override int GetHashCode()
//    {
//        return HashCode.Combine(Id);
//    }
//}
