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
    public partial class Principal : Form
    {
        ComboControl cbc;
        public Principal()
        {
            InitializeComponent();
            cbc = new ComboControl();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            double porcentaje = 0.5;

            this.Height = Screen.FromControl(this).Bounds.Height -
                         Convert.ToInt32(Screen.FromControl(this).Bounds.Height * porcentaje);

            this.Width = Screen.FromControl(this).Bounds.Width -
                         Convert.ToInt32(Screen.FromControl(this).Bounds.Width * porcentaje);
            this.CenterToScreen();
            this.ShowIcon = false;
            button1.BackgroundImageLayout = ImageLayout.Center;
            button2.BackgroundImageLayout = ImageLayout.Center;
            this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;



        }

        private void button1_Click(object sender, EventArgs e)
        {
            CrudRadio c = new CrudRadio();
            this.Hide();
            c.Closed += (s, args) => this.Close();
            c.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
