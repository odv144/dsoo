namespace ClubDeportivo
{
    partial class frmControlVencimiento
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
            this.dgvVencimientos = new System.Windows.Forms.DataGridView();
            this.Actualizar = new System.Windows.Forms.Button();
            this.btnAtras = new System.Windows.Forms.Button();
            this.cmbFiltroVencimiento = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVencimientos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvVencimientos
            // 
            this.dgvVencimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVencimientos.Location = new System.Drawing.Point(29, 97);
            this.dgvVencimientos.Name = "dgvVencimientos";
            this.dgvVencimientos.Size = new System.Drawing.Size(587, 321);
            this.dgvVencimientos.TabIndex = 0;
            this.dgvVencimientos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVencimientos_CellContentClick);
            // 
            // Actualizar
            // 
            this.Actualizar.Location = new System.Drawing.Point(649, 285);
            this.Actualizar.Name = "Actualizar";
            this.Actualizar.Size = new System.Drawing.Size(139, 36);
            this.Actualizar.TabIndex = 1;
            this.Actualizar.Text = "Actualizar";
            this.Actualizar.UseVisualStyleBackColor = true;
            this.Actualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnAtras
            // 
            this.btnAtras.Location = new System.Drawing.Point(649, 382);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(139, 36);
            this.btnAtras.TabIndex = 2;
            this.btnAtras.Text = "Atrás";
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // cmbFiltroVencimiento
            // 
            this.cmbFiltroVencimiento.FormattingEnabled = true;
            this.cmbFiltroVencimiento.Location = new System.Drawing.Point(649, 123);
            this.cmbFiltroVencimiento.Name = "cmbFiltroVencimiento";
            this.cmbFiltroVencimiento.Size = new System.Drawing.Size(139, 21);
            this.cmbFiltroVencimiento.TabIndex = 3;
            this.cmbFiltroVencimiento.SelectedValueChanged += new System.EventHandler(this.cmbFiltroVencimiento_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(646, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Filtro de Vencimiento";
            // 
            // frmControlVencimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbFiltroVencimiento);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.Actualizar);
            this.Controls.Add(this.dgvVencimientos);
            this.Name = "frmControlVencimiento";
            this.Text = "frmControlVencimiento";
            this.Load += new System.EventHandler(this.frmControlVencimiento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVencimientos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVencimientos;
        private System.Windows.Forms.Button Actualizar;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.ComboBox cmbFiltroVencimiento;
        private System.Windows.Forms.Label label1;
    }
}