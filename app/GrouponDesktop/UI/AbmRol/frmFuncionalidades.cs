using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GrouponDesktop.Logic.Global;

namespace GrouponDesktop.AbmRol
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

            clsAbmRol clsAbm = new clsAbmRol();

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

            foreach (Rol.Funcionalidad func in objRol.FuncHabilitadas)
            {
                lstHabilitadas.Items.Add(func);
            }

            foreach (Rol.Funcionalidad func in objRol.FuncInhabilitadas)
            {
                lstDeshabilitadas.Items.Add(func);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void brnGrabar_Click(object sender, EventArgs e)
        {
            clsAbmRol frmabm = new clsAbmRol();
            objRol.NombreRol = txtNombreRol.Text;
            objRol.FuncHabilitadas.Clear();

            foreach (Rol.Funcionalidad func in lstHabilitadas.Items)
            {
                objRol.FuncHabilitadas.Add(func);
            }

            this.objRol.GrabarRol();

            brnGrabar.Enabled = false;
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (lstHabilitadas.SelectedItems.Count > 0)
            {
                if (lstHabilitadas.SelectedItem != null)
                {
                    Rol.Funcionalidad func = (Rol.Funcionalidad)lstHabilitadas.SelectedItem;

                    lstDeshabilitadas.Items.Add(func);
                    lstHabilitadas.Items.Remove(func);

                    this.objRol.FuncInhabilitadas.Add(func);
                    this.objRol.FuncHabilitadas.Remove(func);
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
                    Rol.Funcionalidad func = (Rol.Funcionalidad)lstDeshabilitadas.SelectedItem;

                    lstHabilitadas.Items.Add(func);
                    lstDeshabilitadas.Items.Remove(func);

                    this.objRol.FuncHabilitadas.Add(func);
                    this.objRol.FuncInhabilitadas.Remove(func);
                }

                brnGrabar.Enabled = true;                
            }
        }

        private void txtNombreRol_TextChanged(object sender, EventArgs e)
        {
            brnGrabar.Enabled = true;

        }
    }
}
