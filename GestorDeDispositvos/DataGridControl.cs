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
        public Size tama;
        public Point p;
        public DataGridView ld;
        public BDSQL baseDatos;

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

            this.baseDatos.leeAtributos(this.baseDatos.listaQry[7]);
            t = this.baseDatos.leeRegistros(this.baseDatos.listaQry[5]);

            tama = new Size(300, 200);
            p = new Point(50, 120);
            ld = new DataGridView();
            inicilizaDataGrid();

            ld.DataSource = t;



        }

        /*Este metodo configura el formato de los datagrid */
        public void inicilizaDataGrid()
        {
            
                ld.Size = tama;
                ld.Location = p;
                ld.BackgroundColor = System.Drawing.Color.LightGreen;
                ld.BringToFront();
            
            ld.ColumnCount = this.baseDatos.lAt.Count();
            
            for (int i = 0; i < this.baseDatos.lAt.Count() ; i++)
            {
                
                ld.Columns[i].Name = this.baseDatos.lAt[i];
            }


        }

        /*Este metodo configura el formato de los datagrid */
        public void llenaDataGrid()
        {
            //this.baseDatos.leeRegistros().

            

            for (int i = 0; i < this.baseDatos.lAt.Count(); i++)
            {

                ld.Columns[i].Name = this.baseDatos.lAt[i];
            }


        }


    }
}
