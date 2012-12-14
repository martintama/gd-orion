using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GrouponDesktop.Base;

namespace GrouponDesktop.UI.CargaCredito
{
    public partial class frmCargarCredito : Form
    {
        Carga unaCarga = new Carga();

        public frmCargarCredito()
        {
            InitializeComponent();
        }

        private void montoBox_TextChanged(object sender, EventArgs e)
        {
            int credito;
            int.TryParse(txtMonto.Text, out credito);
            if (credito <= 15)
            {
                lblError.Text = "El monto debe ser mayor a 15$!";
                btnAceptar.Enabled = false;
            }
            else
            {
                lblError.Text = "";
                btnAceptar.Enabled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void mroTarjBox_TextChanged(object sender, EventArgs e)
        {
            int nroTarj;
            int.TryParse(txtNroTarj.Text, out nroTarj);
            if (txtNroTarj.Text.Length != 16)
            {
                lblError.Text = "Debe ingresar 16 Digitos de Tarjeta";
            }
            else
            {
                lblError.Text = "";
            }
        }

        private void cmbPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPago.SelectedIndex == 0)
            {
                gbxDatosTarjeta.Visible = false;
            }
            else
            {
                gbxDatosTarjeta.Visible = true;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (VerificarDatos())
            {
                //Se supone que si pasó la verificación, es válido
                unaCarga.Monto = Decimal.Parse(txtMonto.Text);

                unaCarga.TipoPagoAsociado = (TipoPago)cmbPago.SelectedItem;

                //Si es tarjeta, tengo que cargar más datos
                if (unaCarga.TipoPagoAsociado.Idtipo_Pago != 1)
                {
                    unaCarga.TarjetaAsociada = new Tarjeta();
                    unaCarga.TarjetaAsociada.Titular = txtTitular.Text;
                    unaCarga.TarjetaAsociada.NumeroTarjeta = txtNroTarj.Text;
                    unaCarga.TarjetaAsociada.
                }

            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.LimpiarDatos();
        }

        private Boolean VerificarDatos()
        {
            Boolean valido = true;

            lblMonto.Visible = false;
            lblTitular.Visible = false;
            lblCodSeg.Visible = false;
            lblError.Visible = false;
            lblNroTarjeta.Visible = false;
            
            if (txtMonto.Text == "")
            {
                valido = false;
                lblMonto.Text = "* Obligatorio";
                lblMonto.Visible = true;
            }
            else
            {
                Boolean numeroValido;
                Decimal monto;
                numeroValido = Decimal.TryParse(lblMonto.Text, out monto);

                if (!numeroValido)
                {
                    valido = false;
                    lblMonto.Text = "* Número inválido.";
                    lblMonto.Visible = true;
                }
                else
                {
                    if (monto <= 15)
                    {
                        valido = false;
                        lblMonto.Text = "* Debe ser mayor a $15!";
                        lblMonto.Visible = true;
                    }
                }
            }

            //Si no es efectivo, es tarjeta
            if (((TipoPago)cmbPago.SelectedItem).Idtipo_Pago != 1)
            {
                if (txtTitular.Text == "")
                {
                    valido = false;
                    lblTitular.Text = "* Obligatorio";
                    lblTitular.Visible = true;
                }
                if (txtDni.Text == "")
                {
                    valido = false;
                    txtDni.Text = "* Obligatorio";
                    txtDni.Visible = true;
                }
                if (txtNroTarj.Text == "")
                {
                    valido = false;
                    txtNroTarj.Text = "* Obligatorio";
                    txtNroTarj.Visible = true;
                }
                if (txtCodSeg.Text == "")
                {
                    valido = false;
                    txtCodSeg.Text = "* Obligatorio";
                    txtCodSeg.Visible = true;
                }
            }

            if (!valido)
            {
                lblError.Text = "Complete todos los campos correctamente antes de continuar";
                lblError.Visible = true;
            }
            return valido;
        }

        private void LimpiarDatos()
        {
            cmbPago.DisplayMember = "Descripcion";
            cmbPago.ValueMember = "Idtipo_pago";
            cmbPago.DataSource = TipoPago.GetTiposPago();

            cmbTipoTarjeta.DisplayMember = "Descripcion";
            cmbTipoTarjeta.ValueMember = "Idtipo_tarjeta";
            cmbTipoTarjeta.DataSource = TipoTarjeta.GetTiposTarjeta();
            cmbTipoTarjeta.Visible = false;

            nudAnioVenc.Minimum = Sesion.ConfigApp.FechaActual.Year;
            nudAnioVenc.Maximum = nudAnioVenc.Minimum + 50;
            nudAnioVenc.Value = Sesion.ConfigApp.FechaActual.Year;

            nudMesVenc.Value = 1;

            txtMonto.Text = "";

            txtTitular.Text = "";
            txtCodSeg.Text = "";
            txtNroTarj.Text = "";

            cmbPago.SelectedIndex = 1;
            cmbTipoTarjeta.SelectedIndex = 1;

        }

        private void frmCargarCredito_Load(object sender, EventArgs e)
        {
            this.LimpiarDatos();
        }

    }
}
