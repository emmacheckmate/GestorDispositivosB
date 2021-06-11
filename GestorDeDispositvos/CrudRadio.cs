using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GestorDeDispositvos
{
    public partial class CrudRadio : Form
    {

        DataGridView dataGridEnt ; 
        public CrudRadio()
        {
            dataGridEnt = new DataGridView();

            InitializeComponent();
            this.Controls.Add(dataGridEnt);
            this.inicilizaDataGridRadio();
            dataGridEnt.BringToFront();


        }

        private void CrudRadio_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM catEmp  ", "Data Source=DESKTOP-S0SCMU4" + "\\" + "SQLEXPRESS;Initial Catalog=dbGestDisp;Integrated Security=True");
            SqlDataAdapter da1 = new SqlDataAdapter("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS " +
                                                    "Where TABLE_NAME='catArea' ORDER BY ORDINAL_POSITION ", 
                                                    "Data Source=DESKTOP-S0SCMU4" + 
                                                    "\\" +
                                                    "SQLEXPRESS;Initial Catalog=dbGestDisp;Integrated Security=True");

            DataTable dt = new DataTable();
            da.Fill(dt);
            

            for (int i2 = 0; i2 < dt.Rows.Count; i2++)
            {

                comboBox1.Items.Add(dt.Rows[i2].Field<string>(0));
            }
            da1.Fill(dt);
            
            
            for (int i = 0; i < dt.Columns.Count-1; i++  )
            {
                MessageBox.Show(dt.Columns[i].ColumnName);
                
            }
            
            //


        }

        public void inicilizaDataGridRadio()
        {

            dataGridEnt.Size = new System.Drawing.Size(595, 304);
            dataGridEnt.Location = new System.Drawing.Point(29, 197);

            dataGridEnt.ColumnCount =1;
            dataGridEnt.Columns[0].Name = "Número de Serie";
            dataGridEnt.Columns[0].Width = 150;
            dataGridEnt.BackgroundColor = System.Drawing.Color.LightGreen;
            
        }

        public void inicilizaDataGridEmpleados()
        {

            dataGridEnt.Size = new System.Drawing.Size(595, 304);
            dataGridEnt.Location = new System.Drawing.Point(29, 197);

            dataGridEnt.ColumnCount = 1;
            dataGridEnt.Columns[0].Name = "Nombre";
            dataGridEnt.Columns[0].Width = 150;
            dataGridEnt.BackgroundColor = System.Drawing.Color.LightGreen;

        }

        public void inicilizaDataGridSucursales()
        {

            dataGridEnt.Size = new System.Drawing.Size(595, 304);
            dataGridEnt.Location = new System.Drawing.Point(29, 197);

            dataGridEnt.ColumnCount = 1;
            dataGridEnt.Columns[0].Name = "Nombre";
            dataGridEnt.Columns[0].Width = 150;
            dataGridEnt.BackgroundColor = System.Drawing.Color.LightGreen;

        }

        public void inicilizaDataGridEstado()
        {

            dataGridEnt.Size = new System.Drawing.Size(595, 304);
            dataGridEnt.Location = new System.Drawing.Point(29, 197);

            dataGridEnt.ColumnCount = 1;
            dataGridEnt.Columns[0].Name = "Nombre";
            dataGridEnt.Columns[0].Width = 150;
            dataGridEnt.BackgroundColor = System.Drawing.Color.LightGreen;

        }
       
    }
}
