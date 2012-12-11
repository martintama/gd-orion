using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GrouponDesktop.Base;

namespace GrouponDesktop.UI.AbmProveedor
{
    public partial class frmAbmProveedor : Form
    {
        public Form frmParent;

        public Proveedor elProveedor;

        public Boolean esRegistracion;

        public frmAbmProveedor()
        {
            InitializeComponent();
        }

        private void frmAbmProveedor_Load(object sender, EventArgs e)
        {
            this.CargarCombos();

            //Si no hay nada, es uno nuevo
            if (elProveedor == null)
            {
                esRegistracion = true;
                elProveedor = new Proveedor();
                elProveedor.UsuarioAsociado.TipoUsuarioAsociado = new TipoUsuario(3, "Proveedor");
                lblTitulo.Text = "Registrar nuevo proveedor";
            }
            else
            {
                //Sino, es una edicion
                esRegistracion = false;
                lblTitulo.Text = "Editar proveedor";
                this.CargarDatos();
            }
        }

        private void CargarCombos()
        {
            cmbCiudad.ValueMember = "Idciudad";
            cmbCiudad.DisplayMember = "Descripcion";
            cmbCiudad.DataSource = Ciudad.getListaCiudades();

            cmbRubro.ValueMember = "Idrubro";
            cmbRubro.DisplayMember = "Descripcion";
            cmbRubro.DataSource = Rubro.getRubros();
        }

        private void CargarDatos()
        {
            this.txtRazonSocial.Text = elProveedor.RazonSocial;
            this.txtMail.Text = elProveedor.Mail;
            this.txtTelefono.Text = elProveedor.Telefono;
            this.txtDireccion.Text = elProveedor.Direccion;
            this.txtCodPostal.Text = elProveedor.CodPostal;
            this.cmbCiudad.SelectedValue = elProveedor.Ciudad.Idciudad;
            this.txtCuit.Text = elProveedor.Cuit;
            this.cmbRubro.SelectedValue = elProveedor.Rubro.Idrubro;
            this.txtContacto.Text = elProveedor.Contacto;

            this.txtUsername.Text = elProveedor.UsuarioAsociado.Username;

            chkHabilitado.Checked = elProveedor.UsuarioAsociado.Habilitado;
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            this.GrabarDatos();
        }

        //Se fija que los tipos de datos coincidan y estén completos
        private Boolean VerificarDatos()
        {
            bool valido = true;
            ApagarAvisos();

            if (txtRazonSocial.Text == "")
            {
                valido = false;
                lblRazonSocial.Text = "* Obligatorio";
                lblRazonSocial.Visible = true;
            }

            if (txtMail.Text == "")
            {
                lblMail.Text = "* Obligatorio";
                lblMail.Visible = true;
                valido = false;
            }
            else
            {
                if (!BasicFunctions.IsValidEmail(txtMail.Text))
                {
                    lblMail.Text = "* Email Inválido";
                    lblMail.Visible = true;
                    valido = false;
                }
            }

            if (txtTelefono.Text == "")
            {
                lblTelefono.Text = "* Obligatorio";
                lblTelefono.Visible = true;
                valido = false;
            }
            else
            {
                if (!BasicFunctions.EsNumero(txtTelefono.Text))
                {
                    lblTelefono.Text = "* Solo números";
                    lblTelefono.Visible = true;
                    valido = false;
                }
            }

            if (txtDireccion.Text == "")
            {
                valido = false;
                lblDireccion.Text = "* Obligatorio";
                lblDireccion.Visible = true;
            }

            if (txtCodPostal.Text == "")
            {
                valido = false;
                lblCodpostal.Text = "* Obligatorio";
                lblCodpostal.Visible = true;
            }

            if (cmbCiudad.SelectedValue.ToString() == "")
            {
                valido = false;
                lblCodpostal.Text = "* Obligatorio";
                lblCiudad.Visible = true;
            }

            if (txtCuit.Text == "")
            {
                valido = false;
                txtCuit.Text = "* Obligatorio";
                txtCuit.Visible = true;
            }
            else
            {
                if (!BasicFunctions.EsNumero(txtCuit.Text))
                {
                    txtCuit.Text = "* Solo números. Sin guiones.";
                    valido = false;
                    txtCuit.Visible = true;
                }
            }

            if (cmbRubro.SelectedValue.ToString() == "")
            {
                valido = false;
                lblRubro.Text = "* Obligatorio";
                lblRubro.Visible = true;
            }

            if (txtContacto.Text == "")
            {
                valido = false;
                txtContacto.Text = "* Obligatorio";
                txtContacto.Visible = true;
            }

            if (txtUsername.Text == "")
            {
                valido = false;
                lblUsername.Text = "* Obligatorio";
                lblUsername.Visible = true;
            }

            //Solo para la registración
            if (this.esRegistracion)
            {
                if (txtPassword.Text == "")
                {
                    valido = false;
                    lblPassword.Text = "* Obligatorio";
                    lblPassword.ForeColor = Color.Red;
                    lblPassword.Visible = true;
                }
            }

            if (!valido)
            {
                lblErrorMsg.Text = "Se han encontrado errores al procesar los datos. Debe corregirlos para continuar";
                lblErrorMsg.Visible = true;
            }
            return valido;
        }

        private void ApagarAvisos()
        {
            lblRazonSocial.Visible = false;
            lblMail.Visible = false;
            lblTelefono.Visible = false;
            lblDireccion.Visible = false;
            lblCodpostal.Visible = false;
            lblCiudad.Visible = false;
            lblCuit.Visible = false;
            lblRubro.Visible = false;
            lblContacto.Visible = false;
        }

        private void GrabarDatos()
        {
            Int16 return_value = -1;
            if (this.VerificarDatos())
            {
                this.elProveedor.RazonSocial = txtRazonSocial.Text;
                this.elProveedor.Mail = txtMail.Text;
                this.elProveedor.Telefono = txtTelefono.Text;
                this.elProveedor.Direccion = txtDireccion.Text;
                this.elProveedor.CodPostal = txtCodPostal.Text;
                this.elProveedor.Ciudad = (Ciudad)cmbCiudad.SelectedItem;
                this.elProveedor.Cuit = txtCuit.Text;
                this.elProveedor.Rubro = (Rubro)cmbRubro.SelectedItem;
                this.elProveedor.Contacto = txtContacto.Text;
                this.elProveedor.UsuarioAsociado.Username = txtUsername.Text;
                this.elProveedor.UsuarioAsociado.Clave = txtPassword.Text;

                return_value = this.elProveedor.Grabar();

                switch (return_value)
                {
                    case 0: //Todo OK
                        {
                            if (esRegistracion)
                            {
                                MessageBox.Show("Registración exitosa. Puede ingresar al sistema con su usuario y clave", "Registro de nuevo proveedor");
                            }
                            else
                            {
                                MessageBox.Show("Cambios guardados correctamente", "ABM Proveedores");
                            }
                            this.Close();
                            this.Dispose();

                            break;
                        }
                    case -1: //Usuario ya existe
                        {
                            this.txtUsername.Focus();
                            lblUsername.Text = "* Nombre de usuario ya en uso";
                            lblUsername.Visible = true;
                            break;
                        }
                    case -2: //El proveedor ya se encuentra dado de alta
                        {
                            MessageBox.Show("Se ha detectado que el proveedor ya se encuentra registrado", "Registro de nuevo cliente");
                            break;
                        }
                    default:
                        {
                            MessageBox.Show("Error registrando");
                            break;
                        }

                }
            }

        }

    }
}
