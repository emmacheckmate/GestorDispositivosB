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
        private SqlDataAdapter da;
        private DataTable dt; 

        public List<DataGridViewRow> ldgv;
        public string nombreEquipo;

        

        public List<string> listaQry;
        string cadenacnx = "";

        
        private string Query;
        private string llaveQry;
        private string tablaQry;
        private string valuesQry;
        private string valorabuscar;

        public List<string> lAt;

        public string valorabuscarGS { get { return this.valuesQry; } set { this.valuesQry = value; } }
        public string valueQryGS { get { return this.valuesQry; } set { this.valuesQry = value; } }
        public string tablaQryGS { get { return this.tablaQry; } set { this.tablaQry = value; } }
        public string llaveGS { get { return this.llaveQry; } set { this.llaveQry = value; } }
        public SqlDataAdapter gsda { get { return this.da; } set { this.da = value; } }
        public DataTable gsdt { get { return this.dt; } set { this.dt = value;  } }
        public List<DataGridViewRow> ldgvGS { get { return ldgv; } set { this.ldgv = value; } }
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


        /*Constructor del  objeto para el objeto que va a controlar todas las consultas y 
         los objetos relacionados con la base de datos*/
        public BDSQL()
        {
            dt = new DataTable();
             da = new SqlDataAdapter();


            cadenacnx = "Data Source=" + Environment.MachineName.ToString() +
                                 "\\" +
                                "SQLEXPRESS;Initial Catalog=dbGestDisp;Integrated Security=True";

            listaQry = new List<string>();
            lAt = new List<string>();
            iniciaListaQuery();
        }

        /*Inicializa la lista de combos para los catalogos */

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

            /*Consultas para la insercion de datos */
            listaQry.Add("INSERT INTO catRadio (idRadio) VALUES(" + "'" + this.valueQryGS + "'" + ")");

            /*Consulta para obtener el nombre de los atributos*/
            listaQry.Add("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS " +
                                                    "Where TABLE_NAME='catSucursal' " +
                                                    "ORDER BY ORDINAL_POSITION ");

            /*Consulta para tablas que tienen  llaves de tipo entero*/
            listaQry.Add("SELECT "+ this.llaveGS + 
                         "FROM" + this.tablaQry +
                         "WHERE " + this.llaveGS  + this.valorabuscarGS);


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
