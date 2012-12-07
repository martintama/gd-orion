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
        int credito;

        public frmCargarCredito()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int.TryParse(montoBox.Text, out credito);
            MessageBox.Show(credito.ToString());
        }
    }
}
