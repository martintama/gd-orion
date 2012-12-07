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
                lblError.ForeColor = Color.Red;
                btnAceptar.Enabled = false;
            }
            else
            {
                lblError.Text = "";
                btnAceptar.Enabled = true;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int credito;

            int.TryParse(montoBox.Text, out credito);

        }

        private void hide_nro(object sender, EventArgs e)
        {
            txtNroTarj.Visible = false;
        }

        private void cmbPago_CursorChanged(object sender, EventArgs e)
        {
            //if (cmbPago.Item == 1);
            //Si el item es efectivo, esconderme el campo nro tarjeta
        }
    }
}
