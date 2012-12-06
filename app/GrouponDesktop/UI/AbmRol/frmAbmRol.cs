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
    public partial class frmAbmRol : Form
    {
        public frmAbmRol()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtRol.Text = "";
            CargarListado();
        }

        private void frmAbmRol_Load(object sender, EventArgs e)
        {
            CargarListado();
            this.ActiveControl = txtRol;
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
                this.EditarRol((Rol)dgvRoles.Rows[e.RowIndex].DataBoundItem);
                this.CargarListado();
            }
            else
            {
                if (dgvRoles.Columns[e.ColumnIndex].Name == "btnInhabilitar")
                {
                    Rol objRol = (Rol)dgvRoles.Rows[e.RowIndex].DataBoundItem;

                    if (objRol.Estado)
                    {
                        this.InhabilitarRol((Rol)dgvRoles.Rows[e.RowIndex].DataBoundItem);
                    }
                    else
                    {
                        this.HabilitarRol((Rol)dgvRoles.Rows[e.RowIndex].DataBoundItem);
                    }
                    
                    this.CargarListado();
                }
            }
        }

        private void EditarRol(Rol objRol)
        {
            frmFuncionalidades frmFunc = new frmFuncionalidades();
            frmFunc.objRol = objRol;
            frmFunc.ShowDialog();

            
        }

        private void HabilitarRol(Rol objRol)
        {
            if (MessageBox.Show("Está seguro que desea HABILITAR este rol?", "Habilitar rol", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                objRol.HabilitarRol();
            }
        }
        
        private void InhabilitarRol(Rol objRol)
        {
            this.InhabilitarRol(objRol, false);
        }

        private void InhabilitarRol(Rol objRol, bool forzar)
        {
            if (forzar)
            {
                Int16 retvalue = objRol.InhabilitarRol(true);
                if (retvalue == 0)
                {
                    //Nada, que continue y recargue
                }
                else
                {
                    MessageBox.Show("Error deshabilitando rol", "Deshabilitar rol");
                }
            }
            else
            {
                if (MessageBox.Show("Está seguro que desea DESHABILITAR este rol?", "Deshabilitar rol", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Int16 retvalue = objRol.InhabilitarRol();

                    switch (retvalue)
                    {
                        case 0:
                            {
                                //Nada, que continue y recargue
                                break;
                            }
                        case 1:
                            {
                                if (MessageBox.Show("Aún hay usuarios con el rol a deshabilitar. Si continúa se deshabilitaran también dichos usuarios. Desea continuar?", "Deshabilitar rol", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    this.InhabilitarRol(objRol, true);
                                }
                                break;
                            }
                        default:
                            {
                                MessageBox.Show("Error deshabilitando rol");
                                break;
                            }

                    }
                }
            }
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmFuncionalidades frmFunc = new frmFuncionalidades();
            frmFunc.ShowDialog();

            CargarListado();
        }

        private void dgvRoles_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == this.dgvRoles.Columns["btnInhabilitar"].Index)
            {
                
                if (((List<Rol>)dgvRoles.DataSource).ElementAt(e.RowIndex).Estado == false)
                {
                    e.Value = "Habilitar";
                }
                else
                {
                    e.Value = "Deshabilitar";
                }

            }
            else if (e.ColumnIndex == this.dgvRoles.Columns["colEstado"].Index)
            {
                
                if (((List<Rol>)dgvRoles.DataSource).ElementAt(e.RowIndex).Estado == true)
                {
                    e.Value = "Habilitado";
                }
                else
                {
                    e.Value = "Deshabilitado";
                }
            }
            else if (e.ColumnIndex == this.dgvRoles.Columns["btnEditar"].Index)
            {
                e.Value = "Editar";
            }
        }
    }
}
