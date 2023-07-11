using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Agenda
    {
        #region Atributos
        private static int ultimoId = 10000;//Se agrega nuevo identificador para luego levantar la actividad agendada por id
        private int identificador = ++ultimoId;
        public enum EstaPago { PENDIENTE_PAGO = 1, CONFIRMADA }
        private Huesped huesped;
        private Actividad actividad;
        private EstaPago estaPago;
        private decimal costo;
        private DateTime fecha;
        #endregion

        #region Propiedades
        public int Identificador { get => identificador; set => identificador = value; }
        public Huesped Huesped { get => huesped; set => huesped = value; }
        public Actividad Activdad { get => actividad; set => actividad = value; }
        public EstaPago EstaPago1 { get => estaPago; set => estaPago = value; }
        public decimal Costo { get => costo; set => costo = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        #endregion

        #region Constructor
        public Agenda() { }
        public Agenda(Huesped huesped, Actividad actividad)
        {
            this.Identificador = identificador;
            this.actividad = actividad;
            this.huesped = huesped;
            this.EstaPago1 = estaPago;
            this.costo = costo;
            this.Fecha = DateTime.Now;
        }
        #endregion

        #region Metodos
        public void ValidarAgenda()
        {
            ValidarHuesped();
            ValidarActividad();
            ValidarCosto();
            ValidarPago();
        }
        #endregion

        #region Metodos Utilitarios
        private void ValidarHuesped()
        {
            huesped.ValidarDatosHuesped();
        }
        private void ValidarActividad()
        {
            actividad.ValidarDatos();
        }
        private EstaPago ValidarPago()
        {
            if (costo > 0)
            {
                this.estaPago = EstaPago.PENDIENTE_PAGO;
            }
            else
            {
                this.estaPago = EstaPago.CONFIRMADA;
            }
            return this.estaPago;
        }
        private void ValidarCosto()
        {
            decimal unCosto = actividad.CalcularCosto(actividad.Costo);
            this.costo = CalcularCostoFinal(unCosto);
        }
        private decimal CalcularCostoFinal(decimal unCosto)
        {
            if (huesped.TipoFidelizacion == Huesped.fidelizacion.NIVEL1)
            {
                costo = unCosto;
            }
            if (huesped.TipoFidelizacion == Huesped.fidelizacion.NIVEL2)
            {
                costo = unCosto - ((unCosto * 10) / 100);
            }
            if (huesped.TipoFidelizacion == Huesped.fidelizacion.NIVEL3)
            {
                costo = unCosto - ((unCosto * 15) / 100);
            }
            if (huesped.TipoFidelizacion == Huesped.fidelizacion.NIVEL4)
            {
                costo = unCosto - ((unCosto * 20) / 100);
            }
            return costo;
        }
        #endregion

        #region Override
        public override string ToString()
        {
            if (costo <= 0)
            {
                return ($"{huesped.ToString()}\n{actividad.ToString()}\nCosto: Actividad Gratuita \nEstado: {estaPago}\n--------------------\n");
            }
            else
            {
                return ($"{huesped.ToString()}{actividad.ToString()}\nCosto: {costo}\nEstado: {estaPago}\n--------------------\n");
            }
        }
        public string toHtmlAgenda()
        {
            string newLine = "<br>";
            if (costo <= 0)
            {
                if (actividad is ActividadPropia)
                {
                    ActividadPropia unaActividadP = (ActividadPropia)actividad;
                    return $"{huesped.toHtmlAgenda()}{newLine}{unaActividadP.PropiaHTML()}Total a Pagar: Actividad Gratuita{newLine}Estado: {estaPago}{newLine}";
                }
                else
                {
                    ActividadTercerizada unaActividadT = (ActividadTercerizada)actividad;
                    return $"{huesped.toHtmlAgenda()}{newLine}{unaActividadT.TercerizadaHtml()}Total a Pagar: Actividad Gratuita{newLine}Estado: {estaPago}{newLine}";
                }
            }
            else
            {
                if (actividad is ActividadPropia)
                {
                    ActividadPropia unaActividadP = (ActividadPropia)actividad;
                    return $"{huesped.toHtmlAgenda()}{newLine}{unaActividadP.PropiaHTML()}Total a Pagar: {costo} USD{newLine}Estado: {estaPago}{newLine}";
                }
                else
                {
                    ActividadTercerizada unaActividadT = (ActividadTercerizada)actividad;
                    return $"{huesped.toHtmlAgenda()}{newLine}{unaActividadT.TercerizadaHtml()}Total a Pagar: {costo} USD{newLine}Estado: {estaPago}{newLine}";
                }
            }
        }
            
        }

        #endregion
    }

