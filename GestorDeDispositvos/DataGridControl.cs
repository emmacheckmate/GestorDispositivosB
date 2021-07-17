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
        public Size tama, tama2;
        public Point p, p2;
        public DataGridView ld;
        private DataGridView dgvReportes;
        public BDSQL baseDatos;
        public List<string> ltxt;
        private List<Label> llb;
        private List<string> renglonReportesL;

        public DataGridView GSdgvReportes { get { return this.dgvReportes; } set { this.dgvReportes = value; } }
        public List<string> GSrenglonReportes { get { return this.renglonReportesL; } set { this.renglonReportesL = value; } }

        /*Metodo de get set de los valores de una lista de los textbox de los catalogos*/
        public List<string> GSltxt { get { return this.ltxt; } set { this.ltxt = value; } }

        /*Lista de los nombres nombres de los nombres de los catalogos*/
        public List<Label> llbGS { get { return this.llb; } set { this.llb = value; } }

        /*Metodo get set de la cuadricula de los datos para manipular los registros de 
         la base de datos*/
        public DataGridView gsDataGrid { get { return this.ld; } set { this.ld = value; } }


        /*Metodo para pasar el valor del indice del datagtird */
        public int getSetIndiceDG { get { return this.index; } set { this.index = value; } }

        /*Get set de la clase de base de datos que se encarga la manipulacion de 
         los regisros de la base de datos */
        public BDSQL getSetBD { get { return this.baseDatos; } set { this.baseDatos = value; } }


        /*Constructor del objeto del drig*/
        public DataGridControl() {
            baseDatos = new BDSQL();
            tama = new Size(450, 300);
            p = new Point(15, 169);

            tama2 = new Size(700, 239);
            p2 = new Point(305, 157);
            ld = new DataGridView();
            dgvReportes = new DataGridView();
            this.inicilizaDataGrid(ld, p, tama, Color.FromArgb(100, 50, 28));
            this.inicilizaDataGrid(this.GSdgvReportes, p2, tama2, Color.FromArgb(100, 50, 28));

            renglonReportesL = new List<string>();
            llb = new List<Label>();
            this.iniLabels();
            ini_datagrid_reportes();





        }

        /*Metodo de inicialziacion de las etiquetas de los nombres de los aributos }
         de la tabla de la base de datos*/
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

            this.llbGS.Add(l);
            this.llbGS.Add(l2);
        }

        /*Parametros para la entrada de información para los 
         atributos de las tablas de los catalogos para formar 
        la consulta dentro de la base de datos*/
        public void texto_labels(string txt1, string txt2)
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
            this.cambia_colores(ld);

            ld.RowsDefaultCellStyle.BackColor = Color.NavajoWhite;
            ld.BackgroundColor = Color.FromArgb(100, 50, 28);
            ld.ClearSelection();
            ld.CurrentCell = null;
        }

        /*Este metodo configura el formato de los datagrid */
        public void inicilizaDataGrid(DataGridView d, Point Loc, Size Tam, Color c) {
            d.Size = Tam;
            d.Location = Loc;
            d.BackgroundColor = c;
            d.BringToFront();
            d.ReadOnly = true;

        }

        /*Inicializa el datagrid para los reportes de los radios 
         establece el numero de columnas y los colores */
        public void ini_datagrid_reportes()
        {
            this.GSdgvReportes.DataSource = this.muestra_reportes();

        }

        public void tama_encabezados()
        {
            this.GSdgvReportes.ColumnHeadersHeight = 60;
            this.GSdgvReportes.Columns[0].Width = 40;
            this.GSdgvReportes.Columns[3].Width = 70;
            this.GSdgvReportes.Columns[1].Width = 70;
            this.GSdgvReportes.Columns[4].Width = 100;
            this.GSdgvReportes.Columns[5].Width = 60;
        }

        public void nombres_encabezados()
        {
            this.GSdgvReportes.Columns[0].HeaderText = "Folio";
        }
        public void cambia_encabezados()
        {
            

            this.tama_encabezados();
            this.nombres_encabezados();
            this.GSdgvReportes.Columns[1].HeaderText = "Fecha de\nEntrega";
            this.GSdgvReportes.Columns[2].HeaderText = "Observaciones";
            this.GSdgvReportes.Columns[3].HeaderText = "Número\nde radio";
            
            this.GSdgvReportes.Columns[4].HeaderText = "Encargado\ndel\nradio ";
            this.GSdgvReportes.Columns[6].HeaderText = "Area";
            
            this.GSdgvReportes.Columns[5].HeaderText = "Sucural";
            
            this.GSdgvReportes.Columns[7].HeaderText = "Estado";
            this.GSdgvReportes.Columns[0].DefaultCellStyle.BackColor = Color.LightBlue;
            this.GSdgvReportes.Columns[2].DefaultCellStyle.BackColor = Color.LightBlue;
            this.GSdgvReportes.Columns[4].DefaultCellStyle.BackColor = Color.LightBlue;
            this.GSdgvReportes.Columns[6].DefaultCellStyle.BackColor = Color.LightBlue;
            this.GSdgvReportes.EnableHeadersVisualStyles = false;
            this.GSdgvReportes.Columns[0].HeaderCell.Style.BackColor = Color.CornflowerBlue;
            this.GSdgvReportes.Columns[1].HeaderCell.Style.BackColor = Color.CornflowerBlue;
            this.GSdgvReportes.Columns[2].HeaderCell.Style.BackColor = Color.CornflowerBlue;
            this.GSdgvReportes.Columns[3].HeaderCell.Style.BackColor = Color.CornflowerBlue;
            this.GSdgvReportes.Columns[4].HeaderCell.Style.BackColor = Color.CornflowerBlue;
            this.GSdgvReportes.Columns[5].HeaderCell.Style.BackColor = Color.CornflowerBlue;
            this.GSdgvReportes.Columns[6].HeaderCell.Style.BackColor = Color.CornflowerBlue;
            this.GSdgvReportes.Columns[7].HeaderCell.Style.BackColor = Color.CornflowerBlue;


            string temp = "";
            for (int i = 0; i < this.GSdgvReportes.Columns.Count; i++) {

                temp = this.GSdgvReportes.Columns[i].HeaderText;
                foreach(var c in temp){
                    
                    if ( (int)c == 10  )
                    {
                        //MessageBox.Show(c.ToString());
                    }

                }
             }


        }
        /*Cambia el color de todos los renglonnes de los datagridview*/
        void cambia_colores( DataGridView dt)
        {
            
            foreach (DataGridViewRow row in dt.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.BackColor = Color.FromArgb(100, 200, 100);
                }   
            }
        }

        /*Inicializa el tamaño */
        public void inicializa_tamaColumnas()
        {
            this.GSdgvReportes.Columns[0].Width = 50;
            this.GSdgvReportes.Columns[1].Width = 55;
            this.GSdgvReportes.Columns[3].Width = 60;
            this.GSdgvReportes.Columns[3].Width = 50;
            this.GSdgvReportes.Columns[5].Width = 70;
            this.GSdgvReportes.Columns[6].Width = 50;
        }

        /*Envia la ruta de la imagen del codigo QR */
        public string seleccionaRenglonImagen(int i)
        {
            var cell = this.ld.Rows[i].Cells[1];
            return cell.Value.ToString();
        }

        public List<string> seleccionaRenglonReportes(int i)
        {
            this.GSrenglonReportes.Clear();
            DataGridViewRow renglon = new DataGridViewRow();

            for (int j = 0; j < this.GSdgvReportes.Rows[i].Cells.Count; j++){
              this.GSrenglonReportes.Add(this.GSdgvReportes.Rows[i].Cells[ j ].Value.ToString() );
            }
        
            return this.GSrenglonReportes;
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

        /*Se establece la fecha para revisar el dia en que se dio
         el radio a otra sucursal */
        public void revisa_fecha(DateTimePicker d)
        {
            
            d.MinDate = new DateTime(1985, 6, 20);
            d.MaxDate = DateTime.Today;
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

           
            if (!String.IsNullOrEmpty( s )){
                
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
               
                return null;
            }
        }


        public DataTable muestra_reportes()
        {
            if (this.getSetBD.leeReportesRadio(this.baseDatos.gsListQry[7]) != null)
                {
                return this.getSetBD.leeReportesRadio(this.baseDatos.gsListQry[7]);

            }
            else return null;


        }
    }
}
