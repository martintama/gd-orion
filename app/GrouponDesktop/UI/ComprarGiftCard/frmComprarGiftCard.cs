using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GrouponDesktop.Base;

namespace GrouponDesktop.UI.ComprarGiftCard
{
    public partial class frmComprarGiftCard : Form
    {
        GiftCard elGiftCard = new GiftCard();

        public frmComprarGiftCard()
        {
            InitializeComponent();
        }

        private void frmComprarGiftCard_Load(object sender, EventArgs e)
        {
            elGiftCard.ClienteOrigen = (Cliente)clsMain.objInfoSesion.EntidadLogueada;
            cargarMontos();
        }

        private void cargarMontos()
        {
            this.cmbMonto.ValueMember = "Idmonto";
            this.cmbMonto.DisplayMember = "Monto";
            this.cmbMonto.DataSource = MontoGiftCard.getMontos();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            frmBuscarCliente oFrm = new frmBuscarCliente();
            oFrm.esAbm = false;
            oFrm.ShowDialog();

            if (oFrm.clienteSeleccionado != null)
            {
                            
            
            }

            oFrm.Dispose();

        }

    }
}
