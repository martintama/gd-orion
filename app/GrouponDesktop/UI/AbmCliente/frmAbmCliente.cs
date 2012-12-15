using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GrouponDesktop.Base;
using System.Data.SqlClient;

namespace GrouponDesktop.UI.AbmCliente
{
    public partial class frmAbmCliente : Form
    {
        public Form frmParent;

        public enum TipoOperacion
        {
            Registro = 1,
            Alta,
            Edicion_Admin,
            Edicion_Cliente
        }

        public TipoOperacion tipoOperacion = TipoOperacion.Registro;

        public Cliente objCliente = new Cliente();

        public frmAbmCliente()
        {
            InitializeComponent();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (VerificarDatos())
            {
                try
                {
                    this.objCliente.Nombre = txtNombre.Text;
                    this.objCliente.Apellido = txtApellido.Text;
                    this.objCliente.DNI = Convert.ToInt32(txtDni.Text);
                    this.objCliente.Mail = txtMail.Text;
                    this.objCliente.Telefono = txtTelefono.Text;
                    this.objCliente.Direccion = txtDireccion.Text;
                    this.objCliente.CodPostal = txtCodPostal.Text;
                    this.objCliente.FechaNacimiento = dtpNacimiento.Value;
                    this.objCliente.UsuarioAsociado.Username = txtUsername.Text;
                    this.objCliente.UsuarioAsociado.Clave = txtPassword.Text;

                    if (Convert.ToInt32(cmbRol.SelectedValue) != 0)
                    {
                        this.objCliente.UsuarioAsociado.RolAsociado = new Rol(Convert.ToInt32(cmbRol.SelectedValue), cmbRol.SelectedText);
                    }

                    Int16 return_value = this.objCliente.Grabar();

                    switch (return_value)
                    {
                        case 0: //Todo OK
                            {
                                switch (this.tipoOperacion)
                                {
                                    case TipoOperacion.Registro:
                                        {
                                            MessageBox.Show("Registración exitosa. Puede ingresar al sistema con su usuario y clave", "Registro de nuevo cliente");
                                            break;
                                        }
                                    case TipoOperacion.Edicion_Admin:
                                        {
                                            MessageBox.Show("Cambios guardados correctamente", "ABM Clientes");
                                            break;
                                        }
                                    case TipoOperacion.Alta:
                                        {
                                            MessageBox.Show("Cliente generado correctamente", "ABM Clientes");
                                            break;
                                        }
                                    case TipoOperacion.Edicion_Cliente:
                                        {
                                            MessageBox.Show("Datos guardados correctamente. Puede continuar.", "Editar datos");
                                            break;
                                        }

                                }
                                this.Close();
                                this.Dispose();

                                break;
                            }
                        case 1: //Usuario ya existe
                            {
                                this.txtUsername.Focus();
                                lblUsername.Text = "* Nombre de usuario ya en uso";
                                lblUsername.Visible = true;

                                //Reseteo el objeto Cliente
                                if (this.tipoOperacion == TipoOperacion.Registro || this.tipoOperacion == TipoOperacion.Alta)
                                {
                                    this.objCliente = new Cliente();
                                    this.objCliente.UsuarioAsociado.RolAsociado.Idrol = 2;
                                    this.objCliente.UsuarioAsociado.TipoUsuarioAsociado.Idtipo_usuario = 2;
                                }
                                break;
                            }
                        case 2: //El cliente ya se encuentra dado de alta
                            {
                                MessageBox.Show("Se ha detectado que el cliente ya se encuentra registrado", "Registro de nuevo cliente");

                                //Reseteo el objeto Cliente
                                if (this.tipoOperacion == TipoOperacion.Registro || this.tipoOperacion == TipoOperacion.Alta)
                                {
                                    this.objCliente = new Cliente();
                                    this.objCliente.UsuarioAsociado.RolAsociado.Idrol = 2;
                                    this.objCliente.UsuarioAsociado.TipoUsuarioAsociado.Idtipo_usuario = 2;
                                }

                                break;
                            }
                        default:
                            {
                                MessageBox.Show("Error registrando");
                                break;
                            }

                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Ha ocurrido un error: " + ex.Message + ". El programa se cerrará.");
                    Application.Exit();
                }
            }
        }

        private bool VerificarDatos()
        {
            bool valido = true;
            ApagarAvisos();

            if (txtNombre.Text == "")
            {
                valido = false;
                lblNombre.Text = "* Obligatorio";
                lblNombre.Visible = true;
            }

            if (txtApellido.Text == "")
            {
                valido = false;
                lblApellido.Text = "* Obligatorio";
                lblApellido.Visible = true;
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

            if (txtMail.Text == "")
            {
                lblMail.Text = "* Obligatorio";
                lblMail.Visible = true;
                valido = false;
            }
            else{
                if (!BasicFunctions.EsMail(txtMail.Text))
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
                lblCodPostal.Text = "* Obligatorio";
                lblCodPostal.Visible = true;
            }

            if (objCliente.Ciudades.Count == 0)
            {
                valido = false;
                lblCiudades.Text = "* Obligatorio";
                lblCiudades.Visible = true;
            }

            if (txtUsername.Text == "")
            {
                valido = false;
                lblUsername.Text = "* Obligatorio";
                lblUsername.Visible = true;
            }

            //Solo para la registración o alga de nuevo por parte del admin
            if (this.tipoOperacion == TipoOperacion.Alta ||this.tipoOperacion == TipoOperacion.Registro)
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
            lblNombre.Visible = false;
            lblApellido.Visible = false;
            lblDni.Visible = false;
            lblMail.Visible = false;
            lblTelefono.Visible = false;
            lblDireccion.Visible = false;
            lblCodPostal.Visible = false;
            lblFechaNac.Visible = false;
            lblCiudades.Visible = false;
            lblUsername.Visible = false;
            lblErrorMsg.Visible = false;
        }

        private void CargarTextoCiudades()
        {
            StringBuilder strBuilder = new StringBuilder();

            foreach (Ciudad item in this.objCliente.Ciudades)
            {
                if (strBuilder.Length == 0)
                {
                    strBuilder.Append(item.Descripcion);
                }
                else
                {
                    strBuilder.Append(", " + item.Descripcion);
                }
            }

            txtCiudades.Text = strBuilder.ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void frmAbmCliente_Load(object sender, EventArgs e)
        {
            if (this.tipoOperacion == TipoOperacion.Alta ||this.tipoOperacion == TipoOperacion.Registro)
            {
                this.Text = "Cuponete Orion - Registro de nuevo cliente";
                this.lblTitulo.Text = "Nuevo cliente";
                chkHabilitado.Visible = false;

                
                this.objCliente.UsuarioAsociado.TipoUsuarioAsociado.Idtipo_usuario = 2;

                //Si es un registro: Rol y tipo de usuario "Cliente" por default
                if (this.tipoOperacion == TipoOperacion.Registro)
                {
                    this.objCliente.UsuarioAsociado.RolAsociado.Idrol = 2;
                    lblRol.Visible = true;
                    cmbRol.Visible = false;
                }
                else
                {
                    cmbRol.ValueMember = "Idrol";
                    cmbRol.DisplayMember = "NombreRol";
                    cmbRol.DataSource = Rol.getRoles(2);

                    lblRol.Visible = false;
                    cmbRol.Visible = true;
                }
                
                
            }
            else
            {
                if (this.tipoOperacion == TipoOperacion.Edicion_Admin)
                {
                    this.Text = "Cuponete Orion - Editar cliente";
                    this.lblTitulo.Text = "Editar cliente";

                    lblRol.Visible = false;
                    cmbRol.Visible = true;

                    chkHabilitado.Visible = true;

                    cmbRol.ValueMember = "Idrol";
                    cmbRol.DisplayMember = "NombreRol";
                    cmbRol.DataSource = Rol.getRoles(2);
                }
                else
                {
                    this.Text = "Cuponete Orion - Editar datos";
                    this.lblTitulo.Text = "Editar datos";
                    lblRol.Visible = true;
                    cmbRol.Visible = false;
                    txtUsername.ReadOnly = true;
                    txtPassword.ReadOnly = true;
                }

                this.CargarControles();
            }

        }

        private void btnEditarCiudades_Click(object sender, EventArgs e)
        {
            frmSeleccionCiudad frmCiudad = new frmSeleccionCiudad();
            frmCiudad.listaCiudadesParent = this.objCliente.Ciudades;
            frmCiudad.ShowDialog();

            this.CargarTextoCiudades();
        }

        private void CargarControles()
        {
            txtNombre.Text = objCliente.Nombre;
            txtApellido.Text = objCliente.Apellido;
            txtDni.Text = objCliente.DNI.ToString();
            txtMail.Text = objCliente.Mail;
            txtTelefono.Text = objCliente.Telefono;
            txtDireccion.Text = objCliente.Direccion;
            txtCodPostal.Text = objCliente.CodPostal;
            dtpNacimiento.Value = objCliente.FechaNacimiento;
            CargarTextoCiudades();

            txtUsername.Text = objCliente.UsuarioAsociado.Username;

            if (objCliente.UsuarioAsociado.Habilitado)
                chkHabilitado.Checked = true;
            else
                chkHabilitado.Checked = false;

            cmbRol.SelectedValue = objCliente.UsuarioAsociado.RolAsociado.Idrol;
            dtpNacimiento.MaxDate = Sesion.ConfigApp.FechaActual;
            
        }

    }
}
