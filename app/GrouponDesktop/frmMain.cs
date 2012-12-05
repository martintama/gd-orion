using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GrouponDesktop
{
    public partial class frmMain : Form
    {
        public frmLogin parentLogin;

        public frmMain()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OcultarMenues()
        {
            administrativoStripMenuItem.Visible = false;
            clientesStripMenuItem.Visible = false;
            proveedoresStripMenuItem.Visible = false;

            aBMClienteToolStripMenuItem.Visible = false;
            aBMProveedorToolStripMenuItem.Visible = false;
            aBMRolToolStripMenuItem.Visible = false;

            facturacionToolStripMenuItem.Visible = false;
            publicarCuponesToolStripMenuItem.Visible = false;
            listadoEstadisticoToolStripMenuItem.Visible = false;

            armarCupónToolStripMenuItem1.Visible = false;
            registrarConsumoToolStripMenuItem.Visible = false;

            cargarCreditoToolStripMenuItem.Visible = false;
            comprarCuponToolStripMenuItem.Visible = false;
            comprarGiftcardToolStripMenuItem.Visible = false;
            verHistorialToolStripMenuItem.Visible = false;
            pedirDevoluciónToolStripMenuItem.Visible = false;

            editarUsuarioToolStripMenuItem.Visible = false;
        }
        private void CargarMenues()
        {
            InfoSesion objInfo = clsMain.objInfoSesion;

            foreach(clsMain.Funcionalidades func in clsMain.objInfoSesion.Funcionalidades){
                switch (func)
                {
                    case clsMain.Funcionalidades.ABM_Cliente:
                        {
                            administrativoStripMenuItem.Visible = true;
                            aBMClienteToolStripMenuItem.Visible = true;
                            break;
                        }
                    case clsMain.Funcionalidades.ABM_Proveedor:
                        {
                            administrativoStripMenuItem.Visible = true;
                            aBMProveedorToolStripMenuItem.Visible = true;
                            break;
                        }
                    case clsMain.Funcionalidades.ABM_Rol:
                        {
                            administrativoStripMenuItem.Visible = true;
                            aBMRolToolStripMenuItem.Visible = true;
                            break;
                        }
                    case clsMain.Funcionalidades.Armar_Cupon:
                        {
                            proveedoresStripMenuItem.Visible = true;
                            armarCupónToolStripMenuItem1.Visible = true;
                            break;
                        }
                    case clsMain.Funcionalidades.Cargar_Credito:
                        {
                            clientesStripMenuItem.Visible = true;
                            cargarCreditoToolStripMenuItem.Visible = true;
                            break;
                        }
                    case clsMain.Funcionalidades.Comprar_Cupon:
                        {
                            clientesStripMenuItem.Visible = true;
                            comprarCuponToolStripMenuItem.Visible = true;
                            break;
                        }
                    case clsMain.Funcionalidades.Comprar_GiftCard:
                        {
                            clientesStripMenuItem.Visible = true;
                            comprarGiftcardToolStripMenuItem.Visible = true;
                            break;
                        }
                    case clsMain.Funcionalidades.Facturacion_Proveedores:
                        {
                            administrativoStripMenuItem.Visible = true;
                            facturacionToolStripMenuItem.Visible = true;
                            break;
                        }
                    case clsMain.Funcionalidades.Historial_Compra:
                        {
                            clientesStripMenuItem.Visible = true;
                            verHistorialToolStripMenuItem.Visible = true;
                            break;
                        }
                    case clsMain.Funcionalidades.Listado_Estadístico:
                        {
                            administrativoStripMenuItem.Visible = true;
                            listadoEstadisticoToolStripMenuItem.Visible = true;
                            break;
                        }
                    case clsMain.Funcionalidades.Pedir_Devolucion:
                        {
                            clientesStripMenuItem.Visible = true;
                            pedirDevoluciónToolStripMenuItem.Visible = true;
                            break;
                        }
                    case clsMain.Funcionalidades.Publicar_Cupon:
                        {
                            administrativoStripMenuItem.Visible = true;
                            publicarCuponesToolStripMenuItem.Visible = true;
                            break;
                        }
                    case clsMain.Funcionalidades.Registro_Consumo_cupon:
                        {
                            proveedoresStripMenuItem.Visible = true;
                            registrarConsumoToolStripMenuItem.Visible = true;
                            break;
                        }
                    case clsMain.Funcionalidades.Registro_Usuario:
                        {
                            editarUsuarioToolStripMenuItem.Visible = true;
                            break;
                        }
                }
            }
            
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            OcultarMenues();
            CargarMenues();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            clsMain.objInfoSesion = null;

            frmLogin frm;
            if (this.parentLogin != null)
            {
                frm = this.parentLogin;
            }
            else
            {
                frm = new frmLogin();
            }

            frm.ShowDialog();
        }
    }
}
