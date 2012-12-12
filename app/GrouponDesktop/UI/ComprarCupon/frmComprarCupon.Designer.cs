namespace GrouponDesktop.ComprarCupon
{
    partial class frmComprarCupon
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
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precionormal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnComprar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPrecioReal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtLimitePromo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPrecioFicticio = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCreditoActual = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numCantidadCompra = new System.Windows.Forms.NumericUpDown();
            this.btnReset = new System.Windows.Forms.Button();
            this.chkComprar = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblCheck = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.lblMensaje = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidadCompra)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDatos
            // 
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.descripcion,
            this.precio,
            this.precionormal,
            this.seleccionar});
            this.dgvDatos.Location = new System.Drawing.Point(11, 54);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.Size = new System.Drawing.Size(509, 180);
            this.dgvDatos.TabIndex = 1;
            this.dgvDatos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDatos_CellFormatting);
            this.dgvDatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellContentClick);
            // 
            // descripcion
            // 
            this.descripcion.DataPropertyName = "Descripcion";
            this.descripcion.Frozen = true;
            this.descripcion.HeaderText = "Descripcion";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            this.descripcion.Width = 220;
            // 
            // precio
            // 
            this.precio.DataPropertyName = "PrecioReal";
            this.precio.Frozen = true;
            this.precio.HeaderText = "Precio promocional";
            this.precio.Name = "precio";
            this.precio.ReadOnly = true;
            this.precio.Width = 65;
            // 
            // precionormal
            // 
            this.precionormal.DataPropertyName = "PrecioFicticio";
            this.precionormal.Frozen = true;
            this.precionormal.HeaderText = "Precio Normal";
            this.precionormal.Name = "precionormal";
            this.precionormal.ReadOnly = true;
            this.precionormal.Width = 65;
            // 
            // seleccionar
            // 
            this.seleccionar.Frozen = true;
            this.seleccionar.HeaderText = "Seleccionar";
            this.seleccionar.Name = "seleccionar";
            this.seleccionar.ReadOnly = true;
            this.seleccionar.Width = 90;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cupones del día de hoy para su zona: ";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(452, 505);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 4;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnComprar
            // 
            this.btnComprar.Enabled = false;
            this.btnComprar.Location = new System.Drawing.Point(371, 505);
            this.btnComprar.Name = "btnComprar";
            this.btnComprar.Size = new System.Drawing.Size(75, 23);
            this.btnComprar.TabIndex = 5;
            this.btnComprar.Text = "Comprar";
            this.btnComprar.UseVisualStyleBackColor = true;
            this.btnComprar.Click += new System.EventHandler(this.btnComprar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPrecioReal);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtLimitePromo);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtPrecioFicticio);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtDescripcion);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(18, 240);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(509, 141);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalle del cupón seleccionado";
            // 
            // txtPrecioReal
            // 
            this.txtPrecioReal.Location = new System.Drawing.Point(86, 109);
            this.txtPrecioReal.Name = "txtPrecioReal";
            this.txtPrecioReal.ReadOnly = true;
            this.txtPrecioReal.Size = new System.Drawing.Size(100, 20);
            this.txtPrecioReal.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 112);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Precio normal:";
            // 
            // txtLimitePromo
            // 
            this.txtLimitePromo.Location = new System.Drawing.Point(357, 79);
            this.txtLimitePromo.Name = "txtLimitePromo";
            this.txtLimitePromo.ReadOnly = true;
            this.txtLimitePromo.Size = new System.Drawing.Size(100, 20);
            this.txtLimitePromo.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(231, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Promoción válida hasta:";
            // 
            // txtPrecioFicticio
            // 
            this.txtPrecioFicticio.Location = new System.Drawing.Point(86, 79);
            this.txtPrecioFicticio.Name = "txtPrecioFicticio";
            this.txtPrecioFicticio.ReadOnly = true;
            this.txtPrecioFicticio.Size = new System.Drawing.Size(100, 20);
            this.txtPrecioFicticio.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Precio c/u:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(86, 20);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ReadOnly = true;
            this.txtDescripcion.Size = new System.Drawing.Size(371, 47);
            this.txtDescripcion.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Descripción: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(381, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Su crédito es de:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCreditoActual
            // 
            this.lblCreditoActual.AutoSize = true;
            this.lblCreditoActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreditoActual.Location = new System.Drawing.Point(470, 35);
            this.lblCreditoActual.Name = "lblCreditoActual";
            this.lblCreditoActual.Size = new System.Drawing.Size(57, 13);
            this.lblCreditoActual.TabIndex = 8;
            this.lblCreditoActual.Text = "$ 100.00";
            this.lblCreditoActual.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Cantidad a comprar:";
            // 
            // numCantidadCompra
            // 
            this.numCantidadCompra.Enabled = false;
            this.numCantidadCompra.Location = new System.Drawing.Point(128, 51);
            this.numCantidadCompra.Name = "numCantidadCompra";
            this.numCantidadCompra.Size = new System.Drawing.Size(54, 20);
            this.numCantidadCompra.TabIndex = 1;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(290, 505);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // chkComprar
            // 
            this.chkComprar.AutoSize = true;
            this.chkComprar.Location = new System.Drawing.Point(23, 23);
            this.chkComprar.Name = "chkComprar";
            this.chkComprar.Size = new System.Drawing.Size(154, 17);
            this.chkComprar.TabIndex = 11;
            this.chkComprar.Text = "Deseo comprar este cupón";
            this.chkComprar.UseVisualStyleBackColor = true;
            this.chkComprar.CheckedChanged += new System.EventHandler(this.chkComprar_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblCantidad);
            this.groupBox2.Controls.Add(this.lblCheck);
            this.groupBox2.Controls.Add(this.numCantidadCompra);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.chkComprar);
            this.groupBox2.Location = new System.Drawing.Point(18, 387);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(509, 85);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Compra";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.ForeColor = System.Drawing.Color.Red;
            this.lblCantidad.Location = new System.Drawing.Point(194, 53);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(50, 13);
            this.lblCantidad.TabIndex = 28;
            this.lblCantidad.Text = "* Revisar";
            this.lblCantidad.Visible = false;
            // 
            // lblCheck
            // 
            this.lblCheck.AutoSize = true;
            this.lblCheck.ForeColor = System.Drawing.Color.Red;
            this.lblCheck.Location = new System.Drawing.Point(194, 23);
            this.lblCheck.Name = "lblCheck";
            this.lblCheck.Size = new System.Drawing.Size(50, 13);
            this.lblCheck.TabIndex = 27;
            this.lblCheck.Text = "* Revisar";
            this.lblCheck.Visible = false;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(7, 9);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(131, 20);
            this.label27.TabIndex = 30;
            this.label27.Text = "Comprar cupón";
            // 
            // lblMensaje
            // 
            this.lblMensaje.ForeColor = System.Drawing.Color.Red;
            this.lblMensaje.Location = new System.Drawing.Point(15, 475);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(512, 27);
            this.lblMensaje.TabIndex = 29;
            this.lblMensaje.Text = "Revisar";
            this.lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMensaje.Visible = false;
            // 
            // frmComprarCupon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 540);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.btnComprar);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.lblCreditoActual);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDatos);
            this.Name = "frmComprarCupon";
            this.Text = "Cuponete Orion - Comprar cupón";
            this.Load += new System.EventHandler(this.frmComprarCupon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidadCompra)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnComprar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCreditoActual;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numCantidadCompra;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox txtPrecioReal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtLimitePromo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPrecioFicticio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.CheckBox chkComprar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn precionormal;
        private System.Windows.Forms.DataGridViewButtonColumn seleccionar;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblCheck;
        private System.Windows.Forms.Label lblMensaje;
    }
}