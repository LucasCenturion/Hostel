using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ActividadTercerizada: Actividad
    {
        #region Atributos
        private Proveedor proveedor;
        private bool confirmada;
        private DateTime fechaConfirmacion;
        #endregion

        #region Propiedades
        public Proveedor Proveedor { get => proveedor;}
        public bool Confirmada { get => confirmada; set => confirmada = value; }
        public DateTime FechaConfirmacion { get => fechaConfirmacion; set => fechaConfirmacion = value; }
        #endregion

        #region Constructor
        public ActividadTercerizada()
        {

        }
        public ActividadTercerizada(int identificador, string nombre, string descripcion, DateTime fecha, int cantidadMaxima, int edadMinima, decimal costo, Proveedor proveedor, bool confirmada, DateTime fechaConfirmacion) : base(identificador, nombre, descripcion, fecha, cantidadMaxima, edadMinima, costo)
        {
            this.proveedor = proveedor;
            this.confirmada = confirmada;
            this.fechaConfirmacion = fechaConfirmacion;
        }
        #endregion

        #region Metodos
        public override decimal CalcularCosto(decimal costo)
        {
            if (confirmada)
            {
                costo = costo - ((costo * proveedor.Descuento) /100);
            }
            return costo;
        }
        #endregion

        #region Override
        public override string ToString()
        {
            return ($"Nombre Actividad: {Nombre}\nFecha Actividad: {Fecha.ToShortDateString()}\nProveedor: {proveedor.Nombre}\n--------------------");
        }

        public string TercerizadaHtml()
        {
            string newLine = "<br>";
            return base.toHtml() + ($"{newLine}Proveedor: {proveedor.Nombre}{newLine}Lugar: {proveedor.Direccion}{newLine}");
        }
        #endregion
    }
}
