using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace GestorDeDispositvos
{
    public partial class CrudEmp : Form
    {
        DataGridControl d;
        public CrudEmp()
        {
            InitializeComponent();

            d = new DataGridControl();
            this.d.iniciaBD(4);

            //   d.ld.RowHeaderMouseClick += this.ld_RowHeaderMouseClick;
            this.Controls.Add(d.ld);
        }

        private void CrudEmp_Load(object sender, EventArgs e)
        {
            this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            double porcentajeAnch = 0.5, porcentajeAlt = 0.3;

            this.Height = Screen.FromControl(this).Bounds.Height -
                         Convert.ToInt32(Screen.FromControl(this).Bounds.Height * porcentajeAlt);

            this.Width = Screen.FromControl(this).Bounds.Width -
                         Convert.ToInt32(Screen.FromControl(this).Bounds.Width * porcentajeAnch);
            this.CenterToScreen();
            this.ShowIcon = false;
            txtNombEmp.Text = "";
         


            

        }

        private void txtNombEmp_Validating(object sender, CancelEventArgs e)
        {
           
        }
    }
}
