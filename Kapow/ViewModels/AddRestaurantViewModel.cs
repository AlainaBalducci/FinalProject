using Kapow.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kapow.ViewModels
{
    public class AddRestaurantViewModel
    {
        public int ProfileId { get; set; }
        public Profile? Profile { get; set; }
        public List<SelectListItem>? Restaurants { get; set; }
        public int RestaurantId { get; set; }
        public int RestaurantId2 { get; set; }
        public int RestaurantId3 { get; set; }
        public AddRestaurantViewModel(Profile theProfile, List<RestaurantDto> possibleRestaurants) { 
            Restaurants = new List<SelectListItem>();
            foreach(var restaurant in possibleRestaurants)
            {
                Restaurants.Add(new SelectListItem
                {
                    Value = restaurant.Id.ToString(),
                    Text = restaurant.Name,
                });
            }
            Profile = theProfile;   
        }
        public AddRestaurantViewModel() { }
    }
}
