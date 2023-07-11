using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class ProveedorController : Controller
    {
        public IActionResult Index()
        {
            Sistema unS = Sistema.Instancia;
            List<Proveedor> listaProveedores = unS.DevolverProveedores();
            ViewBag.ListaProveedores = listaProveedores;
            return View();
        }

        [HttpPost]

        public IActionResult CambiarValorPromo(string nombre, int descuento)
        {
            try
            {
                Sistema unS = Sistema.Instancia;
                Proveedor unProveedor = null;
                unProveedor = unS.GetProveedor(nombre);
                if (unProveedor == null)
                    {
                      throw new Exception("No hay un Proveedor para modificar");
                    }
                else
                {
                    unProveedor.Descuento = descuento;
                    unProveedor.Validar();
                }
                TempData["Mensaje"] = "Descuento cambiado con éxito";
                
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error al cambiar Descuento: {ex.Message}";
            }

            return RedirectToAction("Index");
        }

        



    }
}
