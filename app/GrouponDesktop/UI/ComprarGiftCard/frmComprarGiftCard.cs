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
            if (Sesion.Idtipo_usuario == 2)
            {
                elGiftCard.ClienteOrigen = (Cliente)Sesion.EntidadLogueada;
            }
            else
            {
                MessageBox.Show("Esta funcionalidad solo está disponible para clientes", "Comprar GiftCard");
            }

            cargarMontos();
        }

        private void cargarMontos()
        {
            this.cmbMonto.ValueMember = "Monto";
            this.cmbMonto.DisplayMember = "StrMonto";
            this.cmbMonto.DataSource = MontoGiftCard.getMontos();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            frmBuscarCliente oFrm = new frmBuscarCliente();
            oFrm.esAbm = false;
            oFrm.listaExclusion.Clear();
            oFrm.listaExclusion.Add((Cliente)Sesion.EntidadLogueada);
            oFrm.ShowDialog();

            if (oFrm.clienteSeleccionado != null)
            {
                this.elGiftCard.ClienteDestino = oFrm.clienteSeleccionado;
                this.txtUsuarioReceptor.Text = this.elGiftCard.ClienteDestino.Nombre + " " + this.elGiftCard.ClienteDestino.Apellido + " (" + this.elGiftCard.ClienteDestino.DNI + ")";
            }

            oFrm.Dispose();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (VerificarDatos())
            {
                this.elGiftCard.Monto = Convert.ToDecimal(cmbMonto.SelectedValue);
                this.elGiftCard.CompraGiftCard();

                MessageBox.Show("GiftCard comprado exitosamente", "Comprar GiftCard");
                this.Close();
                this.Dispose();
            }
        }

        private bool VerificarDatos()
        {
            Boolean valido = true;
            lblClienteReceptor.Visible = false;
            lblMensaje.Visible = false;

            if (this.elGiftCard.ClienteDestino == null)
            {
                lblClienteReceptor.Visible = true;
                lblMensaje.Text = "Seleccione el cliente de destino";
                lblMensaje.Visible = true;
                valido = false;
            }

            return valido;
        }



    }
}
