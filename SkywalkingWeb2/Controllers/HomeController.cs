using Microsoft.AspNetCore.Mvc;

namespace SkywalkingWeb2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
