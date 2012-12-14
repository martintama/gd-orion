namespace GrouponDesktop.UI.CargaCredito
{
    partial class frmCargarCredito
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
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.cmbPago = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.txtNroTarj = new System.Windows.Forms.TextBox();
            this.labelX = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.gbxDatosTarjeta = new System.Windows.Forms.GroupBox();
            this.lblDni = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCodSeg = new System.Windows.Forms.Label();
            this.lblNroTarjeta = new System.Windows.Forms.Label();
            this.lblTitular = new System.Windows.Forms.Label();
            this.nudMesVenc = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.nudAnioVenc = new System.Windows.Forms.NumericUpDown();
            this.txtTitular = new System.Windows.Forms.TextBox();
            this.cmbTipoTarjeta = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCodSeg = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lblMonto = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.gbxDatosTarjeta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMesVenc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnioVenc)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(387, 315);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 9;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(126, 36);
            this.txtMonto.MaxLength = 10;
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(74, 20);
            this.txtMonto.TabIndex = 0;
            // 
            // cmbPago
            // 
            this.cmbPago.DisplayMember = "Descripcion";
            this.cmbPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPago.FormattingEnabled = true;
            this.cmbPago.Location = new System.Drawing.Point(126, 62);
            this.cmbPago.Name = "cmbPago";
            this.cmbPago.Size = new System.Drawing.Size(121, 21);
            this.cmbPago.TabIndex = 1;
            this.cmbPago.ValueMember = "Idtipo_pago";
            this.cmbPago.SelectedIndexChanged += new System.EventHandler(this.cmbPago_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Monto:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Forma de Pago:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(11, 315);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblError
            // 
            this.lblError.AutoEllipsis = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(17, 289);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(445, 23);
            this.lblError.TabIndex = 5;
            this.lblError.Text = "Error";
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblError.Visible = false;
            // 
            // txtNroTarj
            // 
            this.txtNroTarj.Location = new System.Drawing.Point(110, 99);
            this.txtNroTarj.MaxLength = 16;
            this.txtNroTarj.Name = "txtNroTarj";
            this.txtNroTarj.Size = new System.Drawing.Size(151, 20);
            this.txtNroTarj.TabIndex = 5;
            this.txtNroTarj.TextChanged += new System.EventHandler(this.txtNroTarj_TextChanged);
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(10, 102);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(63, 13);
            this.labelX.TabIndex = 6;
            this.labelX.Text = "Nro Tarjeta:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(12, 9);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(123, 20);
            this.label27.TabIndex = 31;
            this.label27.Text = "Cargar crédito";
            // 
            // gbxDatosTarjeta
            // 
            this.gbxDatosTarjeta.Controls.Add(this.lblDni);
            this.gbxDatosTarjeta.Controls.Add(this.txtDni);
            this.gbxDatosTarjeta.Controls.Add(this.label8);
            this.gbxDatosTarjeta.Controls.Add(this.lblCodSeg);
            this.gbxDatosTarjeta.Controls.Add(this.lblNroTarjeta);
            this.gbxDatosTarjeta.Controls.Add(this.lblTitular);
            this.gbxDatosTarjeta.Controls.Add(this.nudMesVenc);
            this.gbxDatosTarjeta.Controls.Add(this.label7);
            this.gbxDatosTarjeta.Controls.Add(this.nudAnioVenc);
            this.gbxDatosTarjeta.Controls.Add(this.txtTitular);
            this.gbxDatosTarjeta.Controls.Add(this.cmbTipoTarjeta);
            this.gbxDatosTarjeta.Controls.Add(this.label6);
            this.gbxDatosTarjeta.Controls.Add(this.label5);
            this.gbxDatosTarjeta.Controls.Add(this.txtCodSeg);
            this.gbxDatosTarjeta.Controls.Add(this.label4);
            this.gbxDatosTarjeta.Controls.Add(this.txtNroTarj);
            this.gbxDatosTarjeta.Controls.Add(this.label3);
            this.gbxDatosTarjeta.Controls.Add(this.labelX);
            this.gbxDatosTarjeta.Enabled = false;
            this.gbxDatosTarjeta.Location = new System.Drawing.Point(16, 103);
            this.gbxDatosTarjeta.Name = "gbxDatosTarjeta";
            this.gbxDatosTarjeta.Size = new System.Drawing.Size(446, 183);
            this.gbxDatosTarjeta.TabIndex = 5;
            this.gbxDatosTarjeta.TabStop = false;
            this.gbxDatosTarjeta.Text = "Datos de la tarjeta de crédito";
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.ForeColor = System.Drawing.Color.Red;
            this.lblDni.Location = new System.Drawing.Point(221, 77);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(50, 13);
            this.lblDni.TabIndex = 32;
            this.lblDni.Text = "* Revisar";
            this.lblDni.Visible = false;
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(110, 74);
            this.txtDni.MaxLength = 8;
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(100, 20);
            this.txtDni.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "DNI titular:";
            // 
            // lblCodSeg
            // 
            this.lblCodSeg.AutoSize = true;
            this.lblCodSeg.ForeColor = System.Drawing.Color.Red;
            this.lblCodSeg.Location = new System.Drawing.Point(167, 128);
            this.lblCodSeg.Name = "lblCodSeg";
            this.lblCodSeg.Size = new System.Drawing.Size(50, 13);
            this.lblCodSeg.TabIndex = 29;
            this.lblCodSeg.Text = "* Revisar";
            this.lblCodSeg.Visible = false;
            // 
            // lblNroTarjeta
            // 
            this.lblNroTarjeta.AutoSize = true;
            this.lblNroTarjeta.ForeColor = System.Drawing.Color.Red;
            this.lblNroTarjeta.Location = new System.Drawing.Point(268, 102);
            this.lblNroTarjeta.Name = "lblNroTarjeta";
            this.lblNroTarjeta.Size = new System.Drawing.Size(50, 13);
            this.lblNroTarjeta.TabIndex = 28;
            this.lblNroTarjeta.Text = "* Revisar";
            this.lblNroTarjeta.Visible = false;
            // 
            // lblTitular
            // 
            this.lblTitular.AutoSize = true;
            this.lblTitular.ForeColor = System.Drawing.Color.Red;
            this.lblTitular.Location = new System.Drawing.Point(336, 52);
            this.lblTitular.Name = "lblTitular";
            this.lblTitular.Size = new System.Drawing.Size(50, 13);
            this.lblTitular.TabIndex = 27;
            this.lblTitular.Text = "* Revisar";
            this.lblTitular.Visible = false;
            // 
            // nudMesVenc
            // 
            this.nudMesVenc.Location = new System.Drawing.Point(322, 151);
            this.nudMesVenc.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.nudMesVenc.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMesVenc.Name = "nudMesVenc";
            this.nudMesVenc.Size = new System.Drawing.Size(51, 20);
            this.nudMesVenc.TabIndex = 8;
            this.nudMesVenc.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(225, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Mes Vencimiento:";
            // 
            // nudAnioVenc
            // 
            this.nudAnioVenc.Location = new System.Drawing.Point(110, 151);
            this.nudAnioVenc.Maximum = new decimal(new int[] {
            2050,
            0,
            0,
            0});
            this.nudAnioVenc.Name = "nudAnioVenc";
            this.nudAnioVenc.Size = new System.Drawing.Size(74, 20);
            this.nudAnioVenc.TabIndex = 7;
            // 
            // txtTitular
            // 
            this.txtTitular.Location = new System.Drawing.Point(110, 49);
            this.txtTitular.MaxLength = 50;
            this.txtTitular.Name = "txtTitular";
            this.txtTitular.Size = new System.Drawing.Size(221, 20);
            this.txtTitular.TabIndex = 3;
            // 
            // cmbTipoTarjeta
            // 
            this.cmbTipoTarjeta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoTarjeta.FormattingEnabled = true;
            this.cmbTipoTarjeta.Location = new System.Drawing.Point(110, 22);
            this.cmbTipoTarjeta.Name = "cmbTipoTarjeta";
            this.cmbTipoTarjeta.Size = new System.Drawing.Size(126, 21);
            this.cmbTipoTarjeta.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Titular:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Año vencimiento:";
            // 
            // txtCodSeg
            // 
            this.txtCodSeg.Location = new System.Drawing.Point(110, 125);
            this.txtCodSeg.MaxLength = 4;
            this.txtCodSeg.Name = "txtCodSeg";
            this.txtCodSeg.Size = new System.Drawing.Size(52, 20);
            this.txtCodSeg.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Cod. Seg.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Marca:";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(306, 315);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 11;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.ForeColor = System.Drawing.Color.Red;
            this.lblMonto.Location = new System.Drawing.Point(253, 39);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(50, 13);
            this.lblMonto.TabIndex = 30;
            this.lblMonto.Text = "* Revisar";
            this.lblMonto.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(107, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(13, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = "$";
            // 
            // frmCargarCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 347);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblMonto);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.gbxDatosTarjeta);
            this.Controls.Add(this.cmbPago);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAceptar);
            this.Name = "frmCargarCredito";
            this.Text = "Cuponete Orion - Cargar crédito";
            this.Load += new System.EventHandler(this.frmCargarCredito_Load);
            this.gbxDatosTarjeta.ResumeLayout(false);
            this.gbxDatosTarjeta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMesVenc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnioVenc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.ComboBox cmbPago;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.TextBox txtNroTarj;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.GroupBox gbxDatosTarjeta;
        private System.Windows.Forms.TextBox txtTitular;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCodSeg;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTipoTarjeta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudMesVenc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudAnioVenc;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblCodSeg;
        private System.Windows.Forms.Label lblNroTarjeta;
        private System.Windows.Forms.Label lblTitular;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.Label label9;
    }
}