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
        List<string> listaErrores = new List<string>(); 
        List<String> listaPatrones = new List<string>();

        private  string nombrev;
        private int numemp;
        public string Nombre
        {
            set { this.nombrev = value; }
            get { return nombrev; }
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
            /*sucursal*/
            listaPatrones.Add(@"^[0-9\_]+$");
        }

        /*02*/
        public void inicializaMsgBox( )
        {
            listaErrores.Add("Número de serie de radio no valida");
            listaErrores.Add("Nombre de empleado no valido");
            listaErrores.Add("Nombre ingresado no válido");
            listaErrores.Add("Fecha ingresada incorrecta");


        }
        /*Metodo al que va a hacer referencia para verificar los datos que va 
         ingresar para registrar a un empleado */
        public void checaDatosDeEmpleado( string nameE , int numE)
        {


            
        }
    }
}
