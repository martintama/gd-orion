namespace GrouponDesktop.HistorialCupones
{
    partial class frmHistorialCupones
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
            this.label27 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblFechas = new System.Windows.Forms.Label();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaVtoCanje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaCanje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaDevolucion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(12, 9);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(173, 20);
            this.label27.TabIndex = 32;
            this.label27.Text = "Historial de compras";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblFechas);
            this.groupBox1.Controls.Add(this.dtpHasta);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtpDesde);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(16, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(707, 54);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de búsqueda";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Location = new System.Drawing.Point(383, 22);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(200, 20);
            this.dtpHasta.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(307, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Fecha hasta:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Location = new System.Drawing.Point(82, 21);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(200, 20);
            this.dtpDesde.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha desde:";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(648, 92);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrar.TabIndex = 33;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(567, 92);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 34;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Cupones encontrados:";
            // 
            // dgvDatos
            // 
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFecha,
            this.colCodigo,
            this.colDescripcion,
            this.colFechaVtoCanje,
            this.colFechaCanje,
            this.colFechaDevolucion,
            this.colEstado});
            this.dgvDatos.Location = new System.Drawing.Point(12, 132);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowHeadersVisible = false;
            this.dgvDatos.Size = new System.Drawing.Size(711, 294);
            this.dgvDatos.TabIndex = 36;
            this.dgvDatos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDatos_CellFormatting);
            this.dgvDatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellContentClick);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(12, 432);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 37;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // lblFechas
            // 
            this.lblFechas.AutoSize = true;
            this.lblFechas.ForeColor = System.Drawing.Color.Red;
            this.lblFechas.Location = new System.Drawing.Point(589, 25);
            this.lblFechas.Name = "lblFechas";
            this.lblFechas.Size = new System.Drawing.Size(50, 13);
            this.lblFechas.TabIndex = 8;
            this.lblFechas.Text = "* Revisar";
            this.lblFechas.Visible = false;
            // 
            // lblMensaje
            // 
            this.lblMensaje.ForeColor = System.Drawing.Color.Red;
            this.lblMensaje.Location = new System.Drawing.Point(95, 432);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(628, 26);
            this.lblMensaje.TabIndex = 38;
            this.lblMensaje.Text = "Mensaje";
            this.lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMensaje.Visible = false;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Location = new System.Drawing.Point(126, 102);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(14, 13);
            this.lblCantidad.TabIndex = 39;
            this.lblCantidad.Text = "0";
            // 
            // colFecha
            // 
            this.colFecha.Frozen = true;
            this.colFecha.HeaderText = "Fecha Compra";
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            // 
            // colCodigo
            // 
            this.colCodigo.Frozen = true;
            this.colCodigo.HeaderText = "Codigo";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.ReadOnly = true;
            // 
            // colDescripcion
            // 
            this.colDescripcion.Frozen = true;
            this.colDescripcion.HeaderText = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.ReadOnly = true;
            // 
            // colFechaVtoCanje
            // 
            this.colFechaVtoCanje.Frozen = true;
            this.colFechaVtoCanje.HeaderText = "Fecha vto. Canje";
            this.colFechaVtoCanje.Name = "colFechaVtoCanje";
            this.colFechaVtoCanje.ReadOnly = true;
            // 
            // colFechaCanje
            // 
            this.colFechaCanje.Frozen = true;
            this.colFechaCanje.HeaderText = "Fecha Canje";
            this.colFechaCanje.Name = "colFechaCanje";
            this.colFechaCanje.ReadOnly = true;
            // 
            // colFechaDevolucion
            // 
            this.colFechaDevolucion.Frozen = true;
            this.colFechaDevolucion.HeaderText = "FechaDevolucion";
            this.colFechaDevolucion.Name = "colFechaDevolucion";
            this.colFechaDevolucion.ReadOnly = true;
            // 
            // colEstado
            // 
            this.colEstado.Frozen = true;
            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "colEstado";
            this.colEstado.ReadOnly = true;
            // 
            // frmHistorialCupones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 467);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmHistorialCupones";
            this.Text = "Cuponete Orion - Historial";
            this.Load += new System.EventHandler(this.frmHistorialCupones_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label lblFechas;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaVtoCanje;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaCanje;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaDevolucion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;

    }
}