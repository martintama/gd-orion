﻿using System;
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
            clientesStripMenuItem.Visible = true;
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

        private void aBMRolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbmRol.frmAbmRol frmRol = new GrouponDesktop.AbmRol.frmAbmRol();

            frmRol.ShowDialog();
        }

        private void aBMClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbmCliente.frmAbmCliente frmCliente = new GrouponDesktop.AbmCliente.frmAbmCliente();
            frmCliente.ShowDialog();

        }

        private void aBMProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbmProveedor.frmAbmProveedor frmProveedor = new GrouponDesktop.AbmProveedor.frmAbmProveedor();
            frmProveedor.ShowDialog();

        }

        private void facturacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FacturarProveedor.frmFacturarProveedor frmFacturar = new GrouponDesktop.FacturarProveedor.frmFacturarProveedor();
            frmFacturar.ShowDialog();
        }

        private void publicarCuponesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PublicarCupon.frmPublicarCupon frmPublicar = new GrouponDesktop.PublicarCupon.frmPublicarCupon();
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
            ComprarGiftCard.frmComprarGiftCard frmComprarGift = new GrouponDesktop.ComprarGiftCard.frmComprarGiftCard();
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
