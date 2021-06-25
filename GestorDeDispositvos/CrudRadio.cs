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
            panel1.Controls.Add(groupBox1);
            groupBox1.SendToBack();
            this.CenterToScreen();
            


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

        private void button6_Click(object sender, EventArgs e)
        {
                    }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SeleccionForm sf;
            sf = new SeleccionForm();
            sf.ShowDialog();
            this.control
          //  ResetAllControlsBackColor( System.Windows.Forms.Control );
        }
        // Reset all the controls to the user's default Control color. 
        private void ResetAllControlsBackColor(Control control)
        {
            control.BackColor = SystemColors.Control;
            control.ForeColor = SystemColors.ControlText;
            if (control.HasChildren)
            {
                // Recursively call this method for each child control.
                foreach (Control childControl in control.Controls)
                {
                    ResetAllControlsBackColor(childControl);
                }
            }
        }
    }
}
