using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Kapow.Models;
using Kapow.Data;
using Microsoft.EntityFrameworkCore;
using Kapow.ViewModels;
using System.Data;
using Microsoft.AspNetCore.Authorization;

namespace Kapow.Controllers
{
    [Authorize(Roles = "User, Admin")]
    //[Authorize(Roles = "Admin")]
    public class RestaurantController : Controller
    {
        //Baseurl will allow the controller to talk to the api through the local host.  i think
        string Baseurl = "https://localhost:7157";
        private ProfileDbContext context;

        public RestaurantController(ProfileDbContext dbContext)
        {
            context = dbContext;
        }


        //Get request to list off all restaurants
        public async Task<IActionResult> Index()
        {
            List<RestaurantDto> allRestaurants = new List<RestaurantDto>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("/api/restaurant");
                if (response.IsSuccessStatusCode)
                {
                    var RestaurantResponse = response.Content.ReadAsStringAsync().Result;
                    allRestaurants = JsonConvert.DeserializeObject<List<RestaurantDto>>(RestaurantResponse);

                }
            }
            return View(allRestaurants);
        }

        [HttpGet]
        public async Task<IActionResult> Search(int id)
        {
            List<RestaurantDto> allRestaurants = new List<RestaurantDto>();
            Profile theProfile = context.Profiles.Find(id);
            if (theProfile.UserEmail != User.Identity.Name)
            {
                return Redirect("/profile");
            }
            ViewBag.theProfile = theProfile;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("/api/restaurant");
                if (response.IsSuccessStatusCode)
                {
                    var RestaurantResponse = response.Content.ReadAsStringAsync().Result;
                    allRestaurants = JsonConvert.DeserializeObject<List<RestaurantDto>>(RestaurantResponse);

                }
            }
            return View(allRestaurants);
        }

        [HttpPost]
        public async Task<IActionResult> Search(string selectTerm, string? keyword, string foodType, string searchType, string profileId)
        {
            List<RestaurantDto> restaurants = new List<RestaurantDto>();
            List<RestaurantDto> test = new List<RestaurantDto>();

            Profile selectedProfile = context.Profiles.Find(Int32.Parse(profileId));
            ViewBag.theProfile = selectedProfile;

            //GET data from api and house it in a variable
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("/api/restaurant");
                if (response.IsSuccessStatusCode)
                {
                    var RestaurantResponse = response.Content.ReadAsStringAsync().Result;
                    restaurants = JsonConvert.DeserializeObject<List<RestaurantDto>>(RestaurantResponse);
                    //ViewBag.restaurants = restaurants;
                }
            }
            if (searchType == "Name")
            {
                foreach (var r in restaurants)
                {
                    if (keyword != null)
                    {
                        if (r.Name.ToLower() == keyword.ToLower())
                        {
                            test.Add(r);
                        }
                    }
                }
            }
            else if (searchType == "Location")
            {
                foreach (var r in restaurants)
                {
                    if (r.Location == selectTerm)
                    {
                        test.Add(r);
                    }
                }
            }
            else if (searchType == "Food Type")
            {


                foreach (var r in restaurants)
                {
                    int num = (int)r.FoodTag;
                    if (num == Int32.Parse(foodType))
                    {
                        test.Add(r);
                    }
                }
            }
            return View("search", test);
        }


        public async Task<IActionResult> AddRestaurant(int id)
        {
            Profile theProfile = context.Profiles.Find(id);
            //List<RestaurantDto> possibleRestaurants = new List<RestaurantDto>();

            //test
            List<RestaurantDto> possibleRestaurants = context.Restaurants.ToList();


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("/api/restaurant");
                if (response.IsSuccessStatusCode)
                {
                    var RestaurantResponse = response.Content.ReadAsStringAsync().Result;
                    possibleRestaurants = JsonConvert.DeserializeObject<List<RestaurantDto>>(RestaurantResponse);
                }
            }
            AddRestaurantViewModel addRestaurantViewModel = new AddRestaurantViewModel(theProfile, possibleRestaurants);
            return View(addRestaurantViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> AddRestaurant(AddRestaurantViewModel addRestaurantViewModel, string profileId, string userRestaurant, string chosenRestaurant)
        {
            List<RestaurantDto> allRestaurants = new List<RestaurantDto>();


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("/api/restaurant");
                if (response.IsSuccessStatusCode)
                {
                    var RestaurantResponse = response.Content.ReadAsStringAsync().Result;
                    allRestaurants = JsonConvert.DeserializeObject<List<RestaurantDto>>(RestaurantResponse);
                }
            }


            Profile selectedProfile = context.Profiles.Find(Int32.Parse(profileId));

            if (userRestaurant == "Restaurant1")
            {
                selectedProfile.Restaurant1 = chosenRestaurant;
                context.SaveChanges();
                return Redirect("/Profile/About/" + profileId);
            }
            else if (userRestaurant == "Restaurant2")
            {
                selectedProfile.Restaurant2 = chosenRestaurant;
                context.SaveChanges();
                return Redirect("/Profile/About/" + profileId);
            }
            else if (userRestaurant == "Restaurant3")
            {
                selectedProfile.Restaurant3 = chosenRestaurant;
                context.SaveChanges();
                return Redirect("/Profile/About/" + profileId);
            }
            else if (userRestaurant == "Restaurant4")
            {
                selectedProfile.Restaurant4 = chosenRestaurant;
                context.SaveChanges();
                return Redirect("/Profile/About/" + profileId);
            }
            else if (userRestaurant == "Restaurant5")
            {
                selectedProfile.Restaurant5 = chosenRestaurant;
                context.SaveChanges();
                return Redirect("/Profile/About/" + profileId);
            }
            return View();
        }



        //if (ModelState.IsValid)
        //{
        //    int profileIds = addRestaurantViewModel.ProfileId;
        //    int restaurantId = addRestaurantViewModel.RestaurantId;
        //    int restaurantId2 = addRestaurantViewModel.RestaurantId2;
        //    int restaurantId3 = addRestaurantViewModel.RestaurantId3;
        //    int restaurantId4 = addRestaurantViewModel.RestaurantId4;
        //    int restaurantId5 = addRestaurantViewModel.RestaurantId5;



        //Profile theProfile = context.Profiles.Find(profileId);

        //foreach (var restaurant in allRestaurants)
        //{
        //    if (restaurant.Id == restaurantId)
        //    {
        //        theProfile.Restaurant1 = restaurant.Name;
        //    }
        //}

        //foreach (var restaurant in allRestaurants)
        //{
        //    if (restaurant.Id == restaurantId2)
        //    {
        //        theProfile.Restaurant2 = restaurant.Name;
        //    }
        //}

        //foreach (var restaurant in allRestaurants)
        //{
        //    if (restaurant.Id == restaurantId3)
        //    {
        //        theProfile.Restaurant3 = restaurant.Name;
        //    }
        //}
        //foreach (var restaurant in allRestaurants)
        //{
        //    if (restaurant.Id == restaurantId4)
        //    {
        //        theProfile.Restaurant4 = restaurant.Name;
        //    }
        //}
        //foreach (var restaurant in allRestaurants)
        //{
        //    if (restaurant.Id == restaurantId5)
        //    {
        //        theProfile.Restaurant5 = restaurant.Name;
        //    }
        //}


        //        //RestaurantDto theRestaurant = allRestaurants.Find(restaurantId);
        //        //theProfile.Restaurants.Add(theRestaurant);
        //        context.SaveChanges();
        //        return Redirect("/Profile/About/" + profileId);
        //    }
        //    return View();
        //}







        //    if (ModelState.IsValid)
        //    {
        //        int profileId = addRestaurantViewModel.ProfileId;
        //        int restaurantId = addRestaurantViewModel.RestaurantId;

        //        Profile theProfile = context.Profiles.Include(s => s.Restaurants).Where(j => j.Id == profileId).First();
        //        RestaurantDto theRestaurant = context.Restaurants.Where(s => s.Id == restaurantId).First();

        //        theProfile.Restaurants.Add(theRestaurant);

        //        context.SaveChanges();

        //        return Redirect("/Profile/About/" + profileId);
        //    }

        //    return View(addRestaurantViewModel);
        //}


    }
}
