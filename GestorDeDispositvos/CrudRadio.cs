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
        ComboControl cbc;

        public CrudRadio()
        {
            cbc = new ComboControl();
            
            InitializeComponent();
            cbc.iniCBLista();
            for (int i = 0; i < 5; i++)
            {
                panel1.Controls.Add(cbc.lcbGS[i]);
                panel1.Controls.Add(cbc.llbGS[i]);
            }
        }

        private void CrudRadio_Load(object sender, EventArgs e)
        {
            
            panel1.BackColor = Color.FromArgb(255, 192, 128);
            


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtNumEmp.Text = "";
        }
    }
}
