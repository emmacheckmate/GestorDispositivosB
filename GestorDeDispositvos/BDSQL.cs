﻿using System;
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

        public string nombreEquipo;

        public DataTable dt;

        public List<string> listaQry;
        string cadenacnx = "";

        private string cadenaConexion;
        private string Query;
        private string textboxQry;

        public List< string > lAt;

        public List<string> gslAt { get { return lAt; } set { this.lAt = value;  }  }

        public string txtboxQryGS 
        { get { return this.textboxQry; } set { this.textboxQry = value; }  }
        public string nombEq
        { get { return this.nombreEquipo; } set { this.nombreEquipo = value; } }

        public string QuerySG
        {
            get => Query;
            set => Query = value;
        }
        public string cdncnxSG{
            get { return this.cadenacnx; }
            set { this.cadenacnx = value; }
        }


        /*Constructor del  objeto para el objeto que va a controlar todas las consultas y 
         los objetos relacionados con la base de datos*/
        public BDSQL()
        {
            cadenacnx = "Data Source=DESKTOP-S0SCMU4" +
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
            listaQry.Add("INSERT INTO catRadio (idRadio) VALUES(" +"'"+ this.txtboxQryGS +"'"+ ")");

            listaQry.Add("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS " +
                                                    "Where TABLE_NAME='catRadio' " +
                                                    "ORDER BY ORDINAL_POSITION ");



        }

        /*Carga la conexion de los datos y  la tabla que se va a utilizar*/
        public void leeAtributos(string qry)
        {
            SqlDataAdapter da = new SqlDataAdapter(qry, this.cdncnxSG);
            DataTable dt = new DataTable();
            da.Fill(dt);

            
            for (int i2 = 0; i2 < dt.Rows.Count; i2++) {

                gslAt.Add(dt.Rows[i2].Field<string>(0));
                MessageBox.Show(dt.Rows[i2].Field<string>(0) );
            }
            

        }







    }
}
