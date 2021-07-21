using System;
using System.IO;
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
using System.Globalization;
using Microsoft.Reporting.WinForms;
using System.Xml;
using System.Threading;
using System.Drawing.Imaging;


namespace GestorDeDispositvos
{

    public partial class CrudRadio : Form
    {
        private int i = 0;

       
        DataGridControl d;
        ComboControl cbc;
        public List<int> posiciones;
        public List<int> tamaLetras;
        public List<int> posDeCuadros;

        // Declare the dialog.
        internal PrintPreviewDialog PrintPreviewDialog1 = new PrintPreviewDialog();

        // Declare a PrintDocument object named document.
        private System.Drawing.Printing.PrintDocument document = new System.Drawing.Printing.PrintDocument();


        public List<string> posicionesTxt;
        public CrudRadio()
        {
            cbc = new ComboControl();
            InitializeComponent();
            cbc.iniCBLista();
            cbc.llenaCatalogos();
            this.InitializePrintPreviewDialog();
            posiciones = new List<int>();
            tamaLetras = new List<int>();
            posiciones = new List<int>();
            posicionesTxt = new List<string>();
            posDeCuadros = new List<int>();


            d = new DataGridControl();

            d.GSdgvReportes.RowHeaderMouseClick += this.dgvReportes_RowHeaderMouseClick;
            cbc.lcbGS[0].SelectedIndexChanged += this.SelectedIndexChanged_CB1;


            this.Controls.Add(d.ld);
            this.Controls.Add(this.d.GSdgvReportes);
            panel1.Controls.Add(this.d.GSdgvReportes);
            
        }

        public void inicializa_combo_boxes()
        {
            cbc.lcbGS[0].SelectedIndexChanged += this.SelectedIndexChanged_CB1;
        }

        public void SelectedIndexChanged_CB1(object sender, EventArgs e)
        {
            
        }

        

        // Initalize the dialog.

        private void InitializePrintPreviewDialog()
        {

            // Create a new PrintPreviewDialog using constructor.
            this.PrintPreviewDialog1 = new PrintPreviewDialog();

            //Set the size, location, and name.
            this.PrintPreviewDialog1.ClientSize =
                new System.Drawing.Size(400, 300);
            this.PrintPreviewDialog1.Location =
                new System.Drawing.Point(29, 29);
            this.PrintPreviewDialog1.Name = "Impresion de reporte";

            // Associate the event-handling method with the 
            // document's PrintPage event.
            this.document.PrintPage +=
                new System.Drawing.Printing.PrintPageEventHandler
                (this.printDocument1_PrintPage_1);

            this.document.DefaultPageSettings.Landscape = true;

            // Set the minimum size the dialog can be resized to.
            this.PrintPreviewDialog1.MinimumSize =
                new System.Drawing.Size(375, 250);

            // Set the UseAntiAlias property to true, which will allow the 
            // operating system to smooth fonts.
            this.PrintPreviewDialog1.UseAntiAlias = true;
        }




        public void dgvReportes_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (d.seleccionaRenglonReportes(e.RowIndex) != null)
                {
                    this.pasaDatosAControles();
                    

                }
            }
            catch { }
        }


        public void pasaDatosAControles() {
            /*
            MessageBox.Show(d.GSrenglonReportes[0]);
            MessageBox.Show(d.GSrenglonReportes[1]);
            MessageBox.Show(d.GSrenglonReportes[2]);
            MessageBox.Show(d.GSrenglonReportes[3]); //num radio
            MessageBox.Show(d.GSrenglonReportes[4]); //Nombre
            MessageBox.Show(d.GSrenglonReportes[5]); //Suc
            MessageBox.Show(d.GSrenglonReportes[6]);//Area
            MessageBox.Show(d.GSrenglonReportes[7]); //Estado
            */

            this.cbc.lcb[0].SelectedIndex = cbc.buscaEnCombo(d.GSrenglonReportes[3], 0);
            this.cbc.lcb[1].SelectedIndex = cbc.buscaEnCombo(d.GSrenglonReportes[4], 1);
            this.cbc.lcb[2].SelectedIndex = cbc.buscaEnCombo(d.GSrenglonReportes[5], 2);
            this.cbc.lcb[3].SelectedIndex = cbc.buscaEnCombo(d.GSrenglonReportes[6], 3);
            this.cbc.lcb[4].SelectedIndex = cbc.buscaEnCombo(d.GSrenglonReportes[7], 4);


            txtFolio.Text = d.GSrenglonReportes[0];
            this.obsRichtxt.Text = d.GSrenglonReportes[2];
            List<string> fecha = new List<string>();

            this.fechaAsigDatePicker.Value = System.Convert.ToDateTime(d.GSrenglonReportes[1].Substring(0, 10));

        }


        public void copia_datos_controles(List<string> datostxt)
        {
            this.txtFolio.Text = "";
            this.obsRichtxt.Text = "";
        }

        public void inicializa_tooltip()
        {
            ToolTip toolTip1 = new ToolTip();

            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(txtFolio, "Se genera automaticamente al crear un reporte.");

        }

        public void inicializa_texto()
        {
            label2.Text = "Administrador" + "\nde Catalogos";
            txtFolio.TabStop = true;
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

        /*Configura el tamaño de las imagenes de los iconos
         que se utilizan para los botones*/
        public void configura_iconos()
        {
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button2.BackgroundImageLayout = ImageLayout.Stretch;
            button3.BackgroundImageLayout = ImageLayout.Stretch;
            button4.BackgroundImageLayout = ImageLayout.Stretch;
            button5.BackgroundImageLayout = ImageLayout.Stretch;
        }

        /*Metodo que establece configuraciones y valores del formulario
         */
        private void CrudRadio_Load(object sender, EventArgs e)
        {

            
            this.inicializa_texto();
            this.inicializa_tooltip();
            this.configura_iconos();
            this.configura_paneles();
            this.d.cambia_encabezados();

            // this.fechaAsigDatePicker.Value = new DateTime(2012, 05, 28);

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
            txtFolio.Text = "";
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
           

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
        }

        private void button7_Click_1(object sender, EventArgs e)
        {


        }

        public string contruyeFecha(DateTime d)
        {
            string fecha = "";
            List<string> meses = new List<string>();
            meses.Add("Enero"); meses.Add("Febrero"); meses.Add("Marzo"); meses.Add("Abril");
            meses.Add("Mayo"); meses.Add("Junio"); meses.Add("Julio"); meses.Add("Agosto");
            meses.Add("Septiembre"); meses.Add("Octubre"); meses.Add("Noviembre"); meses.Add("Diciembre");

            string[] sacaFecha = d.ToString().Split(' ');
            string[] sacaDias = sacaFecha[0].Split('/');
            
            
            for (int i = 0; i < meses.Count; i++) {
                if ((Convert.ToInt32(sacaDias[1]) - 1) == i)
                { 
                    fecha = sacaDias[0] + " de " + meses[i] + " del " + sacaDias[2];  
                }
            }
           
            return fecha;

        }

        private void printDocument1_PrintPage_1(object sender, PrintPageEventArgs e)
        {
            DateTime TheDate = new DateTime();

            TheDate = DateTime.Now;
            ;

            Font dateFont = new Font("Arial", 10, FontStyle.Regular);
            Font printFont = new Font("Arial", 9);
            Font headFont = new Font("Arial", 17);
            Font titleFont = new Font("Arial", 9, FontStyle.Bold);


            e.Graphics.DrawString(this.contruyeFecha(TheDate), dateFont, Brushes.Black, 920f, 70f);

            int xPos = 50;
            int xPosR = 30;


            float topMargin = e.MarginBounds.Top + 90;
            float yPos = 200;
            float yPosT = 160;

            float linesPerPage = 0;
            int count = 0;
            string texto = "";
            DataGridViewRow row = new DataGridViewRow();
            Image image2 = Image.FromFile("c:\\images.jpg");

            this.encabezados_reporte(e, xPos, yPosT, titleFont);
            this.LLenaLista(xPos); this.LLenaListaTama();
            this.LLenaListaPosCuad(xPos);
            Bitmap imageM = new Bitmap(image2, new Size(image2.Width / 2, image2.Height / 2));
            Pen pen = new Pen(Color.Black, 3);

            Pen penCuadro = new Pen(Color.Black, 2);

            Point[] points = { new Point(50,  100), new Point(document.PrinterSettings.PaperSizes[0].Height-50, 100), };
            document.DefaultPageSettings.PaperSize = document.PrinterSettings.PaperSizes[0];
            

            e.Graphics.DrawLines(pen, points);
            e.Graphics.DrawString("Reporte de radios", headFont, Brushes.Black, 470f, 60f);

            Rectangle r2 = new Rectangle(25, 150,
                            document.PrinterSettings.PaperSizes[0].Height - 50,
                            document.PrinterSettings.PaperSizes[0].Width - 200);
            e.Graphics.DrawRectangle(pen, r2);

            // Calculamos el número de líneas que caben en cada página.
            linesPerPage = e.MarginBounds.Height / printFont.GetHeight(e.Graphics);

            Rectangle r = new Rectangle( 25 , 150 , 
                                        document.PrinterSettings.PaperSizes[0].Height - 50, 
                                        document.PrinterSettings.PaperSizes[0].Width - 200);
            //e.Graphics.DrawRectangle(pen, r );
            e.Graphics.DrawImage(imageM, 20f, 20f);

            while (count < linesPerPage &&
                   i < this.d.GSdgvReportes.Rows.Count)
            {
                this.posicionesTxt.Clear();
                List<string> t = new List<string>();
                row = this.d.GSdgvReportes.Rows[i];
                texto = "";
                
                if (row != null)
                {
                    for (int cont = 0; cont < row.Cells.Count; cont++)
                    {
                        
                        if (row.Cells[cont].Value != null) {
                            if (row.Cells[cont].Value.ToString().Contains('/'))
                            {
                                t.Add(row.Cells[cont].Value.ToString().Substring(0, 10));
                                this.posicionesTxt.Add(row.Cells[cont].Value.ToString().Substring(0, 10) );

                            }
                            else { t.Add(row.Cells[cont].Value.ToString());
                                this.posicionesTxt.Add(row.Cells[cont].Value.ToString());
                            }
                        }
                        
                    }

                }




                yPos = topMargin + (count * printFont.GetHeight(e.Graphics));

                if (posicionesTxt.Count > 0)
                {
                    for (int x = 0; x <= 7; x++){
                        this.dibujaYConfigCuadro(r2, printFont, e, this.posDeCuadros[x], yPos, penCuadro, this.tamaLetras[x]);
                        e.Graphics.DrawString(this.posicionesTxt[x], printFont, Brushes.Black, this.posiciones[x] , yPos);
                    }
                }

                count++;
                i++;
            }
            if (i < this.d.GSdgvReportes.Rows.Count)
                e.HasMorePages = true;
            else{
                e.HasMorePages = false;
                i = 0;
            }
            
        }

        public void dibujaYConfigCuadro(Rectangle r2 ,Font printFont,PrintPageEventArgs e, int xPos, float yPos, Pen penCuadro, int W)
        {
            r2.X += xPos;
            r2.Y = (int)yPos;
            r2.Width = 50;
            r2.Width = W;
            r2.Height = (int)printFont.GetHeight(e.Graphics);
            e.Graphics.DrawRectangle(penCuadro, r2);

        }

        public void encabezados_reporte(PrintPageEventArgs e, float xP, float yP, Font titleFont)
        {
            e.Graphics.DrawString("Número\nde Folio", titleFont, Brushes.Black, xP, yP);
            e.Graphics.DrawString("Fecha\nde Asignación", titleFont, Brushes.Black, xP + 60, yP);
            e.Graphics.DrawString("Observaciones", titleFont, Brushes.Black, xP + 330, yP);
            e.Graphics.DrawString("Número\nde Radio", titleFont, Brushes.Black, xP + 610, yP);
            e.Graphics.DrawString("Reponsable", titleFont, Brushes.Black, xP + 700, yP);
            e.Graphics.DrawString("Beta", titleFont, Brushes.Black, xP + 825, yP);
            e.Graphics.DrawString("Área", titleFont, Brushes.Black, xP + 880, yP);
            e.Graphics.DrawString("Estado", titleFont, Brushes.Black, xP + 950, yP);
        }

        public void LLenaLista(float xP)
        {
            posiciones.Add(65);
            posiciones.Add((int)xP + 75);
            posiciones.Add((int)xP + 160);

            posiciones.Add((int)xP + 600);

            posiciones.Add((int)xP + 675);
            posiciones.Add((int)xP + 840);
            posiciones.Add((int)xP + 863);
            posiciones.Add((int)xP + 943);
        }

        public void LLenaListaPosCuad(float xP)
        {


            posDeCuadros.Add(25);
            posDeCuadros.Add((int)xP +30);
            posDeCuadros.Add((int)xP + 130);

            posDeCuadros.Add((int)xP + 574);

            posDeCuadros.Add((int)xP + 650);

            posDeCuadros.Add((int)xP + 810);

            posDeCuadros.Add((int)xP + 837);
            posDeCuadros.Add((int)xP + 918);
        }

        public void LLenaListaTama()
        {
             
            this.tamaLetras.Add( 50 );
            this.tamaLetras.Add( 95 );
            this.tamaLetras.Add( 438 );
            this.tamaLetras.Add( 70 );
            this.tamaLetras.Add( 155 );

            this.tamaLetras.Add(23 );
            this.tamaLetras.Add( 75 );
            this.tamaLetras.Add(77);
           
        }
        private void button8_Click(object sender, EventArgs e)
        {
            document.DocumentName = "Relación de Radio Frecuencias";
            PrintPreviewDialog1.Document = document;
            PrintPreviewDialog1.ShowIcon = false;  
            PrintPreviewDialog1.ShowDialog();
        }

        private void button7_Click_2(object sender, EventArgs e)
        {
            printDocument1.DocumentName = "Reporte de radios";
            printDocument1.DefaultPageSettings.Landscape = true;
            printDocument1.Print();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Cb editado");
        }

        private void obsRichtxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(obsRichtxt.Text.Count() == obsRichtxt.MaxLength )
            {
                MessageBox.Show("No se permite escribir mas que 70 caracteres");
            }
        }
    }
    }


