using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class Huespedes : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult MisDatos()
        {
            return View();
        }
    }
}
