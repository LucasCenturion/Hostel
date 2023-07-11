using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Operador: Usuario
    {
        #region Atributos
        private DateTime fechaInicioEmpresa;
        #endregion

        #region Propiedades
        public DateTime FechaInicioEmpresa { get => fechaInicioEmpresa; set => fechaInicioEmpresa = value; }
        #endregion

        #region Constructor
        public Operador(string nombre, string apellido, string email, string password, DateTime fechaInicioEmpresa) : base(nombre, apellido, email, password)
        {
            this.fechaInicioEmpresa = fechaInicioEmpresa;
        }
        #endregion



        #region Metodos
        public void ValidarOperador()//Validamos metodos Operador
        {
            ValidarFechaInicioEmpresa();
        }
        #endregion

        #region Metodos Utilitarios
        private void ValidarFechaInicioEmpresa()
        {
            if (fechaInicioEmpresa > DateTime.Now.Date)
            {
                throw new Exception("Fecha invalida");
            }
        }
        #endregion

        #region Override
        public override string ToString()
        {
            return base.ToString + ($"Fecha Inicio en la Empresa: {fechaInicioEmpresa}");
        }
        #endregion
    }
}
