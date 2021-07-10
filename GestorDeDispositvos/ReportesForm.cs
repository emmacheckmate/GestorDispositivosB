using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting;

namespace GestorDeDispositvos
{
    public partial class ReportesForm : Form
    {
        public ReportesForm()
        {

           
            
            InitializeComponent();
            webBrowser1.DocumentText = " < html > < body > < h2 > Reportes de radios</ h2 > < table >"+
                                       "< tr > < td > 1000 </ td >"+ "< td > Paco </ td >"+
                                       "< td > Funcionado </ td >"+
                                       "</ tr > < tr > < td > 1001 </ td >"+
                                       "< td > Jackson </ td >"+
                                       "< td > Reparacion </ td >"+
                                       "</ tr > < tr > < td > 1002 </ td >"+
                                        "< td > Emmanuel </ td > < td > Funcionado </ td >"+ "</ tr > </ table >"
                                        +"</ body > </ html > ";



        }

        private void ReportesForm_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.webBrowser1.DocumentCompleted +=
          new WebBrowserDocumentCompletedEventHandler(PrintDocument);
        }


        private void PrintHelpPage()
        {
            // Create a WebBrowser instance.
            WebBrowser webBrowserForPrinting = new WebBrowser();

            // Add an event handler that prints the document after it loads.
            webBrowserForPrinting.DocumentCompleted +=
                new WebBrowserDocumentCompletedEventHandler(PrintDocument);

            // Set the Url property to load the document.
         //   webBrowserForPrinting.Document = new Uri(@"c:\\prueba.html");
        }

        private void PrintDocument(object sender,
            WebBrowserDocumentCompletedEventArgs e)
        {
            // Print the document now that it is fully loaded.
            ((WebBrowser)sender).Print();

            // Dispose the WebBrowser now that the task is complete.
            ((WebBrowser)sender).Dispose();
        }
    }
}
