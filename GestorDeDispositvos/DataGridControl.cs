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
            tama = new  Size(595, 304);
            p = new Point(0, 0);
            ld = new List<DataGridView>();
            inicializaLista();

        }

        public void inicilizaDataGridRadio()
        {

            ld[0].Size = new System.Drawing.Size(595, 304);
            ld[0].Location = new System.Drawing.Point(29, 197);

            ld[0].ColumnCount = 1;
            ld[0].Columns[0].Name = "Número de Serie";
            ld[0].Columns[0].Width = 150;
            ld[0].BackgroundColor = System.Drawing.Color.LightGreen;

        }

        public void inicilizaDataGridEmpleados()
        {

            ld[0].Size = new System.Drawing.Size(595, 304);
            ld[0].Location = new System.Drawing.Point(29, 197);

            ld[0].ColumnCount = 1;
            ld[0].Columns[0].Name = "Nombre";
            ld[0].Columns[0].Width = 150;
            ld[0].BackgroundColor = System.Drawing.Color.LightGreen;

        }

        public void inicilizaDataGridSucursales()
        {

            ld[1].Size = new System.Drawing.Size(595, 304);
            ld[1].Location = new System.Drawing.Point(29, 197);

            ld[1].ColumnCount = 1;
            ld[1].Columns[0].Name = "Nombre";
            ld[1].Columns[0].Width = 150;
            ld[1].BackgroundColor = System.Drawing.Color.LightGreen;

        }

        public void inicilizaDataGridEstado()
        {

            ld[2].Size = new System.Drawing.Size(595, 304);
            ld[2].Location = new System.Drawing.Point(29, 197);

            ld[2].ColumnCount = 1;
            ld[2].Columns[0].Name = "Nombre";
            ld[2].Columns[0].Width = 150;
            ld[2].BackgroundColor = System.Drawing.Color.LightGreen;

        }
    }
}
