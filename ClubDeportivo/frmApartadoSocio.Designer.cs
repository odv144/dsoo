namespace ClubDeportivo
{
    partial class frmApartadoSocio
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
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnRegistrarSocio = new System.Windows.Forms.Button();
            this.dgvListaSocio = new System.Windows.Forms.DataGridView();
            this.btnAtras = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaSocio)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(21, 24);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(95, 13);
            this.lblNombre.TabIndex = 7;
            this.lblNombre.Text = "Apartado de Socio";
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(772, 219);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(210, 53);
            this.btnEditar.TabIndex = 9;
            this.btnEditar.Text = "Editar Socio";
            this.btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(772, 352);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(210, 52);
            this.btnEliminar.TabIndex = 10;
            this.btnEliminar.Text = "Eliminar Socio";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnRegistrarSocio
            // 
            this.btnRegistrarSocio.Location = new System.Drawing.Point(772, 106);
            this.btnRegistrarSocio.Name = "btnRegistrarSocio";
            this.btnRegistrarSocio.Size = new System.Drawing.Size(210, 54);
            this.btnRegistrarSocio.TabIndex = 11;
            this.btnRegistrarSocio.Text = "Registrar Socio";
            this.btnRegistrarSocio.UseVisualStyleBackColor = true;
            this.btnRegistrarSocio.Click += new System.EventHandler(this.btnRegistrarSocio_Click);
            // 
            // dgvListaSocio
            // 
            this.dgvListaSocio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaSocio.Location = new System.Drawing.Point(12, 106);
            this.dgvListaSocio.Name = "dgvListaSocio";
            this.dgvListaSocio.Size = new System.Drawing.Size(754, 499);
            this.dgvListaSocio.TabIndex = 12;
            this.dgvListaSocio.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListaSocio_CellContentClick);
            // 
            // btnAtras
            // 
            this.btnAtras.Location = new System.Drawing.Point(772, 453);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(210, 52);
            this.btnAtras.TabIndex = 13;
            this.btnAtras.Text = "Atrás";
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // frmApartadoSocio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 617);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.dgvListaSocio);
            this.Controls.Add(this.btnRegistrarSocio);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.lblNombre);
            this.Name = "frmApartadoSocio";
            this.Text = "frmApartadoSocio";
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaSocio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnRegistrarSocio;
        private System.Windows.Forms.DataGridView dgvListaSocio;
        private System.Windows.Forms.Button btnAtras;
    }
}