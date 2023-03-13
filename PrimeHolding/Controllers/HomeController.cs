using Microsoft.AspNetCore.Mvc;

namespace PrimeHolding.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
