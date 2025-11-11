namespace ClubDeportivo
{
    partial class frmListaCuotaVencida
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
            this.dgvListaCuotaVencida = new System.Windows.Forms.DataGridView();
            this.btnActulizarCuota = new System.Windows.Forms.Button();
            this.btnAtras = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaCuotaVencida)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListaCuotaVencida
            // 
            this.dgvListaCuotaVencida.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvListaCuotaVencida.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaCuotaVencida.Location = new System.Drawing.Point(16, 67);
            this.dgvListaCuotaVencida.Name = "dgvListaCuotaVencida";
            this.dgvListaCuotaVencida.Size = new System.Drawing.Size(599, 352);
            this.dgvListaCuotaVencida.TabIndex = 0;
            // 
            // btnActulizarCuota
            // 
            this.btnActulizarCuota.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            this.btnActulizarCuota.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActulizarCuota.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(136)))), ((int)(((byte)(209)))));
            this.btnActulizarCuota.FlatAppearance.BorderSize = 2;
            this.btnActulizarCuota.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActulizarCuota.Location = new System.Drawing.Point(633, 311);
            this.btnActulizarCuota.Name = "btnActulizarCuota";
            this.btnActulizarCuota.Size = new System.Drawing.Size(142, 41);
            this.btnActulizarCuota.TabIndex = 7;
            this.btnActulizarCuota.Text = "Actualizar Pago";
            this.btnActulizarCuota.UseVisualStyleBackColor = false;
            this.btnActulizarCuota.Click += new System.EventHandler(this.btnActulizarCuota_Click);
            // 
            // btnAtras
            // 
            this.btnAtras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            this.btnAtras.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAtras.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(136)))), ((int)(((byte)(209)))));
            this.btnAtras.FlatAppearance.BorderSize = 2;
            this.btnAtras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtras.ForeColor = System.Drawing.Color.Black;
            this.btnAtras.Location = new System.Drawing.Point(633, 378);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(142, 41);
            this.btnAtras.TabIndex = 8;
            this.btnAtras.Text = "Atrás";
            this.btnAtras.UseVisualStyleBackColor = false;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(174, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(334, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Listado de Cuotas Vencidas de Un socio";
            // 
            // frmListaCuotaVencida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.btnActulizarCuota);
            this.Controls.Add(this.dgvListaCuotaVencida);
            this.Name = "frmListaCuotaVencida";
            this.Text = "Cuotas Vencidas de un socio";
            this.Load += new System.EventHandler(this.frmListaCuotaVencida_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaCuotaVencida)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListaCuotaVencida;
        private System.Windows.Forms.Button btnActulizarCuota;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Label label1;
    }
}