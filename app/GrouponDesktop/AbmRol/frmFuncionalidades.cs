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
            if (idrol > 0)
            {
                this.Text = "Editar rol";
            }
            else
            {
                this.Text = "Insertar nuevo rol";
            }
        }

    }
}
