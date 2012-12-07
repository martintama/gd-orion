using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GrouponDesktop.Logic.Global;
using GrouponDesktop.UI.AbmCliente;

namespace GrouponDesktop
{
    public partial class frmSeleccionCiudad : Form
    {
        public frmAbmCliente frmParent;

        public frmSeleccionCiudad()
        {
            InitializeComponent();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (lstSeleccionadas.SelectedItems.Count > 0)
            {
                if (lstSeleccionadas.SelectedItem != null)
                {
                    Ciudad item = (Ciudad)lstSeleccionadas.SelectedItem;

                    lstDisponibles.Items.Add(item);
                    lstSeleccionadas.Items.Remove(item);

                    //No se guardan los cambios aquí
                    //frmParent.objCliente.Ciudades.Remove(item);

                }
                btnGuardar.Enabled = true;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (lstDisponibles.SelectedItems.Count > 0)
            {
                if (lstDisponibles.SelectedItem != null)
                {
                    Ciudad item = (Ciudad)lstDisponibles.SelectedItem;

                    lstSeleccionadas.Items.Add(item);
                    lstDisponibles.Items.Remove(item);

                    //No se guardan los cambios aquí
                    //frmParent.objCliente.Ciudades.Add(item);

                }
                btnGuardar.Enabled = true;
            }
        }

        private void frmSeleccionCiudad_Load(object sender, EventArgs e)
        {

            frmParent.objCliente.GetCiudades();

            this.CargarListas();
        }

        private void CargarListas()
        {
            lstSeleccionadas.Items.Clear();
            lstDisponibles.Items.Clear();

            foreach (Ciudad item in frmParent.objCliente.Ciudades)
            {
                lstSeleccionadas.Items.Add(item);
            }

            foreach (Ciudad item in frmParent.objCliente.CiudadesDisponibles)
            {
                lstDisponibles.Items.Add(item);
            }

        }

        private void AplicarCambios()
        {
            frmParent.objCliente.Ciudades.Clear();
            foreach (Ciudad item in lstSeleccionadas.Items)
            {
                frmParent.objCliente.Ciudades.Add(item);
            }

            btnGuardar.Enabled = false;
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.AplicarCambios();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (btnGuardar.Enabled)
            {
                if (MessageBox.Show("No se han guardado los cambios. Desea guardarlos antes de cerrar?", "Guardar cambios", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.AplicarCambios();
                }
            }

            this.Close();
            this.Dispose();
        }
    }
}

