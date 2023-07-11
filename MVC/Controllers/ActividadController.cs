using Microsoft.AspNetCore.Mvc;
using Dominio;

namespace MVC.Controllers
{
    public class ActividadController : Controller
    {
        public IActionResult Index()
        {
            Sistema unS = Sistema.Instancia;
            List<Actividad> listaA = unS.DevolverActividad();
                ViewBag.ListaActividades = listaA;
            return View();
        }
    }
}
