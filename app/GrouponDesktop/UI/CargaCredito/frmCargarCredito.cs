using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GrouponDesktop.CargaCredito
{
    public partial class frmCargarCredito : Form
    {

        public frmCargarCredito()
        {
            InitializeComponent();
        }

        private void montoBox_TextChanged(object sender, EventArgs e)
        {
            int credito;
            int.TryParse(montoBox.Text, out credito);
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
                txtNroTarj.Visible = false;
                lblNroTarj.Visible = false;
            }
            else
            {
                txtNroTarj.Visible = true;
                lblNroTarj.Visible = true;
            }
        }

        private void lblError_TextChanged(object sender, EventArgs e)
        {
            if (lblError.Text.Length > 0)
            {
                lblError.Visible = true;
            }
            else
            {
                lblError.Visible = false;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int credito;

            int.TryParse(montoBox.Text, out credito);

        }
    }
}
