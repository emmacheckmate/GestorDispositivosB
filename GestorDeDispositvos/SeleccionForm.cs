using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorDeDispositvos
{
    public partial class SeleccionForm : Form
    {
       
        public SeleccionForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            FormDinamico fd;
            int index = this.listBox1.SelectedIndex;
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                MessageBox.Show(index.ToString());
                fd = new FormDinamico( index );
                
                fd.RefToForm1 = this;
                this.Visible = false;
                this.Hide();
                fd.Show();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void SeleccionForm_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
