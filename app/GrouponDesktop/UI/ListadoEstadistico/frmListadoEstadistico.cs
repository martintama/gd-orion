using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GrouponDesktop.Base;

namespace GrouponDesktop.UI.ListadoEstadistico
{
    public partial class frmListadoEstadistico : Form
    {
        Estadistica unaEstadistica;

        public frmListadoEstadistico()
        {
            InitializeComponent();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            dgvDatos.Columns.Clear();
            dgvDatos.AutoGenerateColumns = false;

            unaEstadistica = new Estadistica();
            unaEstadistica.Anio = Convert.ToInt16(nudAnio.Value);
            unaEstadistica.Semestre = Convert.ToInt16(nudSemestre.Value);

            if (rdoDevoluciones.Checked)
                unaEstadistica.Tipo = Estadistica.TipoEstadistica.Devoluciones;
            else
                unaEstadistica.Tipo = Estadistica.TipoEstadistica.GiftCards;

            //No se necesita verificar nada porque los controles ya están limitados
            if (rdoDevoluciones.Checked)
            {
                //Saco el informe de devoluciones
                this.GenerarColumnasListadoDevoluciones();
            }
            else
            {
                this.GenerarColumnasListadoGiftCards();
            }

            dgvDatos.DataSource = unaEstadistica.GetEstadisticas();
            lblCantidad.Text = dgvDatos.Rows.Count.ToString();
        }

        private void GenerarColumnasListadoGiftCards()
        {
            //Simple fila "contadora"
            DataGridViewTextBoxColumn colIndice = new DataGridViewTextBoxColumn();
            colIndice.Name = "colIndice";
            colIndice.HeaderText = "Nº";
            colIndice.Width = 20;
            this.dgvDatos.Columns.Add(colIndice);

            //Usuario (Nombre, Apellido)
            DataGridViewTextBoxColumn colNombreApellido = new DataGridViewTextBoxColumn();
            colNombreApellido.Name = "colNombreApellido";
            colNombreApellido.HeaderText = "Cliente";
            colNombreApellido.Width = 20;
            this.dgvDatos.Columns.Add(colNombreApellido);

            //DNI
            DataGridViewTextBoxColumn colDni = new DataGridViewTextBoxColumn();
            colDni.Name = "colDni";
            colDni.HeaderText = "DNI";
            colDni.Width = 20;
            this.dgvDatos.Columns.Add(colDni);

            //Total giftcards recibidos
            DataGridViewTextBoxColumn colRecibidos = new DataGridViewTextBoxColumn();
            colRecibidos.Name = "colRecibidos";
            colRecibidos.HeaderText = "Recibidos";
            colRecibidos.Width = 20;
            this.dgvDatos.Columns.Add(colRecibidos);

            //Monto recibido
            DataGridViewTextBoxColumn colMonto = new DataGridViewTextBoxColumn();
            colMonto.Name = "colMonto";
            colMonto.HeaderText = "Monto recibido";
            colMonto.Width = 20;
            this.dgvDatos.Columns.Add(colMonto);

            

        }

        private void GenerarColumnasListadoDevoluciones()
        {
            //Simple fila "contadora"
            DataGridViewTextBoxColumn colIndice = new DataGridViewTextBoxColumn();
            colIndice.Name = "colIndice";
            colIndice.HeaderText = "Nº";
            colIndice.Width = 20;
            this.dgvDatos.Columns.Add(colIndice);

            //Razon Social
            DataGridViewTextBoxColumn colProveedor = new DataGridViewTextBoxColumn();
            colProveedor.Name = "colProveedor";
            colProveedor.HeaderText = "Proveedor";
            colProveedor.Width = 60;
            this.dgvDatos.Columns.Add(colProveedor);

            //CUIT
            DataGridViewTextBoxColumn colCuit = new DataGridViewTextBoxColumn();
            colCuit.Name = "colCuit";
            colCuit.HeaderText = "Proveedor";
            colCuit.Width = 60;
            this.dgvDatos.Columns.Add(colCuit);

            //Total de cupones vendidos
            DataGridViewTextBoxColumn colTotal = new DataGridViewTextBoxColumn();
            colTotal.Name = "colTotal";
            colTotal.HeaderText = "Total vendido";
            colTotal.Width = 60;
            this.dgvDatos.Columns.Add(colTotal);

            //Total de cupones devueltos
            DataGridViewTextBoxColumn colDevoluciones = new DataGridViewTextBoxColumn();
            colDevoluciones.Name = "colDevoluciones";
            colDevoluciones.HeaderText = "Devoluciones";
            colDevoluciones.Width = 60;
            this.dgvDatos.Columns.Add(colDevoluciones);

            //Monto total devuelto
            DataGridViewTextBoxColumn colMonto = new DataGridViewTextBoxColumn();
            colMonto.Name = "colDevoluciones";
            colMonto.HeaderText = "Monto devuelto";
            colMonto.Width = 60;
            this.dgvDatos.Columns.Add(colMonto);

            //Porcentaje
            DataGridViewTextBoxColumn colPorcentaje = new DataGridViewTextBoxColumn();
            colPorcentaje.Name = "colPorcentaje";
            colPorcentaje.HeaderText = "Porcentaje";
            colPorcentaje.Width = 60;
            this.dgvDatos.Columns.Add(colPorcentaje);

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            nudAnio.Value = 2000;
            nudSemestre.Value = 1;

            dgvDatos.Rows.Clear();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        
    }
}
