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
            this.btnCobrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaSocio)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.BackColor = System.Drawing.Color.SteelBlue;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.White;
            this.lblNombre.Location = new System.Drawing.Point(15, 32);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(922, 33);
            this.lblNombre.TabIndex = 7;
            this.lblNombre.Text = "APARTADO SOCIO";
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(136)))), ((int)(((byte)(209)))));
            this.btnEditar.FlatAppearance.BorderSize = 2;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Location = new System.Drawing.Point(795, 153);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(142, 41);
            this.btnEditar.TabIndex = 9;
            this.btnEditar.Text = "Editar Socio";
            this.btnEditar.UseVisualStyleBackColor = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(136)))), ((int)(((byte)(209)))));
            this.btnEliminar.FlatAppearance.BorderSize = 2;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Location = new System.Drawing.Point(795, 284);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(142, 41);
            this.btnEliminar.TabIndex = 10;
            this.btnEliminar.Text = "Eliminar Socio";
            this.btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnRegistrarSocio
            // 
            this.btnRegistrarSocio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            this.btnRegistrarSocio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrarSocio.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(136)))), ((int)(((byte)(209)))));
            this.btnRegistrarSocio.FlatAppearance.BorderSize = 2;
            this.btnRegistrarSocio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarSocio.Location = new System.Drawing.Point(795, 89);
            this.btnRegistrarSocio.Name = "btnRegistrarSocio";
            this.btnRegistrarSocio.Size = new System.Drawing.Size(142, 41);
            this.btnRegistrarSocio.TabIndex = 11;
            this.btnRegistrarSocio.Text = "Registrar Socio";
            this.btnRegistrarSocio.UseVisualStyleBackColor = false;
            this.btnRegistrarSocio.Click += new System.EventHandler(this.btnRegistrarSocio_Click);
            // 
            // dgvListaSocio
            // 
            this.dgvListaSocio.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvListaSocio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaSocio.Location = new System.Drawing.Point(18, 89);
            this.dgvListaSocio.Name = "dgvListaSocio";
            this.dgvListaSocio.Size = new System.Drawing.Size(754, 459);
            this.dgvListaSocio.TabIndex = 12;
            this.dgvListaSocio.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListaSocio_CellContentClick);
            // 
            // btnAtras
            // 
            this.btnAtras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            this.btnAtras.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAtras.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(136)))), ((int)(((byte)(209)))));
            this.btnAtras.FlatAppearance.BorderSize = 2;
            this.btnAtras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtras.Location = new System.Drawing.Point(795, 350);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(142, 41);
            this.btnAtras.TabIndex = 13;
            this.btnAtras.Text = "Atrás";
            this.btnAtras.UseVisualStyleBackColor = false;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // btnCobrar
            // 
            this.btnCobrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            this.btnCobrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCobrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(136)))), ((int)(((byte)(209)))));
            this.btnCobrar.FlatAppearance.BorderSize = 2;
            this.btnCobrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCobrar.Location = new System.Drawing.Point(795, 218);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Size = new System.Drawing.Size(142, 41);
            this.btnCobrar.TabIndex = 14;
            this.btnCobrar.Text = "Cobrar Cuota";
            this.btnCobrar.UseVisualStyleBackColor = false;
            this.btnCobrar.Click += new System.EventHandler(this.btnCobrar_Click);
            // 
            // frmApartadoSocio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(965, 569);
            this.Controls.Add(this.btnCobrar);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.dgvListaSocio);
            this.Controls.Add(this.btnRegistrarSocio);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.lblNombre);
            this.Name = "frmApartadoSocio";
            this.Text = "Apartado Socio";
            this.Load += new System.EventHandler(this.frmApartadoSocio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaSocio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnRegistrarSocio;
        private System.Windows.Forms.DataGridView dgvListaSocio;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Button btnCobrar;
    }
}