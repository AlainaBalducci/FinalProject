using Microsoft.AspNetCore.Mvc;

namespace Kapow.Controllers
{
    public class ProfileController : Controller
    {
        //List All Users
        public IActionResult Index()
        {
            return View();
        }

        //Add/create Profile
        public IActionResult Create()
        {
            return View();

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
        public IActionResult About()
        {
            return View();
        }

    }
}