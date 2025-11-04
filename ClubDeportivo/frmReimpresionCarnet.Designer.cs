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
            this.SuspendLayout();
            
            // lblNroSocio
            this.lblNroSocio.AutoSize = true;
            this.lblNroSocio.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroSocio.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblNroSocio.Location = new System.Drawing.Point(12, 105);
            this.lblNroSocio.Name = "lblNroSocio";
            this.lblNroSocio.Size = new System.Drawing.Size(93, 25);
            this.lblNroSocio.TabIndex = 1;
            this.lblNroSocio.Text = "N° Socio:";
            
            // lblNro
            this.lblNro.AutoSize = true;
            this.lblNro.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNro.ForeColor = System.Drawing.Color.Black;
            this.lblNro.Location = new System.Drawing.Point(111, 105);
            this.lblNro.Name = "lblNro";
            this.lblNro.Size = new System.Drawing.Size(78, 25);
            this.lblNro.TabIndex = 2;
            this.lblNro.Text = "123456";
            this.lblNro.Click += new System.EventHandler(this.lblNro_Click);
            
            // lblAyN
            this.lblAyN.AutoSize = true;
            this.lblAyN.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAyN.ForeColor = System.Drawing.Color.Black;
            this.lblAyN.Location = new System.Drawing.Point(203, 136);
            this.lblAyN.Name = "lblAyN";
            this.lblAyN.Size = new System.Drawing.Size(161, 25);
            this.lblAyN.TabIndex = 3;
            this.lblAyN.Text = "Virili Omar Dario";
            this.lblAyN.Click += new System.EventHandler(this.lblAyN_Click);
            
            // lblNombre
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblNombre.Location = new System.Drawing.Point(12, 136);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(185, 25);
            this.lblNombre.TabIndex = 4;
            this.lblNombre.Text = "Apellido y Nombre:";
            
            // btnImprimir
            this.btnImprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(154)))), ((int)(((byte)(180)))));
            this.btnImprimir.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.Color.White;
            this.btnImprimir.Location = new System.Drawing.Point(274, 221);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(159, 28);
            this.btnImprimir.TabIndex = 5;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            
            // lblImporteCuota 
            this.lblImporteCuota.AutoSize = true;
            this.lblImporteCuota.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImporteCuota.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblImporteCuota.Location = new System.Drawing.Point(12, 173);
            this.lblImporteCuota.Name = "lblImporteCuota";
            this.lblImporteCuota.Size = new System.Drawing.Size(180, 25);
            this.lblImporteCuota.TabIndex = 6;
            this.lblImporteCuota.Text = "Importe de  Cuota:";
            
            // lblImporte
            this.lblImporte.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImporte.ForeColor = System.Drawing.Color.Black;
            this.lblImporte.Location = new System.Drawing.Point(198, 173);
            this.lblImporte.Name = "lblImporte";
            this.lblImporte.Size = new System.Drawing.Size(103, 25);
            this.lblImporte.TabIndex = 7;
            this.lblImporte.Text = "$ 25.000";
            this.lblImporte.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            
            // label5
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(68)))), ((int)(((byte)(94)))));
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(-2, 9);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(435, 33);
            this.label5.TabIndex = 9;
            this.label5.Text = "REIMPRESION DE CARNET";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            
            // label1
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(12, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "D.N.I.:";
            
            // txtDni
            this.txtDni.Location = new System.Drawing.Point(85, 74);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(112, 20);
            this.txtDni.TabIndex = 11;
            this.txtDni.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            
            // btnBuscar
            this.btnBuscar.Location = new System.Drawing.Point(217, 71);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 12;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            
            // frmReimpresionCarnet
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(241)))), ((int)(((byte)(244)))));
            this.ClientSize = new System.Drawing.Size(434, 250);
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
    }
}