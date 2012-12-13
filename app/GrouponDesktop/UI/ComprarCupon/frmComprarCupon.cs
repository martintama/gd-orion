using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GrouponDesktop.Base;

namespace GrouponDesktop.UI.ComprarCupon
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
            //Actualizo el credito luego de comprar (o quizas vuelvo de una devolucion)
            ((Cliente)Sesion.EntidadLogueada).ActualizarCredito();

            lblCreditoActual.Text = "$ " + ((Cliente)Sesion.EntidadLogueada).CreditoDisponible.ToString(); ;

            dgvDatos.AutoGenerateColumns = false;
            dgvDatos.DataSource = Cupon.BuscarCupones();

            LimpiarCampos();

        }

        private void LimpiarCampos()
        {
            this.cuponSeleccionado = null;
            this.dgvDatos.ClearSelection();
            this.CargarDatosCupon();
            chkComprar.Checked = false;
            numCantidadCompra.Value = 1;
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
                valido = false;
            }

            //Ahora me fijo si hay suficiente
            if (numCantidadCompra.Value > this.cuponSeleccionado.CantidadDisponible)
            {
                lblCantidad.Text = "* No hay suficiente stock. Intente con una cantidad menor";
                lblCantidad.Visible = true;
                valido = false;
            }
            else
            {
                precioTotal = this.cuponSeleccionado.PrecioReal * numCantidadCompra.Value;

                //SI no me alcanza...
                if (precioTotal > ((Cliente)Sesion.EntidadLogueada).CreditoDisponible)
                {
                    lblMensaje.Text = "No alcanza su crédito disponible para realizar la compra";
                    lblMensaje.Visible = true;
                    valido = false;
                }
                else
                {

                    //Cargo lo que puede comprar todavía
                    this.cuponSeleccionado.CalcularRestoCompra(((Cliente)Sesion.EntidadLogueada).Idcliente);

                    if (this.cuponSeleccionado.CantidadRestoDisponible < numCantidadCompra.Value)
                    {
                        lblMensaje.Text = "No está permitida la compra de tantas unidades de este cupón por persona.";
                        lblMensaje.Visible = true;
                        valido = false;
                    }
                }
            
            }
            

            return valido;
        }
        private void btnComprar_Click(object sender, EventArgs e)
        {
            if (this.VerificarDatos())
            {
                unaCompra = new Compra();
                unaCompra.ClienteAsociado.Idcliente = ((Cliente)Sesion.EntidadLogueada).Idcliente;
                unaCompra.CuponAsociado.Idcupon = this.cuponSeleccionado.Idcupon;
                unaCompra.FechaCompra = Sesion.ConfigApp.FechaActual;
                unaCompra.Cantidad = Convert.ToInt16(this.numCantidadCompra.Value);

                unaCompra.GrabarCompra();

                MessageBox.Show("Compra efectuada exitosamente. El código de su compra es: " + unaCompra.CodigoCompra, "Comprar cupón");

                this.LimpiarCampos();
                this.CargarDatos();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.LimpiarCampos();
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
            this.numCantidadCompra.Enabled = chkComprar.Enabled;
        }


    }
}


