namespace GrouponDesktop.UI.ListadoEstadistico
{
    partial class frmListadoEstadistico
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
            this.label3 = new System.Windows.Forms.Label();
            this.rdoGiftCards = new System.Windows.Forms.RadioButton();
            this.rdoDevoluciones = new System.Windows.Forms.RadioButton();
            this.nudSemestre = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudAnio = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSemestre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(12, 9);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(107, 20);
            this.label27.TabIndex = 32;
            this.label27.Text = "Estadisticas";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.rdoGiftCards);
            this.groupBox1.Controls.Add(this.rdoDevoluciones);
            this.groupBox1.Controls.Add(this.nudSemestre);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nudAnio);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(16, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(383, 116);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalles";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tipo listado:";
            // 
            // rdoGiftCards
            // 
            this.rdoGiftCards.AutoSize = true;
            this.rdoGiftCards.Location = new System.Drawing.Point(191, 82);
            this.rdoGiftCards.Name = "rdoGiftCards";
            this.rdoGiftCards.Size = new System.Drawing.Size(70, 17);
            this.rdoGiftCards.TabIndex = 5;
            this.rdoGiftCards.Text = "Gift cards";
            this.rdoGiftCards.UseVisualStyleBackColor = true;
            // 
            // rdoDevoluciones
            // 
            this.rdoDevoluciones.AutoSize = true;
            this.rdoDevoluciones.Checked = true;
            this.rdoDevoluciones.Location = new System.Drawing.Point(81, 82);
            this.rdoDevoluciones.Name = "rdoDevoluciones";
            this.rdoDevoluciones.Size = new System.Drawing.Size(90, 17);
            this.rdoDevoluciones.TabIndex = 4;
            this.rdoDevoluciones.TabStop = true;
            this.rdoDevoluciones.Text = "Devoluciones";
            this.rdoDevoluciones.UseVisualStyleBackColor = true;
            // 
            // nudSemestre
            // 
            this.nudSemestre.Location = new System.Drawing.Point(81, 52);
            this.nudSemestre.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudSemestre.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSemestre.Name = "nudSemestre";
            this.nudSemestre.Size = new System.Drawing.Size(52, 20);
            this.nudSemestre.TabIndex = 3;
            this.nudSemestre.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Semestre";
            // 
            // nudAnio
            // 
            this.nudAnio.Location = new System.Drawing.Point(81, 22);
            this.nudAnio.Maximum = new decimal(new int[] {
            2050,
            0,
            0,
            0});
            this.nudAnio.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudAnio.Name = "nudAnio";
            this.nudAnio.Size = new System.Drawing.Size(83, 20);
            this.nudAnio.TabIndex = 1;
            this.nudAnio.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Año:";
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(324, 155);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(75, 23);
            this.btnGenerar.TabIndex = 34;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Resultados:";
            // 
            // dgvDatos
            // 
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Location = new System.Drawing.Point(16, 196);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.Size = new System.Drawing.Size(383, 150);
            this.dgvDatos.TabIndex = 36;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(324, 352);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 37;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(243, 155);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 38;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Location = new System.Drawing.Point(91, 180);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(14, 13);
            this.lblCantidad.TabIndex = 40;
            this.lblCantidad.Text = "0";
            // 
            // frmListadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 383);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label27);
            this.Name = "frmListadoEstadistico";
            this.Text = "Cuponete Orion - Estadisticas";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSemestre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nudSemestre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudAnio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdoGiftCards;
        private System.Windows.Forms.RadioButton rdoDevoluciones;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblCantidad;

    }
}