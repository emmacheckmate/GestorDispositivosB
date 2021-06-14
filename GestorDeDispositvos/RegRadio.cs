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
            
            d.baseDatos.leeAtributos(d.baseDatos.listaQry[ 7 ]);

            this.Controls.Add(d.ld);
            
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
