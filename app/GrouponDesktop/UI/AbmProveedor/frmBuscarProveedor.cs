using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GrouponDesktop.UI.AbmProveedor
{
    public partial class frmBuscarProveedor : Form
    {
        public frmBuscarProveedor()
        {
            InitializeComponent();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtDNI.Text = "";
            txtEmail.Text = "";

        }
    }
}
