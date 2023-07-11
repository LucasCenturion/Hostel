//using System;
//using System.Collections.Generic;
//using System.Threading.Channels;
//using Dominio;
//using static System.Runtime.InteropServices.JavaScript.JSType;

//namespace Consola
//{
//    public class Program
//    {
//        static Sistema unS = Sistema.Instancia;
//        static void Main(string[] args)
//        {
//            foreach (string unMensaje in unS.erroresPrecarga)
//            {
//                MensajeError("Error en Precarga: " + unMensaje);
//            }
//            Menu();
//        }

//        #region Menu
//        static void Menu()
//        {
//            Hostal();
//            Sepide();
//        }
//            static void Sepide()
//            {
//                Console.Clear();
//                Hostal();
//                bool exito = false;
//                Console.WriteLine("SELECCIONE USUARIO\n\n1-LISTADO DE TODAS LAS ACTIVIDADES\n2-LISTADO DE PROVEEDORES ORDENADOS ALFABETICAMENTE\n3-VER ACTIVIDADES POR RANGO DE FECHAS Y COSTO\n4-ESTABLECER VALOR DE PROMOCION PARA ACTIVIDADES DE UN PROVEEDOR\n5-ALTA DE HUESPEDES\n6-AGENDARSE EN UNA ACTIVIDAD\n7-VER AGENDA");
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine("\n0-Salir"); Console.ResetColor();
//                do
//                {              
//                    string opcion = Console.ReadLine();
//                    switch (opcion)
//                    {
//                        case "1"://Punto 1 listo
//                        VerACtividades();
//                            exito = true;
//                            break;
//                        case "2":
//                        VerProveedores();
//                        exito = true;
//                            break;
//                    case "3":
//                        DevolverActividadesPorFechas();
//                        exito = true;
//                        break;
//                    case "4":
//                        CambiarValorPromocion();
//                        exito = true;
//                        break;
//                    case "5":
//                        //RegistrarNuevoHuesped();
//                        exito = true;
//                        break;
//                    case "6":
//                        AgendarUnaActividad();
//                        exito = true;
//                        break;
//                    case "7":
//                        VerAgenda();
//                        exito = true;
//                        break;
//                    case "0":
//                            Salir();
//                            break;
//                        default:                         
//                            Menu();
//                            break;
//                    }
                
//                } while (exito == true);
//            }
//        #endregion

//        #region punto 1
//        static void VerACtividades()
//        {
//            Console.Clear();
//            List<Actividad> listaActividades = unS.DevolverActividad();
//            MensajeConfirmacion("Las Actividades Agendadas son:");
//            foreach (Actividad actividad in listaActividades)
//            {
//                Console.WriteLine($"{actividad.ToString()}");
//            }
//            Console.ReadLine();
//            Menu();
//        }

//        #endregion

//        #region punto 2
//        static void VerProveedores()
//        {
//            Console.Clear();
//            List<Proveedor> listaAuxiliar = unS.DevolverProveedores();
//            MensajeConfirmacion("La Lista de Proveedores en orden alfabetico son:");
//            foreach (Proveedor proveedor in listaAuxiliar)
//            {
//                Console.WriteLine($"{proveedor.ToString()}");
//            }
//            Console.ReadLine();
//            Menu();
//        }


//        #endregion

//        #region punto 3
//        static void DevolverActividadesPorFechas()
//        {
//            Console.Clear();
//            Console.WriteLine("Ingrese Fecha de inicio de Busqueda");
//            DateTime fechaInicio = LeerFecha();
//            Console.WriteLine("Ingrese Fecha de final de Busqueda");
//            DateTime fechaFinal = LeerFecha();
//            Console.WriteLine("Ingrese el Costo:");
//            decimal costo = PedirCosto();
//            List<Actividad> nuevaLista = unS.DevolverActividadPorRango(fechaInicio, fechaFinal, costo);
            
//            foreach (Actividad actividad in nuevaLista)
//            {
//                if(nuevaLista == null)
//                {
//                    MensajeError("No hay actividades Registradas");
//                }
//                else Console.WriteLine($"{actividad.ToString()}");
//            }
//            Console.ReadLine();
//            Menu();
//        }

//        #endregion

//        #region punto 4
//        public static Proveedor PedirProveedor()
//        {
//            Proveedor unProveedor = null;
//            string nombre = null;
//            bool ok = false;
//            while (!ok)
//            {
//                Console.WriteLine("Ingrese el nombre del Proveedor:");
//                nombre = Console.ReadLine();
//                unProveedor = unS.GetProveedor(nombre);
//                if (nombre != null)
//                {
//                    ok = true;
//                }
         
//            }
//            return unProveedor;
//        }

//        public static void CambiarValorPromocion()
//        {
//            Proveedor unProveedor = PedirProveedor();   
//            int valorNuevo;
//            try
//            {
//                if (unProveedor == null)
//                {
//                    throw new Exception("No hay un Proveedor para modificar");
//                }
//                Console.WriteLine("Ingrese el valor nuevo de Promocion:");
//                valorNuevo = int.Parse(Console.ReadLine());
//                unProveedor.Descuento = valorNuevo;
//                unProveedor.Validar();
//                MensajeConfirmacion("Valor Cambiado Correctamente!");
//                Console.ReadKey();
//                Menu();
//            }
//            catch (Exception ex)
//            {
//                MensajeError(ex.Message);
//            }
//        }

//        #endregion

//        #region punto 5
//        //static void RegistrarNuevoHuesped()
//        //{
//        //    bool exito = false;
//        //    while (!exito)
//        //    {
//        //        try
//        //        {
//        //            Console.Clear();
//        //            Hostal();
//        //            Huesped.tipoDocumento tipoDoc = SolicitarDocumento();
//        //            Console.Write("Nro.Documento sin dígito verificador: ");
//        //            string nroDocumento = Console.ReadLine();
//        //            Console.Write("Nombre: ");
//        //            string nombre = Console.ReadLine().ToUpper();
//        //            Console.Write("Apellido:");
//        //            string apellido = Console.ReadLine().ToUpper();
//        //            Console.Write("Habitacion:");
//        //            string habitacion = Console.ReadLine().ToUpper();
//        //            Console.WriteLine("Ingrese la fecha de nacimiento");
//        //            DateTime fecha = LeerFecha();
//        //            Huesped.fidelizacion nuevaFid = SolicitarFidelizacion();
//        //            Huesped nuevoHuesped = new Huesped(tipoDoc, nroDocumento, nombre, apellido, habitacion, fecha, nuevaFid);
//        //            nuevoHuesped.ValidarDatosHuesped();
//        //            unS.AgregarHuesped(nuevoHuesped);
//        //            Console.Clear();
//        //            MensajeConfirmacion("Huesped Ingresado Correctamente!");
//        //            exito = true;
//        //            Console.ReadLine();
//        //            Menu();
//        //        }
//        //        catch (Exception ex)
//        //        {
//        //            MensajeError(ex.Message);
//        //        }
//        //    }
//        //}

//        #endregion

//        #region Punto 6 Agenda
//        public static Huesped PedirHuesped()
//        {
//            Huesped unHuesped = null;
//            bool ok = false;
//            while (!ok)
//            {
//                Huesped.tipoDocumento tipoDoc = SolicitarDocumento();
//                Console.WriteLine("Ingrese el documento del Huesped sin dígito verificador:");
//                string documento = Console.ReadLine();
//                unHuesped = unS.GetHuesped(documento, tipoDoc);
//                if (documento == null)
//                {
//                    throw new Exception("Huesped no valido");
//                }
//                if (unHuesped.TipoDeDocumento != tipoDoc || unHuesped.NroDocumento != documento)
//                {
//                    throw new Exception("Huesped no valido");
//                }
//                else
//                {
//                    ok = true;
//                }
//            }
//            return unHuesped;
//        }
//        //public static Actividad PedirActividad()
//        //{
//        //    Actividad unaActividad = null;
//        //    string nombre = null;
//        //    bool ok = false;
//        //    while (!ok)
//        //    {
//        //        Console.WriteLine("Ingrese el nombre de la actividad:");
//        //        nombre = Console.ReadLine();
//        //        unaActividad = unS.GetActividad(nombre);
//        //        if (nombre != null)
//        //        {
//        //            ok = true;
//        //        }

//        //    }
//        //    return unaActividad;
//        //}

//        public static void AgendarUnaActividad()
//        {
//            Console.Clear();
//            bool exito = false;
//            while (!exito)
//            {
//                try
//                {
//                    Huesped unHuesped = PedirHuesped();
//                    if (unHuesped == null)
//                    {
//                        throw new Exception("No se ha ingresado un documento valido");
//                    }
//                    //Actividad unaActividad = PedirActividad();
//                    if (unaActividad == null)
//                    {
//                        throw new Exception("No se ha ingresado una Actividad valida");
//                    }
//                    if (!unS.ValidarEdad(unHuesped, unaActividad))
//                    {
//                        throw new Exception("El huesped no cumple con la edad minima requerida");
//                    }
//                    List<Actividad> actividadesEncontradas = unS.VerificarActividadesxNombre(unaActividad);
//                    Console.Clear();
//                    foreach (Actividad actividadEncontradas in actividadesEncontradas)
//                    {
//                        Console.WriteLine($"-----------\nNombre: {actividadEncontradas.Nombre}\nFecha: {actividadEncontradas.Fecha.ToShortDateString()}\n-----------\n");
//                    }
//                    Console.WriteLine("Ingrese la fecha disponible de la actividad:");
//                    DateTime fecha = LeerFecha();
//                    bool fechaValida = false;
//                    foreach (Actividad actividadEncontradas in actividadesEncontradas)
//                    {
//                        if(fecha == actividadEncontradas.Fecha)
//                        {
//                            fechaValida = true;
//                            break;
//                        }      
//                    }
//                    if (!fechaValida)
//                    {
//                        throw new Exception("ACTIVIDAD NO AGENDADA!\nDebe ingresar una fecha correspondiente a las fechas disponibles");
//                    }
//                    Agenda unAgenda = new Agenda(unHuesped, unaActividad);
//                    unS.AltaAgenda(unAgenda);
//                    MensajeConfirmacion("Agenda Ingresado Correctamente!");                    
//                    exito = true;
//                    Console.ReadLine();          
//                    Menu();
//                }
//                catch (Exception ex)
//                {
//                    MensajeError(ex.Message);
//                }
//            }
//        }

//        #endregion

//        #region VerAgenda
//        //Se realiza el metodo para verificar si la agenda se cargo con exito!
//        static void VerAgenda()
//        {
//            Console.Clear();
//            List<Agenda> listaAuxiliar = unS.DevolverAgenda();
//            MensajeConfirmacion("La Lista de Agendas es: ");
//            foreach (Agenda agenda in listaAuxiliar)
//            {
//                Console.WriteLine($"{agenda.ToString()}");
//            }
//            Console.ReadLine();
//            Menu();
//        }
//        #endregion

//        #region Metodos Utilitarios

//        #region Pedir Nro Documento ya Cargado

//        #region Solicitar tipoDocumento Huesped
//        static Huesped.tipoDocumento SolicitarDocumento()
//        {
//            Huesped.tipoDocumento nuevoTipo;
//            bool exito;
//            do
//            {
//                Console.WriteLine("Ingrese el tipo de Documento:\n\nCI---PASAPORTE---OTROS");
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine("\n0-Salir");
//                Console.ResetColor();
//                string tipo = Console.ReadLine().ToUpper();
//                if (tipo == "0")
//                {
//                    Salir();
//                }
//                exito = Enum.TryParse<Huesped.tipoDocumento>(tipo, out nuevoTipo) && !tipo.All(char.IsDigit);
//                if (!exito)
//                {
//                    MensajeError("Documento Inválido");
//                }
//            } while (!exito);
//            return nuevoTipo;
//        }

//        #endregion
        
        
//        #endregion
//        #region Pedir Fidelizacion
//        static Huesped.fidelizacion SolicitarFidelizacion()
//        {
//            Huesped.fidelizacion nuevaFidelizacion;
//            bool exito;
//            do
//            {
                
//                Console.WriteLine("NIVEL1---NIVEL2---NIVEL3---NIVEL4\n");
//                Console.Write("Ingrese el tipo de Fidelización: ");
//                string tipo = Console.ReadLine().ToUpper();
//                exito = Enum.TryParse<Huesped.fidelizacion>(tipo, out nuevaFidelizacion) && !tipo.All(char.IsDigit);
//                if (!exito)
//                {
//                    MensajeError("Fidelización Invalida");
//                }
//            } while (!exito);
//            return nuevaFidelizacion;
//        }
//        #endregion


//        #region Solicitar Fecha
//        static DateTime LeerFecha()
//        {
//            DateTime fecha;
//            bool exito;
//            do
//            {
//                exito = DateTime.TryParse(Console.ReadLine(), out fecha);
//                if (!exito)
//                {
//                    Console.WriteLine("Fecha con error de Formato");
//                }
//            } while (!exito);
//            return fecha.Date;
//        }
//        #endregion
//        #region Solicitar Costo
//        static decimal PedirCosto()
//        {
//            decimal costo;
//            bool exito;
//            do
//            {
//                exito = decimal.TryParse(Console.ReadLine(), out costo);
//                if (!exito || costo > 9999)
//                {
//                    Console.WriteLine("Ingrese un valor valido de hasta 4 digitos");
//                }
//            } while (!exito);
//            return costo;
//        }
//        #endregion
//        #region cabecera //Mensaje que aparecera como nombre de la Consola en todas las ventanas
//        static void Hostal()
//        {
//            Console.BackgroundColor = ConsoleColor.Green;
//            Console.ForegroundColor = ConsoleColor.Black;
//            Console.WriteLine("HOSTAL - Gestion y Reservas");
//            Console.ResetColor();
//        }
//        #endregion
//        #region Mensaje Confirmacion

//        static void MensajeConfirmacion(string mensaje)
//        {
//            Console.BackgroundColor = ConsoleColor.Green;
//            Console.ForegroundColor = ConsoleColor.Black;
//            Console.WriteLine($"---Confirmado----> {mensaje}");
//            Console.BackgroundColor = ConsoleColor.Black;
//            Console.ForegroundColor = ConsoleColor.White;
//        }

//        #endregion
//        #region Mensaje de Error  //Mensaje de error en color Rojo, muestra los mensajes de error y Excepciones
//        static void MensajeError(string mensaje)
//        {
//            Console.Clear();
//            Console.BackgroundColor = ConsoleColor.Red;
//            Console.WriteLine($"-----Error-----> {mensaje}");
//            Console.BackgroundColor = ConsoleColor.Black;
//            Console.ReadKey();
//        }
//        #endregion
//        #region Salir  //Mensaje al seleccionar opcion 0
//        static void Salir()
//        {
//            Console.Clear();
//            Console.BackgroundColor = ConsoleColor.Gray;
//            Console.ForegroundColor = ConsoleColor.Black;
//            Console.WriteLine($"---> Ejecucion Cancelada");
//            Console.BackgroundColor = ConsoleColor.Black;
//            Environment.Exit(0);//se utiliza para finalizar los procesos desde cualquier metodo al invocarlo, colocamos 0 para determinar que el codigo finaliza sin error
//        }
//        #endregion





//        #endregion

//    }
//}