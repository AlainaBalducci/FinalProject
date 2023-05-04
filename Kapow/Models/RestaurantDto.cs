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

        //public Profile? Profile { get; set; }
        //public int? ProfileId { get; set; }

        //public ICollection<Profile>? Profiles { get; set; }

        //public RestaurantDto(string name)
        //{
        //    Name = name;
        //    Profiles = new List<Profile>();
        //}

        public RestaurantDto()
        {
        }

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
