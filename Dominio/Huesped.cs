using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Huesped : Usuario
    {
        #region Atributos
        public enum tipoDocumento { CI, PASAPORTE, OTROS }
        public enum fidelizacion { NIVEL1 = 1, NIVEL2 = 2, NIVEL3 = 3, NIVEL4 = 4 }

        private tipoDocumento tipoDeDocumento;
        private string nroDocumento;
        private string habitacion;
        private DateTime fechaNacimiento;
        private fidelizacion tipoFidelizacion;
        #endregion

        #region Propiedades
        public tipoDocumento TipoDeDocumento { get => tipoDeDocumento; set => tipoDeDocumento = value; }
        public string NroDocumento { get => nroDocumento; set => nroDocumento = value; }
        public string Habitacion { get => habitacion; set => habitacion = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public fidelizacion TipoFidelizacion { get => tipoFidelizacion; set => tipoFidelizacion = value; }
        #endregion

        #region Constructor
        public Huesped()
        {

        }
        public Huesped(tipoDocumento tipoDeDocumento, string nroDocumento, string nombre, string apellido, string email, string password, string habitacion, DateTime fechaNacimiento, fidelizacion tipoFidelizacion) : base(nombre, apellido, email, password)
        {
            this.tipoDeDocumento = tipoDeDocumento;
            this.nroDocumento = nroDocumento;
            this.habitacion = habitacion;
            this.fechaNacimiento = fechaNacimiento;
            this.tipoFidelizacion = tipoFidelizacion;
        }
        #endregion

        #region Métodos
        public void ValidarDatosHuesped()
        {
            ValidarTipoDocumento();
            ValidarNumeroDocumento();
            ValidarHabitacion();
            ValidarFechaNacimiento();
            ValidarTipoFidelizacion();
        }//Validamos todos los Metodos Utilitarios.
        #endregion

        #region Metodos Utilitarios
        private void ValidarTipoDocumento()//Validamos tipo de Documento con isDefined verificando si el valor ingresado en tipoDeDocumento pertenece al Enum tipoDocumento.
        {
            if (!Enum.IsDefined(typeof(tipoDocumento), tipoDeDocumento))
            {
                throw new Exception("Documento Inválido!");
            }
        }
        private void ValidarNumeroDocumento()//Validamos Requisitos de CI. (Los demás tipos de documentos se agregaron validaciones aunque no solicitados en la letra.)
        {
            switch (tipoDeDocumento)
            {
                case tipoDocumento.CI:
                    if (!(nroDocumento.Length == 7) || !(validarCI()))
                    {
                        throw new Exception("Error en el formato del Documento. CI: 7 caracteres numéricos");
                    }
                    break;
                case tipoDocumento.PASAPORTE:
                    if (!(nroDocumento.Length > 5 && nroDocumento.Length < 11))
                    {
                        throw new Exception("Error en el formato del Documento. PASAPORTE: 6-10 caracteres alfanuméricos");
                    }
                    break;
                case tipoDocumento.OTROS:
                    if (!(nroDocumento.Length > 4) && (nroDocumento.Length < 16))
                    {
                        throw new Exception("Error en el formato del Documento. OTROS: 5-15 caracteres alfanuméricos");
                    }
                    break;
                default:
                    throw new Exception("Numero de Documento inválido!");
                    break;
            }
        }

        private void ValidarHabitacion() //Validamos que habitacion no sea nulo, se utiliza Trim() en habitacion para quitar espacios al principio y final del string
        {
            if (habitacion.Trim().Length <= 0)
            {
                throw new Exception("La habitacion no puede ser vacio!");
            }
        }
        private void ValidarFechaNacimiento()
        {
            if (fechaNacimiento.Date > DateTime.Now.Date)
            {
                throw new Exception("La fecha de nacimiento no puede ser mayor a la fecha actual");
            }
        }//Validamos fecha de nacimiento no sea mayor a fecha actual y parseamos para que muestre dd/mm/yyyy
        private void ValidarTipoFidelizacion()//Validamos tipo de Fidelizacion con isDefined verificando si el valor ingresado en TipoFidelizacion pertenece al Enum fidelizacion.
        {
            if (!Enum.IsDefined(typeof(fidelizacion), TipoFidelizacion))
            {
                if (tipoFidelizacion == null)
                {
                    this.tipoFidelizacion = fidelizacion.NIVEL1;
                }
                else
                {
                    throw new Exception("Fidelización Inválida!");
                }
            }

        }
        private bool validarCI() //Validamos que CI sean solo numeros.
        {
            for (int i = 0; i < nroDocumento.Length; i++)
            {
                if (nroDocumento[i] < '0' || nroDocumento[i] > '9')
                {
                    return false;
                }
            }
            return true;
        }

        private string CalcularDigitoVerificador(string cedula)
        {
            int suma = 0;
            int digitoVerificador = 0;
            int[] multiplicador = { 2, 9, 8, 7, 6, 3, 4 };
            for (int i = 0; i < cedula.Length; i++)
            {
                suma += multiplicador[i] * int.Parse(cedula[i].ToString());
            }
            int resto = suma % 10;
            if (resto != 0)
            {
                digitoVerificador = 10 - resto;
            }
            return digitoVerificador.ToString();
        }
        #endregion

        #region Override
        public override bool Equals(object? obj)
        {
            Huesped huespedParametro = obj as Huesped;
            if (huespedParametro == null) return false;
            return (this.tipoDeDocumento.Equals(huespedParametro.tipoDeDocumento) && (this.nroDocumento.Equals(huespedParametro.nroDocumento)));
        }

        public string toHtmlAgenda()//Se crea este metoo para devolver solo lo que se pide en la visualizacion de agenda del usuario
        {
            return base.toHtmlAgenda();
        }

        public string toHtml()//Este metodo es para devolver todos los datos del usuario en MIS DATOS
        {
            string newLine = "<br>";
            return base.toHtml() + ($"Tipo de Documento: {tipoDeDocumento}{newLine}Nro. de Documento: {nroDocumento}{CalcularDigitoVerificador(nroDocumento)}{newLine}Habitacion: {habitacion}{newLine}Fecha de Nacimiento: {fechaNacimiento}{newLine}Fidelizacion: {TipoFidelizacion}{newLine}");
        }
        #endregion
    }
}