using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GrouponDesktop.Base;

namespace GrouponDesktop.UI.HistorialCupones
{
    public partial class frmHistorialCupones : Form
    {
        public frmHistorialCupones()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private Boolean VerificarDatos()
        {
            Boolean valido = true;

            lblFechas.Visible = false;
            lblMensaje.Visible = false;

            if (DateTime.Compare(dtpDesde.Value, dtpHasta.Value) > 0)
            {
                lblFechas.Visible = true;
                lblMensaje.Text = "La fecha desde no puede ser posterior a la fecha hasta";
                lblMensaje.Visible = true;
            }

            return valido;
        }

        public void CargarDatos()
        {
            dgvDatos.AutoGenerateColumns = false;
            dgvDatos.DataSource = Compra.BuscarCompras(dtpDesde.Value, dtpHasta.Value, ((Cliente)Sesion.EntidadLogueada).Idcliente);
            lblCantidad.Text = dgvDatos.Rows.Count.ToString();
        }

        public void LimpiarCampos()
        {
            dtpHasta.Value = Sesion.ConfigApp.FechaActual;
            dtpDesde.Value = dtpHasta.Value.AddMonths(-1);
        }

        private void dgvDatos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            Compra unaCompra = ((List<Compra>)dgvDatos.DataSource).ElementAt(e.RowIndex);
            if (e.ColumnIndex == this.dgvDatos.Columns["colFecha"].Index)
            {
                e.Value = unaCompra.FechaCompra.ToString("dd/MM/yyyy");
            }
            else if (e.ColumnIndex == this.dgvDatos.Columns["colCodigo"].Index)
            {
                e.Value = unaCompra.CodigoCompra;
            }
            else if (e.ColumnIndex == this.dgvDatos.Columns["colDescripcion"].Index)
            {
                e.Value = unaCompra.CuponAsociado.Descripcion;
            }
            else if (e.ColumnIndex == this.dgvDatos.Columns["colFechaVtoCanje"].Index)
            {
                e.Value = unaCompra.CuponAsociado.FechaVencimientoCanje.ToString("dd/MM/yyyy");
            }
            else if (e.ColumnIndex == this.dgvDatos.Columns["colFechaCanje"].Index)
            {
                if (unaCompra.ConsumoAsociado.FechaConsumo.ToString("dd/MM/yyyy") != "01/01/0001")
                    e.Value = unaCompra.ConsumoAsociado.FechaConsumo.ToString("dd/MM/yyyy");
                else
                    e.Value = "-";
            }
            else if (e.ColumnIndex == this.dgvDatos.Columns["colFechaDevolucion"].Index)
            {
                if (unaCompra.DevolucionAsociada.FechaDevolucion.ToString("dd/MM/yyyy") != "01/01/0001")
                    e.Value = unaCompra.DevolucionAsociada.FechaDevolucion.ToString("dd/MM/yyyy");
                else
                    e.Value = "-";
            }
            else if (e.ColumnIndex == this.dgvDatos.Columns["colEstado"].Index)
            {
                e.Value = unaCompra.Estado.Descripcion;
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (this.VerificarDatos())
            {
                this.CargarDatos();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.LimpiarCampos();
        }

        private void frmHistorialCupones_Load(object sender, EventArgs e)
        {
            this.LimpiarCampos();
            this.CargarDatos();
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
