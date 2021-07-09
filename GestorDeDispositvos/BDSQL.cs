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
        public List<string> listaQry2;

        public List<string> listTablas;
        string cadenacnx = "";

        private string Query;
        private string llaveQry;
        private string tablaQry;
        private string valueQry;
        private string values;


        public List<string> gsTablas { get { return this.listTablas; } set { this.listTablas = value; } }

        public string gsvalues { get { return this.values; } set { this.values = value; } }
        public List<ComboBox> lcbGS { get { return this.lcb; } set { this.lcb = value; } }
        public string valueQryGS { get { return this.valueQry; } set { this.valueQry = value; } }
        public string tablaQryGS { get { return this.tablaQry; } set { this.tablaQry = value; } }
        public string llaveGS { get { return this.llaveQry; } set { this.llaveQry = value; } }
        public SqlDataAdapter gsda { get { return this.da; } set { this.da = value; } }
        public DataTable gsdt { get { return this.dt; } set { this.dt = value; } }

        public List<string> gsListQry { get { return this.listaQry;  } set { this.listaQry = value; } }



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
            lcb = new List<ComboBox>();

            cadenacnx = "Data Source=" + Environment.MachineName.ToString() +
                                 "\\" +
                                "SQLEXPRESS;Initial Catalog=dbGestDisp;Integrated Security=True";

            listaQry = new List<string>();

            listaQry2 = new List<string>();

            listTablas = new List<string>();
            listaTablas();
            iniciaListaQuery();
        }

        public void listaTablas()
        {
            this.gsTablas.Add("catRadio");
            this.gsTablas.Add("catEmp");
            this.gsTablas.Add("catSucursal");
            this.gsTablas.Add("catArea");
            
            this.gsTablas.Add("catEdo");
        }

        /*Se cargan las consultas mas importantes para el sistema
         dentro de una lista y hacer mas rapido la solicitud y 
        carga de información  */
        public void iniciaListaQuery()
        {
            /*Carga de los catalogos de empleados, areas, tipos de dispositivos
             * y estado del dispostivo y sucursales */
            listaQry.Add("SELECT * FROM catRadio");
            listaQry.Add("SELECT * FROM catEmp");
            listaQry.Add("SELECT * FROM catSucursal");

            listaQry.Add("SELECT * FROM catArea");
            listaQry.Add("SELECT * FROM catEdo");

            listaQry.Add("SELECT * FROM catDisp");
            listaQry.Add("SELECT * FROM reportesRadio ");

            /*Consultas de los IDs de todos los catalogos 
             * de los registros*/
            listaQry.Add("SELECT idRadio FROM catRadio WHERE");
            listaQry.Add("SELECT id FROM numEmp WHERE");
            listaQry.Add("SELECT id FROM catSucursal WHERE");
            listaQry.Add("SELECT id FROM catArea WHERE");
            listaQry.Add("SELECT id FROM catEdo WHERE");
            listaQry.Add("SELECT id FROM catDisp WHERE");
            


            listaQry.Add("" +
                "select r.numero_reporte, r.fecha_asignacion, r.observaciones, a.nombre_area, r.numero_radio," +
                 "r.sucursal, edo.nombre, emp.nombEmp " +
                "from[dbGestDisp].[dbo].[reportesRadio] as r" +
                "left join [dbGestDisp].[dbo].[catArea] as a on a.clave_area = r.area" +
                "left join [dbGestDisp].[dbo].[catRadio] as cr on cr.idRadio = r.numero_radio" +
                "left join [dbGestDisp].[dbo].[catSucursal] as su on su.idsuc = r.sucursal" +
                "left join [dbGestDisp].[dbo].[catEdo] as edo on edo.codigo_estado = r.estado" +
                "left join [dbGestDisp].[dbo].[catEmp] as emp on emp.numEmp = r.resp ");
                                   
        }

        /*Carga la conexion de los datos y  la tabla que se va a utilizar*/
        public void leeAtributos(string qry)
        {
            
            SqlDataAdapter da = new SqlDataAdapter(qry, this.cdncnxSG);
            DataTable dt = new DataTable();

             da.Fill(this.gsdt);         
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

        public List<string> buscaRegistros(string qry, string datoBuscar, int i)
        {
            List<string> registros = new List<string>();
            SqlDataAdapter da = new SqlDataAdapter(qry, this.cdncnxSG);
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            MessageBox.Show(qry);
            da.Fill(dt);


            foreach (DataColumn col in dt.Columns)
            {
                foreach (DataRow row in dt.Rows)
                {
                    registros.Add(row[col.ColumnName].ToString());
                }
            }

            return registros;
        }

        public DataTable actualizaReg(string qry)
        {
            List<string> renglon = new List<string>();
            SqlDataAdapter da = new SqlDataAdapter(qry, this.cdncnxSG);
            
            DataTable dt = new DataTable();
            
            
            try
            {

                da.Fill(dt);
                MessageBox.Show("Registro Insertado correctamente", "",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
            }
            catch {
                MessageBox.Show("Número de serie repetido", "",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }

            return dt;
        }

        public DataTable leeReportesRadio(string qry)
        {
            List<string> renglon = new List<string>();
            SqlDataAdapter da = new SqlDataAdapter(qry, this.cdncnxSG);

            DataTable dt = new DataTable();
            
            try
            {
                da.Fill(dt);
                MessageBox.Show("Lectura de base de datos correcta", "",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("No se pudo leer la base de datos", "",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }

            return dt;
        }

        public DataTable eliminaReg(string qry)
        {
            List<string> renglon = new List<string>();
            SqlDataAdapter da = new SqlDataAdapter(qry, this.cdncnxSG);

            DataTable dt = new DataTable();
            FormDinamico f;

            try
            {

                da.Fill(dt);
                MessageBox.Show("Registro Eliminado correctamente", "",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("No se puede eliminar, información que pertenece a otros registros", "",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }

            return dt;
        }

    }
}
