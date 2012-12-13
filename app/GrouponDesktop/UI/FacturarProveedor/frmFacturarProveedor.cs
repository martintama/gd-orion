using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GrouponDesktop.Base;

namespace GrouponDesktop.UI.FacturarProveedor
{
    public partial class frmFacturarProveedor : Form
    {
        Proveedor unProveedor;
   
        public frmFacturarProveedor()
        {
            InitializeComponent();
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

        private void frmFacturarProveedor_Load(object sender, EventArgs e)
        {
            this.LimpiarCampos();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtProveedor.Text = "";
            this.unProveedor = null;

            dtpDesde.Value = Sesion.ConfigApp.FechaActual;
            dtpHasta.Value = Sesion.ConfigApp.FechaActual;

            lblMensaje.Visible = false;
            lblFechaDesde.Visible = false;
            lblNroFactura.Text = "-";
            lblTotalFactura.Text = "-";
            lblProveedor.Visible = false;
            dgvDatos.DataSource = null;
            dgvDatos.ClearSelection();
        }

        private Boolean VerificarDatos()
        {
            Boolean valido = true;

            lblFechaDesde.Visible = false;
            if (DateTime.Compare(dtpDesde.Value, dtpHasta.Value) > 0)
            {
                lblFechaDesde.Visible = true;
                valido = false;
            }

            if (this.unProveedor == null)
            {
                lblProveedor.Visible = true;
                valido = false;
            }

            return valido;
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (this.VerificarDatos())
            {

            }
        }
    }
}
