using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class HuespedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
