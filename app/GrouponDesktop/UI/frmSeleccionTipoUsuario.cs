﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GrouponDesktop.UI.AbmProveedor;
using GrouponDesktop.UI.AbmCliente;

namespace GrouponDesktop
{
    public partial class frmSeleccionTipoUsuario : Form
    {
        public frmSeleccionTipoUsuario()
        {
            InitializeComponent();
        }

        private void btnNuevoProveedor_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAbmProveedor frmProveedor = new frmAbmProveedor();
            frmProveedor.tipoOperacion = frmAbmProveedor.TipoOperacion.Registro;
            frmProveedor.ShowDialog();

            this.Close();
            this.Dispose();
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAbmCliente frmCliente = new frmAbmCliente();
            frmCliente.tipoOperacion = frmAbmCliente.TipoOperacion.Registro;
            frmCliente.ShowDialog();

            this.Close();
            this.Dispose();
        }
    }
}
