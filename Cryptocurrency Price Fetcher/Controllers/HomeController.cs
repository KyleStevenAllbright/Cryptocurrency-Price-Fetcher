using Microsoft.AspNetCore.Mvc;

namespace Cryptocurrency_Price_Fetcher.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
