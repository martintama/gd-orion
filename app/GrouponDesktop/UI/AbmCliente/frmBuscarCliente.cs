using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GrouponDesktop.Logic;
using GrouponDesktop.Logic.Global;

namespace GrouponDesktop.UI.AbmCliente
{
    public partial class frmBuscarCliente : Form
    {
        public frmBuscarCliente()
        {
            InitializeComponent();
        }

        private void frmBuscarCliente_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            clsCliente fnCliente = new clsCliente();
            String nombre = txtNombre.Text;
            String apellido = txtApellido.Text;
            Int32 dni = -1;

            if (txtDNI.Text != "")
            {
                dni = Convert.ToInt32(txtDNI.Text);
            }

            String mail = txtEmail.Text;

            dgvDatos.AutoGenerateColumns = false;
            dgvDatos.DataSource = fnCliente.GetClientes(nombre, apellido, dni, mail);
            
        }

        private Boolean VerificarDatos()
        {
            Boolean valido = true;
            lblSoloNum.Visible = false;
            if (txtDNI.Text != "")
            {
                if (!BasicFunctions.EsNumero(txtDNI.Text))
                {
                    valido = false;
                    lblSoloNum.Visible = true;
                }
            }

            return valido;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (VerificarDatos())
            {
                CargarDatos();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDNI.Text = "";
            txtEmail.Text = "";

            CargarDatos();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void dgvDatos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == this.dgvDatos.Columns["CambiarEstado"].Index)
            {

                if (((List<Cliente>)dgvDatos.DataSource).ElementAt(e.RowIndex).Habilitado == false)
                {
                    e.Value = "Habilitar";
                }
                else
                {
                    e.Value = "Deshabilitar";
                }

            }
            else if (e.ColumnIndex == this.dgvDatos.Columns["Estado"].Index)
            {

                if (((List<Cliente>)dgvDatos.DataSource).ElementAt(e.RowIndex).Habilitado == true)
                {
                    e.Value = "Habilitado";
                }
                else
                {
                    e.Value = "Deshabilitado";
                }
            }
            else if (e.ColumnIndex == this.dgvDatos.Columns["Editar"].Index)
            {
                e.Value = "Editar";
            }
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Si lo que se presionó fue un botón de editar
            if (dgvDatos.Columns[e.ColumnIndex].Name == "Editar")
            {
                this.EditarCliente((Cliente)dgvDatos.Rows[e.RowIndex].DataBoundItem);
                this.CargarDatos();
            }
            else
            {
                if (dgvDatos.Columns[e.ColumnIndex].Name == "CambiarEstado")
                {
                    Cliente objCliente = (Cliente)dgvDatos.Rows[e.RowIndex].DataBoundItem;

                    if (objCliente.Habilitado)
                    {
                        this.InhabilitarCliente(objCliente);
                    }
                    else
                    {
                        this.HabilitarCliente(objCliente);
                    }

                    this.CargarDatos();
                }
            }
        }

        private void EditarCliente(Cliente cliente)
        {
            frmAbmCliente frmAbm = new frmAbmCliente();
            frmAbm.esRegistracion = false;
            frmAbm.objCliente = cliente;
            frmAbm.ShowDialog();

            this.CargarDatos();
        }

        private void HabilitarCliente(Cliente cliente)
        {
            if (MessageBox.Show("Está seguro que desea HABILITAR este cliente?", "Habilitar cliente", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                cliente.Habilitar();
            }
        }

        private void InhabilitarCliente(Cliente cliente)
        {
            if (MessageBox.Show("Está seguro que desea INHABILITAR este cliente?", "Inhabilitar cliente", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                cliente.Inhabilitar();
            }
        }
    }
}

