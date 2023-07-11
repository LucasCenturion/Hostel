using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Actividad : IComparable<Actividad>
    {
        #region Atributos
        private static int ultimoid = 1000;

        private int identificador = ++ultimoid;
        private string nombre;
        private string descripcion;
        private DateTime fecha;
        private int cantidadMaxima;
        private int edadMinima;
        private decimal costo;
        #endregion

        #region Propiedades
        public int Identificador { get => identificador; set => identificador = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public int CantidadMaxima { get => cantidadMaxima; set => cantidadMaxima = value; }
        public int EdadMinima { get => edadMinima; set => edadMinima = value; }
        public decimal Costo { get => costo; set => costo = value; }
        #endregion

        #region Constructor
        public Actividad()
        {

        }
        public Actividad(int identificador, string nombre, string descripcion, DateTime fecha, int cantidadMaxima, int edadMinima, decimal costo)
        {
            this.Identificador = identificador;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Fecha = fecha;
            this.CantidadMaxima = cantidadMaxima;
            this.EdadMinima = edadMinima;
            this.Costo = costo;
        }
        #endregion

        #region Metodos 
        public void ValidarDatos()
        {
            ValidarNombre();
            ValidarDescripcion();
            ValidarFecha();
        }

        public virtual decimal CalcularCosto(decimal costo)
        {
            return this.costo;
        }

        #endregion //Autovalidamos cada metodo utilitario

        #region Metodos utilitarios
        private void ValidarNombre()//Verificamos nombre no sea nulo, y nombre.Length no sea mayor a 25 caracteres.
        {
            if (nombre == null)
            {
                throw new Exception("El nombre no puede ser vacio.");
            }
            if (nombre.Length > 50)
            {
                throw new Exception("El nombre no puede ser mayor a 25 caracteres.");
            }
        }
        private void ValidarDescripcion()
        {
            if (descripcion == null)
            {
                throw new Exception("La actividad debe tener una descripción");
            }
        }
        private void ValidarFecha()
        {
            try
            {
                if (this.Fecha.Date < DateTime.Now.Date)
                {
                    throw new Exception("La fecha ingresada no puede ser anterior o igual a la fecha actual:");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); ;
            }
        }

        public int CompareTo(Actividad actividad)
        {
            return this.identificador.CompareTo(actividad.identificador);
        }//Definimos lista ordenada por identificador
        #endregion

        #region Override
        public override string ToString()
        {
            return ($"\nIdentificador: {identificador} \nNombre: {nombre} \nDescripción: {descripcion} \nFecha: {fecha.ToString("d")} \nCantidad Máxima de Personas: {cantidadMaxima} \nEdad Mínima de Actividad: {edadMinima}\nCosto: {costo}\nProveedor:\n-------------------");
        }

        public string ToStringNombre()
        {
            return ($"Nombre: {nombre}\n Fecha: {fecha.ToShortDateString()}\n ");
        }

        public string toHtml()
        {
            string newLine = "<br>";
            return ($"Nombre Actividad: {nombre} {newLine}Fecha Actividad: {fecha.ToString("d")}");
        }


        #endregion
    }
}
