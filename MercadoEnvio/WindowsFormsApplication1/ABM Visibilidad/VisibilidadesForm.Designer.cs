namespace WindowsFormsApplication1.ABM_Visibilidad
{
    partial class VisibilidadesForm
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txbDesc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.limpiarbtn = new System.Windows.Forms.Button();
            this.Buscarbtn = new System.Windows.Forms.Button();
            this.porcLabel = new System.Windows.Forms.Label();
            this.txbPorc = new System.Windows.Forms.TextBox();
            this.PrecioLabel = new System.Windows.Forms.Label();
            this.txbPrecio = new System.Windows.Forms.TextBox();
            this.codLabel = new System.Windows.Forms.Label();
            this.txbCod = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Modificarbtn = new System.Windows.Forms.Button();
            this.Altabtn = new System.Windows.Forms.Button();
            this.VisilidadesDG = new System.Windows.Forms.DataGridView();
            this.visibilidadesDSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.visibilidadesDS = new WindowsFormsApplication1.ABM_Visibilidad.VisibilidadesDS();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VisilidadesDG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.visibilidadesDSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.visibilidadesDS)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txbDesc);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.limpiarbtn);
            this.groupBox1.Controls.Add(this.Buscarbtn);
            this.groupBox1.Controls.Add(this.porcLabel);
            this.groupBox1.Controls.Add(this.txbPorc);
            this.groupBox1.Controls.Add(this.PrecioLabel);
            this.groupBox1.Controls.Add(this.txbPrecio);
            this.groupBox1.Controls.Add(this.codLabel);
            this.groupBox1.Controls.Add(this.txbCod);
            this.groupBox1.Location = new System.Drawing.Point(10, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(508, 87);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // txbDesc
            // 
            this.txbDesc.Location = new System.Drawing.Point(268, 23);
            this.txbDesc.Name = "txbDesc";
            this.txbDesc.Size = new System.Drawing.Size(112, 20);
            this.txbDesc.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(199, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Descripcion";
            // 
            // limpiarbtn
            // 
            this.limpiarbtn.Location = new System.Drawing.Point(406, 48);
            this.limpiarbtn.Name = "limpiarbtn";
            this.limpiarbtn.Size = new System.Drawing.Size(81, 20);
            this.limpiarbtn.TabIndex = 7;
            this.limpiarbtn.Text = "Limpiar";
            this.limpiarbtn.UseVisualStyleBackColor = true;
            this.limpiarbtn.Click += new System.EventHandler(this.limpiarbtn_Click);
            // 
            // Buscarbtn
            // 
            this.Buscarbtn.Location = new System.Drawing.Point(406, 19);
            this.Buscarbtn.Name = "Buscarbtn";
            this.Buscarbtn.Size = new System.Drawing.Size(81, 20);
            this.Buscarbtn.TabIndex = 6;
            this.Buscarbtn.Text = "Buscar";
            this.Buscarbtn.UseVisualStyleBackColor = true;
            this.Buscarbtn.Click += new System.EventHandler(this.Buscarbtn_Click);
            // 
            // porcLabel
            // 
            this.porcLabel.AutoSize = true;
            this.porcLabel.Location = new System.Drawing.Point(7, 55);
            this.porcLabel.Name = "porcLabel";
            this.porcLabel.Size = new System.Drawing.Size(58, 13);
            this.porcLabel.TabIndex = 5;
            this.porcLabel.Text = "Porcentaje";
            // 
            // txbPorc
            // 
            this.txbPorc.Location = new System.Drawing.Point(71, 52);
            this.txbPorc.Name = "txbPorc";
            this.txbPorc.Size = new System.Drawing.Size(108, 20);
            this.txbPorc.TabIndex = 4;
            this.txbPorc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // PrecioLabel
            // 
            this.PrecioLabel.AutoSize = true;
            this.PrecioLabel.Location = new System.Drawing.Point(225, 48);
            this.PrecioLabel.Name = "PrecioLabel";
            this.PrecioLabel.Size = new System.Drawing.Size(37, 13);
            this.PrecioLabel.TabIndex = 3;
            this.PrecioLabel.Text = "Precio";
            // 
            // txbPrecio
            // 
            this.txbPrecio.Location = new System.Drawing.Point(268, 48);
            this.txbPrecio.Name = "txbPrecio";
            this.txbPrecio.Size = new System.Drawing.Size(112, 20);
            this.txbPrecio.TabIndex = 2;
            this.txbPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // codLabel
            // 
            this.codLabel.AutoSize = true;
            this.codLabel.Location = new System.Drawing.Point(25, 22);
            this.codLabel.Name = "codLabel";
            this.codLabel.Size = new System.Drawing.Size(40, 13);
            this.codLabel.TabIndex = 1;
            this.codLabel.Text = "Codigo";
            // 
            // txbCod
            // 
            this.txbCod.Location = new System.Drawing.Point(71, 19);
            this.txbCod.Name = "txbCod";
            this.txbCod.Size = new System.Drawing.Size(108, 20);
            this.txbCod.TabIndex = 0;
            this.txbCod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // button1
            // 
            this.button1.Image = global::WindowsFormsApplication1.Properties.Resources.delete_icon;
            this.button1.Location = new System.Drawing.Point(52, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(36, 33);
            this.button1.TabIndex = 6;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Deletebutton1_Click);
            // 
            // Modificarbtn
            // 
            this.Modificarbtn.Image = global::WindowsFormsApplication1.Properties.Resources.modifyPage;
            this.Modificarbtn.Location = new System.Drawing.Point(94, 7);
            this.Modificarbtn.Name = "Modificarbtn";
            this.Modificarbtn.Size = new System.Drawing.Size(36, 33);
            this.Modificarbtn.TabIndex = 4;
            this.Modificarbtn.UseVisualStyleBackColor = true;
            this.Modificarbtn.Click += new System.EventHandler(this.Modificarbtn_Click);
            // 
            // Altabtn
            // 
            this.Altabtn.Image = global::WindowsFormsApplication1.Properties.Resources.Button_New_icon;
            this.Altabtn.Location = new System.Drawing.Point(10, 7);
            this.Altabtn.Name = "Altabtn";
            this.Altabtn.Size = new System.Drawing.Size(36, 33);
            this.Altabtn.TabIndex = 3;
            this.Altabtn.UseVisualStyleBackColor = true;
            this.Altabtn.Click += new System.EventHandler(this.Altabtn_Click);
            // 
            // VisilidadesDG
            // 
            this.VisilidadesDG.AutoGenerateColumns = false;
            this.VisilidadesDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.VisilidadesDG.DataSource = this.visibilidadesDSBindingSource;
            this.VisilidadesDG.Location = new System.Drawing.Point(13, 140);
            this.VisilidadesDG.Name = "VisilidadesDG";
            this.VisilidadesDG.Size = new System.Drawing.Size(505, 274);
            this.VisilidadesDG.TabIndex = 7;
            // 
            // visibilidadesDSBindingSource
            // 
            this.visibilidadesDSBindingSource.DataSource = this.visibilidadesDS;
            this.visibilidadesDSBindingSource.Position = 0;
            // 
            // visibilidadesDS
            // 
            this.visibilidadesDS.DataSetName = "VisibilidadesDS";
            this.visibilidadesDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // VisibilidadesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 435);
            this.Controls.Add(this.VisilidadesDG);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Modificarbtn);
            this.Controls.Add(this.Altabtn);
            this.Controls.Add(this.groupBox1);
            this.Name = "VisibilidadesForm";
            this.Text = "Visibilidades";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VisilidadesDG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.visibilidadesDSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.visibilidadesDS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Buscarbtn;
        private System.Windows.Forms.Label porcLabel;
        private System.Windows.Forms.TextBox txbPorc;
        private System.Windows.Forms.Label PrecioLabel;
        private System.Windows.Forms.TextBox txbPrecio;
        private System.Windows.Forms.Label codLabel;
        private System.Windows.Forms.TextBox txbCod;
        private System.Windows.Forms.Button Altabtn;
        private System.Windows.Forms.Button Modificarbtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button limpiarbtn;
        private System.Windows.Forms.DataGridView VisilidadesDG;
        private System.Windows.Forms.BindingSource visibilidadesDSBindingSource;
        private VisibilidadesDS visibilidadesDS;
        private System.Windows.Forms.TextBox txbDesc;
        private System.Windows.Forms.Label label1;
    }
}