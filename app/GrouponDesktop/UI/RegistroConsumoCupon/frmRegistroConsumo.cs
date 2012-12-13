using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GrouponDesktop.Base;

namespace GrouponDesktop.RegistroConsumoCupon
{
    public partial class frmRegistroConsumo : Form
    {
        Compra unaCompra;

        public frmRegistroConsumo()
        {
            InitializeComponent();
        }

        private void frmRegistroConsumo_Load(object sender, EventArgs e)
        {
            this.LimpiarDatosCompra();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.LimpiarDatosCompra();

            lblErrorCodigo.Visible = false;
            if (txtCodigo.Text != "")
            {
                this.Buscar();
            }
            else
            {
                lblErrorCodigo.Text = "Ingrese un código de cupón";
                lblErrorCodigo.Visible = true;
            }
        }

        private void LimpiarDatosCompra()
        {
            this.txtDescripcion.Text = "";
            this.txtCantidad.Text = "";
            this.txtLimiteCanje.Text = "";
            this.txtPrecioReal.Text = "";
            this.txtTotal.Text = "";
            this.txtFechaCompra.Text = "";
            this.txtComprador.Text = "";
            this.txtDni.Text = "";
            lblEstado.Text = "-";
            lblCheck.Visible = false;
            lblMensaje.Visible = false;
            this.chkVerificado.Checked = false;
            this.chkVerificado.Enabled = false;
            this.btnRegistrar.Enabled = false;
        }

        private void Buscar()
        {
            unaCompra = Compra.BuscarCompra(txtCodigo.Text);

            lblErrorCodigo.Visible = false;
            if (unaCompra.Idcompra > 0)
            {
                this.CargarDatosCompra();
            }
            else
            {
                if (unaCompra.Idcompra == 0)
                {
                    lblErrorCodigo.Text = "El código ingresado es inválido";
                    lblErrorCodigo.Visible = true;
                }
                else
                {
                    lblErrorCodigo.Text = "El código ingresado pertenece a otro proveedor.";
                    lblErrorCodigo.Visible = true;
                }
            }

        }

        private void CargarDatosCompra()
        {
            txtDescripcion.Text = unaCompra.CuponAsociado.Descripcion;
            txtCantidad.Text = unaCompra.Cantidad.ToString();
            txtLimiteCanje.Text = unaCompra.CuponAsociado.FechaVencimientoCanje.ToString("dd/MM/yyyy");
            txtComprador.Text = unaCompra.ClienteAsociado.Nombre + " " + unaCompra.ClienteAsociado.Apellido;
            txtDni.Text = unaCompra.ClienteAsociado.DNI.ToString();
            txtPrecioReal.Text = unaCompra.CuponAsociado.PrecioReal.ToString();
            txtTotal.Text = (unaCompra.CuponAsociado.PrecioReal * unaCompra.Cantidad).ToString();
            txtFechaCompra.Text = unaCompra.FechaCompra.ToString("dd/MM/yyyy");

            chkVerificado.Checked = false;

            switch (unaCompra.Estado.Idestado_compra)
            {
                case 1:
                    {
                        lblEstado.ForeColor = Color.Green;
                        lblEstado.Text = "Consumo habilitado";

                        chkVerificado.Enabled = true;
                        btnRegistrar.Enabled = true;
                        break;
                    }
                case 2:
                    {
                        lblEstado.ForeColor = Color.Red;
                        lblEstado.Text = "Consumo no habilitado. Cupón ya consumido.";

                        chkVerificado.Enabled = false;
                        btnRegistrar.Enabled = false;

                        break;
                    }
                case 3:
                    {
                        lblEstado.ForeColor = Color.Red;
                        lblEstado.Text = "Consumo no habilitado. Cupón devuelto el " + unaCompra.DevolucionAsociada.FechaDevolucion.ToString("dd/MM/yyyy");

                        chkVerificado.Enabled = false;
                        btnRegistrar.Enabled = false;
                        break;
                    }
                case 4:
                    {
                        lblEstado.ForeColor = Color.Red;
                        lblEstado.Text = "Consumo no habilitado. Cupón vencido.";

                        chkVerificado.Enabled = false;
                        
                        break;
                    }
            }


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtCodigo.Text = "";
            this.LimpiarDatosCompra();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (this.unaCompra.Idcompra > 0)
            {
                lblCheck.Visible = false;
                if (this.chkVerificado.Checked)
                {
                    Consumo unConsumo = new Consumo();
                    unConsumo.FechaConsumo = Sesion.currentDate;
                    unConsumo.Idcliente = unaCompra.ClienteAsociado.Idcliente;
                    unConsumo.Idcompra = unaCompra.Idcompra;
                    unConsumo.Consumir();

                    if (MessageBox.Show("Cupón consumido correctamente. ¿Desea ingresar otro cupón?", "Consumir cupón", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        this.LimpiarDatosCompra();
                        this.txtCodigo.Text = "";
                        this.txtCodigo.Focus();
                    }
                    else
                    {
                        this.Close();
                        this.Dispose();
                    };
                }
                else
                {
                    lblCheck.Text = "Debe verificar el DNI del comprador";
                    lblCheck.Visible = true;
                }
            }
        }

        private void txtComprador_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
