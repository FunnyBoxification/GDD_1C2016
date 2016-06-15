namespace WindowsFormsApplication1.ABM_Usuario
{
    partial class AltaModUsuarioForm
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
            this.UserName = new System.Windows.Forms.Label();
            this.txbUsername = new System.Windows.Forms.TextBox();
            this.txbPassw = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.datos1 = new WindowsFormsApplication1.ABM_Usuarios.Datos();
            this.datosCliente1 = new WindowsFormsApplication1.ABM_Usuario.DatosCliente();
            this.datosEmpresa1 = new WindowsFormsApplication1.ABM_Usuario.DatosEmpresa();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UserName
            // 
            this.UserName.AutoSize = true;
            this.UserName.Location = new System.Drawing.Point(42, 20);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(57, 13);
            this.UserName.TabIndex = 0;
            this.UserName.Text = "UserName";
            // 
            // txbUsername
            // 
            this.txbUsername.Location = new System.Drawing.Point(105, 17);
            this.txbUsername.Name = "txbUsername";
            this.txbUsername.Size = new System.Drawing.Size(86, 20);
            this.txbUsername.TabIndex = 7;
            // 
            // txbPassw
            // 
            this.txbPassw.Location = new System.Drawing.Point(264, 16);
            this.txbPassw.Name = "txbPassw";
            this.txbPassw.Size = new System.Drawing.Size(86, 20);
            this.txbPassw.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(205, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Password";
            // 
            // datos1
            // 
            this.datos1.Direccion = "";
            this.datos1.Dpto = "";
            this.datos1.Localidad = "";
            this.datos1.Location = new System.Drawing.Point(26, 190);
            this.datos1.Mail = "";
            this.datos1.Name = "datos1";
            this.datos1.Nro = "";
            this.datos1.Piso = "";
            this.datos1.Size = new System.Drawing.Size(339, 209);
            this.datos1.TabIndex = 8;
            this.datos1.Telefono = "";
            // 
            // datosCliente1
            // 
            this.datosCliente1.Apellido = "";
            this.datosCliente1.Documento = "";
            this.datosCliente1.FechaNac = new System.DateTime(2016, 6, 14, 18, 55, 14, 868);
            this.datosCliente1.Location = new System.Drawing.Point(15, 48);
            this.datosCliente1.Name = "datosCliente1";
            this.datosCliente1.Nombre = "";
            this.datosCliente1.Size = new System.Drawing.Size(365, 150);
            this.datosCliente1.TabIndex = 11;
            this.datosCliente1.Tipo = "";
            // 
            // datosEmpresa1
            // 
            this.datosEmpresa1.Ciudad = "";
            this.datosEmpresa1.Contacto = "";
            this.datosEmpresa1.Cuit = "";
            this.datosEmpresa1.Location = new System.Drawing.Point(26, 73);
            this.datosEmpresa1.Name = "datosEmpresa1";
            this.datosEmpresa1.RazonSocial = "";
            this.datosEmpresa1.Rubro = "";
            this.datosEmpresa1.Size = new System.Drawing.Size(328, 125);
            this.datosEmpresa1.TabIndex = 12;
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(290, 391);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 13;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // AltaModUsuarioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 426);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.datosEmpresa1);
            this.Controls.Add(this.datosCliente1);
            this.Controls.Add(this.txbPassw);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.datos1);
            this.Controls.Add(this.txbUsername);
            this.Controls.Add(this.UserName);
            this.Name = "AltaModUsuarioForm";
            this.Text = "AltaModUsuarioForm";
            this.Load += new System.EventHandler(this.AltaModUsuarioForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UserName;
        private System.Windows.Forms.TextBox txbUsername;
        private ABM_Usuarios.Datos datos1;
        private System.Windows.Forms.TextBox txbPassw;
        private System.Windows.Forms.Label label1;
        private DatosCliente datosCliente1;
        private DatosEmpresa datosEmpresa1;
        private System.Windows.Forms.Button btnGrabar;
    }
}