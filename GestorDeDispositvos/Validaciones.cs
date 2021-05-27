using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GestorDeDispositvos
{
    /*Clase para realizar todas las validaciones para los 
     datos a ingresar */
    class Validaciones
    {
        List<String> listaPatrones = new List<string>();
        MessageBox msgbx;

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
        /*Metodo constructor para el objeto de validaciones */
         public Validaciones()
        {
            inicializaListaDePatrones();
        }

        /*Este metodo sirve para llenar una lista con los patrones de las expresiones 
         comunes que el usuario para ingresar */
        public void inicializaListaDePatrones()
        {
            /*Patron para el numero de serie del radio*/
            listaPatrones.Add(@"^[a-zA-Z0-9\_]+$");
            /*Numero de emp*/
            listaPatrones.Add(@"^[0-9\_]+$");

        }

        /*02*/
        public void inicializaMsgBox(string mensaje, string caption, MessageBoxButtons b )
        {

        }
        /*Metodo al que va a hacer referencia para verificar los datos que va }
         ingresar para registrar a un empleado */
        public void checaDatosDeEmpleado( string nameE , int numE)
        {


            
        }
    }
}
