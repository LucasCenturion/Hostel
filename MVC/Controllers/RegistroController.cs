using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class RegistroController : Controller
    {
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registro(Huesped unH)
        {
            try
            {
                Sistema unS = Sistema.Instancia;
                unS.AgregarUsuario(unH);
                return RedirectToAction("Registro");
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = $"Error en el alta de Huesped: {ex.Message}";
                return View();
            }
        }
    }
}
