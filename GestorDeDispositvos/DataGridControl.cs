using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace GestorDeDispositvos
{
    class DataGridControl
    {
        /*Atributos para la clase: index es es la posicion del renglon 
         tama es el tamaño de la cuadricula del datagridview, point indica la posicion 
        dentro del area del formulario, ld es el datagrid view que se encarga de mover 
        y direccionar la informacion dentro de la base de datos
        baseDatos se encarga de abrir y hacer una conexión con la base de 
        datos */
        private int index = -1;
        public Size tama;
        public Point p;
        public DataGridView ld;
        public BDSQL baseDatos;

        public List<Label> llb;
        public List<Label> llbGS { get { return this.llb; } set { this.llb = value; } }


        /*Metodo para pasar el valor del indice del datagtird */
        public Size getSetIndiceDG
        {
            get { return this.tama; }
            set { this.tama = value; }
        }


        /*Metodo de asignacion del tamaño para el  data grid */
        public Size getSetSize
        {
            get { return this.tama; }
            set { this.tama = value; }
        }

        /*Este metodo es para asignar la posicion del  datagrid */
        public Point getSetP
        { get { return this.p; } set { this.p = value; } }

        /*Constructor del objeto del drig*/
        public DataGridControl()
        {
            baseDatos = new BDSQL();
            tama = new Size(800, 300);
            p = new Point(15, 200);
            ld = new DataGridView();
            this.inicilizaDataGrid();

            llb = new List<Label> ();
          //  iniLabels();

        }

        public void iniLabels()
        {
            //Catalogo  de 
            this.llbGS.Add(new Label());
            this.llbGS[0].Text = "Número de Serie:";
            this.llbGS.Add(new Label());
            this.llbGS[1].Text = "Código QR:";

            //Catalogo de empleados
            this.llbGS.Add(new Label());
            this.llbGS[2].Text = "Número de asignación:";
            this.llbGS.Add(new Label());
            this.llbGS[3].Text = "Nombre:";

            //Sucursales solo van a utilizarse como B6..etc
            this.llbGS.Add(new Label());
            this.llbGS[4].Text = "Código:";

            //Estados
            this.llbGS.Add(new Label());
            this.llbGS[5].Text = "Codigo:";

            this.llbGS.Add(new Label());
            this.llbGS[5].Text = "Diagnostico:";
        }

        public void eligeEtiquetas()
        {

        }
        /*Se le manda como parametro el indice de la lista del Qry 
         del predeterminado para las consultas mas comunes en el sitema*/
        public void iniciaBD(int numQry)
        {
            DataTable t = new DataTable();
            t = this.baseDatos.leeRegistros(this.baseDatos.listaQry[numQry]);
            ld.DataSource = t;
            ld.ClearSelection();
            ld.CurrentCell = null;
        }

        /*Este metodo configura el formato de los datagrid */
        public void inicilizaDataGrid(){
            ld.Size = tama;
            ld.Location = p;
            ld.BackgroundColor = Color.FromArgb(255, 192, 128);
            ld.BringToFront();
            ld.ReadOnly = true;
        }

        public string seleccionaRenglonImagen( int i )
        {
            var cell = this.ld.Rows[i].Cells[1];
            return cell.Value.ToString();
        }

        public string seleccionaNombreLlave()
        {
            
            var cell = this.ld.Columns[ 0 ].Name;
            return cell.ToString();
        }

        public string seleccionaRenglonLlave(int i)
        {

            var cell = this.ld.Rows[i].Cells[0];
            return cell.Value.ToString() ;
        }

        /*Este metodo configura el formato de los datagrid */
        public void llenaDataGrid()
        {
           
            

            for (int i = 0; i < this.baseDatos.lAt.Count(); i++)
            {

                ld.Columns[i].Name = this.baseDatos.lAt[i];
            }


        }


    }
}
