using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class MisDatos : Controller
    {
        public IActionResult Mis_Datos()
        {
            Sistema unS = Sistema.Instancia;
            List<Usuario> listaUsuarios = unS.DevolverUsuario();
            ViewBag.ListaUsuarios = listaUsuarios;
            return View();
        }
    }
}
