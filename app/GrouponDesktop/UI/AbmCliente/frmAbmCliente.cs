using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GrouponDesktop.Logic.Global;

namespace GrouponDesktop.AbmCliente
{
    public partial class frmAbmCliente : Form
    {
        public Form frmParent;
        public frmAbmCliente()
        {
            InitializeComponent();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            Cliente objCliente = new Cliente();

            objCliente.Nombre = txtNombre.Text;
            objCliente.Apellido = txtApellido.Text;
            objCliente.DNI = Convert.ToInt32(txtDni.Text);
            objCliente.Mail = txtMail.Text;
            objCliente.Telefono = txtTelefono.Text;
            objCliente.Direccion = txtDireccion.Text;
            objCliente.CodPostal = txtCodPostal.Text;
            objCliente.FechaNacimiento = dtpNacimiento.Value;
            
            foreach(Ciudad objCiudad in lstCiudades.Items){
                objCliente.Ciudades.Add(objCiudad);
            }

            objCliente.UsuarioAsociado.Username = txtUsername.Text;
            objCliente.UsuarioAsociado.Clave = txtPassword.Text;

            Int16 return_value = objCliente.Grabar();

            switch (return_value)
            {
                case 0: //Todo OK
                    {
                        MessageBox.Show("Registración exitosa. Puede ingresar al sistema con su usuario y clave", "Registro de nuevo cliente");
                        break;
                    } 
                case 1: //Usuario ya existe
                    {
                        MessageBox.Show("El usuario ya está en uso", "Registro de nuevo cliente");
                        break;
                    }
                case 2: //El cliente ya se encuentra dado de alta
                    {
                        MessageBox.Show("Se ha detectado que el cliente ya se encuentra registrado", "Registro de nuevo cliente");
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
