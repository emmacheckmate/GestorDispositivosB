using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.SqlServer.Management.Smo;
using System.IO;
  

namespace GestorDeDispositvos
{
    public partial class RegRadio : Form
    {
        string rutaCompleta = "";
        string nombreArchivo;
        string rutaCarpeta;
        public string carpeta;
        private String path;
        private int indice;
        string directorioBase = "";
        public RegRadio()
        {
            InitializeComponent();

            DataGridControl d = new DataGridControl();
            
            d.ld.RowHeaderMouseClick += this.ld_RowHeaderMouseClick; 
            this.Controls.Add(d.ld);
            
        }


        private void ld_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            try
            {
                MessageBox.Show( e.RowIndex.ToString() );
                
            }
            catch { }
        }
        private void RegRadio_Load(object sender, EventArgs e)
        {
            this.ShowIcon = false;
            
            pictureBox2.ImageLocation = "C:\\Users\\link2\\OneDrive\\Documentos\\GitHub\\GestorDispositivosB\\GestorDeDispositvos\\Resources\\codigoqr.jpg";
            pictureBox2.Refresh();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
                        
            Interaction.InputBox("Escribir número de serie", "Buscar" );
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardarPIc_Click(object sender, EventArgs e)
        {
            SaveFileDialog sv = new SaveFileDialog();

            sv.Title = "Nombre para la imagen:";
            sv.InitialDirectory = path;
            rutaCarpeta = path;

            sv.Filter = "Base de Datos (*.dd)|*.dd";
            sv.DefaultExt = "dd";
            sv.AddExtension = true;
            if (DialogResult.OK == sv.ShowDialog())
            {

                

                

                nombreArchivo = sv.FileName;

                string folderName = Directory.GetCurrentDirectory();
                MessageBox.Show(folderName);
                string pathString = System.IO.Path.Combine(folderName, nombreArchivo.Remove(nombreArchivo.Length - 3, 3));
                string directorioCombinado = Path.GetFullPath(System.IO.Path.Combine(folderName, nombreArchivo.Remove(nombreArchivo.Length - 3, 3)));

                this.directorioBase = directorioCombinado;
                //se le agrega el archivo concatenado que se va a escribrir
                string Dir_diccionario = directorioCombinado += "\\" + Path.GetFileName(sv.FileName); ;
                MessageBox.Show(Dir_diccionario);

                if (!System.IO.Directory.Exists(pathString))
                {
                    System.IO.Directory.CreateDirectory(pathString);
                }

                rutaCompleta = Dir_diccionario;
             

                nombreArchivo = Dir_diccionario;

             
            }
            else
            {
             
            }
            sv.Dispose();
        }
    }
}
