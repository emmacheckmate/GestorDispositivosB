using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GestorDeDispositvos
{
    class ComboControl
    {
        private BDSQL bd;
        public List<ComboBox> lcb;
        public List<Label> llb;
      
        public ComboControl()
        {
            llb = new List<Label>();
            bd = new BDSQL();
            lcb = new List<ComboBox>();
        }

        public List< Label > llbGS { get { return this.llb; } set { this.llb = value; } }
        public List<ComboBox> lcbGS { get { return this.lcb; } set { this.lcb = value; } }

        /*Se inicializa la lista de los combox para
         * mostrar todos los catalogos de las tablas*/
        public void iniCBLista()
        {
            string[] arr = new string[] { "Número de Radio", "Reponsable encargado ", "Sucursal", "Área", "Condición del radio:" };

            Point p = new Point(200, 50);
            int x = 400, y = 150;
            
            for (int i = 0; i < 5; i++)
            {
                this.llbGS.Add(new Label());
                this.llbGS[ i ].Text = arr[ i ];
                this.lcbGS.Add(new ComboBox());
                this.lcbGS[ i ].Location = new Point(x, y);
                this.lcbGS[ i ].BringToFront();
                this.llbGS[ i ].Location = new Point(x, y-15);

                y += 40;
            }
            

        }

        /*Este metodo se utiliza para llenar los valores de los combobox
         con todos los registros de cada una de las tables*/
        public void llenaCatalogos()
        {
            DataGridView ld = new DataGridView();

            DataTable d = bd.leeRegistros("");
            ld.DataSource = d;

            /*Se ingresa a la lista de los combos y 
             * los catalogos que va ser cargados en }
             * dentro de cada combo*/
            for (int j = 0; j < this.lcbGS.Count; j++)
            {
                for (int i = 0; i < ld.Rows.Count; i++)
                {
                    /*Se pasa la informacion del datable al
                    datagridview para solo obtener los nombres  */
                    this.lcbGS[j].Items.Add(ld.Rows[i].Cells[1].ToString());
                    
                         //panel1.Controls.Add(cbc.lcbGS[i]);
                }
            }
        }
        /*Inicializa la lista de combos para los catalogos */



    }
}
