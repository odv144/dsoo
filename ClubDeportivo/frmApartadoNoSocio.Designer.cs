namespace ClubDeportivo
{
    partial class frmApartadoNoSocio
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
            this.dgvListaNoSocio = new System.Windows.Forms.DataGridView();
            this.btnRegistrarNoSocio = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAtras = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaNoSocio)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Apartado No Socios";
            // 
            // dgvListaNoSocio
            // 
            this.dgvListaNoSocio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaNoSocio.Location = new System.Drawing.Point(16, 77);
            this.dgvListaNoSocio.Name = "dgvListaNoSocio";
            this.dgvListaNoSocio.Size = new System.Drawing.Size(746, 493);
            this.dgvListaNoSocio.TabIndex = 1;
            this.dgvListaNoSocio.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListaNoSocio_CellContentClick);
            // 
            // btnRegistrarNoSocio
            // 
            this.btnRegistrarNoSocio.Location = new System.Drawing.Point(797, 77);
            this.btnRegistrarNoSocio.Name = "btnRegistrarNoSocio";
            this.btnRegistrarNoSocio.Size = new System.Drawing.Size(228, 62);
            this.btnRegistrarNoSocio.TabIndex = 2;
            this.btnRegistrarNoSocio.Text = "Registrar No Socio";
            this.btnRegistrarNoSocio.UseVisualStyleBackColor = true;
            this.btnRegistrarNoSocio.Click += new System.EventHandler(this.btnRegistrarNoSocio_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(797, 178);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(228, 55);
            this.btnEditar.TabIndex = 3;
            this.btnEditar.Text = "Editar No Socios";
            this.btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(797, 276);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(228, 58);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Eliminar Socio";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnAtras
            // 
            this.btnAtras.Location = new System.Drawing.Point(797, 393);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(228, 55);
            this.btnAtras.TabIndex = 5;
            this.btnAtras.Text = "Atrás";
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // frmApartadoNoSocio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 600);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnRegistrarNoSocio);
            this.Controls.Add(this.dgvListaNoSocio);
            this.Controls.Add(this.label1);
            this.Name = "frmApartadoNoSocio";
            this.Text = "frmApartadoNoSocio";
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaNoSocio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvListaNoSocio;
        private System.Windows.Forms.Button btnRegistrarNoSocio;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAtras;
    }
}