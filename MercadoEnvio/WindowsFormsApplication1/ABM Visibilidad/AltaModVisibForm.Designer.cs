namespace WindowsFormsApplication1.ABM_Visibilidad
{
    partial class AltaModVisibForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txbDesc = new System.Windows.Forms.TextBox();
            this.txbPorc = new System.Windows.Forms.TextBox();
            this.txbPrecio = new System.Windows.Forms.TextBox();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descripcion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Porcentaje";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Precio";
            // 
            // txbDesc
            // 
            this.txbDesc.Location = new System.Drawing.Point(105, 13);
            this.txbDesc.Name = "txbDesc";
            this.txbDesc.Size = new System.Drawing.Size(167, 20);
            this.txbDesc.TabIndex = 3;
            // 
            // txbPorc
            // 
            this.txbPorc.Location = new System.Drawing.Point(105, 74);
            this.txbPorc.Name = "txbPorc";
            this.txbPorc.Size = new System.Drawing.Size(124, 20);
            this.txbPorc.TabIndex = 4;
            // 
            // txbPrecio
            // 
            this.txbPrecio.Location = new System.Drawing.Point(105, 132);
            this.txbPrecio.Name = "txbPrecio";
            this.txbPrecio.Size = new System.Drawing.Size(123, 20);
            this.txbPrecio.TabIndex = 5;
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(154, 184);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 6;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(44, 184);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // AltaVisibForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.txbPrecio);
            this.Controls.Add(this.txbPorc);
            this.Controls.Add(this.txbDesc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AltaVisibForm";
            this.Text = "AltaVisib";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbDesc;
        private System.Windows.Forms.TextBox txbPorc;
        private System.Windows.Forms.TextBox txbPrecio;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Button btnCancelar;
    }
}