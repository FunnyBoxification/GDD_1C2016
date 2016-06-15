namespace WindowsFormsApplication1.Generar_Publicación
{
    partial class GenerarPublicacion
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
            this.Tipo = new System.Windows.Forms.Label();
            this.Filtros = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.tbxDesc = new System.Windows.Forms.TextBox();
            this.tbxCod = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxTipo = new System.Windows.Forms.ComboBox();
            this.dsPublicacionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsPublicaciones = new WindowsFormsApplication1.Generar_Publicación.dsPublicaciones();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Filtros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsPublicacionesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPublicaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Tipo
            // 
            this.Tipo.AutoSize = true;
            this.Tipo.Location = new System.Drawing.Point(26, 33);
            this.Tipo.Name = "Tipo";
            this.Tipo.Size = new System.Drawing.Size(28, 13);
            this.Tipo.TabIndex = 0;
            this.Tipo.Text = "Tipo";
            // 
            // Filtros
            // 
            this.Filtros.Controls.Add(this.btnBuscar);
            this.Filtros.Controls.Add(this.btnLimpiar);
            this.Filtros.Controls.Add(this.tbxDesc);
            this.Filtros.Controls.Add(this.tbxCod);
            this.Filtros.Controls.Add(this.label);
            this.Filtros.Controls.Add(this.label1);
            this.Filtros.Controls.Add(this.cbxTipo);
            this.Filtros.Controls.Add(this.Tipo);
            this.Filtros.Location = new System.Drawing.Point(12, 12);
            this.Filtros.Name = "Filtros";
            this.Filtros.Size = new System.Drawing.Size(1051, 79);
            this.Filtros.TabIndex = 1;
            this.Filtros.TabStop = false;
            this.Filtros.Text = "Filtros";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(970, 28);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 8;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(878, 29);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 7;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // tbxDesc
            // 
            this.tbxDesc.Location = new System.Drawing.Point(573, 29);
            this.tbxDesc.Name = "tbxDesc";
            this.tbxDesc.Size = new System.Drawing.Size(286, 20);
            this.tbxDesc.TabIndex = 6;
            // 
            // tbxCod
            // 
            this.tbxCod.Location = new System.Drawing.Point(335, 31);
            this.tbxCod.Name = "tbxCod";
            this.tbxCod.Size = new System.Drawing.Size(143, 20);
            this.tbxCod.TabIndex = 5;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(504, 32);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(63, 13);
            this.label.TabIndex = 3;
            this.label.Text = "Descripcion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(216, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Código de Publicación";
            // 
            // cbxTipo
            // 
            this.cbxTipo.FormattingEnabled = true;
            this.cbxTipo.Location = new System.Drawing.Point(60, 30);
            this.cbxTipo.Name = "cbxTipo";
            this.cbxTipo.Size = new System.Drawing.Size(121, 21);
            this.cbxTipo.TabIndex = 1;
            // 
            // dsPublicacionesBindingSource
            // 
            this.dsPublicacionesBindingSource.DataSource = this.dsPublicaciones;
            this.dsPublicacionesBindingSource.Position = 0;
            // 
            // dsPublicaciones
            // 
            this.dsPublicaciones.DataSetName = "dsPublicaciones";
            this.dsPublicaciones.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(890, 615);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(167, 23);
            this.btnGenerar.TabIndex = 3;
            this.btnGenerar.Text = "Generar Publicacion";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 97);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1051, 512);
            this.dataGridView1.TabIndex = 4;
            // 
            // GenerarPublicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 662);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.Filtros);
            this.Name = "GenerarPublicacion";
            this.Text = "Generar Publicacion";
            this.Filtros.ResumeLayout(false);
            this.Filtros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsPublicacionesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPublicaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Tipo;
        private System.Windows.Forms.GroupBox Filtros;
        private System.Windows.Forms.TextBox tbxCod;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxTipo;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.TextBox tbxDesc;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.BindingSource dsPublicacionesBindingSource;
        private dsPublicaciones dsPublicaciones;
        private System.Windows.Forms.DataGridView dataGridView1;
       // private System.Windows.Forms.BindingSource dsPublicacionesBindingSource;
       // private dsPublicaciones dsPublicaciones;
    }
}