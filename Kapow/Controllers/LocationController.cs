using Kapow.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kapow.Controllers
{
    public class LocationController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Location location)
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}
