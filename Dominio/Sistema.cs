using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Sistema
    {
        private static Sistema instancia;
        private List<Usuario> usuarios = new List<Usuario>();
        private List<Huesped> huespedes = new List<Huesped>();
        private List<Proveedor> proveedores = new List<Proveedor>();
        private List<Operador> operadores = new List<Operador>();
        private List<Actividad> actividades = new List<Actividad>();
        private List<Agenda> agendas = new List<Agenda>();
        public List<string> erroresPrecarga = new List<string>();

        public static Sistema Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new Sistema();
                }
                return instancia;
            }
        }


        public Sistema()
        {
            #region Precarga Proveedor
            AltaProveedor(new Proveedor("DreamWorks S.R.L.", "23048549", "Suarez 3380 Apto 304", 10));
            AltaProveedor(new Proveedor("Estela Umpierrez S.A.", "33459678", "Lima 2456", 7));
            AltaProveedor(new Proveedor("TravelFun", "29152020", "Misiones 1140", 9));
            AltaProveedor(new Proveedor("Rekreation S.A.", "29162019", "Bacacay 1211", 11));
            AltaProveedor(new Proveedor("Alonso & Umpierrez", "24051920", "18 de Julio 1956 Apto 4", 10));
            AltaProveedor(new Proveedor("Electric Blue", "26018945", "Cooper 678", 5));
            AltaProveedor(new Proveedor("Lúdica S.A.", "26142967", "Dublin 560", 4));
            AltaProveedor(new Proveedor("Gimenez S.R.L.", "29001010", "Andes 1190", 7));
            AltaProveedor(new Proveedor("", "22041120", "Agraciada 2512 Apto. 1", 8));
            AltaProveedor(new Proveedor("Norberto Molina", "22001189", "Paraguay 2100", 9));
            #endregion

            #region Precarga Huesped
            AgregarUsuario(new Huesped(Huesped.tipoDocumento.CI, "5538253", "LUCAS", "CENTURION", "lacm.lucas@gmail.com", "12345678", "A1", DateTime.Parse("10/12/1991"), Huesped.fidelizacion.NIVEL1));
            AgregarUsuario(new Huesped(Huesped.tipoDocumento.PASAPORTE, "55382536", "LUCAS", "MIGUEL", "lacm.@gmail.com", "12345678", "A1", DateTime.Parse("02/04/1994"), Huesped.fidelizacion.NIVEL4));
            #endregion

            #region Precarga Operador
            AgregarUsuario(new Operador("LUCAS", "CENTURION", "admin@admin.com", "password", DateTime.Parse("10/01/2023")));


            #endregion

            #region Precarga Actividad

            #region Precarga Actividad Propia
            AgregarActividad(new ActividadPropia(1004, "Kangoo Jumps", "El huesped sera integrante de una experencia de una sesion de 30 de Kangoo Jumps", DateTime.Parse("2023/6/19"), 2, 18, 580, "Encargado de gimnsaio", ActividadPropia.lugares.GIMNASIO, "NO"));
            AgregarActividad(new ActividadPropia(1005, "Degustacion de Vinos", "Sera integrante de una charla con un profesional y de una degustacion de diferentes vinos", DateTime.Parse("2023/12/2"), 15, 21, 950, "Encargado de hotel", ActividadPropia.lugares.PATIO_TERRAZA, "SI"));
            AgregarActividad(new ActividadPropia(1006, "Show de Magia", "Un show de magia para todo publico", DateTime.Parse("2023/6/3"), 35, 0, 250, "Encargado de hotel", ActividadPropia.lugares.SALON_PLANTA_BAJA, "NO"));
            AgregarActividad(new ActividadPropia(1011, "Aqua Zumba", "Una solucion divertida para hacer ejercicio", DateTime.Parse("2023/7/4"), 18, 10, 420, "Encargado de hotel", ActividadPropia.lugares.PISCINA_INTERIOR, "NO"));
            AgregarActividad(new ActividadPropia(1012, "Torneo de PingPong", "Se realizara un torneo con premio a una canasta de comida", DateTime.Parse("2023/5/5"), 20, 12, 220, "Encargado de hotel", ActividadPropia.lugares.SALON_PLANTA_BAJA, "NO"));
            AgregarActividad(new ActividadPropia(1013, "Reto de Comida", "El huesped que pueda terminar una pizza en menos tiempo ganara.", DateTime.Parse("2023/6/5"), 5, 20, 150, "Encargado de hotel", ActividadPropia.lugares.PATIO_TERRAZA, "SI"));
            AgregarActividad(new ActividadPropia(1021, "Reto Cervezero", "El huesped que pueda terminar una cerveza en menos tiempo ganara.", DateTime.Parse("2023/8/3"), 5, 19, 150, "Encargado de hotel", ActividadPropia.lugares.PATIO_TERRAZA, "SI"));
            AgregarActividad(new ActividadPropia(1022, "Dia de Spa", "Actividad para relajarse y disfrutar", DateTime.Parse("2023/7/2"), 10, 18, 350, "Encargado de hotel", ActividadPropia.lugares.SALA_SPA, "NO"));
            AgregarActividad(new ActividadPropia(1023, "Masaje de Piedras Calientes", "Actividad para relajarse y disfrutar", DateTime.Parse("2023/5/4"), 10, 18, 350, "Encargado de hotel", ActividadPropia.lugares.SALA_SPA, "NO"));
            AgregarActividad(new ActividadPropia(1024, "Sesion de Crossfit", "Tendra una sesion de 30m de puro ejercicio", DateTime.Parse("2023/11/1"), 15, 18, 0, "Encargado de hotel", ActividadPropia.lugares.GIMNASIO, "NO"));
            #endregion

            #region Precarga Actividad Tercializada
            AgregarActividad(new ActividadTercerizada(1001, "Paseo en cuatriciclo", "Sera trasladado del hotel a los medanos donde lo estaran esperando cuatriciclos en los que se paseara", DateTime.Parse("2023/7/1"), 25, 12, 350, GetProveedor("Norberto Molina"), true, DateTime.Parse("2023/4/28")));
            AgregarActividad(new ActividadTercerizada(1002, "Torneo de Ajederez", "La oportunidad de demostrar tus habilidades en el ajedrez", DateTime.Parse("2023/5/2"), 30, 15, 220, GetProveedor("Gimenez S.R.L."), true, DateTime.Parse("2023/4/25")));
            AgregarActividad(new ActividadTercerizada(1003, "Zumba", "La mejor manera de mezclar el entrenamineto con el baile.", DateTime.Parse("2023/5/3"), 15, 17, 200, GetProveedor("Rekreation S.A."), true, DateTime.Parse("2023/4/30")));
            AgregarActividad(new ActividadTercerizada(1007, "Show de Circo", "TravelFun trae el mejor show de circo  la ciudad", DateTime.Parse("2023/5/4"), 150, 0, 450, GetProveedor("TravelFun"), true, DateTime.Parse("2023/4/20")));
            AgregarActividad(new ActividadTercerizada(1008, "Show de Magia", "Show de magia a cargo de uno de los magos mas importantes de la ciudad", DateTime.Parse("2023/5/5"), 100, 0, 350, GetProveedor("Estela Umpierrez S.A."), true, DateTime.Parse("2023/4/21")));
            AgregarActividad(new ActividadTercerizada(1009, "Torneo de PingPong", "Demuestra tus habilidades en el pingpong", DateTime.Parse("2023/5/1"), 24, 12, 180, GetProveedor("Lúdica S.A."), true, DateTime.Parse("2023/4/25")));
            AgregarActividad(new ActividadTercerizada(1010, "Baile Nocturno", "Baile apto para +18, Puertas abiertas a partir de 00:30", DateTime.Parse("2023/5/2"), 200, 18, 470, GetProveedor("Alonso & Umpierrez"), true, DateTime.Parse("2023/4/29")));
            AgregarActividad(new ActividadTercerizada(1014, "Show de Drones", "TravelFun trae su espetacular show de drones", DateTime.Parse("2023/5/3"), 150, 0, 0, GetProveedor("TravelFun"), true, DateTime.Parse("2023/4/23")));
            AgregarActividad(new ActividadTercerizada(1015, "Expo Barber Show", "Los mejores barberos compitiendo entre si", DateTime.Parse("2023/5/4"), 120, 0, 330, GetProveedor("Norberto Molina"), true, DateTime.Parse("2023/4/28")));
            AgregarActividad(new ActividadTercerizada(1016, "Show de musica", "Varias Bandas Musicales Daran un concierto", DateTime.Parse("2023/5/5"), 100, 0, 330, GetProveedor("DreamWorks S.R.L."), true, DateTime.Parse("2023/4/19")));
            AgregarActividad(new ActividadTercerizada(1017, "Exposicion de arte", "Las pinturas mas conocidas del pais en una sola sala no te lo pierdas. ", DateTime.Parse("2023/5/1"), 85, 22, 950, GetProveedor("Alonso & Umpierrez"), true, DateTime.Parse("2023/4/27")));
            AgregarActividad(new ActividadTercerizada(1018, "Pool Party", "La fiesta mas alocada divertida, Evento para +18", DateTime.Parse("2023/5/2"), 180, 18, 400, GetProveedor("Rekreation S.A."), true, DateTime.Parse("2023/4/29")));
            AgregarActividad(new ActividadTercerizada(1019, "Show de Fuegos Artificiales", "Una noche magica y iluminida, Incluye la cena", DateTime.Parse("2023/5/3"), 110, 0, 850, GetProveedor("Norberto Molina"), true, DateTime.Parse("2023/4/16")));
            AgregarActividad(new ActividadTercerizada(1020, "Reto de comida", "El competidor que pueda terminar una pizza en menos tiempo se llevara el premio", DateTime.Parse("2023/5/4"), 5, 18, 320, GetProveedor("Lúdica S.A."), true, DateTime.Parse("2023/4/22")));
            AgregarActividad(new ActividadTercerizada(1025, "Show de Motocross", "Veras los mejores saltos, acrobacias y demas en motos", DateTime.Parse("2023/5/5"), 200, 12, 550, GetProveedor("TravelFun"), true, DateTime.Parse("2023/4/26")));
            #endregion

            #endregion
            //AltaAgenda(new Agenda(GetHuesped("5538253", Huesped.tipoDocumento.CI), GetActividad(1005)));
            AltaAgenda(new Agenda(GetHuesped("5538253", Huesped.tipoDocumento.CI), GetActividad(1024)));
            AltaAgenda(new Agenda(GetHuesped("5538253", Huesped.tipoDocumento.CI), GetActividad(1004)));
            AltaAgenda(new Agenda(GetHuesped("55382536", Huesped.tipoDocumento.PASAPORTE), GetActividad(1024)));
            AltaAgenda(new Agenda(GetHuesped("55382536", Huesped.tipoDocumento.PASAPORTE), GetActividad(1004)));
        }

        #region Usuario
        public void AgregarUsuario(Huesped huesped)
        {
            try
            {
                if (huesped == null)
                {
                    throw new Exception("No se puede agregar un Huesped vacio");
                }
                huesped.ValidarDatosHuesped();
                VerificarHuespedExiste(huesped);
                huespedes.Add(huesped);
                usuarios.Add(huesped);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AgregarUsuario(Operador operador)
        {
            try
            {
                if (operador == null)
                {
                    throw new Exception("No se puede agregar un Operador vacio");
                }
                operadores.Add(operador);
                usuarios.Add(operador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Usuario? LeerUsuarioPwd(string email, string pass)
        {
            foreach (Usuario user in usuarios)
            {
                if (user.Email == email && user.Password == pass)
                {
                    return user;
                }
            }
            return null;
        }

        public List<Usuario> DevolverUsuario()
        {
            return usuarios;
        }

        #endregion



        #region Huesped
        public bool BuscarHuesped(Huesped nuevoHuesped)//Verificamos con un bool si el huesped ya existe en la lista
        {
            bool encontre = false;
            int indice = 0;
            while (!encontre && indice < huespedes.Count)
            {
                if ((huespedes[indice].TipoDeDocumento == nuevoHuesped.TipoDeDocumento) && (huespedes[indice].NroDocumento == nuevoHuesped.NroDocumento))
                {
                    encontre = true;
                }
                else indice++;
            }
            return encontre;
        }
        public void VerificarHuespedExiste(Huesped huesped)//Validamos BuscarHuesped e informamos si existe el huesped
        {
            if (BuscarHuesped(huesped))
            {
                throw new Exception("El Cliente ya se encuentra registrado en el Sistema!");
            }
        }

        public Huesped GetHuesped(string documento, Huesped.tipoDocumento tipoDoc) //Busca huesped y compara por nroDocumento y nombre, devuelve el huesped encontrado
        {
            Huesped unHuesped = null;
            int i = 0;

            while (i < huespedes.Count && unHuesped == null)
            {
                if (huespedes[i].NroDocumento == documento && huespedes[i].TipoDeDocumento == tipoDoc)
                {
                    unHuesped = huespedes[i];
                }
                i++;
            }
            return unHuesped;
        }
        #endregion

        #region Operador
        public bool BuscarOperador(Operador nuevoOperador)//Verificamos con un bool si el operador ya existe en la lista
        {
            bool encontre = false;
            int indice = 0;
            while (!encontre && indice < operadores.Count)
            {
                if ((operadores[indice].Email == nuevoOperador.Email))
                {
                    encontre = true;
                }
                else indice++;
            }
            return encontre;
        }
        public void VerificarOperadorExiste(Operador nuevoOperador)//Validamos BuscarOperador e informamos si existe el mismo
        {
            if (BuscarOperador(nuevoOperador))
            {
                throw new Exception("El Operador ya se encuentra registrado en el Sistema!");
            }
        }
        #endregion

        #region Actividad
        public void AgregarActividad(Actividad actividad)
        {
            try
            {
                if(actividad == null)
                {
                    throw new Exception("No se puede agregar una actividad vacia");
                }
                actividades.Add(actividad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Actividad> DevolverActividad()
        {
            List<Actividad> listaAuxiliarOrdenada = new List<Actividad>(actividades);
            listaAuxiliarOrdenada.Sort((a, b) =>
            {
                return DateTime.Compare(DateTime.Now, a.Fecha);
            });
            return listaAuxiliarOrdenada;
        }
        public List<Actividad> DevolverActividadPorRango(DateTime fechaInicio, DateTime fechaFin, decimal costo)
        {
            List<Actividad> listaAuxiliar = new List<Actividad>();
            foreach (Actividad unaActividad in actividades)
            {
                if ((unaActividad.Fecha >= fechaInicio && unaActividad.Fecha <= fechaFin) && unaActividad.Costo > costo)
                {
                    listaAuxiliar.Add(unaActividad);
                }
            }
            listaAuxiliar = listaAuxiliar.OrderByDescending(a => a.Costo).ToList();
            return listaAuxiliar;
        }//Devolvemos lista de actividades entre rangos de fecha y costo mayor al costo brindado
        public Actividad GetActividad(int identificador)
        {
            Actividad unaActividad = null;
            int i = 0;

            while (i < actividades.Count && unaActividad == null)
            {
                if (actividades[i].Identificador == identificador)
                {
                    unaActividad = actividades[i];
                }
                i++;
            }
            return unaActividad;
        }//Busca en la lista la actividad por nombre y devuelve la actividad encontrada
        #endregion

        #region Proveedor
        public bool BuscarProveedor(Proveedor nuevoProveedor)//Verificamos con un bool si el Proveedor ya existe en la lista
        {
            bool encontre = false;
            int indice = 0;
            while (!encontre && indice < proveedores.Count)
            {
                if ((proveedores[indice].Nombre == nuevoProveedor.Nombre))
                {
                    encontre = true;
                }
                else indice++;
            }
            return encontre;
        }
        public void VerificarProveedorExiste(Proveedor nuevoProveedor)//Validamos BuscarProveedor e informamos si existe el mismo
        {
            if (BuscarProveedor(nuevoProveedor))
            {
                throw new Exception("El Proveedor ya se encuentra registrado en el Sistema!");
            }
        }
        public void AltaProveedor(Proveedor nuevoProveedor)//Validamos datos del proveedor, verificamos existencia y lo agrefamos en la lista
        {
            try
            {
                if (nuevoProveedor == null)
                {
                    throw new Exception("El Proveedor no puede ser nulo");
                }
                nuevoProveedor.Validar();
                VerificarProveedorExiste(nuevoProveedor);
                proveedores.Add(nuevoProveedor);
            }
            catch (Exception ex)
            {
                erroresPrecarga.Add(ex.Message);
            }
        }//Validamos metodos Proveedor y agregamos a la lista
        public Proveedor GetProveedor(string nombre)//Buscamos proveedor por nombre y devolvemos en caso de encontrarlo
        {
            Proveedor unProveedor = null;
            int i = 0;

            while (i < proveedores.Count && unProveedor == null)
            {
                if (proveedores[i].Nombre == nombre)
                {
                    unProveedor = proveedores[i];
                }
                i++;
            }
            return unProveedor;
        }
        public List<Proveedor> DevolverProveedores()
        {
            List<Proveedor> listaAuxiliarOrdenada = new List<Proveedor>(proveedores);
            listaAuxiliarOrdenada.Sort((a, b) => string.Compare(a.Nombre, b.Nombre));
            return listaAuxiliarOrdenada;
        }//Devolvemos la lista de Proveedores Ordenado Alfabeticamente, El metodo Sort se aplica en el metodo desde Sistema
        #endregion

        #region Agenda
        public bool BuscarAgenda(Agenda nuevaAgenda)//Verificamos con un bool si el huesped ya existe en la lista de agendas
        {
            bool encontre = false;
            int indice = 0;
            while (!encontre && indice < agendas.Count)
            {
                if ((agendas[indice].Huesped.TipoDeDocumento == nuevaAgenda.Huesped.TipoDeDocumento) && (agendas[indice].Huesped.NroDocumento == nuevaAgenda.Huesped.NroDocumento) && (agendas[indice].Activdad.Nombre == nuevaAgenda.Activdad.Nombre) && (agendas[indice].Activdad.Fecha == nuevaAgenda.Activdad.Fecha))
                {
                    encontre = true;
                }
                else indice++;
            }
            return encontre;
        }
        public void VerificarAgendaExiste(Agenda nuevaAgenda)//Validamos BuscarAgenda e informamos si existe el mismo
        {
            if (BuscarAgenda(nuevaAgenda))
            {
                throw new Exception("Ya se encuentra registrado en la Actividad!");
            }
        }
        public bool ValidarEdad(Huesped unHuesped, Actividad unaActividad)//Comparamos edad del huesped con edadminima para actividad
        {
            int edad = DateTime.Now.Year - unHuesped.FechaNacimiento.Year;
            if (edad < unaActividad.EdadMinima)
            {
                return false;
            }
            return true;
        }
        public void AltaAgenda(Agenda nuevaAgenda)
        {
            try
            {
                if (nuevaAgenda == null)
                {
                    throw new Exception("La agenda no puede ser nulo");
                }
                nuevaAgenda.ValidarAgenda();
                VerificarAgendaExiste(nuevaAgenda);
                if (CantidadMaxima(nuevaAgenda) == true)
                {
                    throw new Exception("La agenda supera la capacidad Maxima!");
                }
                else
                {
                    agendas.Add(nuevaAgenda);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }//Verificamos datos y validaciones luego se agrega una nueva agenda
        public List<Actividad> VerificarActividadesxNombre(Actividad actividad)//Buscamos en la lista de Actividades una actividad existente
        {
            List<Actividad> listaAuxiliar = new List<Actividad>();
            foreach (Actividad unaActividad in actividades)
            {
                if (unaActividad.Nombre == actividad.Nombre)
                {
                    listaAuxiliar.Add(unaActividad);
                }
            }
            return listaAuxiliar;
        }
        public List<Agenda> DevolverAgenda()//retornamos todas las actividades agendadas
        {
            return agendas;
        }

        public List<Agenda> DevolverAgendaXTipoyNroDoc(string tipoDoc, string nroDoc)//retornamos todas las actividades agendadas x tipo y numero de documento
        {
            try
            {
                List<Agenda> DevolverAgenda = new List<Agenda>();
                foreach (Agenda unaAgenda in agendas)
                {
                    if (unaAgenda.Huesped.TipoDeDocumento.Equals(tipoDoc) && unaAgenda.Huesped.NroDocumento.Equals(nroDoc))
                    {
                        DevolverAgenda.Add(unaAgenda);
                    }
                }
                return DevolverAgenda;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CantidadMaxima(Agenda nuevaAgenda)//Verificamos con un bool si el huesped ya cumple con la capacidad maxima de la actividad
        {
            bool encontre = false;
            int indice = 0;
            int contador = 0;
            while (!encontre && indice < agendas.Count)
            {
                if ((agendas[indice].Activdad.Nombre == nuevaAgenda.Activdad.Nombre) && (agendas[indice].Activdad.Fecha == nuevaAgenda.Activdad.Fecha))
                {
                    contador++;
                }
                indice++;
            }
            if (contador >= nuevaAgenda.Activdad.CantidadMaxima)
            {
                encontre = true;
            }
            else
            {
                encontre = false;
            }
            return encontre;
        }
        #endregion

        public List<Agenda> DevolverListaAgenda(string email)
        {
            List<Agenda> unaAgenda = new List<Agenda>();
            foreach (Agenda agenda in agendas)
            {
                if (agenda.Huesped.Email == email)
                {
                    unaAgenda.Add(agenda);
                }
            }
            return unaAgenda;


        }


        public Agenda GetAgenda(int identificador)
        {
            Agenda unaAgenda = null;
            int i = 0;

            while (i < agendas.Count && unaAgenda == null)
            {
                if (agendas[i].Identificador == identificador)
                {
                    unaAgenda = agendas[i];
                }
                i++;
            }
            return unaAgenda;
        }



    }
}
