using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ActividadPropia: Actividad
    {
        #region Atributos
        public enum lugares{GIMNASIO, SALA_SPA, PATIO_TERRAZA, PISCINA_INTERIOR, PISCINA_EXTERIOR, SALON_PLANTA_BAJA}
        private Usuario huesped;
        private string personaResponsable;
        private lugares lugar;
        private string actividadAirelibre;
        #endregion

        #region Propiedades
        public string PersonaResponsable { get => personaResponsable; set => personaResponsable = value; }
        private lugares Lugar { get => lugar; set => lugar = value; }
        public string ActividadAirelibre { get => actividadAirelibre; set => actividadAirelibre = value; }
        public Usuario Huesped { get => huesped; }
        #endregion

        #region Constructor
        public ActividadPropia(int identificador, string nombre, string descripcion, DateTime fecha, int cantidadMaxima, int edadMinima, decimal costo, string personaResponsable, lugares lugar, string actividadAirelibre):base(identificador,nombre,descripcion,fecha,cantidadMaxima,edadMinima,costo)
        {
            this.personaResponsable = personaResponsable;
            this.lugar = lugar;
            this.actividadAirelibre = actividadAirelibre;
        }
        #endregion

        #region Metodos
        public void ValidarDatos()
        {
            validarPersonaResponsable();
            validarLugar();
            ValidarAireLibre();
        }
        #endregion

        #region Metodos Utilitarios
        public void validarPersonaResponsable()
        {
            if (PersonaResponsable == null)
            {
                throw new Exception("El responsable de la actividad no puede ser nulo!");
            }
        }
        public void validarLugar()
        {
            if (!Enum.IsDefined(typeof(lugares), Lugar))
            {
                throw new Exception("El lugar ingresado no es válido!");
            }
        }
        public bool ValidarAireLibre()
        {
            bool validar = false;
            if (actividadAirelibre == "SI")
            {
                validar = true;
            }
            if (actividadAirelibre == "NO")
            {
                validar = false;
            }
            else
            {
                throw new Exception("Ingreso Incorrecto!");
            }
            return validar;
        }
        #endregion

        #region Override
        public override decimal CalcularCosto(decimal costo)
        {
            return costo;
        }

        public override string ToString()
        {
            return ($"Nombre Actividad: {Nombre}\n" +
                $"Fecha Actividad: {Fecha.ToShortDateString()}\nLugar: {lugar}\n--------------------");
        }

        public string PropiaHTML()
        {
            string newLine = "<br>";
            return base.toHtml() + ($"{newLine}Lugar: {lugar}{newLine}");
        }
        #endregion
    }
}
