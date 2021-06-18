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
        public Principal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
