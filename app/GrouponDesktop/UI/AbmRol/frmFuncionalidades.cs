using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GrouponDesktop.Base;

namespace GrouponDesktop.UI.AbmRol
{
    public partial class frmFuncionalidades : Form
    {

        public Rol objRol = new Rol();

        public frmFuncionalidades()
        {
            InitializeComponent();
        }

        private void frmFuncionalidades_Load(object sender, EventArgs e)
        {

            Rol clsAbm = new Rol();

            if (objRol.Idrol > 0){
                this.Text = "Editar rol";
            }
            else
            {
                this.Text = "Insertar nuevo rol";
            }

            //GetRol devuelve el ROL buscado o un "template" (con todas las funcionalidades deshabilitadas)
            objRol.GetFuncionalidades();

            this.CargarFormulario();

            brnGrabar.Enabled = false;

            this.ActiveControl = txtNombreRol;
        }

        private void CargarFormulario()
        {
            this.txtNombreRol.Text = this.objRol.NombreRol;

            lstHabilitadas.Items.Clear();
            lstDeshabilitadas.Items.Clear();

            foreach (Funcionalidad func in objRol.FuncHabilitadas)
            {
                lstHabilitadas.Items.Add(func);
            }

            foreach (Funcionalidad func in objRol.FuncInhabilitadas)
            {
                lstDeshabilitadas.Items.Add(func);
            }

            foreach (TipoUsuario tipo in objRol.TipoUsuarioAsociados)
            {
                switch (tipo.Idtipo_usuario)
                {
                    case 1: //Administrativo
                        {
                            chkAdministrativo.Checked = true;
                            break;
                        }
                    case 2: //Cliente
                        {
                            chkCliente.Checked = true;
                            break;
                        }
                    case 3: //Proveedor
                        {
                            chkProveedor.Checked = true;
                            break;
                        }

                }
            }
        }

        private void GrabarCambios()
        {
            Rol frmabm = new Rol();
            objRol.NombreRol = txtNombreRol.Text;
            objRol.FuncHabilitadas.Clear();
            objRol.TipoUsuarioAsociados.Clear();

            foreach (Funcionalidad func in lstHabilitadas.Items)
            {
                objRol.FuncHabilitadas.Add(func);
            }

            if (chkAdministrativo.Checked)
            {
                objRol.TipoUsuarioAsociados.Add(new TipoUsuario(1, null));
            }
            if (chkCliente.Checked)
            {
                objRol.TipoUsuarioAsociados.Add(new TipoUsuario(2, null));
            }
            if (chkProveedor.Checked)
            {
                objRol.TipoUsuarioAsociados.Add(new TipoUsuario(3, null));
            }

            this.objRol.GrabarRol();
        }

        private bool VerificarDatos()
        {
            Boolean valido = true;
            lblAsociado.Visible = false;
            lblHabilitadas.Visible = false;
            lblNombre.Visible = false;
            if (this.txtNombreRol.Text == "")
            {
                lblNombre.Visible = true;
            }

            if (!chkAdministrativo.Checked && !chkCliente.Checked && !chkProveedor.Checked)
            {
                lblAsociado.Visible = true;
            }

            if (lstHabilitadas.Items.Count == 0)
            {
                lblHabilitadas.Visible = true;
            }
            return valido;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (brnGrabar.Enabled){
                if (MessageBox.Show("No se han guardado los cambios. Desea guardarlos antes de cerrar?", "Guardar cambios", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.GrabarCambios();
                }
            }
            this.Close();
            this.Dispose();
        }

        private void brnGrabar_Click(object sender, EventArgs e)
        {
            if (VerificarDatos())
            {
                this.GrabarCambios();

                MessageBox.Show("Datos grabados correctamente", "ABM rol");
                brnGrabar.Enabled = false;

                this.Close();
                this.Dispose();
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (lstHabilitadas.SelectedItems.Count > 0)
            {
                if (lstHabilitadas.SelectedItem != null)
                {
                    Funcionalidad func = (Funcionalidad)lstHabilitadas.SelectedItem;

                    lstDeshabilitadas.Items.Add(func);
                    lstHabilitadas.Items.Remove(func);

                    this.objRol.FuncInhabilitadas.Add(func);
                    this.objRol.FuncHabilitadas.Remove(func);

                    if (lstHabilitadas.Items.Count > 0)
                    {
                        lstHabilitadas.SelectedIndex = 0;
                    }
                }
                brnGrabar.Enabled = true;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (lstDeshabilitadas.SelectedItems.Count > 0)
            {
                if (lstDeshabilitadas.SelectedItem != null)
                {
                    Funcionalidad func = (Funcionalidad)lstDeshabilitadas.SelectedItem;

                    lstHabilitadas.Items.Add(func);
                    lstDeshabilitadas.Items.Remove(func);

                    this.objRol.FuncHabilitadas.Add(func);
                    this.objRol.FuncInhabilitadas.Remove(func);

                    if (lstDeshabilitadas.Items.Count > 0)
                    {
                        lstDeshabilitadas.SelectedIndex = 0;
                    }
                }

                brnGrabar.Enabled = true;                
            }
        }

        private void txtNombreRol_TextChanged(object sender, EventArgs e)
        {
            brnGrabar.Enabled = true;

        }

        private void chkCliente_CheckedChanged(object sender, EventArgs e)
        {
            brnGrabar.Enabled = true;
        }

        private void chkProveedor_CheckedChanged(object sender, EventArgs e)
        {
            brnGrabar.Enabled = true;
        }

        private void chkAdministrativo_CheckedChanged(object sender, EventArgs e)
        {
            brnGrabar.Enabled = true;
        }
    }
}
