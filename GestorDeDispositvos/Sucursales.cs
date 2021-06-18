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
    public partial class sucursales : Form
    {
        DataGridControl d;
        public sucursales()
        {
            InitializeComponent();


            d = new DataGridControl();
            this.d.iniciaBD(5);

            //   d.ld.RowHeaderMouseClick += this.ld_RowHeaderMouseClick;
            this.Controls.Add(d.ld);
        }

        private void sucursales_Load(object sender, EventArgs e)
        {
            double porcentajeAnch = 0.5, porcentajeAlt = 0.3; 

            this.Height = Screen.FromControl(this).Bounds.Height -
                         Convert.ToInt32(Screen.FromControl(this).Bounds.Height * porcentajeAlt);

            this.Width = Screen.FromControl(this).Bounds.Width -
                         Convert.ToInt32(Screen.FromControl(this).Bounds.Width * porcentajeAnch);
            this.CenterToScreen();
            this.ShowIcon = false;
        }
    }
}
