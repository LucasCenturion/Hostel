using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dominio
{
    public abstract class Usuario//Se agrega clase abstracta Usuario
    {
        #region Atributos
        private string nombre;
        private string apellido;
        private string email;
        private string password;
        #endregion

        #region Propiedades
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        #endregion


        #region Constructor
        public Usuario() { }

        public Usuario(string nombre, string apellido, string email, string password)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.email = email;
            this.password = password;
        }
        #endregion


        #region Metodos

        public void ValidarDatos()
        {
            ValidarNombre();
            ValidarApellido();
            ValidarEmail();
            ValidarPassword();
        }

        private void ValidarNombre()
        {
            if (nombre == null || nombre.Trim().Length < 3)
            {
                throw new Exception("Nombre Inválido! Reintente.");
            }
        }

        private void ValidarApellido()
        {
            if (apellido == null || apellido.Trim().Length < 3)
            {
                throw new Exception("Nombre Inválido! Reintente.");
            }
        }

        private void ValidarEmail()
        {
            char a = '@';
            int buscaChar = email.IndexOf(a);//Defino buscador de caracter @ en el email.
            if (buscaChar == 0 || buscaChar == email.Length - 1 || buscaChar == -1)//Verifico que posicion de @ no este en primer ni ultimo lugar
            {
                throw new Exception("El email ingresado no es válido.");
            }
        }

        private void ValidarPassword()
        {
            if (password.Length < 6)
            {
                throw new Exception("La contrasena debe tener minimo 6 caracteres");
            }
        }

        public string toHtmlAgenda()//Metodo para devolver solo Nombre y Apellido en Agenda
        {
            string newLine = "<br>";
            return $"Nombre: {nombre}{newLine}Apellido: {apellido}";
        }

        public string toHtml()//Metodo para devolver todos los datos del usuario
        {
            string newLine = "<br>";
            return $"Nombre: {nombre}{newLine}Apellido: {apellido}{newLine}Email: {email}";
        }

        #endregion
    }




}
