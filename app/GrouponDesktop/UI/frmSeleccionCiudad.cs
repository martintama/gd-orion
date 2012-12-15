using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GrouponDesktop.Base;
using GrouponDesktop.UI.AbmCliente;
using System.Data.SqlClient;

namespace GrouponDesktop
{
    public partial class frmSeleccionCiudad : Form
    {
        //Recibe la lista en la que hay que cargar las ciudades (la del parent)
        public List<Ciudad> listaCiudadesParent;

        private List<Ciudad> listaCiudadesDisponibles;

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

                    if (lstSeleccionadas.Items.Count > 0)
                    {
                        lstSeleccionadas.SelectedIndex = 0;
                    }

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

                    if (lstDisponibles.Items.Count > 0)
                    {
                        lstDisponibles.SelectedIndex = 0;
                    }

                }
                btnGuardar.Enabled = true;
            }
        }

        private void frmSeleccionCiudad_Load(object sender, EventArgs e)
        {
            this.CargarListas();
        }

        private void CargarListas()
        {
            lstSeleccionadas.Items.Clear();
            lstDisponibles.Items.Clear();

            foreach (Ciudad item in listaCiudadesParent)
            {
                lstSeleccionadas.Items.Add(item);
            }

            try
            {
                //Cargo todas las ciudades y luego saco las ciudades que ya están-
                listaCiudadesDisponibles = Ciudad.getListaCiudades(this.listaCiudadesParent);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ha ocurrido un error: " + ex.Message + ". El programa se cerrará.");
                Application.Exit();
            }
            foreach (Ciudad item in listaCiudadesDisponibles)
            {
                lstDisponibles.Items.Add(item);
            }

        }

        private void AplicarCambios()
        {
            listaCiudadesParent.Clear();
            
            foreach (Ciudad item in lstSeleccionadas.Items)
            {
                listaCiudadesParent.Add(item);
            }

            btnGuardar.Enabled = false;
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.AplicarCambios();
            this.Close();
            this.Dispose();
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

