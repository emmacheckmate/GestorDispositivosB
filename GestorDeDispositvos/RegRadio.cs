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
using System.Text.RegularExpressions;

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
        DataGridControl d;
        public RegRadio()
        {
            InitializeComponent();

             d = new DataGridControl();

            d.ld.RowHeaderMouseClick += this.ld_RowHeaderMouseClick;
            this.Controls.Add(d.ld);

        }


        private void ld_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            try
            {  
                pictureBox2.Image = Image.FromFile( d.seleccionaRenglonImagen(e.RowIndex) );


                if (d.seleccionaRenglonImagen(e.RowIndex) == "NULL")
                {
                    MessageBox.Show("FFFF");
                    pictureBox2.Image = pictureBox2.ErrorImage;
                    pictureBox2.Refresh();
                }



                pictureBox2.Refresh();
            }
            catch { }
        }
        private void RegRadio_Load(object sender, EventArgs e)
        {
            double porcentaje = 0.3;

            this.Height = Screen.FromControl(this).Bounds.Height -
                         Convert.ToInt32(Screen.FromControl(this).Bounds.Height * porcentaje);

            this.Width = Screen.FromControl(this).Bounds.Width -
                         Convert.ToInt32(Screen.FromControl(this).Bounds.Width * porcentaje);
            this.CenterToScreen();


            this.ShowIcon = false;
            this.pictureBxIni();


        }

        /*Este metodo se encarga de inicializar las configuraciones y parametros importantes
        y estados para el catolgo de radios*/
        public void pictureBxIni()
        {

            this.pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;

            if (pictureBox2.Image != null)
            {
            }
            else if (pictureBox2.Image == null )
            {

                pictureBox2.Image = pictureBox2.ErrorImage;
                pictureBox2.Refresh();
            }


            string ruta = "C:\\codigoqr.jpg";
            string output = ruta.Replace(@"\\", @"\");
        
            


        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
                        
            Interaction.InputBox("Escribir número de serie", "Buscar" );
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }
        /*Metodo que se encarga de dar ubicacion a las imagenes de sistema
        la ubicacion  oficial va a ser C:/sistemaDispostivosBeta8*/
        public void guardarImg()
        {
            SaveFileDialog sv = new SaveFileDialog();

            sv.Title = "Nombre para la imagen:";
            sv.InitialDirectory = path;
            rutaCarpeta = path;

            sv.Filter = "Imagenes (*.jpg)|*.jpg";
            sv.DefaultExt = "";
            sv.AddExtension = true;
            if (DialogResult.OK == sv.ShowDialog()) {
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
        private void btnGuardarPIc_Click(object sender, EventArgs e)
        {
            guardarImg();
            
        }
    }
}
