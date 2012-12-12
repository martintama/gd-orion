using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GrouponDesktop.Base;

namespace GrouponDesktop.UI.PublicarCupon
{
    public partial class frmPublicarCupon : Form
    {

        private Proveedor unProveedor;
        
        public frmPublicarCupon()
        {
            InitializeComponent();
        }

        private void frmPublicarCupon_Load(object sender, EventArgs e)
        {

        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            frmBuscarProveedor oFrm = new frmBuscarProveedor();
            oFrm.esAbm = false;
            oFrm.ShowDialog();

            if (oFrm.proveedorSeleccionado != null)
            {
                this.unProveedor = oFrm.proveedorSeleccionado;
                this.txtProveedor.Text = this.unProveedor.RazonSocial + " (" + this.unProveedor.Cuit + ")";
            }

            oFrm.Dispose();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.unProveedor = null;
            this.txtProveedor.Text = "";

            this.CargarDatos();
        }

        private void CargarDatos()
        {
            throw new NotImplementedException();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {

        }
    }
}
