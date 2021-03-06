﻿namespace GrouponDesktop.UI
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUsername = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarClaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrativoStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMProveedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMRolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.facturacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.publicarCuponesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoEstadisticoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarCreditoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comprarCuponToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comprarGiftcardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verHistorialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pedirDevoluciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedoresStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.armarCupónToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarConsumoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblUsername});
            this.statusStrip1.Location = new System.Drawing.Point(0, 141);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(400, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.Stretch = false;
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(94, 17);
            this.toolStripStatusLabel1.Text = "Usuario logueado:";
            // 
            // lblUsername
            // 
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(11, 17);
            this.lblUsername.Text = "-";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.administrativoStripMenuItem,
            this.clientesStripMenuItem,
            this.proveedoresStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(400, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cambiarClaveToolStripMenuItem,
            this.toolStripSeparator1,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // cambiarClaveToolStripMenuItem
            // 
            this.cambiarClaveToolStripMenuItem.Name = "cambiarClaveToolStripMenuItem";
            this.cambiarClaveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cambiarClaveToolStripMenuItem.Text = "Cambiar clave";
            this.cambiarClaveToolStripMenuItem.Click += new System.EventHandler(this.cambiarClaveToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // administrativoStripMenuItem
            // 
            this.administrativoStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aBMClienteToolStripMenuItem,
            this.aBMProveedorToolStripMenuItem,
            this.aBMRolToolStripMenuItem,
            this.facturacionToolStripMenuItem,
            this.publicarCuponesToolStripMenuItem,
            this.listadoEstadisticoToolStripMenuItem});
            this.administrativoStripMenuItem.Name = "administrativoStripMenuItem";
            this.administrativoStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.administrativoStripMenuItem.Text = "Administrativo";
            // 
            // aBMClienteToolStripMenuItem
            // 
            this.aBMClienteToolStripMenuItem.Name = "aBMClienteToolStripMenuItem";
            this.aBMClienteToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.aBMClienteToolStripMenuItem.Text = "ABM Cliente";
            this.aBMClienteToolStripMenuItem.Click += new System.EventHandler(this.aBMClienteToolStripMenuItem_Click);
            // 
            // aBMProveedorToolStripMenuItem
            // 
            this.aBMProveedorToolStripMenuItem.Name = "aBMProveedorToolStripMenuItem";
            this.aBMProveedorToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.aBMProveedorToolStripMenuItem.Text = "ABM Proveedor";
            this.aBMProveedorToolStripMenuItem.Click += new System.EventHandler(this.aBMProveedorToolStripMenuItem_Click);
            // 
            // aBMRolToolStripMenuItem
            // 
            this.aBMRolToolStripMenuItem.Name = "aBMRolToolStripMenuItem";
            this.aBMRolToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.aBMRolToolStripMenuItem.Text = "ABM Rol";
            this.aBMRolToolStripMenuItem.Click += new System.EventHandler(this.aBMRolToolStripMenuItem_Click);
            // 
            // facturacionToolStripMenuItem
            // 
            this.facturacionToolStripMenuItem.Name = "facturacionToolStripMenuItem";
            this.facturacionToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.facturacionToolStripMenuItem.Text = "Facturar proveedores";
            this.facturacionToolStripMenuItem.Click += new System.EventHandler(this.facturacionToolStripMenuItem_Click);
            // 
            // publicarCuponesToolStripMenuItem
            // 
            this.publicarCuponesToolStripMenuItem.Name = "publicarCuponesToolStripMenuItem";
            this.publicarCuponesToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.publicarCuponesToolStripMenuItem.Text = "Publicar cupones";
            this.publicarCuponesToolStripMenuItem.Click += new System.EventHandler(this.publicarCuponesToolStripMenuItem_Click);
            // 
            // listadoEstadisticoToolStripMenuItem
            // 
            this.listadoEstadisticoToolStripMenuItem.Name = "listadoEstadisticoToolStripMenuItem";
            this.listadoEstadisticoToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.listadoEstadisticoToolStripMenuItem.Text = "Listado estadistico";
            this.listadoEstadisticoToolStripMenuItem.Click += new System.EventHandler(this.listadoEstadisticoToolStripMenuItem_Click);
            // 
            // clientesStripMenuItem
            // 
            this.clientesStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cargarCreditoToolStripMenuItem,
            this.comprarCuponToolStripMenuItem,
            this.comprarGiftcardToolStripMenuItem,
            this.verHistorialToolStripMenuItem,
            this.pedirDevoluciónToolStripMenuItem});
            this.clientesStripMenuItem.Name = "clientesStripMenuItem";
            this.clientesStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.clientesStripMenuItem.Text = "Clientes";
            // 
            // cargarCreditoToolStripMenuItem
            // 
            this.cargarCreditoToolStripMenuItem.Name = "cargarCreditoToolStripMenuItem";
            this.cargarCreditoToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.cargarCreditoToolStripMenuItem.Text = "Cargar crédito";
            this.cargarCreditoToolStripMenuItem.Click += new System.EventHandler(this.cargarCreditoToolStripMenuItem_Click);
            // 
            // comprarCuponToolStripMenuItem
            // 
            this.comprarCuponToolStripMenuItem.Name = "comprarCuponToolStripMenuItem";
            this.comprarCuponToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.comprarCuponToolStripMenuItem.Text = "Comprar cupón";
            this.comprarCuponToolStripMenuItem.Click += new System.EventHandler(this.comprarCuponToolStripMenuItem_Click);
            // 
            // comprarGiftcardToolStripMenuItem
            // 
            this.comprarGiftcardToolStripMenuItem.Name = "comprarGiftcardToolStripMenuItem";
            this.comprarGiftcardToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.comprarGiftcardToolStripMenuItem.Text = "Comprar giftcard";
            this.comprarGiftcardToolStripMenuItem.Click += new System.EventHandler(this.comprarGiftcardToolStripMenuItem_Click);
            // 
            // verHistorialToolStripMenuItem
            // 
            this.verHistorialToolStripMenuItem.Name = "verHistorialToolStripMenuItem";
            this.verHistorialToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.verHistorialToolStripMenuItem.Text = "Ver historial";
            this.verHistorialToolStripMenuItem.Click += new System.EventHandler(this.verHistorialToolStripMenuItem_Click);
            // 
            // pedirDevoluciónToolStripMenuItem
            // 
            this.pedirDevoluciónToolStripMenuItem.Name = "pedirDevoluciónToolStripMenuItem";
            this.pedirDevoluciónToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.pedirDevoluciónToolStripMenuItem.Text = "Pedir devolución";
            this.pedirDevoluciónToolStripMenuItem.Click += new System.EventHandler(this.pedirDevoluciónToolStripMenuItem_Click);
            // 
            // proveedoresStripMenuItem
            // 
            this.proveedoresStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.armarCupónToolStripMenuItem1,
            this.registrarConsumoToolStripMenuItem});
            this.proveedoresStripMenuItem.Name = "proveedoresStripMenuItem";
            this.proveedoresStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.proveedoresStripMenuItem.Text = "Proveedores";
            // 
            // armarCupónToolStripMenuItem1
            // 
            this.armarCupónToolStripMenuItem1.Name = "armarCupónToolStripMenuItem1";
            this.armarCupónToolStripMenuItem1.Size = new System.Drawing.Size(174, 22);
            this.armarCupónToolStripMenuItem1.Text = "Armar Cupón";
            this.armarCupónToolStripMenuItem1.Click += new System.EventHandler(this.armarCupónToolStripMenuItem1_Click);
            // 
            // registrarConsumoToolStripMenuItem
            // 
            this.registrarConsumoToolStripMenuItem.Name = "registrarConsumoToolStripMenuItem";
            this.registrarConsumoToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.registrarConsumoToolStripMenuItem.Text = "Registrar consumo";
            this.registrarConsumoToolStripMenuItem.Click += new System.EventHandler(this.registrarConsumoToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 163);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Cuponete Orion";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarClaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem administrativoStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMProveedorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMRolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem facturacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proveedoresStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem publicarCuponesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listadoEstadisticoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargarCreditoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comprarCuponToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem armarCupónToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem registrarConsumoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comprarGiftcardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verHistorialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pedirDevoluciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblUsername;
    }
}

