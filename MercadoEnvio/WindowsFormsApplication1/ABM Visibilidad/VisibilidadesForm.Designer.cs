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
            this.Codtxtb = new System.Windows.Forms.TextBox();
            this.codLabel = new System.Windows.Forms.Label();
            this.PrecioLabel = new System.Windows.Forms.Label();
            this.preciotxtb = new System.Windows.Forms.TextBox();
            this.porcLabel = new System.Windows.Forms.Label();
            this.porctxtb = new System.Windows.Forms.TextBox();
            this.Buscarbtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Modificarbtn = new System.Windows.Forms.Button();
            this.Altabtn = new System.Windows.Forms.Button();
            this.limpiarbtn = new System.Windows.Forms.Button();
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
            this.groupBox1.Controls.Add(this.limpiarbtn);
            this.groupBox1.Controls.Add(this.Buscarbtn);
            this.groupBox1.Controls.Add(this.porcLabel);
            this.groupBox1.Controls.Add(this.porctxtb);
            this.groupBox1.Controls.Add(this.PrecioLabel);
            this.groupBox1.Controls.Add(this.preciotxtb);
            this.groupBox1.Controls.Add(this.codLabel);
            this.groupBox1.Controls.Add(this.Codtxtb);
            this.groupBox1.Location = new System.Drawing.Point(10, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 87);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // Codtxtb
            // 
            this.Codtxtb.Location = new System.Drawing.Point(71, 19);
            this.Codtxtb.Name = "Codtxtb";
            this.Codtxtb.Size = new System.Drawing.Size(108, 20);
            this.Codtxtb.TabIndex = 0;
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
            // PrecioLabel
            // 
            this.PrecioLabel.AutoSize = true;
            this.PrecioLabel.Location = new System.Drawing.Point(234, 22);
            this.PrecioLabel.Name = "PrecioLabel";
            this.PrecioLabel.Size = new System.Drawing.Size(37, 13);
            this.PrecioLabel.TabIndex = 3;
            this.PrecioLabel.Text = "Precio";
            // 
            // preciotxtb
            // 
            this.preciotxtb.Location = new System.Drawing.Point(277, 19);
            this.preciotxtb.Name = "preciotxtb";
            this.preciotxtb.Size = new System.Drawing.Size(100, 20);
            this.preciotxtb.TabIndex = 2;
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
            // porctxtb
            // 
            this.porctxtb.Location = new System.Drawing.Point(71, 52);
            this.porctxtb.Name = "porctxtb";
            this.porctxtb.Size = new System.Drawing.Size(108, 20);
            this.porctxtb.TabIndex = 4;
            // 
            // Buscarbtn
            // 
            this.Buscarbtn.Location = new System.Drawing.Point(296, 53);
            this.Buscarbtn.Name = "Buscarbtn";
            this.Buscarbtn.Size = new System.Drawing.Size(81, 20);
            this.Buscarbtn.TabIndex = 6;
            this.Buscarbtn.Text = "Buscar";
            this.Buscarbtn.UseVisualStyleBackColor = true;
            this.Buscarbtn.Click += new System.EventHandler(this.Buscarbtn_Click);
            // 
            // button1
            // 
            this.button1.Image = global::WindowsFormsApplication1.Properties.Resources.delete_icon;
            this.button1.Location = new System.Drawing.Point(52, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(36, 33);
            this.button1.TabIndex = 6;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Modificarbtn
            // 
            this.Modificarbtn.Image = global::WindowsFormsApplication1.Properties.Resources.modifyPage;
            this.Modificarbtn.Location = new System.Drawing.Point(94, 7);
            this.Modificarbtn.Name = "Modificarbtn";
            this.Modificarbtn.Size = new System.Drawing.Size(36, 33);
            this.Modificarbtn.TabIndex = 4;
            this.Modificarbtn.UseVisualStyleBackColor = true;
            // 
            // Altabtn
            // 
            this.Altabtn.Image = global::WindowsFormsApplication1.Properties.Resources.Button_New_icon;
            this.Altabtn.Location = new System.Drawing.Point(10, 7);
            this.Altabtn.Name = "Altabtn";
            this.Altabtn.Size = new System.Drawing.Size(36, 33);
            this.Altabtn.TabIndex = 3;
            this.Altabtn.UseVisualStyleBackColor = true;
            // 
            // limpiarbtn
            // 
            this.limpiarbtn.Location = new System.Drawing.Point(207, 53);
            this.limpiarbtn.Name = "limpiarbtn";
            this.limpiarbtn.Size = new System.Drawing.Size(81, 20);
            this.limpiarbtn.TabIndex = 7;
            this.limpiarbtn.Text = "Limpiar";
            this.limpiarbtn.UseVisualStyleBackColor = true;
            this.limpiarbtn.Click += new System.EventHandler(this.limpiarbtn_Click);
            // 
            // VisilidadesDG
            // 
            this.VisilidadesDG.AutoGenerateColumns = false;
            this.VisilidadesDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.VisilidadesDG.DataSource = this.visibilidadesDSBindingSource;
            this.VisilidadesDG.Location = new System.Drawing.Point(13, 140);
            this.VisilidadesDG.Name = "VisilidadesDG";
            this.VisilidadesDG.Size = new System.Drawing.Size(397, 277);
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
            this.ClientSize = new System.Drawing.Size(423, 429);
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
        private System.Windows.Forms.TextBox porctxtb;
        private System.Windows.Forms.Label PrecioLabel;
        private System.Windows.Forms.TextBox preciotxtb;
        private System.Windows.Forms.Label codLabel;
        private System.Windows.Forms.TextBox Codtxtb;
        private System.Windows.Forms.Button Altabtn;
        private System.Windows.Forms.Button Modificarbtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button limpiarbtn;
        private System.Windows.Forms.DataGridView VisilidadesDG;
        private System.Windows.Forms.BindingSource visibilidadesDSBindingSource;
        private VisibilidadesDS visibilidadesDS;
    }
}