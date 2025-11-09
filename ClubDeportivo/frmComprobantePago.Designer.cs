namespace ClubDeportivo
{
    partial class frmComprobantePago
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
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblImporte = new System.Windows.Forms.Label();
            this.lblImporteCuota = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblAyN = new System.Windows.Forms.Label();
            this.lblNro = new System.Windows.Forms.Label();
            this.lblNroSocio = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblUsuario
            // 
            this.lblUsuario.BackColor = System.Drawing.Color.SteelBlue;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(11, 22);
            this.lblUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(425, 33);
            this.lblUsuario.TabIndex = 17;
            this.lblUsuario.Text = "PAGO DE NO SOCIO";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblImporte
            // 
            this.lblImporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImporte.ForeColor = System.Drawing.Color.Black;
            this.lblImporte.Location = new System.Drawing.Point(333, 165);
            this.lblImporte.Name = "lblImporte";
            this.lblImporte.Size = new System.Drawing.Size(103, 25);
            this.lblImporte.TabIndex = 16;
            this.lblImporte.Text = "$ 25.000";
            this.lblImporte.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblImporteCuota
            // 
            this.lblImporteCuota.AutoSize = true;
            this.lblImporteCuota.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImporteCuota.ForeColor = System.Drawing.Color.Black;
            this.lblImporteCuota.Location = new System.Drawing.Point(12, 177);
            this.lblImporteCuota.Name = "lblImporteCuota";
            this.lblImporteCuota.Size = new System.Drawing.Size(112, 13);
            this.lblImporteCuota.TabIndex = 15;
            this.lblImporteCuota.Text = "Importe de  Cuota:";
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.SteelBlue;
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.Color.White;
            this.btnImprimir.Location = new System.Drawing.Point(277, 211);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(159, 28);
            this.btnImprimir.TabIndex = 14;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.Black;
            this.lblNombre.Location = new System.Drawing.Point(12, 140);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(113, 13);
            this.lblNombre.TabIndex = 13;
            this.lblNombre.Text = "Apellido y Nombre:";
            // 
            // lblAyN
            // 
            this.lblAyN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAyN.ForeColor = System.Drawing.Color.Black;
            this.lblAyN.Location = new System.Drawing.Point(140, 128);
            this.lblAyN.Name = "lblAyN";
            this.lblAyN.Size = new System.Drawing.Size(296, 25);
            this.lblAyN.TabIndex = 12;
            this.lblAyN.Text = "Virili Omar Dario";
            this.lblAyN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNro
            // 
            this.lblNro.AutoSize = true;
            this.lblNro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNro.ForeColor = System.Drawing.Color.Black;
            this.lblNro.Location = new System.Drawing.Point(388, 103);
            this.lblNro.Name = "lblNro";
            this.lblNro.Size = new System.Drawing.Size(49, 13);
            this.lblNro.TabIndex = 11;
            this.lblNro.Text = "123456";
            this.lblNro.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNroSocio
            // 
            this.lblNroSocio.AutoSize = true;
            this.lblNroSocio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroSocio.ForeColor = System.Drawing.Color.Black;
            this.lblNroSocio.Location = new System.Drawing.Point(12, 109);
            this.lblNroSocio.Name = "lblNroSocio";
            this.lblNroSocio.Size = new System.Drawing.Size(61, 13);
            this.lblNroSocio.TabIndex = 10;
            this.lblNroSocio.Text = "N° Socio:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Fecha Pago:";
            // 
            // lblFecha
            // 
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.Black;
            this.lblFecha.Location = new System.Drawing.Point(210, 65);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(226, 25);
            this.lblFecha.TabIndex = 19;
            this.lblFecha.Text = "Fecha de Hoy";
            this.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmComprobantePago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(454, 265);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.lblImporte);
            this.Controls.Add(this.lblImporteCuota);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblAyN);
            this.Controls.Add(this.lblNro);
            this.Controls.Add(this.lblNroSocio);
            this.Name = "frmComprobantePago";
            this.Text = "COMPROBANTE DE PAGO";
            this.Load += new System.EventHandler(this.frmComprobantePago_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblImporte;
        private System.Windows.Forms.Label lblImporteCuota;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblAyN;
        private System.Windows.Forms.Label lblNro;
        private System.Windows.Forms.Label lblNroSocio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFecha;
    }
}