using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorDeDispositvos { 

    
    public partial class FormDinamico : Form
    {
        string rutaCompleta = "";
        string nombreArchivo;
        string rutaCarpeta;
        public string carpeta;
        private String path;
        private int indice;
        string directorioBase = "";
        DataGridControl d;

        public Form RefToForm1 { get; set; }
        private int numCatalogo = -1;
        public int numCatGS { get { return this.numCatalogo; } set { this.numCatalogo = value; } }
        public FormDinamico( int n )
        {
            this.numCatGS = n;

            d = new DataGridControl();
            this.d.iniciaBD(0);
            d.ld.RowHeaderMouseClick += this.ld_RowHeaderMouseClick;

            this.Controls.Add(d.ld);

            InitializeComponent();
        }

        /*Metodo que hace referencua a la clase de datagridcontrol para poder
 manipular la informacion proveniente del  catalogo de radios*/
        private void ld_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            try
            {
             //   pictureBox2.Image = Image.FromFile(d.seleccionaRenglonImagen(e.RowIndex));
                MessageBox.Show(d.seleccionaNombreLlave());
            }
            catch
            {


                if (d.seleccionaRenglonImagen(e.RowIndex).Length <= 1)
                {
           //         pictureBox2.Image = pictureBox2.ErrorImage;
                }
            }

         //   pictureBox2.Refresh();
        }

        private void FormDinamico_Load(object sender, EventArgs e)
        {
            this.Text = this.numCatGS.ToString();
            this.CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.RefToForm1.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
