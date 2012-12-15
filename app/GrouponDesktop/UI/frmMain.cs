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

            cambiarClaveToolStripMenuItem.Visible = true;
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
                }
            }
            
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ChequearSolicitarDatos();
            OcultarMenues();
            CargarMenues();
            this.lblUsername.Text = Sesion.GetUsuarioAsociado().Username;
        }

        private void ChequearSolicitarDatos()
        {
            //Si me piden los datos para completar nuevamente, cuando un administrativo me cambia el rol
            //Si es cliente
            if (Sesion.Idtipo_usuario == 2)
            {
                if (((Cliente)Sesion.EntidadLogueada).SolicitarDatos)
                {
                    MessageBox.Show("Su rol ha sido modificado por un administrador. Debe completar nuevamente sus datos");
                    AbmCliente.frmAbmCliente oFrm = new GrouponDesktop.UI.AbmCliente.frmAbmCliente();
                    oFrm.tipoOperacion = GrouponDesktop.UI.AbmCliente.frmAbmCliente.TipoOperacion.Edicion_Cliente;
                    oFrm.objCliente = (Cliente)Sesion.EntidadLogueada;
                    oFrm.ShowDialog();
                }
            }
            else if (Sesion.Idtipo_usuario == 3) //O proveedor
            {
                if (((Proveedor)Sesion.EntidadLogueada).SolicitarDatos)
                {
                    MessageBox.Show("Su rol ha sido modificado por un administrador. Debe completar nuevamente sus datos");
                    AbmProveedor.frmAbmProveedor oFrm = new GrouponDesktop.UI.AbmProveedor.frmAbmProveedor();
                    oFrm.tipoOperacion = GrouponDesktop.UI.AbmProveedor.frmAbmProveedor.TipoOperacion.Edicion_Cliente;
                    oFrm.elProveedor = (Proveedor)Sesion.EntidadLogueada;
                    oFrm.ShowDialog();
                }
            }

            
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

            if (Sesion.Idtipo_usuario == 1)
            {
                AbmRol.frmAbmRol frmRol = new AbmRol.frmAbmRol();
                frmRol.ShowDialog();
            }
            else
            {
                MessageBox.Show("Para utilizar esta funcionalidad debe ser un ADMINISTRATIVO");
            }

        }

        private void aBMClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Sesion.Idtipo_usuario == 1)
            {
                frmBuscarCliente frmCliente = new frmBuscarCliente();
                frmCliente.ShowDialog();
            }
            else
            {
                MessageBox.Show("Para utilizar esta funcionalidad debe ser un ADMINISTRATIVO");
            }
        }

        private void aBMProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Sesion.Idtipo_usuario == 1)
            {
                frmBuscarProveedor frmProveedor = new frmBuscarProveedor();
                frmProveedor.ShowDialog();
            }
            else
            {
                MessageBox.Show("Para utilizar esta funcionalidad debe ser un ADMINISTRATIVO");
            }

        }

        private void facturacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (Sesion.Idtipo_usuario == 1)
            {
                FacturarProveedor.frmFacturarProveedor frmFacturar = new FacturarProveedor.frmFacturarProveedor();
                frmFacturar.ShowDialog();
            }
            else
            {
                MessageBox.Show("Para utilizar esta funcionalidad debe ser un ADMINISTRATIVO");
            }
        }

        private void publicarCuponesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (Sesion.Idtipo_usuario == 1)
            {
                PublicarCupon.frmPublicarCupon frmPublicar = new PublicarCupon.frmPublicarCupon();
                frmPublicar.ShowDialog();
            }
            else
            {
                MessageBox.Show("Para utilizar esta funcionalidad debe ser un ADMINISTRATIVO");
            }
        }

        private void listadoEstadisticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Sesion.Idtipo_usuario == 1)
            {
                ListadoEstadistico.frmListadoEstadistico frmListado = new ListadoEstadistico.frmListadoEstadistico();
                frmListado.ShowDialog();

            }
            else
            {
                MessageBox.Show("Para utilizar esta funcionalidad debe ser un ADMINISTRATIVO");
            }
        }

        private void cargarCreditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Sesion.Idtipo_usuario == 2)
            {
                if (Sesion.GetUsuarioAsociado().Habilitado)
                {
                    CargaCredito.frmCargarCredito frmCargar = new CargaCredito.frmCargarCredito();
                    frmCargar.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Su usuario ha sido inhabilitado y no puede acceder a esta funcionalidad. Por favor contactese con el administrador", "Usuario inhabilitado");
                }
            }
            else
            {
                MessageBox.Show("Para utilizar esta funcionalidad debe ser un CLIENTE");
            }
        }

        private void comprarCuponToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Sesion.Idtipo_usuario == 2)
            {
                if (Sesion.GetUsuarioAsociado().Habilitado)
                {
                    ComprarCupon.frmComprarCupon frmComprar = new ComprarCupon.frmComprarCupon();
                    frmComprar.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Su usuario ha sido inhabilitado y no puede acceder a esta funcionalidad. Por favor contactese con el administrador", "Usuario inhabilitado");
                }
            }
            else
            {
                MessageBox.Show("Para utilizar esta funcionalidad debe ser un CLIENTE");
            }
           
        }

        private void comprarGiftcardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Sesion.Idtipo_usuario == 2)
            {
                if (Sesion.GetUsuarioAsociado().Habilitado)
                {
                    ComprarGiftCard.frmComprarGiftCard frmComprarGift = new ComprarGiftCard.frmComprarGiftCard();
                    frmComprarGift.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Su usuario ha sido inhabilitado y no puede acceder a esta funcionalidad. Por favor contactese con el administrador", "Usuario inhabilitado");
                }
            }
            else
            {
                MessageBox.Show("Para utilizar esta funcionalidad debe ser un CLIENTE");
            }
            
        }

        private void verHistorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            if (Sesion.Idtipo_usuario == 2)
            {
                HistorialCupones.frmHistorialCupones frmHistorial = new HistorialCupones.frmHistorialCupones();
                frmHistorial.ShowDialog();
            }
            else
            {
                MessageBox.Show("Para utilizar esta funcionalidad debe ser un CLIENTE");
            }
        }

        private void pedirDevoluciónToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (Sesion.Idtipo_usuario == 2)
            {
                if (Sesion.GetUsuarioAsociado().Habilitado)
                {
                    PedirDevolucion.frmPedirDevolucion frmDevolucion = new PedirDevolucion.frmPedirDevolucion();
                    frmDevolucion.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Su usuario ha sido inhabilitado y no puede acceder a esta funcionalidad. Por favor contactese con el administrador", "Usuario inhabilitado");
                }
            }
            else
            {
                MessageBox.Show("Para utilizar esta funcionalidad debe ser un CLIENTE");
            }
        }

        private void armarCupónToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Sesion.Idtipo_usuario == 3)
            {
                if (Sesion.GetUsuarioAsociado().Habilitado)
                {
                    ArmarCupon.frmArmarCupon frmArmarCupon = new ArmarCupon.frmArmarCupon();
                    frmArmarCupon.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Su usuario ha sido inhabilitado y no puede acceder a esta funcionalidad. Por favor contactese con el administrador", "Usuario inhabilitado");
                }
            }
            else
            {
                MessageBox.Show("Para utilizar esta funcionalidad debe ser un PROVEEDOR");
            }
        }

        private void registrarConsumoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Sesion.Idtipo_usuario == 3)
            {
                if (Sesion.GetUsuarioAsociado().Habilitado)
                {
                    RegistroConsumoCupon.frmRegistroConsumo frmConsumo = new RegistroConsumoCupon.frmRegistroConsumo();
                    frmConsumo.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Su usuario ha sido inhabilitado y no puede acceder a esta funcionalidad. Por favor contactese con el administrador", "Usuario inhabilitado");
                }
            }
            else
            {
                MessageBox.Show("Para utilizar esta funcionalidad debe ser un PROVEEDOR");
            }
            
        }


        private void cambiarClaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCambiarPassword frmPassword = new frmCambiarPassword();
            frmPassword.ShowDialog();
        }

    }
}
