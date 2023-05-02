using System.Data;
using Kapow.Data;
using Kapow.Models;
using Kapow.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kapow.Controllers
{
    [Authorize(Roles = "User, Admin")]
    public class ProfileController : Controller
    {

        private ProfileDbContext context;

        public ProfileController(ProfileDbContext dbContext)
        {
            context = dbContext;
        }

        //List All Users
        public IActionResult Index()
        {
            // can add query to populate list with profiles that have a nonempty favorite restaurant -- maybe
            List<Profile> profiles = context.Profiles.ToList();
            return View(profiles);
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
                    Restaurants = ""
                };
                context.Profiles.Add(newProfile);
                context.SaveChanges();
                return Redirect("/profile");
            }
            return View("Create", addProfileViewModel);
        }

        //Delete Restaurants
        [Authorize(Roles = "Admin")]
        public IActionResult Delete()
        {
            ViewBag.profiles = context.Profiles.ToList();

            return View();
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





        //Edit Profile- change location, tags
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