using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GrouponDesktop.Base;
using GrouponDesktop.UI.AbmProveedor;

namespace GrouponDesktop.UI
{
    
    public partial class frmBuscarProveedor : Form
    {
        public Boolean esAbm;
        public Proveedor proveedorSeleccionado;

        public frmBuscarProveedor()
        {
            InitializeComponent();
            CargarDatos();
        }

        private Boolean verificarDatos()
        {
            Boolean valido = true;
            lblSoloNum.Visible = false;
            if (txtCuit.Text != "")
            {
                if (!BasicFunctions.EsNumero(txtCuit.Text))
                {
                    valido = false;
                    lblSoloNum.Visible = true;
                }
            }

            return valido;
        }

        private void CargarDatos()
        {
            if (verificarDatos())
            {
                Proveedor oProveedor = new Proveedor();
                String razonsocial = txtNombre.Text;
                String email = txtMail.Text;

                String cuit = "";
                if (txtCuit.Text != "")
                {
                    cuit = txtCuit.Text;
                }

                dgvDatos.AutoGenerateColumns = false;
                dgvDatos.DataSource = Proveedor.BuscarProveedor(razonsocial, cuit, email, false, 0);
            }
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtMail.Text = "";
            txtCuit.Text = "";

            this.CargarDatos();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            this.CargarDatos();
        }

        private void dgvDatos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.esAbm)
            {
                if (e.ColumnIndex == this.dgvDatos.Columns["colCambiarEstado"].Index)
                {

                    if (((List<Proveedor>)dgvDatos.DataSource).ElementAt(e.RowIndex).UsuarioAsociado.Habilitado == false)
                    {
                        e.Value = "Habilitar";
                    }
                    else
                    {
                        e.Value = "Deshabilitar";
                    }

                }
                else if (e.ColumnIndex == this.dgvDatos.Columns["colEditar"].Index)
                {
                    e.Value = "Editar";
                }
            }
            else
            {
                if (e.ColumnIndex == this.dgvDatos.Columns["colSeleccionar"].Index)
                {
                    e.Value = "Seleccionar";
                }
            }
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                //Si lo que se presionó fue un botón de editar
                if (dgvDatos.Columns[e.ColumnIndex].Name == "colEditar")
                {
                    this.EditarProveedor((Proveedor)dgvDatos.Rows[e.RowIndex].DataBoundItem);
                    this.CargarDatos();
                }
                else if (dgvDatos.Columns[e.ColumnIndex].Name == "colCambiarEstado")
                {
                    Proveedor unProveedor = (Proveedor)dgvDatos.Rows[e.RowIndex].DataBoundItem;

                    if (unProveedor.UsuarioAsociado.Habilitado)
                    {
                        this.InhabilitarProveedor(unProveedor);
                    }
                    else
                    {
                        this.HabilitarProveedor(unProveedor);
                    }

                    this.CargarDatos();

                }
                else if (dgvDatos.Columns[e.ColumnIndex].Name == "colSeleccionar")
                {
                    this.proveedorSeleccionado = (Cliente)dgvDatos.Rows[e.RowIndex].DataBoundItem;
                    this.Close();
                }
            }
        }

        private void HabilitarProveedor(Proveedor unProveedor)
        {
            if (MessageBox.Show("Está seguro que desea HABILITAR este proveedor?", "Habilitar proveedor", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                unProveedor.Habilitar();
            }
            
            this.CargarDatos();
        }

        private void InhabilitarProveedor(Proveedor unProveedor)
        {
            if (MessageBox.Show("Está seguro que desea INHABILITAR este proveedor?", "Inhabilitar cliente", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                unProveedor.Inhabilitar();
            }

            this.CargarDatos();
        }

        private void EditarProveedor(Proveedor proveedor)
        {
            AbmProveedor.frmAbmProveedor oFrm = new AbmProveedor.frmAbmProveedor();
            oFrm.elProveedor = proveedor;
            oFrm.ShowDialog();

            this.CargarDatos();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAbmProveedor oFrm = new frmAbmProveedor();
            oFrm.tipoOperacion = frmAbmProveedor.TipoOperacion.Alta;
            oFrm.ShowDialog();

            this.CargarDatos();
        }

        private void frmBuscarProveedor_Load(object sender, EventArgs e)
        {
            //Si es un formulario para seleccionar un solo usuario, o si es parte del ABM
            dgvDatos.AutoGenerateColumns = false;
            dgvDatos.Columns.Clear();
            if (this.esAbm)
            {
                DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
                colNombre.Name = "colCuit";
                colNombre.HeaderText = "Cuit";
                colNombre.Width = 120;
                colNombre.DataPropertyName = "Cuit";
                this.dgvDatos.Columns.Add(colNombre);

                DataGridViewTextBoxColumn colApellido = new DataGridViewTextBoxColumn();
                colApellido.Name = "coRazonSocial";
                colApellido.HeaderText = "RazonSocial";
                colApellido.Width = 120;
                colApellido.DataPropertyName = "RazonSocial";
                this.dgvDatos.Columns.Add(colApellido);

                DataGridViewTextBoxColumn colDni = new DataGridViewTextBoxColumn();
                colDni.Name = "colMail";
                colDni.HeaderText = "Mail";
                colDni.Width = 70;
                colDni.DataPropertyName = "Mail";
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
                colNombre.Name = "colCuit";
                colNombre.HeaderText = "Cuit";
                colNombre.Width = 120;
                colNombre.DataPropertyName = "Cuit";
                this.dgvDatos.Columns.Add(colNombre);

                DataGridViewTextBoxColumn colApellido = new DataGridViewTextBoxColumn();
                colApellido.Name = "coRazonSocial";
                colApellido.HeaderText = "RazonSocial";
                colApellido.Width = 120;
                colApellido.DataPropertyName = "RazonSocial";
                this.dgvDatos.Columns.Add(colApellido);

                DataGridViewTextBoxColumn colDni = new DataGridViewTextBoxColumn();
                colDni.Name = "colMail";
                colDni.HeaderText = "Mail";
                colDni.Width = 70;
                colDni.DataPropertyName = "Mail";
                this.dgvDatos.Columns.Add(colDni);

                DataGridViewButtonColumn colSeleccionar = new DataGridViewButtonColumn();
                colSeleccionar.Name = "colSeleccionar";
                colSeleccionar.HeaderText = "Seleccionar";
                colSeleccionar.Width = 120;
                this.dgvDatos.Columns.Add(colSeleccionar);
            }
        }
        
    }
}
