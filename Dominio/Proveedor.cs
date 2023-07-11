using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Proveedor
    {
        #region Atributos
        private string nombre;
        private string telefono;
        private string direccion;
        private int descuento;
        #endregion

        #region Propiedades
        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public int Descuento { get => descuento; set => descuento = value; }
        #endregion

        #region Constructor
        public Proveedor() 
        {

        }
        public Proveedor(string nombre, string telefono, string direccion, int descuento)
        {
            this.nombre = nombre;
            this.telefono = telefono;
            this.direccion = direccion;
            this.descuento = descuento;
        }
        #endregion

        #region Metodos
        public void Validar()
        {
            ValidarNombre();
            ValidarTelefono();
            ValidarDireccion();
        }
        #endregion

        #region Metodos Utilitarios
        private void ValidarNombre()
        {
            if (nombre == null || nombre == "")
            {
                throw new Exception("El nombre no puede ser vacio!");
            }            
        }//Validamos que nombre no sea nulo
        private void ValidarTelefono()
        {
            if (telefono.Length < 8 || validarTelefonoNumero()==false) 
            {
                throw new Exception("El telefono debe contener 8 digitos numericos!");
            }
        }//Validamos que telefono tenga 8 digitos numericos
        private void ValidarDireccion() 
        {  
            if (direccion == null) 
            { 
                throw new Exception("Debe ingresar la direccion correspondiente"); 
            } 
        }//Validamos que direccion no sea nulo
        private bool validarTelefonoNumero() //Validamos que Telefono sean solo numeros.
        {
            for (int i = 0; i < telefono.Length; i++)
            {
                if (telefono[i] < '0' || telefono[i] > '9')
                {
                    return false;
                }
            }
            return true;
        }


        #endregion

        #region Override
        public override string ToString()
        {
            return ($"Nombre: {nombre} \nTelefono: {telefono} \nDireccion: {direccion} \nDescuento: {descuento} USD\n\n");
        }
        #endregion
    }
}
