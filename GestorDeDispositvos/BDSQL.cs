using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace GestorDeDispositvos
{
    class BDSQL
    {
        public DataTable dt;

        string cadenacnx = "Data Source=DESKTOP-S0SCMU4" + "\\" + "SQLEXPRESS;Initial Catalog=dbGestDisp;Integrated Security=True";
        private string cadeConexion;
        private string Query;
        

        public string QuerySG
        {
            get => Query;
            set => Query = value;
        }
        public string cdncnxSG
        {
            get => cadeConexion;
            set => cadeConexion = value;
        }

        
        public void inicializaSQLAdpater(string qry)
        {
          SqlDataAdapter da = new SqlDataAdapter( qry ,  cadeConexion );
         
        }
    }
}
