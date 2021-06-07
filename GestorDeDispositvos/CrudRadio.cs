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
        

        public CrudRadio()
        {
            InitializeComponent();
             
        }

        private void CrudRadio_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT nombArea FROM catArea ", "Data Source=DESKTOP-S0SCMU4" + "\\" + "SQLEXPRESS;Initial Catalog=dbGestDisp;Integrated Security=True");

            DataTable dt = new DataTable();
            da.Fill(dt);
            
            for (int i = 0; i < dt.Rows.Count; i++  )
            {
                comboBox1.Items.Add(dt.Rows[i].Field<string>(0));
            }
            



        }
    }
}
