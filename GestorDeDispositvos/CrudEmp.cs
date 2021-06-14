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
        public CrudEmp()
        {
            InitializeComponent();
        }

        private void CrudEmp_Load(object sender, EventArgs e)
        {

            this.ShowIcon = false;
            txtNombEmp.Text = "";
            txtNumEmp.Text = "";


            new Impresion();

        }

        private void txtNombEmp_Validating(object sender, CancelEventArgs e)
        {
           
        }
    }
}
