using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GrouponDesktop.Base;

namespace GrouponDesktop.ComprarCupon
{
    public partial class frmComprarCupon : Form
    {
        Cupon cuponSeleccionado;
        Compra unaCompra;

        public frmComprarCupon()
        {
            InitializeComponent();
        }

        private void frmComprarCupon_Load(object sender, EventArgs e)
        {
            this.CargarDatos();
        }

        private void CargarDatos()
        {
            lblCreditoActual.Text = "$ " + ((Cliente)Sesion.EntidadLogueada).CreditoDisponible.ToString(); ;

            dgvDatos.AutoGenerateColumns = false;
            dgvDatos.DataSource = Cupon.BuscarCupones();
            dgvDatos.ClearSelection();
            
        }

        private void LimpiarCampos()
        {
            this.cuponSeleccionado = null;
            this.CargarDatosCupon();
            chkComprar.Checked = false;
            numCantidadCompra.Value = 0;
        }

        private Boolean VerificarDatos()
        {
            Boolean valido = true;
            Decimal precioTotal = 0;
            
            lblCheck.Visible = false;
            lblCantidad.Visible = false;
            lblMensaje.Visible = false;

            if (!chkComprar.Checked)
            {
                lblCheck.Text = "* Debe tildar este casillero para confimar su compra";
                lblCheck.Visible = true;
            }

            //Ahora me fijo si hay suficiente
            if (numCantidadCompra.Value > this.cuponSeleccionado.CantidadDisponible)
            {
                lblCantidad.Text = "* No hay disponibles la cantidad seleccionada. Intente con una menor";
                lblCantidad.Visible = true;
            }
            else
            {
                precioTotal = this.cuponSeleccionado.PrecioReal * numCantidadCompra.Value;

                //SI no me alcanza...
                if (precioTotal > ((Cliente)Sesion.EntidadLogueada).CreditoDisponible)
                {
                    lblMensaje.Text = "No alcanza su crédito disponible para realizar la compra";
                    lblMensaje.Visible = true;
                }
            }
            

            return valido;
        }
        private void btnComprar_Click(object sender, EventArgs e)
        {
            if (this.VerificarDatos())
            {
                unaCompra = new Compra();
                unaCompra.Idcliente = ((Cliente)Sesion.EntidadLogueada).Idcliente;
                unaCompra.CuponAsociado.Idcupon = this.cuponSeleccionado.Idcupon;
                unaCompra.FechaCompra = Sesion.currentDate;
                unaCompra.Cantidad = Convert.ToInt16(this.numCantidadCompra.Value);

                unaCompra.GrabarDatos();

                Decimal precioTotal = this.cuponSeleccionado.PrecioReal * numCantidadCompra.Value;

                ((Cliente)Sesion.EntidadLogueada).CreditoDisponible = ((Cliente)Sesion.EntidadLogueada).CreditoDisponible - precioTotal;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private void dgvDatos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == this.dgvDatos.Columns["seleccionar"].Index)
            {
                e.Value = "Seleccionar";
            }
        }
        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                //Si lo que se presionó fue un botón de editar
                //if (dgvDatos.Rows[e.RowIndex][e.ColumnIndex].Name == "seleccionar")
                //{
                cuponSeleccionado = ((Cupon)dgvDatos.Rows[e.RowIndex].DataBoundItem);
                this.CargarDatosCupon();
                //}
            }
            else
            {
                cuponSeleccionado = null;
                this.CargarDatosCupon();
            }
        }

        private void CargarDatosCupon()
        {
            if (this.cuponSeleccionado != null)
            {
                this.txtDescripcion.Text = this.cuponSeleccionado.Descripcion;
                this.txtPrecioReal.Text = "$ " + this.cuponSeleccionado.PrecioReal;
                this.txtPrecioFicticio.Text = "$ " + this.cuponSeleccionado.PrecioFicticio;
                this.txtLimitePromo.Text = this.cuponSeleccionado.FechaVencimiento.ToString("dd/MM/yyyy");
            }
            else
            {
                this.txtDescripcion.Text = "";
                this.txtLimitePromo.Text = "";
                this.txtPrecioFicticio.Text = "";
                this.txtPrecioReal.Text = "";
            }
           
        }

        private void chkComprar_CheckedChanged(object sender, EventArgs e)
        {
            this.btnComprar.Enabled = chkComprar.Checked;
        }


    }
}


