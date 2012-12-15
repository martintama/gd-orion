namespace GrouponDesktop.UI
{
    partial class frmCambiarPassword
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
            this.label27 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPasswordActual = new System.Windows.Forms.MaskedTextBox();
            this.txtPasswordNuevo1 = new System.Windows.Forms.MaskedTextBox();
            this.txtPasswordNuevo2 = new System.Windows.Forms.MaskedTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lblPasswordActual = new System.Windows.Forms.Label();
            this.lblPasswordNuevo1 = new System.Windows.Forms.Label();
            this.lblPasswordNuevo2 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(12, 9);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(157, 20);
            this.label27.TabIndex = 31;
            this.label27.Text = "Cambiar Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Password actual:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Nuevo password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Repita nuevo password:";
            // 
            // txtPasswordActual
            // 
            this.txtPasswordActual.Location = new System.Drawing.Point(146, 40);
            this.txtPasswordActual.Name = "txtPasswordActual";
            this.txtPasswordActual.PasswordChar = '*';
            this.txtPasswordActual.Size = new System.Drawing.Size(140, 20);
            this.txtPasswordActual.TabIndex = 35;
            // 
            // txtPasswordNuevo1
            // 
            this.txtPasswordNuevo1.Location = new System.Drawing.Point(146, 70);
            this.txtPasswordNuevo1.Name = "txtPasswordNuevo1";
            this.txtPasswordNuevo1.PasswordChar = '*';
            this.txtPasswordNuevo1.Size = new System.Drawing.Size(140, 20);
            this.txtPasswordNuevo1.TabIndex = 36;
            // 
            // txtPasswordNuevo2
            // 
            this.txtPasswordNuevo2.Location = new System.Drawing.Point(146, 98);
            this.txtPasswordNuevo2.Name = "txtPasswordNuevo2";
            this.txtPasswordNuevo2.PasswordChar = '*';
            this.txtPasswordNuevo2.Size = new System.Drawing.Size(140, 20);
            this.txtPasswordNuevo2.TabIndex = 37;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(280, 132);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 38;
            this.button1.Text = "Grabar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(16, 132);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 39;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblPasswordActual
            // 
            this.lblPasswordActual.AutoSize = true;
            this.lblPasswordActual.ForeColor = System.Drawing.Color.Red;
            this.lblPasswordActual.Location = new System.Drawing.Point(292, 43);
            this.lblPasswordActual.Name = "lblPasswordActual";
            this.lblPasswordActual.Size = new System.Drawing.Size(63, 13);
            this.lblPasswordActual.TabIndex = 40;
            this.lblPasswordActual.Text = "* Requerido";
            this.lblPasswordActual.Visible = false;
            // 
            // lblPasswordNuevo1
            // 
            this.lblPasswordNuevo1.AutoSize = true;
            this.lblPasswordNuevo1.ForeColor = System.Drawing.Color.Red;
            this.lblPasswordNuevo1.Location = new System.Drawing.Point(292, 73);
            this.lblPasswordNuevo1.Name = "lblPasswordNuevo1";
            this.lblPasswordNuevo1.Size = new System.Drawing.Size(63, 13);
            this.lblPasswordNuevo1.TabIndex = 41;
            this.lblPasswordNuevo1.Text = "* Requerido";
            this.lblPasswordNuevo1.Visible = false;
            // 
            // lblPasswordNuevo2
            // 
            this.lblPasswordNuevo2.AutoSize = true;
            this.lblPasswordNuevo2.ForeColor = System.Drawing.Color.Red;
            this.lblPasswordNuevo2.Location = new System.Drawing.Point(292, 101);
            this.lblPasswordNuevo2.Name = "lblPasswordNuevo2";
            this.lblPasswordNuevo2.Size = new System.Drawing.Size(63, 13);
            this.lblPasswordNuevo2.TabIndex = 42;
            this.lblPasswordNuevo2.Text = "* Requerido";
            this.lblPasswordNuevo2.Visible = false;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(199, 132);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 43;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // frmCambiarPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 167);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.lblPasswordNuevo2);
            this.Controls.Add(this.lblPasswordNuevo1);
            this.Controls.Add(this.lblPasswordActual);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtPasswordNuevo2);
            this.Controls.Add(this.txtPasswordNuevo1);
            this.Controls.Add(this.txtPasswordActual);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label27);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmCambiarPassword";
            this.Text = "Cuponete Orion - Cambiar Password";
            this.Load += new System.EventHandler(this.frmCambiarPassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtPasswordActual;
        private System.Windows.Forms.MaskedTextBox txtPasswordNuevo1;
        private System.Windows.Forms.MaskedTextBox txtPasswordNuevo2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblPasswordActual;
        private System.Windows.Forms.Label lblPasswordNuevo1;
        private System.Windows.Forms.Label lblPasswordNuevo2;
        private System.Windows.Forms.Button btnLimpiar;
    }
}