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
    
    public partial class frmBuscarProveedor : Form
    {
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
                dgvDatos.DataSource = Proveedor.BuscarProveedor(razonsocial, cuit, email);
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
            if (e.ColumnIndex == this.dgvDatos.Columns["cambiarEstado"].Index)
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
            else if (e.ColumnIndex == this.dgvDatos.Columns["editar"].Index)
            {
                e.Value = "Editar";
            }
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                //Si lo que se presionó fue un botón de editar
                if (dgvDatos.Columns[e.ColumnIndex].Name == "editar")
                {
                    this.EditarProveedor((Proveedor)dgvDatos.Rows[e.RowIndex].DataBoundItem);
                    this.CargarDatos();
                }
                else
                {
                    if (dgvDatos.Columns[e.ColumnIndex].Name == "cambiarEstado")
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
            frmAbmProveedor oFrm = new frmAbmProveedor();
            oFrm.elProveedor = proveedor;
            oFrm.ShowDialog();

            this.CargarDatos();
        }
        
    }
}
