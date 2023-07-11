using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class LoginController : Controller
    {

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Login(string email, string password)
        {
            Sistema unS = Sistema.Instancia;
            Usuario unU = unS.LeerUsuarioPwd(email, password);
            if (unU != null)
            {
                HttpContext.Session.SetString("Usuario", email);
                HttpContext.Session.SetString("Password", password);
                HttpContext.Session.SetString("Rol", unU.GetType().ToString());
                if (unU is Usuario) {
                    return RedirectToAction("inicio", "Inicio");
                }
            }
            ViewBag.Mensaje = "Credenciales Incorrectas";
            return View();

        }

        public IActionResult Logout()//Logout 
        {
            HttpContext.Session.Clear();
            return Redirect("/Inicio/inicio");
        }
    }
}
