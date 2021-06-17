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
        private int index = -1;
        public Size tama;
        public Point p;
        public DataGridView ld;
        public BDSQL baseDatos;

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
        { get { return this.p;  } set { this.p = value;  }   }

        /*Constructor del objeto del drig*/
        public DataGridControl()
        {
            DataTable t = new DataTable();

            baseDatos = new BDSQL();

            
            t = this.baseDatos.leeRegistros(this.baseDatos.listaQry[0]);

            tama = new Size(300, 200);
            p = new Point(250, 150);
            ld = new DataGridView();
            

            ld.DataSource = t;
            inicilizaDataGrid();



        }

        /*Este metodo configura el formato de los datagrid */
        public void inicilizaDataGrid()
        {
            
                ld.Size = tama;
                ld.Location = p;
                ld.BackgroundColor = System.Drawing.Color.PeachPuff;
                ld.BringToFront();
                ld.ReadOnly = true;
          

        }

        public string seleccionaRenglonImagen( int i )
        {
            string ima = "";
            var cell = this.ld.Rows[ i ].Cells[ 1 ];

            ima = cell.Value.ToString();
            if ( ima.Length == 0) { ima = "NULL"; }
            
            return ima;
        }

        public void seleccionaRenglonLlave(int i)
        {

            var cell = this.ld.Rows[i].Cells[0];
            //MessageBox.Show(cell.Value.ToString());
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
