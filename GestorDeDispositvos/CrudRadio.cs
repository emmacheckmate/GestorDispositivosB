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



using System.Drawing.Imaging;


namespace GestorDeDispositvos
{
    
    public partial class CrudRadio : Form
    {
        
        private int m_currentPageIndex;
        private IList< Stream > m_streams;
        DataGridControl d;
        ComboControl cbc;
        Microsoft.Reporting.WinForms.ReportViewer reportViewerSales = new Microsoft.Reporting.WinForms.ReportViewer();
        Microsoft.Reporting.WinForms.ReportDataSource reportDataSourceSales = new Microsoft.Reporting.WinForms.ReportDataSource();

        public CrudRadio()
        {
            cbc = new ComboControl();
            InitializeComponent();
            cbc.iniCBLista();
            cbc.llenaCatalogos( );
            

            d = new DataGridControl();
           
            d.dgvReportes.RowHeaderMouseClick += this.dgvReportes_RowHeaderMouseClick;
            this.Controls.Add(d.ld);
            this.Controls.Add(this.d.dgvReportes);
            panel1.Controls.Add(this.d.dgvReportes);
            

        }

        public void dgvReportes_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if(d.seleccionaRenglonReportes(e.RowIndex) != null)
                {
                    this.pasaDatosAControles();   
                }
            }
            catch{  }
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
            this.Run();
            //this.guardarxml();
        }


       

        private DataTable LoadSalesData()
        {
            // Create a new DataSet and read sales data file 
            //    data.xml into the first DataTable.

            DataSet dataSet = new DataSet();
            dataSet.ReadXml(@"..\..\data.xml");
            return dataSet.Tables[0];
            
        }
        // Routine to provide to the report renderer, in order to
        //    save an image for each page of the report.
        private Stream CreateStream(string name,
          string fileNameExtension, Encoding encoding,
          string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }
        // Export the given report as an EMF (Enhanced Metafile) file.
        private void Export(LocalReport report)
        {
            string deviceInfo =
              @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>8.5in</PageWidth>
                <PageHeight>11in</PageHeight>
                <MarginTop>0.25in</MarginTop>
                <MarginLeft>0.25in</MarginLeft>
                <MarginRight>0.25in</MarginRight>
                <MarginBottom>0.25in</MarginBottom>
            </DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream, out warnings);

            foreach (Stream stream in m_streams)
                stream.Position = 0;
        }
        // Handler for PrintPageEvents
        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new
               Metafile(m_streams[m_currentPageIndex]);

            // Adjust rectangular area with printer margins.
            Rectangle adjustedRect = new Rectangle(
                ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                ev.PageBounds.Width,
                ev.PageBounds.Height);

            // Draw a white background for the report
            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

            // Draw the report content
            ev.Graphics.DrawImage(pageImage, adjustedRect);

            // Prepare for the next page. Make sure we haven't hit the end.
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

        private void Print()
        {
            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("Error: no stream to print.");
            PrintDocument printDoc = new PrintDocument();
            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cannot find the default printer.");
            }
            else
            {
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                m_currentPageIndex = 0;
                printDoc.Print();
            }
        }
        // Create a local report for Report.rdlc, load the data,
        //    export the report to an .emf file, and print it.
        private void Run()
        {
            LocalReport report = new LocalReport();
            report.ReportPath = @"..\..\Report.rdlc";
            report.DataSources.Add(
               new ReportDataSource("Sales", LoadSalesData()));
            Export(report);
            Print();
        }

        public void Dispose()
        {
            if (m_streams != null)
            {
                foreach (Stream stream in m_streams)
                    stream.Close();
                m_streams = null;
            }
        }

        // By using this method we can convert datatable to xml
        public string ConvertDatatableToXML(DataTable dt)
        {
            MemoryStream str = new MemoryStream();
            dt.WriteXml(str, true);
            str.Seek(0, SeekOrigin.Begin);
            StreamReader sr = new StreamReader(str);
            string xmlstr;
            xmlstr = sr.ReadToEnd();
            return (xmlstr);
        }

        public void guardarxml()
        {

            // Create the XmlDocument.
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<item><name>wrench</name></item>");

            // Add a price element.
            XmlElement newElem = doc.CreateElement("price");
            newElem.InnerText = "10.95";
            doc.DocumentElement.AppendChild(newElem);

            // Save the document to a file. White space is
            // preserved (no white space).
            doc.PreserveWhitespace = true;
            doc.Save("data.xml");
        }



    }
}
