using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System;

namespace GestorDeDispositvos
{
    class ComboControl
    {
        private BDSQL bd;
        public List<ComboBox> lcb , lcb2;
        public List<Label> llb;
        public List<Label> llbGS { get { return this.llb; } set { this.llb = value; } }

        public ComboControl()
        {
            llb = new List<Label>();
            bd = new BDSQL();
            lcb = new List<ComboBox>();
            lcb2 = new List<ComboBox>();
        }

       
        public List<ComboBox> lcbGS { get { return this.lcb; } set { this.lcb = value; } }

        public List<ComboBox> lcbGS2 { get { return this.lcb2; } set { this.lcb2 = value; } }

        /*Se inicializa la lista de los combox para
         * mostrar todos los catalogos de las tablas*/
        public void iniCBLista()
        {
            string[] arr = new string[] { "Número de Radio", "Reponsable encargado ", "Sucursal", "Área", "Condición del radio:" };

            Point p = new Point(200, 50);
            int x = 400, y = 150;

            Random r = new Random();

            for (int i = 0; i < 5; i++)
            {
                this.llbGS.Add(new Label());
                this.llbGS[ i ].Text = arr[ i ];
                this.lcbGS.Add(new ComboBox());
                this.lcbGS2.Add(new ComboBox());
                this.lcbGS[ i ].Location = new Point(x, y);
                this.lcbGS[ i ].BringToFront();
                this.llbGS[ i ].Location = new Point(x, y-15);
                this.llbGS[i].BackColor=   Color.FromArgb(255, 224, 192);
                this.lcbGS[i].ForeColor = System.Drawing.Color.Black;
                this.lcbGS[i].BackColor = Color.FromArgb(r.Next(20, 244), 140, 63);
                this.lcbGS[i].Font = new Font("Arial", 7, FontStyle.Bold);


                y += 40;
            }
          



        }

        /*Este metodo se utiliza para llenar los valores de los combobox
         con todos los registros de cada una de las tables*/
        public void llenaCatalogooos()
        {
            DataTable d = new DataTable();
            
            
            
            
            

            /*Se ingresa a la lista de los combos y 
             * los catalogos que va ser cargados en }
             * dentro de cada combo*/


            List<string> s = new List<string>() ;

            for (int i = 0; i < this.lcbGS.Count; i++)
            {
                d = bd.leeRegistros(this.bd.listaQry[ i ]);

                foreach (DataRow dtRow in d.Rows)
                {
                    s.Clear();

                    foreach (DataColumn dc in d.Columns)
                    {
                        s.Add(dtRow[dc].ToString());

                    }

                    this.lcbGS[i].Items.Add(s[0]);
                    if (d.Columns.Count == 2)
                    {
                        this.lcbGS2[i].Items.Add(s[1]);
                    }
                }
            }
            

        
        }
        



    }
}

