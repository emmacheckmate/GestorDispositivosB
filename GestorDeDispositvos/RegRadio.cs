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
  

namespace GestorDeDispositvos
{
    public partial class RegRadio : Form
    {
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
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
                        
            Interaction.InputBox("Escribir número de serie", "Buscar" );
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }
    }
}
