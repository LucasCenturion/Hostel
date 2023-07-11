using Dominio;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

namespace MVC.Controllers
{
    public class AgendaController : Controller
    {
        public IActionResult Agenda(int id)//Esta vista se encargará de mostrar al Huesped los datos del mismo y de la agenda antes de confirmar el ingreso al sistema de la agenda.
        {
            if (HttpContext.Session.GetString("Usuario") != null && HttpContext.Session.GetString("Rol") == "Dominio.Huesped")
            {
                Sistema unS = Sistema.Instancia;
                Actividad unaActividad = unS.GetActividad(id);
                ViewBag.Actividad = unaActividad;       
            }
            return View();
        }

        public IActionResult ListaDeAgendas()
        {
            if (HttpContext.Session.GetString("Usuario") != null && HttpContext.Session.GetString("Rol") == "Dominio.Operador")
            {
                try
                {
                    Sistema unS = Sistema.Instancia;
                    List<Agenda> listaAgenda = unS.DevolverAgenda();
                    ViewBag.Agenda = listaAgenda;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return View();
        }

        public IActionResult MiAgenda()
        {
            Sistema unS = Sistema.Instancia;
            string email = HttpContext.Session.GetString("Usuario");
            List<Agenda> listaAgenda = unS.DevolverAgenda();//traemos todas las listas
            List<Agenda> misAgendas = new List<Agenda>();//filtramos la lista del usuario
            foreach (Agenda agenda in listaAgenda)
            {
                if (agenda.Huesped.Email == email)
                {
                    misAgendas.Add(agenda);
                }
            }
            ViewBag.MisAgendas = misAgendas;
            return View();
        }

        public IActionResult RegistroAgenda(int id) 
        {
            try
            {
                Sistema unS = Sistema.Instancia;//Creo instancia
                Actividad unaActividad = unS.GetActividad(id);//Verifico la actividad a buscar con el parametro "id"
                string email = HttpContext.Session.GetString("Usuario");
                string pass = HttpContext.Session.GetString("Password");
                Usuario unU = unS.LeerUsuarioPwd(email, pass);
                ViewBag.Actividad = unaActividad;
                ViewBag.Usuario = unU;  
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View();
        }

        public IActionResult BuscarAgendaXDoc()
        {
            Sistema unS = Sistema.Instancia;
            List<Usuario> unU = unS.DevolverUsuario();
            ViewBag.Usuario = unU;
            return View();
        }

        public IActionResult ConfirmarAgenda()
        {
            Sistema unS = Sistema.Instancia;
            List<Agenda> unaAgenda = unS.DevolverAgenda();
            ViewBag.TodaslasAgendas = unaAgenda;
            return View();
        }


        [HttpPost]

        public IActionResult DevolverAgendaXDoc(Huesped.tipoDocumento TipoDeDocumento, string NroDocumento)
        {
            try
            {
                Sistema unS = Sistema.Instancia;
                Usuario unU = unS.GetHuesped(NroDocumento, TipoDeDocumento);
                if (unU != null)
                {
                    List<Agenda> unaAgenda = unS.DevolverListaAgenda(unU.Email);
                    ViewBag.DevolverAgendaXDoc = unaAgenda;
                }
                else
                {
                    throw new Exception("Huesped es nulo");
                }
                
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"No se ha encontrado: {ex.Message}";
            }
            return View();
        }

        [HttpPost]
        public IActionResult RegistroAgendaNueva(int identificador)
        {
            try
            {
                Sistema unS = Sistema.Instancia;
                Actividad unaActividad = unS.GetActividad(identificador);
                string email = HttpContext.Session.GetString("Usuario");
                string pass = HttpContext.Session.GetString("Password");
                Usuario unU = unS.LeerUsuarioPwd(email, pass);
                ViewBag.Actividad = unaActividad;
                ViewBag.Usuario = unU;
                
                if (unU is Huesped)
                {
                    Huesped unH = (Huesped)unU;

                    if (!unS.ValidarEdad(unH, unaActividad))
                    {
                        throw new Exception("Error al validar Edad!");
                    }

                    Agenda unAgendaNueva = new Agenda( unH, unaActividad);
                    unS.AltaAgenda(unAgendaNueva);
                    TempData["Mensaje"] = "Agenda agregada con éxito";
                }
                else
                {
                    throw new Exception("No se ha agregado la agenda");
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error Agenda: {ex.Message}";
            }

            return RedirectToAction("MiAgenda","Agenda");
        }

        [HttpPost]
        public IActionResult ConfirmarPago(int identificador)
        {
                
                Sistema unS = Sistema.Instancia;
                Agenda unaAgenda = unS.GetAgenda(identificador);
                try
                {
                    if(unaAgenda.EstaPago1 == Dominio.Agenda.EstaPago.PENDIENTE_PAGO)
                    {
                    unaAgenda.EstaPago1 = Dominio.Agenda.EstaPago.CONFIRMADA;
                    }
                    
                }

                catch (Exception ex)
                {
                    TempData["Error"] = $"Error al confirmar actividad: {ex.Message}";
                }

                return RedirectToAction("ConfirmarAgenda", "Agenda");
            
        }



        public IActionResult DevolverAgendaDelDia(DateTime fecha)
        {
            Sistema unS = Sistema.Instancia;
            List<Agenda> unaAgenda = unS.DevolverAgenda();
            try
            {
                List<Agenda> AgendaDelDia = new List<Agenda>();
                foreach (Agenda Agenda in unaAgenda)
                {
                    if (Agenda.Activdad.Fecha.Date == fecha.Date)
                    {
                        AgendaDelDia.Add(Agenda);
                    }
                }
                    if (fecha == null)
                    {
                        throw new Exception("La fecha ingresada no existe");
                    }
                if (AgendaDelDia.Count == 0)
                {
                    throw new Exception("No hay Agenda para la fecha ingresada");
                }
                ViewBag.DevolverAgendaDelDia = AgendaDelDia;
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error: {ex.Message}";
            }
            return View();
        }

    }
}
