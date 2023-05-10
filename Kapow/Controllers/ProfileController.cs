using Kapow.Data;
using Kapow.Models;
using Kapow.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NuGet.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace Kapow.Controllers
{
    [Authorize(Roles = "User, Admin")]
    //[Authorize(Roles = "Admin")]
    public class ProfileController : Controller
    {

        private ProfileDbContext context;
        string Baseurl = "https://localhost:7157";
        public ProfileController(ProfileDbContext dbContext)
        {
            context = dbContext;
        }




        //List All Users
        public IActionResult Index()
        {
            // can add query to populate list with profiles that have a nonempty favorite restaurant -- maybe
            List<Profile> profiles = context.Profiles.ToList();
            foreach(Profile profile in profiles)
            {
                if(profile.UserEmail == User.Identity.Name) {
                    //Redirect("/profile/about" + profile.Id);
                    //return Redirect("/profile/about/"+ profile.Id.ToString());
                    return View(profiles);
                }

            }
            return View("create");
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
            List<RestaurantDto>? allRestaurants = new List<RestaurantDto>();
            RestaurantDto? restaurant = null;

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
            int? id1 = Int32.Parse(profileId1);
            int? id2 = Int32.Parse(profileId2);

            Profile? selectedProfile1 = context.Profiles.Find(id1);
            Profile? selectedProfile2 = context.Profiles.Find(id2);

            List<string>? selectedProfile1List = selectedProfile1?.MakeRestaurantList();
            List<string>? selectedProfile2List = selectedProfile2?.MakeRestaurantList();

            if (selectedProfile1List.Count == 0 && selectedProfile2List.Count == 0)
            {
                ViewBag.error = "No restaurants have been added. Please update your restaurant list.";
                List<Profile> profiles = context.Profiles.ToList();
                return View(profiles);
            }

            foreach (string x in selectedProfile1List)
            {
                if (selectedProfile2List.Contains(x))
                {
                    foreach (var r in allRestaurants)
                    {
                        if (r.Name == x)
                        {
                            restaurant = r;
                            return View("MatchResult", restaurant);
                        }
                    }
                }
            }
            //combines the restaurant lists from 2 profiles, selects a random restaurant from the combined list. random.Next() method generates a random integer between 0 and the number of elements in combinedList
            List<string> combinedList = selectedProfile1List.Concat(selectedProfile2List).ToList();

            Random random = new Random();
            string randomRestaurant = combinedList[random.Next(combinedList.Count)];

            foreach (var r in allRestaurants)
            {
                if (r.Name == randomRestaurant)
                {
                    restaurant = r;
                    break;
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
            List<Profile>? profiles = context.Profiles.ToList();
            foreach (Profile p in profiles)
            {
                if (p.UserEmail == User.Identity.Name)
                {
                    ViewBag.error = "Sorry, you already have a profile with this account";
                    return View("Create", addProfileViewModel);
                }
            }

            if (ModelState.IsValid)
            {
                Profile newProfile = new Profile
                {
                    UserName = addProfileViewModel.UserName,
                    FirstName = addProfileViewModel.FirstName,
                    HomeBase = addProfileViewModel.HomeBase,
                    ImageUrl = addProfileViewModel.ImageUrl,
                    //Restaurants = ""
                    Restaurant1 = "",
                    Restaurant2 = "",
                    Restaurant3 = "",
                    Restaurant4 = "",
                    Restaurant5 = "",
                    UserEmail = User.Identity.Name
                };
                context.Profiles.Add(newProfile);
                context.SaveChanges();
                return Redirect("/profile/about/" + newProfile.Id);
            }
            return View("Create", addProfileViewModel);
        }

        //Delete profiles
        [Authorize(Roles = "Admin")]
        public IActionResult Delete()
        {
            List<Profile> profiles = context.Profiles.ToList();

            //ViewBag.profiles = context.Profiles.ToList();

            return View(profiles);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int[] profileIds)
        {
            foreach (int profileId in profileIds)
            {
                Profile theProfile = context.Profiles.Find(profileId);
                context.Profiles.Remove(theProfile);
            }

            context.SaveChanges();

            return Redirect("/profile");
        }

            public IActionResult Edit()
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

    

        