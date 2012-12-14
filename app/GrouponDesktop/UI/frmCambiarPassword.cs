using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GrouponDesktop.Base;

namespace GrouponDesktop.UI
{
    public partial class frmCambiarPassword : Form
    {
        public frmCambiarPassword()
        {
            InitializeComponent();
        }

        private Boolean VerificarDatos()
        {
            Boolean valido = true;

            lblPasswordActual.Visible = false;
            lblPasswordNuevo1.Visible = false;
            lblPasswordNuevo2.Visible = false;
            if (txtPasswordActual.Text == "")
            {
                lblPasswordActual.Text = "* Requerido";
                lblPasswordActual.Visible = true;
                valido = false;
            }

            if (txtPasswordNuevo1.Text == "")
            {
                lblPasswordActual.Text = "* Requerido";
                lblPasswordNuevo1.Visible = true;
                valido = false;
            }

            if (txtPasswordNuevo2.Text == "")
            {
                lblPasswordActual.Text = "* Requerido";
                lblPasswordNuevo2.Visible = true;
                valido = false;
            }

            if (txtPasswordNuevo1.Text != "" && (txtPasswordNuevo1.Text != txtPasswordNuevo2.Text))
            {
                lblPasswordNuevo1.Text = "* No coinciden";
                lblPasswordNuevo1.Visible = true;
                lblPasswordNuevo2.Text = "* No coinciden";
                lblPasswordNuevo2.Visible = true;
                valido = false;
            }

            return valido;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (VerificarDatos())
            {
                Int16 result = Sesion.GetUsuarioAsociado().CambiarClave(txtPasswordActual.Text, txtPasswordNuevo1.Text);

                switch (result)
                {
                    case 0:
                        {
                            MessageBox.Show("La contraseña ha sido modificada con exito!", "Cambiar clave");
                            this.Close();
                            this.Dispose();
                            break;
                        }
                    case -1:
                        {
                            MessageBox.Show("La contraseña actual no es válida", "Cambiar clave");
                            this.LimpiarCampos();
                            this.txtPasswordActual.Focus();
                            break;
                        }
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            this.txtPasswordActual.Text = "";
            this.txtPasswordNuevo1.Text = "";
            this.txtPasswordNuevo2.Text = "";
        }
    }
}
