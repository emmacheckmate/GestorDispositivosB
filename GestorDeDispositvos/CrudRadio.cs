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
            dataGridEnt.BringToFront();


        }

        private void CrudRadio_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da1 = new SqlDataAdapter("SELECT * FROM catArea ", "Data Source=DESKTOP-S0SCMU4" + "\\" + "SQLEXPRESS;Initial Catalog=dbGestDisp;Integrated Security=True");
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Information_Schema.Columns Where catArea PRDER NY COLUMN_NAME ", 
                                                    "Data Source=DESKTOP-S0SCMU4" + 
                                                    "\\" +
                                                    "SQLEXPRESS;Initial Catalog=dbGestDisp;Integrated Security=True");

            DataTable dt = new DataTable();
            da.Fill(dt);
            
            for (int i = 0; i < dt.Rows.Count; i++  )
            {
                
                comboBox1.Items.Add(dt.Rows[i].Field<string>(0));
            }
            
          //


        }

        public void inicilizaDataGridEntidad()
        {

            dataGridEnt.Size = new System.Drawing.Size(595, 304);
            dataGridEnt.Location = new System.Drawing.Point(29, 197);

            dataGridEnt.ColumnCount = 5;
            dataGridEnt.Columns[0].Name = "No. Ser";

            dataGridEnt.Columns[0].Width = 150;
            dataGridEnt.Columns[1].Name = "DIR_AT";
            dataGridEnt.Columns[2].Name = "DIR_ENT  ";
            dataGridEnt.Columns[3].Name = "DIR_DATOS";
            dataGridEnt.Columns[4].Name = "SIG_ENT";
            dataGridEnt.BackgroundColor = System.Drawing.Color.LightGreen;
            dataGridEnt.Columns[1].Visible = false;
            dataGridEnt.Columns[2].Visible = false;
            dataGridEnt.Columns[3].Visible = false;
            dataGridEnt.Columns[4].Visible = false;
        }

        public void cargaCatalogos(int filas, ComboBox c)
        { }

     
    }
}
