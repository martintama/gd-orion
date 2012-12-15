using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GrouponDesktop.Base;
using System.Data.SqlClient;

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
            dtpDesde.Enabled = true;
            dtpHasta.Enabled = true;
            btnExaminar.Enabled = true;

            lblFechaDesde.Visible = false;
            lblMensaje.Visible = false;
            lblFechaDesde.Visible = false;
            lblNroFactura.Text = "-";
            lblTotalFactura.Text = "-";
            lblProveedor.Visible = false;
            dgvDatos.AutoGenerateColumns = false;
            dgvDatos.DataSource = null;
            dgvDatos.ClearSelection();
            lblCantidad.Text = "0";
            btnFacturar.Enabled = false;
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
                try
                {
                    dgvDatos.DataSource = Consumo.BuscarConsumos(this.unProveedor.Idproveedor, dtpDesde.Value, dtpHasta.Value);

                    if (dgvDatos.Rows.Count > 0)
                    {
                        lblCantidad.Text = dgvDatos.Rows.Count.ToString();
                        dtpDesde.Enabled = false;
                        dtpHasta.Enabled = false;
                        btnExaminar.Enabled = false;
                        btnFacturar.Enabled = true;
                    }
                    else
                    {
                        btnFacturar.Enabled = false;
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Ha ocurrido un error: " + ex.Message + ". El programa se cerrará.");
                    Application.Exit();
                }
            }

        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            //Solo si hay algo que facturar...
            if (dgvDatos.Rows.Count > 0)
            {
                try
                {
                    Factura unaFactura = Compra.Facturar(this.unProveedor, dtpDesde.Value, dtpHasta.Value);
                    this.lblNroFactura.Text = unaFactura.NroFactura.ToString(); ;
                    this.lblTotalFactura.Text = "$ " + unaFactura.Monto;

                    MessageBox.Show("Factura " + unaFactura.NroFactura.ToString() + " generada correctamente por : " + unaFactura.Monto);

                    this.LimpiarCampos();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Ha ocurrido un error: " + ex.Message + ". El programa se cerrará.");
                    Application.Exit();
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void dgvDatos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDatos.DataSource != null)
            {
                Consumo unConsumo = ((List<Consumo>)dgvDatos.DataSource).ElementAt(e.RowIndex);

                if (e.ColumnIndex == this.dgvDatos.Columns["colFechaConsumo"].Index)
                {
                    e.Value = unConsumo.FechaConsumo.ToString("dd/MM/yyyy");
                }
                else if (e.ColumnIndex == this.dgvDatos.Columns["colCodigoCupon"].Index)
                {
                    e.Value = unConsumo.CompraAsociada.CuponAsociado.Codigo;
                }
                else if (e.ColumnIndex == this.dgvDatos.Columns["colCodigoCompra"].Index)
                {
                    e.Value = unConsumo.CompraAsociada.CodigoCompra;
                }
                else if (e.ColumnIndex == this.dgvDatos.Columns["colDescripcion"].Index)
                {
                    e.Value = unConsumo.CompraAsociada.CuponAsociado.Descripcion;
                }
                else if (e.ColumnIndex == this.dgvDatos.Columns["conMonto"].Index)
                {
                    e.Value = "$ " + unConsumo.CompraAsociada.MontoCompra.ToString();
                }
            }
        }
    }
}
