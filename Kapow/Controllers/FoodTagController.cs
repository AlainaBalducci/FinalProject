using Microsoft.AspNetCore.Mvc;

namespace Kapow.Controllers
{
    public class FoodTagController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
