﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace GestorDeDispositvos
{
    public partial class CrudEmp : Form
    {
        public CrudEmp()
        {
            InitializeComponent();
        }

        private void CrudEmp_Load(object sender, EventArgs e)
        {

            txtNombEmp.Text = "";
            txtNumEmp.Text = "";


        }
    }
}
