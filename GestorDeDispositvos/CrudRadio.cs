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
using System.Drawing.Printing;    

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
            

            d = new DataGridControl();
           // this.da
           // this.d.iniciaBD(n);

            d.dgvReportes.RowHeaderMouseClick += this.dgvReportes_RowHeaderMouseClick;
            this.Controls.Add(d.ld);
            this.Controls.Add(this.d.dgvReportes);
            panel1.Controls.Add(this.d.dgvReportes);

        }

        public void dgvReportes_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                d.seleccionaRenglonReportes(e.RowIndex);
            }
            catch{  }
        }
        public void inicializa_tooltip()
        {
            ToolTip toolTip1 = new ToolTip();

            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(txtNumEmp, "Se genera automaticamente al crear un reporte.");

        }

        public void inicializa_texto() 
        {
            label2.Text = "Administrador" + "\nde Catalogos";
            txtNumEmp.TabStop = true;
        }

        public void configura_paneles()
        {
            panel1.BackColor = Color.FromArgb(255, 192, 128);
            panel1.Controls.Add(groupBox1);
            for (int i = 0; i < 5; i++)
            {
                // Lista de comboboxes
                panel1.Controls.Add(cbc.lcbGS[i]);

                // Lista de etiquetas
                panel1.Controls.Add(cbc.llbGS[i]);
            }
        }


        public void configura_iconos()
        {
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button2.BackgroundImageLayout = ImageLayout.Stretch;
            button3.BackgroundImageLayout = ImageLayout.Stretch;
            button4.BackgroundImageLayout = ImageLayout.Stretch;
            button5.BackgroundImageLayout = ImageLayout.Stretch;
        }
        private void CrudRadio_Load(object sender, EventArgs e)
        {
            this.inicializa_texto();
            this.inicializa_tooltip();
            this.configura_iconos();
            this.configura_paneles();

            this.dateTimePicker2.Value = new DateTime(2012, 05, 28);

            this.Width = 1200;
            this.Height = 467;
             

            groupBox1.SendToBack();
            this.CenterToScreen();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.SizeGripStyle = SizeGripStyle.Hide;
            this.MinimizeBox = false;
            this.MaximizeBox = false;

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

        private void button5_Click(object sender, EventArgs e)
        {
            SeleccionForm sf;
            sf = new SeleccionForm();
            sf.ShowDialog();
        }
        
        private void button6_Click_1(object sender, EventArgs e)
        {
            ReportesForm r = new ReportesForm();
            r.ShowDialog();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            PrintDialog PrintDialog = new PrintDialog();
            PrintDialog.ShowDialog();
            string name = PrintDialog.PrinterSettings.PrinterName;

            string s = "string to print";

            PrintDocument p = new PrintDocument();
            p.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
            {
                e1.Graphics.DrawString(s, new Font("Times New Roman", 12), new SolidBrush(Color.Black), 
                                          new RectangleF(0, 0, p.DefaultPageSettings.PrintableArea.Width, 
                                          p.DefaultPageSettings.PrintableArea.Height));

            };
            try
            {
                p.Print();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Occured While Printing", ex);
            }
        }


    }
}
