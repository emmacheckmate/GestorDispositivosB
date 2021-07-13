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

        private int m_currentPageIndex;
        private IList<Stream> m_streams;
        DataGridControl d;
        ComboControl cbc;
        Microsoft.Reporting.WinForms.ReportViewer reportViewerSales = new Microsoft.Reporting.WinForms.ReportViewer();
        Microsoft.Reporting.WinForms.ReportDataSource reportDataSourceSales = new Microsoft.Reporting.WinForms.ReportDataSource();

        // Declare the dialog.
        internal PrintPreviewDialog PrintPreviewDialog1 = new PrintPreviewDialog();

        // Declare a PrintDocument object named document.
        private System.Drawing.Printing.PrintDocument document = new System.Drawing.Printing.PrintDocument();



        public CrudRadio()
        {
            cbc = new ComboControl();
            InitializeComponent();
            cbc.iniCBLista();
            cbc.llenaCatalogos();
            this.InitializePrintPreviewDialog();

            d = new DataGridControl();

            d.GSdgvReportes.RowHeaderMouseClick += this.dgvReportes_RowHeaderMouseClick;
            this.Controls.Add(d.ld);
            this.Controls.Add(this.d.GSdgvReportes);
            panel1.Controls.Add(this.d.GSdgvReportes);


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
            DateTime calendar;
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
            ReportesForm r = new ReportesForm();
            r.ShowDialog();

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


            string c = d.ToString();
            string anio = c.Substring(3,5);
            int tma = c.Length;
            string mes = d.ToString().Substring(3, 2);
            for (int i = 0; i < meses.Count; i++) {
                if ( (Convert.ToInt32(mes) -1 )  == i)
                {

                  //  MessageBox.Show("TAMA " + tma.ToString() + " "+ c );

                    MessageBox.Show(d.ToString().Substring(0, 2) + " de " + meses[i] + " del "+ anio);
                    
                }
            }
            return fecha;

        }

        private void printDocument1_PrintPage_1(object sender, PrintPageEventArgs e)
        {
            DateTime TheDate = new DateTime();

            TheDate = DateTime.Now;
            this.contruyeFecha(TheDate);

            Font printFont = new Font("Arial", 9);
            Font headFont = new Font("Arial", 17);
            Font titleFont = new Font("Arial", 9 , FontStyle.Bold);
            

            ////  e.Graphics.DrawString( t , printFont, Brushes.Black, 500f, 25f);
            int xPos = 50;
            float topMargin = e.MarginBounds.Top + 90;
            float yPos = 200;
            float yPosT = 160;

            float linesPerPage = 0;
            int count = 0;
            string texto = "";
            DataGridViewRow row = new DataGridViewRow();
            Image image2 = Image.FromFile("c:\\images.jpg");
            this.encabezados_reporte( e, xPos, yPosT, titleFont );
            Bitmap imageM = new Bitmap(image2, new Size(image2.Width / 2, image2.Height / 2));
            Pen pen = new Pen(Color.Black, 3);

            Pen penCuadro = new Pen(Color.LightBlue, 2);


            Point[] points = { new Point(50,  100), new Point(document.PrinterSettings.PaperSizes[0].Height-50, 100), };
            document.DefaultPageSettings.PaperSize = document.PrinterSettings.PaperSizes[0];
            

            e.Graphics.DrawLines(pen, points);
            e.Graphics.DrawString("Reporte de radios", headFont, Brushes.Black, 470f, 50f);

            Rectangle r2 = new Rectangle(25, 150,
                            document.PrinterSettings.PaperSizes[0].Height - 50,
                            document.PrinterSettings.PaperSizes[0].Width - 200);
            e.Graphics.DrawRectangle(pen, r2);

            // Calculamos el número de líneas que caben en cada página.
            linesPerPage = e.MarginBounds.Height / printFont.GetHeight(e.Graphics);

            Rectangle r = new Rectangle( 25 , 150 , 
                                        document.PrinterSettings.PaperSizes[0].Height - 50, 
                                        document.PrinterSettings.PaperSizes[0].Width - 200);
            e.Graphics.DrawRectangle(pen, r );
            e.Graphics.DrawImage(imageM, 20f, 20f);

            
            // Recorremos las filas del DataGridView hasta que llegemos
            // a las líneas que nos caben en cada página o al final del grid.
            while (count < linesPerPage && i < this.d.GSdgvReportes.Rows.Count)
            {
                List<string> t = new List<string>();
                row = this.d.GSdgvReportes.Rows[i];
                texto = "";
                string celdaDato;
                if (row != null)
                {
                    for (int cont = 0; cont < row.Cells.Count; cont++)
                    {
                        if (row.Cells[cont].Value != null) {
                            if (row.Cells[cont].Value.ToString().Contains('/'))
                            {
                                t.Add(row.Cells[cont].Value.ToString().Substring(0, 10));
                            }
                            else { t.Add(row.Cells[cont].Value.ToString()); }
                            


                        }
                        
                    }


                    for (int j = 0; j < t.Count; j++)
                    {
                        texto += t[j];
                    }
                    
                    
                }

                yPos = topMargin + (count * printFont.GetHeight(e.Graphics));
              
                e.Graphics.DrawString(texto, printFont, Brushes.Black, xPos, yPos);
                r2.X = xPos;
                r2.Y = (int)yPos;
                r2.Width = 40;
                r2.Height = 30;

                e.Graphics.DrawRectangle(penCuadro, r2);

                count++;
                i++;
            }

            // Una vez fuera del bucle comprobamos si nos quedan más filas 
            // por imprimir, si quedan saldrán en la siguente página

            if (i < this.d.GSdgvReportes.Rows.Count)
                e.HasMorePages = true;
            else
            {
                // si llegamos al final, se establece HasMorePages a 
                // false para que se acabe la impresión
                e.HasMorePages = false;

                // Es necesario poner el contador a 0 porque, por ejemplo si se hace 
                // una impresión desde PrintPreviewDialog, se vuelve disparar este 
                // evento como si fuese la primera vez, y si i está con el valor de la
                // última fila del grid no se imprime nada
                i = 0;
            }
            
        }

        public void encabezados_reporte(PrintPageEventArgs e, float xP, float yP, Font titleFont)
        {
            e.Graphics.DrawString("Número\nde Folio", titleFont, Brushes.Black, xP, yP);

            e.Graphics.DrawString("Fecha\nde Asignación", titleFont, Brushes.Black, xP + 60, yP);

            e.Graphics.DrawString("Observaciones", titleFont, Brushes.Black, xP + 240, yP);

            e.Graphics.DrawString("Número\nde Radio", titleFont, Brushes.Black, xP + 470, yP);

            e.Graphics.DrawString("Reponsable", titleFont, Brushes.Black, xP + 540, yP);

            e.Graphics.DrawString("Sucursal", titleFont, Brushes.Black, xP + 650, yP);

            e.Graphics.DrawString("Área", titleFont, Brushes.Black, xP + 800, yP);

            e.Graphics.DrawString("Estado", titleFont, Brushes.Black, xP + 950, yP);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            // if (TreeView1.SelectedNode != null)
            document.DocumentName = "Reporte de Radios";
            PrintPreviewDialog1.Document = document;
            PrintPreviewDialog1.ShowIcon = false;

            // Call the ShowDialog method. This will trigger the document's
            //  PrintPage event.
            PrintPreviewDialog1.ShowDialog();
        }
    }
    }


