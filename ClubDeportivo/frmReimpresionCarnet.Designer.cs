namespace ClubDeportivo
{
    partial class frmReimpresionCarnet
    {
        private System.ComponentModel.IContainer components = null;

        // Limpieza de recursos:

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code


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
            this.label1 = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblFecha = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNroSocio
            // 
            this.lblNroSocio.AutoSize = true;
            this.lblNroSocio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblNroSocio.ForeColor = System.Drawing.Color.Black;
            this.lblNroSocio.Location = new System.Drawing.Point(13, 122);
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
            this.lblNro.Location = new System.Drawing.Point(74, 122);
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
            this.lblAyN.Location = new System.Drawing.Point(260, 150);
            this.lblAyN.Name = "lblAyN";
            this.lblAyN.Size = new System.Drawing.Size(128, 17);
            this.lblAyN.TabIndex = 3;
            this.lblAyN.Text = "Virili Omar Dario";
            this.lblAyN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblAyN.Click += new System.EventHandler(this.lblAyN_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblNombre.ForeColor = System.Drawing.Color.Black;
            this.lblNombre.Location = new System.Drawing.Point(13, 154);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(113, 13);
            this.lblNombre.TabIndex = 4;
            this.lblNombre.Text = "Apellido y Nombre:";
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.SteelBlue;
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnImprimir.ForeColor = System.Drawing.Color.White;
            this.btnImprimir.Location = new System.Drawing.Point(263, 210);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(159, 28);
            this.btnImprimir.TabIndex = 5;
            this.btnImprimir.Text = "IMPRIMIR";
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // lblImporteCuota
            // 
            this.lblImporteCuota.AutoSize = true;
            this.lblImporteCuota.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblImporteCuota.ForeColor = System.Drawing.Color.Black;
            this.lblImporteCuota.Location = new System.Drawing.Point(13, 186);
            this.lblImporteCuota.Name = "lblImporteCuota";
            this.lblImporteCuota.Size = new System.Drawing.Size(112, 13);
            this.lblImporteCuota.TabIndex = 6;
            this.lblImporteCuota.Text = "Importe de  Cuota:";
            // 
            // lblImporte
            // 
            this.lblImporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblImporte.ForeColor = System.Drawing.Color.Black;
            this.lblImporte.Location = new System.Drawing.Point(319, 180);
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
            this.label5.Location = new System.Drawing.Point(16, 9);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(406, 33);
            this.label5.TabIndex = 9;
            this.label5.Text = "REIMPRESION DE CARNET";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(13, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "D.N.I.:";
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(77, 83);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(112, 20);
            this.txtDni.TabIndex = 11;
            this.txtDni.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Location = new System.Drawing.Point(195, 80);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 25);
            this.btnBuscar.TabIndex = 12;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblFecha.ForeColor = System.Drawing.Color.Black;
            this.lblFecha.Location = new System.Drawing.Point(12, 58);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(46, 13);
            this.lblFecha.TabIndex = 13;
            this.lblFecha.Text = "Fecha:";
            // 
            // frmReimpresionCarnet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(434, 250);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblImporte);
            this.Controls.Add(this.lblImporteCuota);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblAyN);
            this.Controls.Add(this.lblNro);
            this.Controls.Add(this.lblNroSocio);
            this.Name = "frmReimpresionCarnet";
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblFecha;
    }
}