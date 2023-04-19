using Microsoft.AspNetCore.Mvc;

namespace Kapow.Controllers
{
    public class LocationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
