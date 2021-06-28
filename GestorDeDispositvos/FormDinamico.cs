﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
            panel1.Controls.Add(pictureBox3);
            
        }

        public void eligeCatalogo(int op)
        {
            switch (op)
            {
                case 0:
                    this.Text = "Catalogo Radios";
                    this.Controls.Add(this.d.llbGS.ElementAt(0));
                    this.Controls.Add(this.d.llbGS.ElementAt( 1 ));

                    panel1.Controls.Add(this.d.llbGS.ElementAt( 0 ) );
                    panel1.Controls.Add(this.d.llbGS.ElementAt( 1 ));
                    this.pictureBox2.Visible = true;

                    break;

                case 1:
                    
                    this.Text = "Catalogo Áreas";

                    this.Controls.Add(this.d.llbGS.ElementAt(0));
                    this.Controls.Add(this.d.llbGS.ElementAt(1));

                    panel1.Controls.Add(this.d.llbGS.ElementAt(0));
                    panel1.Controls.Add(this.d.llbGS.ElementAt(1));

                    break;


                case 3:
                    this.Text = "Catalogo de Estados";

                    this.Controls.Add(this.d.llbGS.ElementAt(2));
                    this.Controls.Add(this.d.llbGS.ElementAt(3));

                    panel1.Controls.Add(this.d.llbGS.ElementAt(2));
                    panel1.Controls.Add(this.d.llbGS.ElementAt(3));
                    break;

                case 4:
                    this.Text = "Catalogo de Empleados";

                    this.Controls.Add(this.d.llbGS.ElementAt(4));
                    this.Controls.Add(this.d.llbGS.ElementAt(5));

                    panel1.Controls.Add(this.d.llbGS.ElementAt(4));
                    panel1.Controls.Add(this.d.llbGS.ElementAt(5));
                    break;

                case 5:
                    this.Text = "Catalogo de Sucursales";

                    this.Controls.Add(this.d.llbGS.ElementAt(6));
                    panel1.Controls.Add(this.d.llbGS.ElementAt(6));
                    break;
            }

            d.ld.RowHeaderMouseClick += this.ld_RowHeaderMouseClick;
            this.Controls.Add(d.ld);
        }

        public void pasapanel (int i )
        {

        }

        /*Metodo que hace referencua a la clase de datagridcontrol para poder
        manipular la informacion proveniente del  catalogo de radios*/
        private void ld_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            try
            {
                d.getSetIndiceDG = e.RowIndex;
                d.seleccionaInformacion(this.d.getSetIndiceDG);
                textBox1.Text = d.seleccionaInformacion(this.d.getSetIndiceDG)[0].ToString();
                textBox2.Text = d.seleccionaInformacion(this.d.getSetIndiceDG)[1].ToString();

                if (this.numCatGS == 0) {
                    pictureBox2.Image = Image.FromFile(d.seleccionaRenglonImagen(this.d.getSetIndiceDG )); }

                
                

            }
            catch
            {
                /*
                if (d.seleccionaRenglonImagen(e.RowIndex).Length <= 1 && this.numCatGS == 0)
                    
                {
                    pictureBox2.Image = pictureBox2.ErrorImage;
                }*/
            }
            pictureBox2.Refresh();
        }

        public void pictureBxIni()
        {
            this.pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            if (pictureBox2.Image != null)
            {
            }
            else if (pictureBox2.Image == null)
            {

                pictureBox2.Image = pictureBox2.ErrorImage;
                pictureBox2.Refresh();
            }


            string ruta = "C:\\codigoqr.jpg";
            string output = ruta.Replace(@"\\", @"\");
        }
        private void FormDinamico_Load(object sender, EventArgs e)
        {
            this.pictureBox2.Visible = false;
            eligeCatalogo(this.numCatGS);
            this.CenterToScreen();
            this.pictureBxIni();
            this.pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }


        /*Boton Guardar: */
        private void button4_Click(object sender, EventArgs e)
        {
            if (
            d.getSetIndiceDG == -1
            )
            {
                MessageBox.Show(d.ld.CurrentCell.RowIndex.ToString());
                MessageBox.Show("No hay registro seleccionado", "Información",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Exclamation);

                
            }
            else {
                d.insertaReg(textBox1.Text,
                             textBox2.Text, this.numCatGS);
            }
         
            
        }

        public void guardarImg()
        {

            var path = new Uri(
    System.IO.Path.GetDirectoryName(
        System.Reflection.Assembly.GetExecutingAssembly().CodeBase)
    ).LocalPath;
            MessageBox.Show(Directory.GetCurrentDirectory());

            SaveFileDialog sv = new SaveFileDialog();

            sv.Title = "Imagen con codigo QR";
            sv.InitialDirectory = path;
            rutaCarpeta = path;

            sv.Filter = "Imagenes (*.jpg  *.bmp *.gif )|*.jpg *.bmp *.gif ";
            sv.DefaultExt = "";
            sv.AddExtension = true;
            if (DialogResult.OK == sv.ShowDialog())
            {
                nombreArchivo = sv.FileName;

                
                
                string folderName = Directory.GetCurrentDirectory();
                
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

               
            }
            else
            {

            }
            sv.Dispose();

        }

        private void btnGuardarPIc_Click(object sender, EventArgs e)
        {

            SaveFileDialog sv = new SaveFileDialog();
            string fileToCopy = "c:\\archivo.txt";
            string destinationDirectory = "c:\\myDestinationFolder\\";

            var path =new Uri(
                                System.IO.Path.GetDirectoryName(
                                System.Reflection.Assembly.GetExecutingAssembly().CodeBase)
                              ).LocalPath;

            sv.Title = "Imagen con codigo QR";
            sv.InitialDirectory = path;
            rutaCarpeta = path;

            sv.Filter = "Imagenes (*.jpg  *.bmp *.gif )|*.jpg *.bmp *.gif ";
            sv.DefaultExt = "";
            sv.AddExtension = true;
            if (DialogResult.OK == sv.ShowDialog())
            {
                nombreArchivo = sv.FileName;
            }

                string carpetaParaGuardar = System.IO.Path.Combine(path, "Imagenes");

            MessageBox.Show(carpetaParaGuardar);

            if (!Directory.Exists( carpetaParaGuardar))
            {
                Directory.CreateDirectory(carpetaParaGuardar);
            }if (DialogResult.OK == sv.ShowDialog())
            {
                nombreArchivo = sv.FileName;

          //  File.Copy(fileToCopy, destinationDirectory + Path.GetFileName(fileToCopy));
            //guardarImg();
        }
    }

