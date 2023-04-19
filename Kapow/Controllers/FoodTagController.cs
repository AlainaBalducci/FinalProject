using Kapow.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kapow.Controllers
{
    public class FoodTagController : Controller
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
        public IActionResult Create(FoodTag foodTag)
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}
