namespace ClubDeportivo
{
    partial class frmCarnetPrinter
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
            this.lblNroSocio = new System.Windows.Forms.Label();
            this.lblNro = new System.Windows.Forms.Label();
            this.lblAyN = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.lblImporteCuota = new System.Windows.Forms.Label();
            this.lblImporte = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNroSocio
            // 
            this.lblNroSocio.AutoSize = true;
            this.lblNroSocio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblNroSocio.ForeColor = System.Drawing.Color.Black;
            this.lblNroSocio.Location = new System.Drawing.Point(18, 65);
            this.lblNroSocio.Name = "lblNroSocio";
            this.lblNroSocio.Size = new System.Drawing.Size(61, 13);
            this.lblNroSocio.TabIndex = 1;
            this.lblNroSocio.Text = "N° Socio:";
            // 
            // lblNro
            // 
            this.lblNro.AutoSize = true;
            this.lblNro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblNro.ForeColor = System.Drawing.Color.Black;
            this.lblNro.Location = new System.Drawing.Point(98, 65);
            this.lblNro.Name = "lblNro";
            this.lblNro.Size = new System.Drawing.Size(49, 13);
            this.lblNro.TabIndex = 2;
            this.lblNro.Text = "123456";
            this.lblNro.Click += new System.EventHandler(this.lblNro_Click);
            // 
            // lblAyN
            // 
            this.lblAyN.AutoSize = true;
            this.lblAyN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblAyN.ForeColor = System.Drawing.Color.Black;
            this.lblAyN.Location = new System.Drawing.Point(260, 92);
            this.lblAyN.Name = "lblAyN";
            this.lblAyN.Size = new System.Drawing.Size(128, 17);
            this.lblAyN.TabIndex = 3;
            this.lblAyN.Text = "Virili Omar Dario";
            this.lblAyN.Click += new System.EventHandler(this.lblAyN_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblNombre.ForeColor = System.Drawing.Color.Black;
            this.lblNombre.Location = new System.Drawing.Point(18, 96);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(113, 13);
            this.lblNombre.TabIndex = 4;
            this.lblNombre.Text = "Apellido y Nombre:";
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.SteelBlue;
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.Color.White;
            this.btnImprimir.Location = new System.Drawing.Point(262, 168);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(159, 28);
            this.btnImprimir.TabIndex = 5;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // lblImporteCuota
            // 
            this.lblImporteCuota.AutoSize = true;
            this.lblImporteCuota.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblImporteCuota.ForeColor = System.Drawing.Color.Black;
            this.lblImporteCuota.Location = new System.Drawing.Point(19, 133);
            this.lblImporteCuota.Name = "lblImporteCuota";
            this.lblImporteCuota.Size = new System.Drawing.Size(112, 13);
            this.lblImporteCuota.TabIndex = 6;
            this.lblImporteCuota.Text = "Importe de  Cuota:";
            // 
            // lblImporte
            // 
            this.lblImporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblImporte.ForeColor = System.Drawing.Color.Black;
            this.lblImporte.Location = new System.Drawing.Point(318, 127);
            this.lblImporte.Name = "lblImporte";
            this.lblImporte.Size = new System.Drawing.Size(103, 25);
            this.lblImporte.TabIndex = 7;
            this.lblImporte.Text = "$ 25.000";
            this.lblImporte.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.SteelBlue;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(17, 9);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(404, 33);
            this.label5.TabIndex = 9;
            this.label5.Text = "CARNET DE SOCIO";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmCarnetPrinter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(434, 211);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblImporte);
            this.Controls.Add(this.lblImporteCuota);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblAyN);
            this.Controls.Add(this.lblNro);
            this.Controls.Add(this.lblNroSocio);
            this.Name = "frmCarnetPrinter";
            this.Text = "Carnet";
            this.Load += new System.EventHandler(this.frmCarnetPrinter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblNroSocio;
        private System.Windows.Forms.Label lblNro;
        private System.Windows.Forms.Label lblAyN;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Label lblImporteCuota;
        private System.Windows.Forms.Label lblImporte;
        private System.Windows.Forms.Label label5;
    }
}