using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GrouponDesktop.AbmRol
{
    public partial class frmAbmRol : Form
    {
        public frmAbmRol()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtRol.Text = "";
            CargarListado();
        }

        private void frmAbmRol_Load(object sender, EventArgs e)
        {
            CargarListado();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargarListado();
        }


        private void CargarListado()
        {
            clsAbmRol clsAbm = new clsAbmRol();
            dgvRoles.DataSource = clsAbm.GetRoles(txtRol.Text);
        }

        private void dgvRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Si lo que se presionó fue un botón de editar
            if (dgvRoles.Columns[e.ColumnIndex].Name == "btnEditar")
            {
                MessageBox.Show(dgvRoles.Rows[e.RowIndex].Cells["colNombreRol"].Value.ToString());
                MessageBox.Show(dgvRoles.Rows[e.RowIndex].Cells["colIdrol"].Value.ToString());
            }
            else
            {
            }
        }

        private void EditarRol(Int32 idrol)
        {
            frmFuncionalidades frmFunc = new frmFuncionalidades();
            frmFunc.idrol = idrol;
            frmFunc.ShowDialog();
        }

        private void InhabilitarRol(Int32 idrol, String nombre)
        {
            
        }
    }
}
