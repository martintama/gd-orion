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

        private void button1_Click(object sender, EventArgs e)
        {
            int credito;

            int.TryParse(montoBox.Text, out credito);
            MessageBox.Show(credito.ToString());
        }

        private void montoBox_TextChanged(object sender, EventArgs e)
        {
            int credito;
            int.TryParse(montoBox.Text, out credito);
            if (credito <= 15)
            {
                lblError.Text = "El monto debe ser mayor a 15$!";
                lblError.ForeColor = Color.Red;
            }
            else
            {
                lblError.Text = "";
            }
        }
    }
}
