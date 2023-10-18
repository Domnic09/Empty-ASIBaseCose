using Microsoft.AspNetCore.Mvc;

namespace NavOS.Basecode.WebApp.Controllers
{
    public class DaeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
