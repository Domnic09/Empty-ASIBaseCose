using Microsoft.AspNetCore.Mvc;

namespace ASI.Basecode.WebApp.Controllers
{
    public class DaeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
