using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace GestorDeDispositvos
{
    /*Clase que se encarga de administrar y mandar las consultas 
     dentro de la base de datos, también los objetos que se utilizaran
    en los diferentes formularios en los que se den las altas, bajas y 
    las modificaciones en las tablas
    */
    class BDSQL
    {
        public int numCataLogos = 5;
        public List<DataGridView> ldgCat;

        public DataTable dt;
        public List<ComboBox> combos;
        public List<string> listaQry;
        string cadenacnx = "Data Source=DESKTOP-S0SCMU4" + 
                                                    "\\" + 
                            "SQLEXPRESS;Initial Catalog=dbGestDisp;Integrated Security=True";

        private string cadenaConexion;
        private string Query;
        private string nomBD;
        private string equipo;

        public string QuerySG
        {
            get => Query;
            set => Query = value;
        }
        public string cdncnxSG
        {
            get => cadenaConexion;
            set => cadenaConexion = value;
        }

        /*incializa datagridview */
        public void iniDGV()
        {
            for(int c =0; c < numCataLogos; c++) { ldgCat.Add(new DataGridView()); }
        }
        /*Constructor del  objeto para el objeto que va a controlar todas las consultas y 
         los objetos relacionados con la base de datos*/
        public BDSQL()
        {
            combos = new List<ComboBox>();
            ldgCat = new List<DataGridView>();
            listaQry = new List<string>();

            iniCombox();
            iniDGV();
        }

        /*Inicializa la lista de combos para los catalogos */
        public void iniCombox() {
            for (int i = 0; i < 2; i++)
            {
                combos.Add(new ComboBox());
            }
        }
        public void iniciListaQuery()
        {
            /*Carga de los catalogos de empleados, areas, tipos de dispositivos
             * y estado del dispostivo y sucursales */
            listaQry.Add("SELECT * FROM catArea");
            listaQry.Add("SELECT * FROM catDisp");
            listaQry.Add("SELECT * FROM catEdo");
            listaQry.Add("SELECT * FROM catEmp");
            listaQry.Add("SELECT * FROM catSucursal");

        }
        public void inicializaSQLAdpater(string qry)
        {
          SqlDataAdapter da = new SqlDataAdapter( qry ,  cadenaConexion );
        }

        public void inicializa_dgv( int i )
        {



            ldgCat[0].Size = new System.Drawing.Size(595, 304);
            ldgCat[0].Location = new System.Drawing.Point(29, 197);

                ldgCat[0].ColumnCount = 5;
                ldgCat[0].Columns[0].Name = "No. Ser";

                ldgCat[0].Columns[0].Width = 150;
                ldgCat[0].Columns[1].Name = "DIR_AT";
                ldgCat[0].Columns[2].Name = "DIR_ENT  ";
                ldgCat[0].Columns[3].Name = "DIR_DATOS";
                ldgCat[0].Columns[4].Name = "SIG_ENT";
                ldgCat[0].BackgroundColor = System.Drawing.Color.LightGreen;
                ldgCat[0].Columns[1].Visible = false;
                ldgCat[0].Columns[2].Visible = false;
                ldgCat[0].Columns[3].Visible = false;
                ldgCat[0].Columns[4].Visible = false;
            
        }
    }
}
