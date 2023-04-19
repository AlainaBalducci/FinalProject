using Microsoft.AspNetCore.Mvc;

namespace Kapow.Controllers
{
    public class RestaurantController : Controller
    {

        //Search bar function for list of restaurants
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create() 
        {
            return View();
        }

        public IActionResult Update() 
        {
        return View();
        }

        public IActionResult Delete() 
        { 
            return View(); 
        }    

        public IActionResult Detail()
        {
            return View();
        }
    }
}
