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
            this.dgvListaNoSocio = new System.Windows.Forms.DataGridView();
            this.btnRegistrarNoSocio = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAtras = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaNoSocio)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListaNoSocio
            // 
            this.dgvListaNoSocio.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvListaNoSocio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaNoSocio.Location = new System.Drawing.Point(19, 77);
            this.dgvListaNoSocio.Name = "dgvListaNoSocio";
            this.dgvListaNoSocio.Size = new System.Drawing.Size(746, 431);
            this.dgvListaNoSocio.TabIndex = 1;
            this.dgvListaNoSocio.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListaNoSocio_CellContentClick);
            // 
            // btnRegistrarNoSocio
            // 
            this.btnRegistrarNoSocio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            this.btnRegistrarNoSocio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrarNoSocio.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(136)))), ((int)(((byte)(209)))));
            this.btnRegistrarNoSocio.FlatAppearance.BorderSize = 2;
            this.btnRegistrarNoSocio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarNoSocio.Location = new System.Drawing.Point(797, 77);
            this.btnRegistrarNoSocio.Name = "btnRegistrarNoSocio";
            this.btnRegistrarNoSocio.Size = new System.Drawing.Size(142, 41);
            this.btnRegistrarNoSocio.TabIndex = 2;
            this.btnRegistrarNoSocio.Text = "Registrar No Socio";
            this.btnRegistrarNoSocio.UseVisualStyleBackColor = false;
            this.btnRegistrarNoSocio.Click += new System.EventHandler(this.btnRegistrarNoSocio_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(136)))), ((int)(((byte)(209)))));
            this.btnEditar.FlatAppearance.BorderSize = 2;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Location = new System.Drawing.Point(797, 142);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(142, 41);
            this.btnEditar.TabIndex = 3;
            this.btnEditar.Text = "Editar No Socios";
            this.btnEditar.UseVisualStyleBackColor = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(136)))), ((int)(((byte)(209)))));
            this.btnEliminar.FlatAppearance.BorderSize = 2;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Location = new System.Drawing.Point(797, 204);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(142, 41);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Revisar Quitar?";
            this.btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnAtras
            // 
            this.btnAtras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            this.btnAtras.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAtras.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(136)))), ((int)(((byte)(209)))));
            this.btnAtras.FlatAppearance.BorderSize = 2;
            this.btnAtras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtras.Location = new System.Drawing.Point(797, 269);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(142, 41);
            this.btnAtras.TabIndex = 5;
            this.btnAtras.Text = "Atrás";
            this.btnAtras.UseVisualStyleBackColor = false;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(19, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(920, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "APARTADO NO SOCIO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // frmApartadoNoSocio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(962, 525);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnRegistrarNoSocio);
            this.Controls.Add(this.dgvListaNoSocio);
            this.Controls.Add(this.label1);
            this.Name = "frmApartadoNoSocio";
            this.Text = "Apartado No Socio";
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaNoSocio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvListaNoSocio;
        private System.Windows.Forms.Button btnRegistrarNoSocio;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Label label1;
    }
}