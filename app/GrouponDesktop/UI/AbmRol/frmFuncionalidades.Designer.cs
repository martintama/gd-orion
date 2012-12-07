namespace GrouponDesktop.Logic
{
    partial class frmFuncionalidades
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblHabilitadas = new System.Windows.Forms.Label();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lstDeshabilitadas = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lstHabilitadas = new System.Windows.Forms.ListBox();
            this.brnGrabar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblAsociado = new System.Windows.Forms.Label();
            this.chkAdministrativo = new System.Windows.Forms.CheckBox();
            this.chkProveedor = new System.Windows.Forms.CheckBox();
            this.chkCliente = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNombreRol = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblHabilitadas);
            this.groupBox1.Controls.Add(this.btnQuitar);
            this.groupBox1.Controls.Add(this.btnAgregar);
            this.groupBox1.Controls.Add(this.lstDeshabilitadas);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lstHabilitadas);
            this.groupBox1.Location = new System.Drawing.Point(12, 97);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(467, 293);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Listado de funcionalidades";
            // 
            // lblHabilitadas
            // 
            this.lblHabilitadas.AutoSize = true;
            this.lblHabilitadas.ForeColor = System.Drawing.Color.Red;
            this.lblHabilitadas.Location = new System.Drawing.Point(72, 20);
            this.lblHabilitadas.Name = "lblHabilitadas";
            this.lblHabilitadas.Size = new System.Drawing.Size(63, 13);
            this.lblHabilitadas.TabIndex = 10;
            this.lblHabilitadas.Text = "* Requerido";
            this.lblHabilitadas.Visible = false;
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(197, 87);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(75, 23);
            this.btnQuitar.TabIndex = 5;
            this.btnQuitar.Text = "Quitar ->";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(197, 46);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "<- Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lstDeshabilitadas
            // 
            this.lstDeshabilitadas.DisplayMember = "Descripcion";
            this.lstDeshabilitadas.FormattingEnabled = true;
            this.lstDeshabilitadas.Location = new System.Drawing.Point(288, 36);
            this.lstDeshabilitadas.Name = "lstDeshabilitadas";
            this.lstDeshabilitadas.Size = new System.Drawing.Size(170, 238);
            this.lstDeshabilitadas.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(287, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Deshabilitadas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Habilitadas";
            // 
            // lstHabilitadas
            // 
            this.lstHabilitadas.DisplayMember = "Descripcion";
            this.lstHabilitadas.FormattingEnabled = true;
            this.lstHabilitadas.Location = new System.Drawing.Point(10, 36);
            this.lstHabilitadas.Name = "lstHabilitadas";
            this.lstHabilitadas.Size = new System.Drawing.Size(170, 238);
            this.lstHabilitadas.TabIndex = 0;
            // 
            // brnGrabar
            // 
            this.brnGrabar.Enabled = false;
            this.brnGrabar.Location = new System.Drawing.Point(324, 397);
            this.brnGrabar.Name = "brnGrabar";
            this.brnGrabar.Size = new System.Drawing.Size(75, 24);
            this.brnGrabar.TabIndex = 2;
            this.brnGrabar.Text = "Grabar";
            this.brnGrabar.UseVisualStyleBackColor = true;
            this.brnGrabar.Click += new System.EventHandler(this.brnGrabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(405, 396);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 25);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cerrar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nombre:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblNombre);
            this.groupBox2.Controls.Add(this.lblAsociado);
            this.groupBox2.Controls.Add(this.chkAdministrativo);
            this.groupBox2.Controls.Add(this.chkProveedor);
            this.groupBox2.Controls.Add(this.chkCliente);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtNombreRol);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(467, 79);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos del rol:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.ForeColor = System.Drawing.Color.Red;
            this.lblNombre.Location = new System.Drawing.Point(309, 23);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(63, 13);
            this.lblNombre.TabIndex = 9;
            this.lblNombre.Text = "* Requerido";
            this.lblNombre.Visible = false;
            // 
            // lblAsociado
            // 
            this.lblAsociado.AutoSize = true;
            this.lblAsociado.ForeColor = System.Drawing.Color.Red;
            this.lblAsociado.Location = new System.Drawing.Point(393, 51);
            this.lblAsociado.Name = "lblAsociado";
            this.lblAsociado.Size = new System.Drawing.Size(63, 13);
            this.lblAsociado.TabIndex = 8;
            this.lblAsociado.Text = "* Requerido";
            this.lblAsociado.Visible = false;
            // 
            // chkAdministrativo
            // 
            this.chkAdministrativo.AutoSize = true;
            this.chkAdministrativo.Location = new System.Drawing.Point(283, 50);
            this.chkAdministrativo.Name = "chkAdministrativo";
            this.chkAdministrativo.Size = new System.Drawing.Size(91, 17);
            this.chkAdministrativo.TabIndex = 7;
            this.chkAdministrativo.Text = "Administrativo";
            this.chkAdministrativo.UseVisualStyleBackColor = true;
            this.chkAdministrativo.CheckedChanged += new System.EventHandler(this.chkAdministrativo_CheckedChanged);
            // 
            // chkProveedor
            // 
            this.chkProveedor.AutoSize = true;
            this.chkProveedor.Location = new System.Drawing.Point(178, 50);
            this.chkProveedor.Name = "chkProveedor";
            this.chkProveedor.Size = new System.Drawing.Size(75, 17);
            this.chkProveedor.TabIndex = 6;
            this.chkProveedor.Text = "Proveedor";
            this.chkProveedor.UseVisualStyleBackColor = true;
            this.chkProveedor.CheckedChanged += new System.EventHandler(this.chkProveedor_CheckedChanged);
            // 
            // chkCliente
            // 
            this.chkCliente.AutoSize = true;
            this.chkCliente.Location = new System.Drawing.Point(83, 50);
            this.chkCliente.Name = "chkCliente";
            this.chkCliente.Size = new System.Drawing.Size(58, 17);
            this.chkCliente.TabIndex = 5;
            this.chkCliente.Text = "Cliente";
            this.chkCliente.UseVisualStyleBackColor = true;
            this.chkCliente.CheckedChanged += new System.EventHandler(this.chkCliente_CheckedChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "Asociado a:";
            // 
            // txtNombreRol
            // 
            this.txtNombreRol.Location = new System.Drawing.Point(83, 19);
            this.txtNombreRol.Name = "txtNombreRol";
            this.txtNombreRol.Size = new System.Drawing.Size(211, 20);
            this.txtNombreRol.TabIndex = 0;
            this.txtNombreRol.TextChanged += new System.EventHandler(this.txtNombreRol_TextChanged);
            // 
            // frmFuncionalidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 429);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.brnGrabar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFuncionalidades";
            this.Text = "Editar rol";
            this.Load += new System.EventHandler(this.frmFuncionalidades_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.ListBox lstDeshabilitadas;
        private System.Windows.Forms.ListBox lstHabilitadas;
        private System.Windows.Forms.Button brnGrabar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtNombreRol;
        private System.Windows.Forms.CheckBox chkAdministrativo;
        private System.Windows.Forms.CheckBox chkProveedor;
        private System.Windows.Forms.CheckBox chkCliente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblAsociado;
        private System.Windows.Forms.Label lblHabilitadas;

    }
}