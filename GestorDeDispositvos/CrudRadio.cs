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
        DataGridControl d;
        ComboControl cbc;

        public CrudRadio()
        {
            cbc = new ComboControl();
            
            InitializeComponent();
            cbc.iniCBLista();
            cbc.llenaCatalogos( );
            for (int i = 0; i < 5; i++)
            {
                panel1.Controls.Add(cbc.lcbGS[i]);
                panel1.Controls.Add(cbc.llbGS[i]);
            }

            d = new DataGridControl();
            this.da
            this.d.iniciaBD(n);
            d.ld.RowHeaderMouseClick += this.ld_RowHeaderMouseClick;

            this.Controls.Add(d.ld);

        }

        public void inicializa_tooltip()
        {
            ToolTip toolTip1 = new ToolTip();

            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(txtNumEmp, "Se genera automaticamente al crear un reporte.");

        }
        private void CrudRadio_Load(object sender, EventArgs e)
        {
            this.inicializa_tooltip();
            label2.Text = "Administrador" + "\nde Catalogos";


            txtNumEmp.TabStop = true;

            this.dateTimePicker2.Value = new DateTime(2012, 05, 28);
            panel1.BackColor = Color.FromArgb(255, 192, 128);
            panel1.Controls.Add(groupBox1);
            groupBox1.SendToBack();
            this.CenterToScreen();

            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button2.BackgroundImageLayout = ImageLayout.Stretch;
            button3.BackgroundImageLayout = ImageLayout.Stretch;
            button4.BackgroundImageLayout = ImageLayout.Stretch;
            button5.BackgroundImageLayout = ImageLayout.Stretch;

            ///this.SetBounds(20, 20, 300, 300);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

          
            this.SizeGripStyle = SizeGripStyle.Hide;

            this.MinimizeBox = false;
            this.MaximizeBox = false;

          


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
        }
        

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            ReportesForm r = new ReportesForm();
            r.ShowDialog();

        }
    }
}
