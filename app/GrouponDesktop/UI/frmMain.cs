using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GrouponDesktop.Base;

namespace GrouponDesktop.UI
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

            cargarCreditoToolStripMenuItem.Visible = true;
            comprarCuponToolStripMenuItem.Visible = false;
            comprarGiftcardToolStripMenuItem.Visible = false;
            verHistorialToolStripMenuItem.Visible = false;
            pedirDevoluciónToolStripMenuItem.Visible = false;

            cambiarClaveToolStripMenuItem.Visible = false;
        }
        private void CargarMenues()
        {
            
            Usuario usuarioAsociado = Sesion.GetUsuarioAsociado();
            foreach (Funcionalidad func in usuarioAsociado.RolAsociado.FuncHabilitadas)
            {
                switch (func.idfuncionalidad)
                {
                    
                    case 1:  //clsMain.Funcionalidades.ABM_Cliente:
                        {
                            administrativoStripMenuItem.Visible = true;
                            aBMClienteToolStripMenuItem.Visible = true;
                            break;
                        }
                    case 2: //clsMain.Funcionalidades.ABM_Proveedor:
                        {
                            administrativoStripMenuItem.Visible = true;
                            aBMProveedorToolStripMenuItem.Visible = true;
                            break;
                        }
                    case 3: //clsMain.Funcionalidades.ABM_Rol:
                        {
                            administrativoStripMenuItem.Visible = true;
                            aBMRolToolStripMenuItem.Visible = true;
                            break;
                        }
                    case 4: //clsMain.Funcionalidades.Armar_Cupon:
                        {
                            proveedoresStripMenuItem.Visible = true;
                            armarCupónToolStripMenuItem1.Visible = true;
                            break;
                        }
                    case 5: //clsMain.Funcionalidades.Cargar_Credito:
                        {
                            clientesStripMenuItem.Visible = true;
                            cargarCreditoToolStripMenuItem.Visible = true;
                            break;
                        }
                    case 6: //clsMain.Funcionalidades.Comprar_Cupon:
                        {
                            clientesStripMenuItem.Visible = true;
                            comprarCuponToolStripMenuItem.Visible = true;
                            break;
                        }
                    case 7: //clsMain.Funcionalidades.Comprar_GiftCard:
                        {
                            clientesStripMenuItem.Visible = true;
                            comprarGiftcardToolStripMenuItem.Visible = true;
                            break;
                        }
                    case 8: //clsMain.Funcionalidades.Facturacion_Proveedores:
                        {
                            administrativoStripMenuItem.Visible = true;
                            facturacionToolStripMenuItem.Visible = true;
                            break;
                        }
                    case 9: //clsMain.Funcionalidades.Historial_Compra:
                        {
                            clientesStripMenuItem.Visible = true;
                            verHistorialToolStripMenuItem.Visible = true;
                            break;
                        }
                    case 10: //clsMain.Funcionalidades.Listado_Estadístico:
                        {
                            administrativoStripMenuItem.Visible = true;
                            listadoEstadisticoToolStripMenuItem.Visible = true;
                            break;
                        }
                    case 11: //clsMain.Funcionalidades.Pedir_Devolucion:
                        {
                            clientesStripMenuItem.Visible = true;
                            pedirDevoluciónToolStripMenuItem.Visible = true;
                            break;
                        }
                    case 12: //clsMain.Funcionalidades.Publicar_Cupon:
                        {
                            administrativoStripMenuItem.Visible = true;
                            publicarCuponesToolStripMenuItem.Visible = true;
                            break;
                        }
                    case 13: //clsMain.Funcionalidades.Registro_Consumo_cupon:
                        {
                            proveedoresStripMenuItem.Visible = true;
                            registrarConsumoToolStripMenuItem.Visible = true;
                            break;
                        }
                    case 14: //clsMain.Funcionalidades.Registro_Usuario:
                        {
                            cambiarClaveToolStripMenuItem.Visible = true;
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

            Sesion.CerrarSesion();

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

        private void aBMRolToolStripMenuItem_Click(object sender, EventArgs e)
        {

            AbmRol.frmAbmRol frmRol = new AbmRol.frmAbmRol();

            frmRol.ShowDialog();
        }

        private void aBMClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmBuscarCliente frmCliente = new frmBuscarCliente();
            frmCliente.ShowDialog();

        }

        private void aBMProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBuscarProveedor frmProveedor = new frmBuscarProveedor();
            frmProveedor.ShowDialog();

        }

        private void facturacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FacturarProveedor.frmFacturarProveedor frmFacturar = new GrouponDesktop.FacturarProveedor.frmFacturarProveedor();
            frmFacturar.ShowDialog();
        }

        private void publicarCuponesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PublicarCupon.frmPublicarCupon frmPublicar = new PublicarCupon.frmPublicarCupon();
            frmPublicar.ShowDialog();
        }

        private void listadoEstadisticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListadoEstadistico.frmListadoEstadistico frmListado = new GrouponDesktop.ListadoEstadistico.frmListadoEstadistico();
            frmListado.ShowDialog();
        }

        private void cargarCreditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CargaCredito.frmCargarCredito frmCargar = new GrouponDesktop.CargaCredito.frmCargarCredito();
            frmCargar.ShowDialog();
        }

        private void comprarCuponToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComprarCupon.frmComprarCupon frmComprar = new GrouponDesktop.ComprarCupon.frmComprarCupon();
            frmComprar.ShowDialog();
        }

        private void comprarGiftcardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComprarGiftCard.frmComprarGiftCard frmComprarGift = new ComprarGiftCard.frmComprarGiftCard();
            frmComprarGift.ShowDialog();
        }

        private void verHistorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistorialCupones.frmHistorialCupones frmHistorial = new GrouponDesktop.HistorialCupones.frmHistorialCupones();
            frmHistorial.ShowDialog();
        }

        private void pedirDevoluciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PedirDevolucion.frmPedirDevolucion frmDevolucion = new GrouponDesktop.PedirDevolucion.frmPedirDevolucion();
            frmDevolucion.ShowDialog();
        }

        private void armarCupónToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ArmarCupon.frmArmarCupon frmArmarCupon = new GrouponDesktop.ArmarCupon.frmArmarCupon();
            frmArmarCupon.ShowDialog();
        }

        private void registrarConsumoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroConsumoCupon.frmRegistroConsumo frmConsumo = new GrouponDesktop.RegistroConsumoCupon.frmRegistroConsumo();
            frmConsumo.ShowDialog();
        }

    }
}
