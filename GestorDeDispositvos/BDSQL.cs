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
        /*Lista de combox que se encarga de mostrar la informacion de 
         los catalogos, da se encargar de hacer la instancia y la cadena de conexion 
        dt se encarga */
        private List<ComboBox> lcb;
        private SqlDataAdapter da;
        private DataTable dt;

      
        public string nombreEquipo;

        public List<string> listaQry;
        string cadenacnx = "";

        private string Query;
        private string llaveQry;
        private string tablaQry;
        private string valueQry;
        private string valorNuevo;

       

        public List<string> lAt;

        public string valorNuevoGS { get { return this.valorNuevo; } set { this.valorNuevo = value; } }
        public List<ComboBox> lcbGS { get { return this.lcb; } set { this.lcb = value; } }
        public string valueQryGS { get { return this.valueQry; } set { this.valueQry = value; } }
        public string tablaQryGS { get { return this.tablaQry; } set { this.tablaQry = value; } }
        public string llaveGS { get { return this.llaveQry; } set { this.llaveQry = value; } }
        public SqlDataAdapter gsda { get { return this.da; } set { this.da = value; } }
        public DataTable gsdt { get { return this.dt; } set { this.dt = value; } }
     
        public List<string> gslAt { get { return lAt; } set { this.lAt = value; } }


        public string nombEq
        { get { return this.nombreEquipo; } set { this.nombreEquipo = value; } }

        public string QuerySG
        {
            get => Query;
            set => Query = value;
        }
        public string cdncnxSG {
            get { return this.cadenacnx; }
            set { this.cadenacnx = value; }
        }

        public BDSQL(int modoReportes)
        {
            dt = new DataTable();
            da = new SqlDataAdapter();
            lcb = new List<ComboBox>();

            cadenacnx = "Data Source=" + Environment.MachineName.ToString() +
                                 "\\" +
                                "SQLEXPRESS;Initial Catalog=dbGestDisp;Integrated Security=True";

            listaQry = new List<string>();
            lAt = new List<string>();
            iniciaListaQuery();
            iniCBLista();
        }


        /*Constructor del  objeto para el objeto que va a controlar todas las consultas y 
         los objetos relacionados con la base de datos*/
        public BDSQL()
        {
            dt = new DataTable();
            da = new SqlDataAdapter();
            lcb = new List<ComboBox>();

            cadenacnx = "Data Source=" + Environment.MachineName.ToString() +
                                 "\\" +
                                "SQLEXPRESS;Initial Catalog=dbGestDisp;Integrated Security=True";

            listaQry = new List<string>();
            lAt = new List<string>();
            iniciaListaQuery();
        }

        /*Se inicializa la lista de los combox para
         * mostrar todos los catalogos de las tablas*/
        public void iniCBLista() 
        {
            for (int i = 0; i < 5; i++) {
                this.lcbGS.Add( new ComboBox());
            }
        }

        /*Este metodo se utiliza para llenar los valores de los combobox
         con todos los registros de cada una de las tables*/
        public void llenaCatalogos()
        {
            DataGridView ld = new DataGridView();

            DataTable d = this.leeRegistros("");
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
                }
            }
            

            // cell.Value.ToString();

        }
        /*Inicializa la lista de combos para los catalogos */

        
        /*Se cargan las consultas mas importantes para el sistema
         dentro de una lista y hacer mas rapido la solicitud y 
        carga de información  */
        public void iniciaListaQuery()
        {
            /*Carga de los catalogos de empleados, areas, tipos de dispositivos
             * y estado del dispostivo y sucursales */
            listaQry.Add("SELECT * FROM catRadio");
            listaQry.Add("SELECT * FROM catArea");
            listaQry.Add("SELECT * FROM catDisp");
            listaQry.Add("SELECT * FROM catEdo");
            listaQry.Add("SELECT * FROM catEmp");
            listaQry.Add("SELECT * FROM catSucursal");

            /*Consultas para la insercion, actualizacion de datos para los radios */
            listaQry.Add("INSERT INTO catRadio (idRadio) VALUES(" + "'" + this.valueQryGS + "'" + ")");

            //UPDATE para la catologo de radios
            listaQry.Add("UPDATE catRadio SET"+this.llaveGS+"='"+this.valueQryGS+"'"+
                                               
                         "WHERE"+this.llaveGS +"='"+this.valorNuevoGS +"'" );

            /*Consulta para obtener el nombre de los atributos*/
            listaQry.Add("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS " +
                                                    "Where TABLE_NAME='catSucursal' " +
                                                    "ORDER BY ORDINAL_POSITION ");



        }

        /*Carga la conexion de los datos y  la tabla que se va a utilizar*/
        public void leeAtributos(string qry)
        {
            
            SqlDataAdapter da = new SqlDataAdapter(qry, this.cdncnxSG);
            DataTable dt = new DataTable();

             da.Fill(this.gsdt);  
         //   MessageBox.Show("No se pudo encontrar base de datos"); 
          
        }


        /*Carga la conexion de los datos y  la tabla que se va a utilizar*/
        public DataTable leeRegistros(string qry)
        {
            List<string> renglon = new List<string>();
            SqlDataAdapter da = new SqlDataAdapter(qry, this.cdncnxSG);
            DataTable dt = new DataTable();
            da.Fill(dt); 
            return dt;
        }

    }
}
