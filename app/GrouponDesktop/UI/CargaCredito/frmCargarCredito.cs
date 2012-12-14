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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void cmbPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt16(cmbPago.SelectedValue) == 2) //Efectivo
            {
                gbxDatosTarjeta.Enabled = false;
            }
            else
            {
                gbxDatosTarjeta.Enabled = true;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (VerificarDatos())
            {
                unaCarga.ClienteAsociado.Idcliente = ((Cliente)Sesion.EntidadLogueada).Idcliente;
                //Se supone que si pasó la verificación, es válido
                unaCarga.Monto = Decimal.Parse(txtMonto.Text);

                unaCarga.TipoPagoAsociado = (TipoPago)cmbPago.SelectedItem;

                //Si es tarjeta, tengo que cargar más datos
                if (unaCarga.TipoPagoAsociado.Idtipo_Pago != 2)
                {
                    unaCarga.TarjetaAsociada = new Tarjeta();
                    
                    unaCarga.TarjetaAsociada.TipoTarjetaAsociada = (TipoTarjeta)cmbTipoTarjeta.SelectedItem;
                    unaCarga.TarjetaAsociada.Titular = txtTitular.Text;
                    unaCarga.TarjetaAsociada.Dni = Convert.ToInt32(txtDni.Text);
                    unaCarga.TarjetaAsociada.NumeroTarjeta = txtNroTarj.Text;
                    unaCarga.TarjetaAsociada.CodigoSeguridad = Convert.ToInt16(txtCodSeg.Text);
                    unaCarga.TarjetaAsociada.AnioVencimiento = Convert.ToInt16(nudAnioVenc.Value);
                    unaCarga.TarjetaAsociada.MesVencimiento = Convert.ToInt16(nudMesVenc.Value);
                }

                unaCarga.Efectivizar();

                MessageBox.Show("Carga realizada exitosamente!", "Cargar Crédito");

                this.Close();
                this.Dispose();

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
            lblDni.Visible = false;
            
            if (txtMonto.Text == "")
            {
                valido = false;
                lblMonto.Text = "* Obligatorio";
                lblMonto.Visible = true;
            }
            else
            {
                Boolean numeroValido;
                Int32 monto;
                numeroValido = Int32.TryParse(txtMonto.Text, out monto);

                if (!numeroValido)
                {
                    valido = false;
                    lblMonto.Text = "* Número inválido. Solo números enteros.";
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
            if (((TipoPago)cmbPago.SelectedItem).Idtipo_Pago != 2)
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
                    lblDni.Text = "* Obligatorio";
                    lblDni.Visible = true;
                }
                else
                {
                    if (!BasicFunctions.EsNumero(txtDni.Text) || Convert.ToInt32(txtDni.Text) > 99999999 || Convert.ToInt32(txtDni.Text) < 1000000)
                    {
                        lblDni.Text = "* DNI Inválido";
                        valido = false;
                        lblDni.Visible = true;
                    }
                }
                if (txtNroTarj.Text == "")
                {
                    valido = false;
                    lblNroTarjeta.Text = "* Obligatorio";
                    lblNroTarjeta.Visible = true;
                }
                else
                {
                    if (!BasicFunctions.EsNumero(txtNroTarj.Text))
                    {
                        lblNroTarjeta.Text = "* Nro de tarjeta inválida. Debe ingresar solo dígitos";
                        valido = false;
                        lblNroTarjeta.Visible = true;
                    }

                    if (((TipoTarjeta)cmbTipoTarjeta.SelectedItem).Idtipo_tarjeta == 3) //Si es AMEX
                    {
                        if (txtNroTarj.Text.Length != 15)
                        {
                            lblNroTarjeta.Text = "* Nro de tarjeta inválida";
                            valido = false;
                            lblNroTarjeta.Visible = true;
                        }
                    }
                    else
                    {
                        if (txtNroTarj.Text.Length != 16)
                        {
                            lblNroTarjeta.Text = "* Nro de tarjeta inválida";
                            valido = false;
                            lblNroTarjeta.Visible = true;
                        }
                    }
                }
                if (txtCodSeg.Text == "")
                {
                    valido = false;
                    lblCodSeg.Text = "* Obligatorio";
                    lblCodSeg.Visible = true;
                }
                else
                {
                    if (!BasicFunctions.EsNumero(txtCodSeg.Text))
                    {
                        lblCodSeg.Text = "* Código de seguridad inválido";
                        valido = false;
                        lblCodSeg.Visible = true;
                    }

                    if (((TipoTarjeta)cmbTipoTarjeta.SelectedItem).Idtipo_tarjeta == 3) //Si es AMEX
                    {
                        if (txtCodSeg.Text.Length != 4)
                        {
                            lblCodSeg.Text = "* Código de seguridad inválido. Debe ser de 4 dígitos";
                            valido = false;
                            lblCodSeg.Visible = true;
                        }
                    }
                    else
                    {
                        if (txtCodSeg.Text.Length != 3)
                        {
                            lblCodSeg.Text = "* Código de seguridad inválido. Debe ser de 3 dígitos";
                            valido = false;
                            lblCodSeg.Visible = true;
                        }
                    }
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
            
            cmbPago.DataSource = TipoPago.GetTiposPago();
            cmbPago.DisplayMember = "Descripcion";
            cmbPago.ValueMember = "Idtipo_pago";

            cmbTipoTarjeta.DataSource = TipoTarjeta.GetTiposTarjeta();
            cmbTipoTarjeta.DisplayMember = "Descripcion";
            cmbTipoTarjeta.ValueMember = "Idtipo_tarjeta";
            cmbPago.SelectedIndex = 0;

            nudAnioVenc.Minimum = Sesion.ConfigApp.FechaActual.Year;
            nudAnioVenc.Maximum = nudAnioVenc.Minimum + 50;
            nudAnioVenc.Value = Sesion.ConfigApp.FechaActual.Year;

            nudMesVenc.Value = Sesion.ConfigApp.FechaActual.Month;

            txtMonto.Text = "";

            txtTitular.Text = "";
            txtCodSeg.Text = "";
            txtNroTarj.Text = "";

            if (Convert.ToInt16(cmbPago.SelectedValue) == 3)//Si es con tarjeta de credito
            {
                gbxDatosTarjeta.Enabled = true;
            }
            else
            {
                gbxDatosTarjeta.Enabled = false;
            }

        }

        private void frmCargarCredito_Load(object sender, EventArgs e)
        {
            this.LimpiarDatos();
        }

        private void txtNroTarj_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
