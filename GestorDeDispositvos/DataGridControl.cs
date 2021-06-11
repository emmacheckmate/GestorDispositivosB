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
        public List<DataGridView> ld;

        public void inicializaLista()
        {
            for( int i = 0; i < 5; i++ )
            { ld.Add( new DataGridView() ); }
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
            tama = new  Size( 595, 304 );
            p = new Point( 29, 197 );
            ld = new List<DataGridView>();
            inicializaLista();
            inicilizaListaDataGrids();
        }

        /*Este metodo estable el formato de los datagrid */
        public void inicilizaListaDataGrids()
        {
            for (int i = 0; i < ld.Count; i++)
            {
                ld[i].Size = tama;
                ld[i].Location = p;
                ld[i].Columns[0].Width = 150;
                ld[i].BackgroundColor = System.Drawing.Color.LightGreen;
                ld[i].BringToFront();

            }

            ld[0].ColumnCount = 1;
            ld[0].Columns[0].Name = "Número de Serie";


        }
    }
}
