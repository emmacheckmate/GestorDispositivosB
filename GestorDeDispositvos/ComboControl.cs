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
        public List<ComboBox> lcb ;
        public List<Label> llb;
        public List< List<string> > listaClaves;
        public List<Label> llbGS { get { return this.llb; } set { this.llb = value; } }

        public ComboControl()
        {
            llb = new List<Label>();
            bd = new BDSQL();
            lcb = new List<ComboBox>();
            listaClaves = new List< List<string> >();
           
        }

       
        public List<ComboBox> lcbGS { get { return this.lcb; } set { this.lcb = value; } }

        

        /*Se inicializa la lista de los combox para
         * mostrar todos los catalogos de las tablas*/
        public void iniCBLista()
        {
            string[] arr = new string[] { "Número de Radio", "Reponsable encargado ", "Sucursal", "Área", "Condición del radio:" };

            Point p = new Point(200, 50);
            int x = 25, y = 190;

            Random r = new Random();

            for (int i = 0; i < 5; i++)
            {
                this.llbGS.Add(new Label());
                this.llbGS[ i ].Text = arr[ i ];
                
                this.lcbGS.Add(new ComboBox());
                
                this.lcbGS[ i ].Location = new Point(x, y);
                this.lcbGS[ i ].BringToFront();
                this.llbGS[ i ].Location = new Point(x, y-15);
                this.llbGS[i].BackColor=   Color.FromArgb(255, 224, 192);
                this.lcbGS[i].ForeColor = System.Drawing.Color.Black;

                this.lcbGS[i].Size = new System.Drawing.Size(180, 26);

                this.lcbGS[i].BackColor = Color.FromArgb(r.Next(20, 244), 140, 63);
                this.lcbGS[i].Font = new Font("Arial", 7, FontStyle.Bold);


                y += 35;
            }

            this.lcbGS[ 0 ].Text = "Elegir";
            this.lcbGS[ 1 ].Text = "Seleccionar";
            this.lcbGS[ 2 ].Text = "Establecer";
            this.lcbGS[ 3 ].Text = "Indicar";
            this.lcbGS[ 4 ].Text = "Asignar";
            this.lcbGS[0].TabIndex = 8;
            this.lcbGS[1].TabIndex = 9;
            this.lcbGS[2].TabIndex = 10;
            this.lcbGS[3].TabIndex = 11;
            this.lcbGS[4].TabIndex = 12;
        }

        /*Este metodo se utiliza para llenar los valores de los combobox
         con todos los registros de cada una de las tables*/
        public void llenaCatalogos()
        {
            DataTable d = new DataTable();
            
            /*Se ingresa a la lista de los combos y 
             * los catalogos que va ser cargados en }
             * dentro de cada combo*/


            List<string> s = new List<string>() ;
            List<string> s2 = new List<string>();

            for (int i = 0; i < this.lcbGS.Count; i++) {
                d = bd.leeRegistros(this.bd.listaQry[i]);

                foreach (DataColumn col in d.Columns){
                    if (col.Ordinal == 0){
                        this.listaClaves.Add(new List<string>());
                        foreach (DataRow row in d.Rows){
                            this.listaClaves[i].Add(row[col.Ordinal].ToString());
                        }
                    }
                }

                foreach (DataRow dtRow in d.Rows){
                    s.Clear();

                    foreach (DataColumn dc in d.Columns)
                    {
                        s.Add(dtRow[dc].ToString());
                        
                    }
                    
                    if ( d.Columns.Count == 2 && i != 0 )
                    {
                        this.lcbGS[i].Items.Add(s[1]);
                    }
                    else 
                    {
                        this.lcbGS[i].Items.Add(s[0]);
                    }   
                }   
            }
        }


        public void muestra_listaDListas()
        {
            string datos = "";
            foreach (List<string> l in this.listaClaves)
            {
                
                foreach(string ll in l)
                {
                    datos += ll + " " ;
                }
                datos += "\n\n";
            }
            //MessageBox.Show(datos);
        }

        



    }
}

