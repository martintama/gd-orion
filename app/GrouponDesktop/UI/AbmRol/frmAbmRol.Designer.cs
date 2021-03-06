﻿namespace GrouponDesktop.UI.AbmRol
{
    partial class frmAbmRol
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvRoles = new System.Windows.Forms.DataGridView();
            this.colNombreRol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkAdministrativo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEditar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnInhabilitar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colIdrol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hdnColEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtRol = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.label27 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(475, 295);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(12, 79);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "Agregar rol";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Roles en sistema";
            // 
            // dgvRoles
            // 
            this.dgvRoles.AllowUserToAddRows = false;
            this.dgvRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNombreRol,
            this.colEstado,
            this.chkAdministrativo,
            this.chkCliente,
            this.chkProveedor,
            this.btnEditar,
            this.btnInhabilitar,
            this.colIdrol,
            this.hdnColEstado});
            this.dgvRoles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvRoles.Location = new System.Drawing.Point(16, 125);
            this.dgvRoles.MultiSelect = false;
            this.dgvRoles.Name = "dgvRoles";
            this.dgvRoles.ReadOnly = true;
            this.dgvRoles.RowHeadersVisible = false;
            this.dgvRoles.Size = new System.Drawing.Size(534, 164);
            this.dgvRoles.TabIndex = 8;
            this.dgvRoles.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvRoles_CellFormatting);
            this.dgvRoles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRoles_CellContentClick);
            // 
            // colNombreRol
            // 
            this.colNombreRol.DataPropertyName = "NombreRol";
            this.colNombreRol.Frozen = true;
            this.colNombreRol.HeaderText = "Nombre rol";
            this.colNombreRol.Name = "colNombreRol";
            this.colNombreRol.ReadOnly = true;
            this.colNombreRol.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colNombreRol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colNombreRol.Width = 150;
            // 
            // colEstado
            // 
            this.colEstado.Frozen = true;
            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "colEstado";
            this.colEstado.ReadOnly = true;
            this.colEstado.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colEstado.Width = 80;
            // 
            // chkAdministrativo
            // 
            this.chkAdministrativo.Frozen = true;
            this.chkAdministrativo.HeaderText = "A";
            this.chkAdministrativo.Name = "chkAdministrativo";
            this.chkAdministrativo.ReadOnly = true;
            this.chkAdministrativo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chkAdministrativo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.chkAdministrativo.Width = 20;
            // 
            // chkCliente
            // 
            this.chkCliente.Frozen = true;
            this.chkCliente.HeaderText = "C";
            this.chkCliente.Name = "chkCliente";
            this.chkCliente.ReadOnly = true;
            this.chkCliente.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chkCliente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.chkCliente.Width = 20;
            // 
            // chkProveedor
            // 
            this.chkProveedor.Frozen = true;
            this.chkProveedor.HeaderText = "P";
            this.chkProveedor.Name = "chkProveedor";
            this.chkProveedor.ReadOnly = true;
            this.chkProveedor.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chkProveedor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.chkProveedor.Width = 20;
            // 
            // btnEditar
            // 
            this.btnEditar.Frozen = true;
            this.btnEditar.HeaderText = "Editar";
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.ReadOnly = true;
            this.btnEditar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.btnEditar.Text = "Editar";
            this.btnEditar.ToolTipText = "Editar";
            this.btnEditar.Width = 80;
            // 
            // btnInhabilitar
            // 
            this.btnInhabilitar.DataPropertyName = "NombreRol";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInhabilitar.DefaultCellStyle = dataGridViewCellStyle2;
            this.btnInhabilitar.Frozen = true;
            this.btnInhabilitar.HeaderText = "Cambiar estado";
            this.btnInhabilitar.Name = "btnInhabilitar";
            this.btnInhabilitar.ReadOnly = true;
            this.btnInhabilitar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.btnInhabilitar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btnInhabilitar.Text = "Habilitar";
            this.btnInhabilitar.ToolTipText = "Cambiar estado";
            this.btnInhabilitar.Width = 110;
            // 
            // colIdrol
            // 
            this.colIdrol.DataPropertyName = "idrol";
            this.colIdrol.Frozen = true;
            this.colIdrol.HeaderText = "Idrol";
            this.colIdrol.Name = "colIdrol";
            this.colIdrol.ReadOnly = true;
            this.colIdrol.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colIdrol.Visible = false;
            // 
            // hdnColEstado
            // 
            this.hdnColEstado.DataPropertyName = "Estado";
            this.hdnColEstado.HeaderText = "EstadoNoVisible";
            this.hdnColEstado.Name = "hdnColEstado";
            this.hdnColEstado.ReadOnly = true;
            this.hdnColEstado.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.hdnColEstado.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtRol);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(13, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(537, 46);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro de roles";
            // 
            // txtRol
            // 
            this.txtRol.Location = new System.Drawing.Point(88, 17);
            this.txtRol.MaxLength = 50;
            this.txtRol.Name = "txtRol";
            this.txtRol.Size = new System.Drawing.Size(149, 20);
            this.txtRol.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nombre del rol:";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(475, 79);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrar.TabIndex = 10;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(394, 79);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 11;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(12, 4);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(98, 20);
            this.label27.TabIndex = 30;
            this.label27.Text = "ABM Roles";
            // 
            // frmAbmRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 330);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.dgvRoles);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnCerrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAbmRol";
            this.Text = "Cuponete Orion - ABM de Roles";
            this.Load += new System.EventHandler(this.frmAbmRol_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvRoles;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtRol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreRol;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn chkAdministrativo;
        private System.Windows.Forms.DataGridViewTextBoxColumn chkCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn chkProveedor;
        private System.Windows.Forms.DataGridViewButtonColumn btnEditar;
        private System.Windows.Forms.DataGridViewButtonColumn btnInhabilitar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdrol;
        private System.Windows.Forms.DataGridViewTextBoxColumn hdnColEstado;
        private System.Windows.Forms.Label label27;

    }
}