using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GrouponDesktop.Base;

namespace GrouponDesktop.PedirDevolucion
{
    public partial class frmPedirDevolucion : Form
    {

        Devolucion laDevolucion;
        Compra unaCompra;

        public frmPedirDevolucion()
        {
            InitializeComponent();
        }

        private void LimpiarCampos()
        {
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            txtCantidad.Text = "";
            txtLimitePromo.Text = "";
            lblEstado.Text = "-";
            chkConfirmar.Checked = false;
            txtMotivo.Text = "";
        }

        private void ApagarAvisos()
        {
            lblErrorCodigo.Visible = false;
            lblCheck.Visible = false;
            lblMotivo.Visible = false;
        }

        private Boolean VerificarCampos()
        {
            Boolean valido = true;
            lblErrorCodigo.Visible = false;
            if (txtCodigo.Text == "")
            {
                lblErrorCodigo.Text = "* Requerido";
                lblErrorCodigo.Visible = true;
                valido = false;
            }

            return valido;
        }

        private Boolean VerificarCamposDevolucion()
        {
            Boolean valido = true;
            lblCheck.Visible = false;
            lblMotivo.Visible = false;

            if (!chkConfirmar.Checked){
                lblCheck.Visible = true;
                lblCheck.Text = "* Requerido";
                valido = false;
            }
            if (txtMotivo.Text == "")
            {
                lblMotivo.Text = "* Requerido";
                lblMotivo.Visible = true;
                valido = false;
            }

            return valido;
        }

        private void Buscar()
        {
            unaCompra = Compra.BuscarCompra(txtCodigo.Text, (Cliente)Sesion.EntidadLogueada);

            if (unaCompra != null)
            {
                this.CargarDatosCompra();
            }
            else
            {
                lblErrorCodigo.Text = "El código ingresado es inválido";
            }
        }

        private void CargarDatosCompra()
        {
            txtDescripcion.Text = unaCompra.CuponAsociado.Descripcion;
            txtCantidad.Text = unaCompra.Cantidad.ToString();
            txtLimitePromo.Text = unaCompra.CuponAsociado.FechaVencimientoCanje.ToString("dd/MM/yyyy");

            switch (unaCompra.Estado.Idestado_compra)
            {
                case 1:
                    {
                        lblEstado.ForeColor = Color.Green;
                        lblEstado.Text = "Devolución habilitada";
                        
                        HabilitarDevolucion();
                        break;
                    }
                case 2:
                    {
                        lblEstado.ForeColor = Color.Red;
                        lblEstado.Text = "Devolución no habilitada. Cupón ya consumido.";

                        DeshabilitarDevolucion();
                        break;
                    }
                case 3:
                    {
                        lblEstado.ForeColor = Color.Green;
                        lblEstado.Text = "Devolución no habilitada. Cupón ya devuelto.";

                        DeshabilitarDevolucion();
                        break;
                    }
                case 4:
                    {
                        lblEstado.ForeColor = Color.Green;
                        lblEstado.Text = "Devolución no habilitada. Cupón vencido.";

                        DeshabilitarDevolucion();
                        break;
                    }
            }


        }

        private void HabilitarDevolucion()
        {
            chkConfirmar.Enabled = true;
            txtMotivo.Enabled = true;
            btnDevolucion.Enabled = true;
        }
        private void DeshabilitarDevolucion()
        {
            chkConfirmar.Enabled = false;
            txtMotivo.Enabled = false;
            btnDevolucion.Enabled = false;
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (this.VerificarCampos())
            {
                this.Buscar();
            }
        }

        
        private void button4_Click(object sender, EventArgs e)
        {
            this.LimpiarCampos();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.VerificarCamposDevolucion())
            {
                laDevolucion.Idcliente = ((Cliente)Sesion.EntidadLogueada).Idcliente;
                laDevolucion.Idcompra = unaCompra.Idcompra;
                laDevolucion.Motivo = txtMotivo.Text;
                laDevolucion.FechaDevolucion = Sesion.currentDate;

                laDevolucion.Devolver();

                if (MessageBox.Show("Cupón devuelto correctamente. ¿Desea devolver otro cupón?", "Devolver cupón", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.LimpiarCampos();
                }
                else
                {
                    this.Close();
                    this.Dispose();
                };
                

            }
        }


    }
}
