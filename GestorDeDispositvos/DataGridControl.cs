using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

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
            baseDatos = new BDSQL();
            this.baseDatos.leeAtributos(this.baseDatos.listaQry[7]);
            tama = new  Size( 595, 304 );
            p = new Point( 29, 197 );
            ld = new DataGridView();
            inicilizaDataGrid();
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

        /*Establece el numero de columnas para cada datagrid y
         los nombres de la base de datos */ 
        public void setColumnasNombres( List<string> et )
        {
            ld.ColumnCount = et.Count();
            
            
        }
    }
}
