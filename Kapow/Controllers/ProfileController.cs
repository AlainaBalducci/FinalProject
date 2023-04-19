using Microsoft.AspNetCore.Mvc;

namespace Kapow.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
