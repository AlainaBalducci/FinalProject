using Microsoft.AspNetCore.Mvc;

namespace Kapow.Controllers
{
    public class RestaurantController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
