using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GrouponDesktop.Base;
using System.Data.SqlClient;

namespace GrouponDesktop.UI.ArmarCupon
{
    public partial class frmArmarCupon : Form
    {
        Cupon elCupon = new Cupon();

        public frmArmarCupon()
        {
            InitializeComponent();
            this.LimpiarFormulario();
        }

        public Boolean VerificarDatos()
        {
            Boolean valido = true;
            Decimal precioReal = 0;
            Decimal precioFicticio = 0;
            this.ApagarAvisos();
            if (this.txtDescripcion.Text == "")
            {
                valido = false;
                lblDescripcion.Text = "* Obligatorio";
                lblDescripcion.Visible = true;
            }

            if (DateTime.Compare(this.dtpFechaPublicacion.Value, this.dtpFechaVencimientoOferta.Value) >= 0)
            {
                valido = false;
                lblFechaPublicacion.Text = "* Debe ser anterior a la de vencimiento";
                lblFechaPublicacion.Visible = true;
            }

            if (DateTime.Compare(this.dtpFechaVencimientoOferta.Value, this.dtpFechaVencimientoCanje.Value) >= 0)
            {
                valido = false;
                lblFechaVencimientoOferta.Text = "* Debe ser anterior a la de canje";
                lblFechaVencimientoOferta.Visible = true;
            }

            if (txtPrecioReal.Text == "")
            {
                valido = false;
                lblPrecioReal.Text = "* Obligatorio";
                lblPrecioReal.Visible = true;
            }
            else
            {
                Boolean numeroValido;
                
                numeroValido = Decimal.TryParse(txtPrecioReal.Text, out precioReal);

                if (!numeroValido)
                {
                    valido = false;
                    lblPrecioReal.Text = "* Número inválido.";
                    lblPrecioReal.Visible = true;
                    precioReal = 0; //Lo dejo en cero para indicar que no se pudo
                }
                else{
                    if (precioReal <= 0){
                        valido = false;
                        lblPrecioReal.Text = "* Debe ser mayor a cero";
                        lblPrecioReal.Visible = true;
                    }
                }
            }

            if (txtPrecioFicticio.Text == "")
            {
                valido = false;
                lblPrecioFicticio.Text = "* Obligatorio";
                lblPrecioFicticio.Visible = true;
            }
            else
            {
                Boolean numeroValido;
                numeroValido = Decimal.TryParse(txtPrecioFicticio.Text, out precioFicticio);

                if (!numeroValido)
                {
                    valido = false;
                    lblPrecioFicticio.Text = "* Número inválido.";
                    lblPrecioFicticio.Visible = true;
                }
                else
                {
                    if (precioFicticio <= 0)
                    {
                        valido = false;
                        lblPrecioFicticio.Text = "* Debe ser mayor a cero";
                        lblPrecioFicticio.Visible = true;
                    }
                    else
                    {
                        if (precioReal > 0 && precioReal > precioFicticio) //Si el precio real era valido
                        {
                            valido = false;
                            lblPrecioFicticio.Text = "* Debe ser mayor o igual al real";
                            lblPrecioFicticio.Visible = true;
                        }
                    }
                }
            }

            if (txtStock.Value == 0)
            {
                valido = false;
                lblStock.Text = "* Debe ser mayor a cero";
                lblStock.Visible = true;
            }

            if (txtMaxCliente.Value == 0)
            {
                valido = false;
                lblMaxCliente.Text = "* Debe ser mayor a cero";
                lblMaxCliente.Visible = true;
            }
            else
            {
                if (txtMaxCliente.Value > txtStock.Value)
                {
                    valido = false;
                    lblMaxCliente.Text = "* No puede ser mayor al stock de cupones";
                    lblMaxCliente.Visible = true;
                }
            }

            if (this.elCupon.ListaCiudades.Count == 0)
            {
                valido = false;
                lblZonas.Text = "* Seleccione alguna zona";
                lblZonas.Visible = true;
            }

            if (!valido)
            {
                lblMensaje.Text = "Errores detectados. Debe solucionarlos para continuar";
                lblMensaje.Visible = true;
            }
            return valido;
            
        }

        private void ApagarAvisos()
        {
            this.lblDescripcion.Visible = false;
            this.lblFechaPublicacion.Visible = false;
            this.lblFechaVencimientoCanje.Visible = false;
            this.lblFechaVencimientoOferta.Visible = false;
            this.lblPrecioReal.Visible = false;
            this.lblPrecioFicticio.Visible = false;
            this.lblStock.Visible = false;
            this.lblMaxCliente.Visible = false;
            this.lblZonas.Visible = false;
            this.lblMensaje.Visible = false;
        }

        private void LimpiarFormulario()
        {
            txtDescripcion.Text = "";
            dtpFechaPublicacion.Value = Sesion.ConfigApp.FechaActual;
            dtpFechaVencimientoCanje.Value = Sesion.ConfigApp.FechaActual;
            dtpFechaVencimientoOferta.Value = Sesion.ConfigApp.FechaActual;
            txtPrecioReal.Text = "";
            txtPrecioFicticio.Text = "";
            txtStock.Value = 0;
            txtMaxCliente.Value = 0;
            txtZonas.Text = "";

            this.elCupon = new Cupon();
        }

        private void Grabar()
        {
            try
            {
                this.elCupon.ProveedorAsoaciado.Idproveedor = ((Proveedor)Sesion.EntidadLogueada).Idproveedor;
                this.elCupon.Descripcion = txtDescripcion.Text;
                this.elCupon.FechaAlta = Sesion.ConfigApp.FechaActual;
                this.elCupon.FechaPublicacion = this.dtpFechaPublicacion.Value;
                this.elCupon.FechaVencimiento = this.dtpFechaVencimientoOferta.Value;
                this.elCupon.FechaVencimientoCanje = this.dtpFechaVencimientoCanje.Value;
                this.elCupon.PrecioReal = Decimal.Parse(txtPrecioReal.Text);
                this.elCupon.PrecioFicticio = Decimal.Parse(txtPrecioFicticio.Text);
                this.elCupon.CantidadDisponible = Convert.ToInt16(this.txtStock.Value);
                this.elCupon.CantidadMaxUsuario = Convert.ToInt16(this.txtMaxCliente.Value);
                //La lista de ciudades ya está cargada...
                this.elCupon.Grabar();

                MessageBox.Show("Cupón generado correctamente", "Armar cupón");
                this.Close();
                this.Dispose();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ha ocurrido un error: " + ex.Message + ". El programa se cerrará.");
                Application.Exit();
            }

        }
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            frmSeleccionCiudad frmSeleccion = new frmSeleccionCiudad();
            frmSeleccion.listaCiudadesParent = this.elCupon.ListaCiudades;
            frmSeleccion.ShowDialog();

            this.CargarTextoCiudades();
        }

        private void CargarTextoCiudades()
        {
            StringBuilder strBuilder = new StringBuilder();

            foreach (Ciudad item in this.elCupon.ListaCiudades)
            {
                if (strBuilder.Length == 0)
                {
                    strBuilder.Append(item.Descripcion);
                }
                else
                {
                    strBuilder.Append(", " + item.Descripcion);
                }
            }

            txtZonas.Text = strBuilder.ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (this.VerificarDatos())
            {
                this.Grabar();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.LimpiarFormulario();
        }
    }
}
