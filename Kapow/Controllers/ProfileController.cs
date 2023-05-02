using Kapow.Data;
using Kapow.Models;
using Kapow.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Newtonsoft.Json;
using NuGet.Protocol;
using System;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;

namespace Kapow.Controllers
{
    [Authorize(Roles = "User, Admin")]

    public class ProfileController : Controller
    {
        string Baseurl = "https://localhost:7157";
        private ProfileDbContext context;

        public ProfileController(ProfileDbContext dbContext)
        {
            context = dbContext;
        }

        //List All Users
        //Will now also have checkboxes with each profile
        public IActionResult Index()
        {
            // can add query to populate list with profiles that have a nonempty favorite restaurant -- maybe
            List<Profile> profiles = context.Profiles.ToList();
            return View(profiles);

            
        }
        [HttpGet]
        public IActionResult Match()
        {
            List<Profile> profiles = context.Profiles.ToList();
            return View(profiles);
        }

        [HttpPost]
        public async Task<IActionResult> Match(string profileId1, string profileId2)
        {
            List<RestaurantDto> allRestaurants = new List<RestaurantDto>();
            RestaurantDto restaurant = null;

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
            int id1 = Int32.Parse(profileId1);
            int id2 = Int32.Parse(profileId2);

            Profile selectedProfile1 = context.Profiles.Find(id1);
            Profile selectedProfile2 = context.Profiles.Find(id2);

            List<string> selectedProfile1List = selectedProfile1.MakeRestaurantList();
            List<string> selectedProfile2List = selectedProfile2.MakeRestaurantList();

            foreach(string x in selectedProfile1List)
            {
                if (selectedProfile2List.Contains(x))
                {
                    foreach(var r in allRestaurants)
                    {
                        if(r.Name == x)
                        {
                            restaurant = r;
                            return View("MatchResult",restaurant);
                        }
                    }
                }
            }

            var random = new Random();
            int index = random.Next(0, selectedProfile1List.Count);
            foreach (var r in allRestaurants)
            {
                if (r.Name == selectedProfile1List[index])
                {
                    restaurant = r;
                    
                }
            }

            return View("MatchResult", restaurant);
        }





        public IActionResult MatchResult()
        {
            return View();
        }

        //Add/create Profile
        public IActionResult Create()
        {
            AddProfileViewModel addProfileViewModel = new AddProfileViewModel();
            return View(addProfileViewModel);

        }

        [HttpPost]
        public IActionResult Create(AddProfileViewModel addProfileViewModel)
        {
            if (ModelState.IsValid)
            {
                Profile newProfile = new Profile
                {
                    UserName = addProfileViewModel.UserName,
                    FirstName = addProfileViewModel.FirstName,
                    HomeBase = addProfileViewModel.HomeBase,
                    ImageUrl = addProfileViewModel.ImageUrl,
                    Restaurant1 = "",
                    Restaurant2 = "",
                    Restaurant3 = ""
                };
                context.Profiles.Add(newProfile);
                context.SaveChanges();
                return Redirect("/profile");
            }
            return View("Create", addProfileViewModel);
        }

        //Delete Restaurants
        public IActionResult Delete()
        {
            return View();

        }

        //Edit Profile- change location, tags
        public IActionResult Edit()
        {
            return View();
        }

        //Add restaurants to profile
        public IActionResult AddRest()
        {
            return View();
        }

        //Show details of an individual profile
        public IActionResult About(int id)
        {
            Profile selectedProfile = context.Profiles.Find(id);
            return View(selectedProfile);
        }
        



    }
}