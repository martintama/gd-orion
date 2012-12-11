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
    public partial class frmBuscarCliente : Form
    {
        public Boolean esAbm = true;
        public Cliente clienteSeleccionado;

        public frmBuscarCliente()
        {
            InitializeComponent();
        }

        private void frmBuscarCliente_Load(object sender, EventArgs e)
        {
            //Si es un formulario para seleccionar un solo usuario, o si es parte del ABM
            dgvDatos.AutoGenerateColumns = false;
            dgvDatos.Columns.Clear();
            if (this.esAbm)
            {
                DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
                colNombre.Name = "colNombre";
                colNombre.HeaderText = "Nombre";
                colNombre.Width = 120;
                colNombre.DataPropertyName = "Nombre";
                this.dgvDatos.Columns.Add(colNombre);

                DataGridViewTextBoxColumn colApellido = new DataGridViewTextBoxColumn();
                colApellido.Name = "colApellido";
                colApellido.HeaderText = "Apellido";
                colApellido.Width = 120;
                colApellido.DataPropertyName = "Apellido";
                this.dgvDatos.Columns.Add(colApellido);

                DataGridViewTextBoxColumn colDni = new DataGridViewTextBoxColumn();
                colDni.Name = "colDni";
                colDni.HeaderText = "DNI";
                colDni.Width = 70;
                colDni.DataPropertyName = "DNI";
                this.dgvDatos.Columns.Add(colDni);

                DataGridViewTextBoxColumn colEstado = new DataGridViewTextBoxColumn();
                colEstado.Name = "colEstado";
                colEstado.HeaderText = "Estado";
                colEstado.Width = 60;
                this.dgvDatos.Columns.Add(colEstado);

                DataGridViewButtonColumn colEditar = new DataGridViewButtonColumn();
                colEditar.Name = "colEditar";
                colEditar.HeaderText = "Editar";
                colEditar.Width = 50;
                this.dgvDatos.Columns.Add(colEditar);
                
                DataGridViewButtonColumn colCambiarEstado = new DataGridViewButtonColumn();
                colCambiarEstado.Name = "colCambiarEstado";
                colCambiarEstado.HeaderText = "Cambiar Estado";
                colCambiarEstado.Width = 100;
                this.dgvDatos.Columns.Add(colCambiarEstado);


            }
            else
            {
                DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
                colNombre.Name = "colNombre";
                colNombre.HeaderText = "Nombre";
                colNombre.Width = 150;
                colNombre.DataPropertyName = "Nombre";
                this.dgvDatos.Columns.Add(colNombre);

                DataGridViewTextBoxColumn colApellido = new DataGridViewTextBoxColumn();
                colApellido.Name = "colApellido";
                colApellido.HeaderText = "Apellido";
                colApellido.Width = 150;
                colApellido.DataPropertyName = "Apellido";
                this.dgvDatos.Columns.Add(colApellido);

                DataGridViewTextBoxColumn colDni = new DataGridViewTextBoxColumn();
                colDni.Name = "colDni";
                colDni.HeaderText = "DNI";
                colDni.Width = 70;
                colDni.DataPropertyName = "DNI";
                this.dgvDatos.Columns.Add(colDni);

                DataGridViewButtonColumn colSeleccionar = new DataGridViewButtonColumn();
                colSeleccionar.Name = "colSeleccionar";
                colSeleccionar.HeaderText = "Seleccionar";
                colSeleccionar.Width = 120;
                this.dgvDatos.Columns.Add(colSeleccionar);
            }

            CargarDatos();
        }

        private void CargarDatos()
        {
            Cliente fnCliente = new Cliente();
            String nombre = txtNombre.Text;
            String apellido = txtApellido.Text;
            Int32 dni = -1;

            if (txtDNI.Text != "")
            {
                dni = Convert.ToInt32(txtDNI.Text);
            }

            String mail = txtEmail.Text;

            
            dgvDatos.DataSource = Cliente.GetClientes(nombre, apellido, dni, mail);
            
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
            if (e.ColumnIndex == this.dgvDatos.Columns["colCambiarEstado"].Index)
            {

                if (((List<Cliente>)dgvDatos.DataSource).ElementAt(e.RowIndex).UsuarioAsociado.Habilitado == false)
                {
                    e.Value = "Habilitar";
                }
                else
                {
                    e.Value = "Deshabilitar";
                }

            }
            else if (e.ColumnIndex == this.dgvDatos.Columns["colEstado"].Index)
            {

                if (((List<Cliente>)dgvDatos.DataSource).ElementAt(e.RowIndex).UsuarioAsociado.Habilitado == true)
                {
                    e.Value = "Habilitado";
                }
                else
                {
                    e.Value = "Deshabilitado";
                }
            }
            else if (e.ColumnIndex == this.dgvDatos.Columns["colEditar"].Index)
            {
                e.Value = "Editar";
            }
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                //Si lo que se presionó fue un botón de editar
                if (dgvDatos.Columns[e.ColumnIndex].Name == "colEditar")
                {
                    this.EditarCliente((Cliente)dgvDatos.Rows[e.RowIndex].DataBoundItem);
                    this.CargarDatos();
                }
                else if (dgvDatos.Columns[e.ColumnIndex].Name == "colCambiarEstado")
                {
                    Cliente unCliente = (Cliente)dgvDatos.Rows[e.RowIndex].DataBoundItem;

                    if (unCliente.UsuarioAsociado.Habilitado)
                    {
                        this.InhabilitarCliente(unCliente);
                    }
                    else
                    {
                        this.HabilitarCliente(unCliente);
                    }

                    this.CargarDatos();
                }
                else if (dgvDatos.Columns[e.ColumnIndex].Name == "colSeleccionar")
                {
                    this.clienteSeleccionado = (Cliente)dgvDatos.Rows[e.RowIndex].DataBoundItem;
                    this.Close();
                }
            }
        }

        private void EditarCliente(Cliente cliente)
        {
            AbmCliente.frmAbmCliente frmAbm = new AbmCliente.frmAbmCliente();
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

