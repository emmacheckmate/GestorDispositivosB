using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace GestorDeDispositvos
{
    /*Clase para realizar todas las validaciones para los 
     datos a ingresar */
    class Validaciones
    {
        List<String> listaPatrones = new List<string>();

        private  string nombrev;
        private int numemp;
        public string Nombre
        {
            get => nombrev;
            set => nombrev = value;
        }

        public int numero
        {
            get => numemp;
            set => numemp = value;
        }

         public Validaciones()
        {
            inicializaListaDePatrones();
        }

        public void inicializaListaDePatrones()
        {
            listaPatrones.Add(@"^[a-zA-Z0-9\_]+$");

        }
        public void checaDatosDeEmpleado( string nameE , int numE)
        {
            
        }
    }
}
