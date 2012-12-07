namespace GrouponDesktop.CargaCredito
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
            this.montoBox = new System.Windows.Forms.TextBox();
            this.cmbPago = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.txtNroTarj = new System.Windows.Forms.TextBox();
            this.lblNroTarj = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(12, 139);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // montoBox
            // 
            this.montoBox.Location = new System.Drawing.Point(12, 50);
            this.montoBox.Name = "montoBox";
            this.montoBox.Size = new System.Drawing.Size(100, 20);
            this.montoBox.TabIndex = 1;
            this.montoBox.TextChanged += new System.EventHandler(this.montoBox_TextChanged);
            // 
            // cmbPago
            // 
            this.cmbPago.FormattingEnabled = true;
            this.cmbPago.Items.AddRange(new object[] {
            "Efectivo",
            "Tarjeta Credito",
            "Tarjeta Debito"});
            this.cmbPago.Location = new System.Drawing.Point(12, 76);
            this.cmbPago.Name = "cmbPago";
            this.cmbPago.Size = new System.Drawing.Size(121, 21);
            this.cmbPago.Sorted = true;
            this.cmbPago.TabIndex = 2;
            this.cmbPago.SelectedIndexChanged += new System.EventHandler(this.cmbPago_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(148, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Monto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(148, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Forma de Pago";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(167, 139);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblError
            // 
            this.lblError.AutoEllipsis = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(12, 9);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(230, 38);
            this.lblError.TabIndex = 5;
            this.lblError.Text = "Error";
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblError.Visible = false;
            this.lblError.TextChanged += new System.EventHandler(this.lblError_TextChanged);
            // 
            // txtNroTarj
            // 
            this.txtNroTarj.Location = new System.Drawing.Point(12, 103);
            this.txtNroTarj.Name = "txtNroTarj";
            this.txtNroTarj.Size = new System.Drawing.Size(100, 20);
            this.txtNroTarj.TabIndex = 1;
            this.txtNroTarj.Visible = false;
            this.txtNroTarj.TextChanged += new System.EventHandler(this.mroTarjBox_TextChanged);
            // 
            // lblNroTarj
            // 
            this.lblNroTarj.AutoSize = true;
            this.lblNroTarj.Location = new System.Drawing.Point(148, 106);
            this.lblNroTarj.Name = "lblNroTarj";
            this.lblNroTarj.Size = new System.Drawing.Size(60, 13);
            this.lblNroTarj.TabIndex = 6;
            this.lblNroTarj.Text = "Nro Tarjeta";
            this.lblNroTarj.Visible = false;
            // 
            // frmCargarCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 174);
            this.Controls.Add(this.lblNroTarj);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbPago);
            this.Controls.Add(this.txtNroTarj);
            this.Controls.Add(this.montoBox);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Name = "frmCargarCredito";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox montoBox;
        private System.Windows.Forms.ComboBox cmbPago;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.TextBox txtNroTarj;
        private System.Windows.Forms.Label lblNroTarj;
    }
}