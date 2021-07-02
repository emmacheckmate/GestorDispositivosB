using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using Microsoft.VisualBasic;

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
        public DataGridView ld, gdvReportes;
        public BDSQL baseDatos;
        public List<string> ltxt;
        private List<Label> llb;

        public List<string> GSltxt { get { return this.ltxt; } set { this.ltxt = value; } }
        public List<Label> llbGS { get { return this.llb; } set { this.llb = value; } }

        public DataGridView gsDataGrid { get { return this.ld; } set { this.ld = value; } }


        /*Metodo para pasar el valor del indice del datagtird */
        public int getSetIndiceDG
        {
            get { return this.index; }
            set { this.index = value; }
        }

        public BDSQL getSetBD
        {
            get { return this.baseDatos; }

            set { this.baseDatos = value; }
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
            tama = new Size(500, 300);
            p = new Point(15, 250);
            ld = new DataGridView();
            this.inicilizaDataGrid();
            llb = new List<Label>();
            this.iniLabels();
            gdvReportes = new DataGridView();

        }

        public void iniLabels()
        {
            Label l = new Label();
            Label l2 = new Label();
            l.Size = new System.Drawing.Size(300, 30);
            l.Location = new System.Drawing.Point(15, 50);
            l.ForeColor = Color.Black;
            l.Font = new Font("Arial", 10, FontStyle.Bold);
            l.BringToFront();

            l2.Location = new System.Drawing.Point(15, 80);
            l2.ForeColor = Color.Black;
            l2.Font = new Font("Arial", 10, FontStyle.Bold);
            l2.BringToFront();

            //Catalogo  de radios 

            this.llbGS.Add(l);
           
            this.llbGS.Add( l2 );
          
        }

        public void texto_labels(string txt1 , string txt2)
        {
            this.llbGS[0].Text = txt1;
            this.llbGS[1].Text = txt2;
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

        public void inicializaDGReportes()
        {
            ld.ColumnCount = 4;
        }


        /*Este metodo configura el formato de los datagrid */
        public void inicilizaDataGrid() {
            ld.Size = tama;
            ld.Location = p;
            ld.BackgroundColor = Color.FromArgb(255, 192, 128);
            ld.BringToFront();
            ld.ReadOnly = true;
        }

        public string seleccionaRenglonImagen(int i)
        {
            var cell = this.ld.Rows[i].Cells[1];
            return cell.Value.ToString();
        }

        public List<string> seleccionaInformacion(int i)
        {
            List<string> t = new List<string>();

            for(int j = 0; j < this.ld.Columns.Count; j++ )
            {
                t.Add(this.ld.Rows[i].Cells[j].Value.ToString());
            }
            return t;
        }

        public string seleccionaNombreLlave()
        {

            var cell = this.ld.Columns[0].Name;
            return cell.ToString();
        }

        public string seleccionaRenglonLlave(int i)
        {

            var cell = this.ld.Rows[i].Cells[0];
            return cell.Value.ToString();
        }

        public List<string> manda_datos()
        {
            
            List<string> t = new List<string>();
            if (this.getSetIndiceDG != -1)
            {
                foreach (DataGridViewRow row in ld.SelectedRows){
                    t.Add(row.Cells[0].Value.ToString());
                    t.Add(row.Cells[1].Value.ToString());
                }
            }
            return t;
        }
        public void insertaReg(string txtb1, string txtb2, int indiceCatalogo) {
            this.getSetBD.valueQryGS = "\u0027" + txtb1 + "\u0027" + "," + "\u0027" + txtb2 + "\u0027";

            this.getSetBD.gsvalues = "";

            foreach (DataGridViewColumn s in this.ld.Columns) {
                this.getSetBD.gsvalues += s.Name.ToString() + ","; }

            this.getSetBD.llaveGS = this.ld.Columns[ 0 ].Name;
            this.getSetBD.gsvalues= this.getSetBD.gsvalues.TrimEnd(',');


            /*insert into catRadio(idRadio, codigoQR) values('ABC123','c:/imagen.jpg');*/

            string Qry = "INSERT INTO " + this.getSetBD.gsTablas[indiceCatalogo] +
                         " ("+ this.getSetBD.gsvalues + ") "+
                         " VALUES (" + this.getSetBD.valueQryGS + ");" ;

            this.getSetBD.actualizaReg(Qry);
        }
        public void configPrincipal()
        {
            this.getSetBD.gsvalues = "";
        }
        public void updateReg(string txtb1, string txtb2, int indiceCatalogo)
        {
            List<string> nombre = new List<string>();
            List<string> txtbx = new List<string>();
            txtbx.Clear();
            txtbx.Add(txtb1);
            txtbx.Add(txtb2);
           
            this.getSetBD.gsvalues = "";
            foreach (DataGridViewColumn s in this.ld.Columns)
            {
                nombre.Add (s.Name.ToString());
            }

            for (int cont = 0; cont < nombre.Count; cont++)
            {
                this.getSetBD.gsvalues += " " + nombre[cont] + " = " + "'" + txtbx[cont] +"'"+ ",";
            }


            this.getSetBD.gsvalues = this.getSetBD.gsvalues.TrimEnd(',');
            this.getSetBD.llaveGS = this.ld.Columns[0].Name;
            

            string Qry = "UPDATE " + this.getSetBD.gsTablas[indiceCatalogo]  +"\n"+
                         " SET " + this.getSetBD.gsvalues + "\n" +
                         " WHERE " + this.getSetBD.llaveGS + " = " +
                         "'"+this.seleccionaRenglonLlave(this.getSetIndiceDG)+"'" + ";";
            
            this.getSetBD.actualizaReg(Qry);
        }

        public void eliminaReg(string txtb1, string txtb2, int indiceCatalogo)
        {
            this.getSetBD.valueQryGS = "\u0027" + txtb1 + "\u0027";

            

            this.getSetBD.llaveGS = this.ld.Columns[0].Name;
            this.getSetBD.gsvalues = this.ld.Columns[0].Name +" = "+ "\u0027" + txtb1 + "\u0027";

            string Qry = "DELETE FROM " + this.getSetBD.gsTablas[indiceCatalogo] +
                         " WHERE " + this.getSetBD.gsvalues    +"; " ;
           
            this.getSetBD.eliminaReg(Qry);
        }

        public List<string> buscarReg(int indiceCatalogo)
        {
            string Qry = "";
            string s = Interaction.InputBox("Escribir " + this.ld.Columns[0].Name, "Buscar");

           
            if (!String.IsNullOrEmpty( s ))
            {
                
                //s = Interaction.InputBox("Escribir " + this.ld.Columns[0].Name, "Buscar");
                if (indiceCatalogo == 4)
                {
                    Qry = "SELECT * " +
                          " FROM " + this.getSetBD.gsTablas[indiceCatalogo] +
                          " WHERE " + this.ld.Columns[0].Name + " = " +
                          "" + s + ";";
                }
                else 
                {
                    Qry = "SELECT * " +
                    " FROM " + this.getSetBD.gsTablas[indiceCatalogo] +
                    " WHERE " + this.ld.Columns[0].Name + " = " +
                    "'" + s + "';";
                }
                this.GSltxt = this.getSetBD.buscaRegistros(Qry, s, indiceCatalogo);
                foreach (DataGridViewRow row in this.ld.Rows)
                {
                    for (int index = 0; index < ld.ColumnCount - 1; index++)
                    {
                        DataGridViewCell cell = row.Cells[index];
                        if (cell.Value == DBNull.Value || cell.Value == null)
                            continue;
                        if (cell.Value.ToString().Contains( this.GSltxt[0]) )
                        {
                          
                            this.ld.ClearSelection();
                            this.ld.Rows[row.Index].Selected = true;
                            this.getSetIndiceDG = row.Index;
                        }
                    }
                }

                            return this.GSltxt;

            }
            else
            {
                MessageBox.Show("Ingresar clave a buscar");
                //this.baseDatos.buscaRegistros( Qry  );

                return null;
            }
        }
    }
}
