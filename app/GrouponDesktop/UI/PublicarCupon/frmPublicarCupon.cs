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

namespace GrouponDesktop.UI.PublicarCupon
{
    public partial class frmPublicarCupon : Form
    {

        private Proveedor unProveedor = new Proveedor();

        List<Cupon> listaCuponesPublicar = new List<Cupon>();

        public frmPublicarCupon()
        {
            InitializeComponent();
        }

        private void frmPublicarCupon_Load(object sender, EventArgs e)
        {
            this.txtFecha.Text = Sesion.ConfigApp.FechaActual.ToString("dd/MM/yyyy");
            CargarDatos();
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
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            this.unProveedor = new Proveedor();
            this.txtProveedor.Text = "";

            this.CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                List<Cupon> listaCupones = Cupon.BuscarCupones(unProveedor.Idproveedor, false);
                dgvDatos.AutoGenerateColumns = false;
                dgvDatos.DataSource = listaCupones;

                lblCantidad.Text = listaCupones.Count.ToString();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ha ocurrido un error: " + ex.Message + ". El programa se cerrará.");
                Application.Exit();
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            this.CargarDatos();   
        }

        private void btnPublicar_Click(object sender, EventArgs e)
        {
            try
            {
                listaCuponesPublicar.Clear();
                lblMensaje.Visible = false;
                foreach (DataGridViewRow fila in dgvDatos.Rows)
                {
                    DataGridViewCheckBoxCell celdaCheck = (DataGridViewCheckBoxCell)fila.Cells[0];

                    if (Convert.ToBoolean(celdaCheck.Value))
                    {
                        listaCuponesPublicar.Add((Cupon)fila.DataBoundItem);
                    }
                }

                if (listaCuponesPublicar.Count > 0)
                {
                    Cupon.PublicarCupones(listaCuponesPublicar);
                    MessageBox.Show("Cupones publicados exitosamente");
                    this.LimpiarCampos();
                }
                else
                {
                    lblMensaje.Text = "Debe seleccionar al menos un cupón para publicar";
                    lblMensaje.Visible = true;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ha ocurrido un error: " + ex.Message + ". El programa se cerrará.");
                Application.Exit();
            }
        }

        private void dgvDatos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
   
            if (e.ColumnIndex == this.dgvDatos.Columns["colProveedor"].Index)
            {
                e.Value = ((List<Cupon>)dgvDatos.DataSource).ElementAt(e.RowIndex).ProveedorAsoaciado.RazonSocial;
            }
            else if (e.ColumnIndex == this.dgvDatos.Columns["colFechaFin"].Index)
            {
                e.Value = ((List<Cupon>)dgvDatos.DataSource).ElementAt(e.RowIndex).FechaVencimiento.ToString("dd/MM/yyyy");
            }
          
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
