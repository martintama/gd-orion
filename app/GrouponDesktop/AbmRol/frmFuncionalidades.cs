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
    public partial class frmFuncionalidades : Form
    {
        //El idrol a editar si se edita
        public Int32 idrol = 0;

        public frmFuncionalidades()
        {
            InitializeComponent();
        }

        private void frmFuncionalidades_Load(object sender, EventArgs e)
        {
            clsAbmRol clsAbm = new clsAbmRol();
            if (idrol > 0)
            {
                this.Text = "Editar rol";
                ClsRol objRol = clsAbm.GetRol(idrol);
                this.CargarFormulario(objRol);
            }
            else
            {
                this.Text = "Insertar nuevo rol";
            }
        }

        private void CargarFormulario(ClsRol objRol)
        {
            this.txtNombreRol.Text = objRol.NombreRol;

            foreach (ClsRol.Funcionalidad func in objRol.FuncHabilitadas)
            {
                lstHabilitadas.Items.Add(func);
            }

            foreach (ClsRol.Funcionalidad func in objRol.FuncInhabilitadas)
            {
                lstDeshabilitadas.Items.Add(func);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void brnGrabar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
