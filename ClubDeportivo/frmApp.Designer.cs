namespace ClubDeportivo
{
    partial class frmApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmApp));
            this.btnCobro = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblSeccion = new System.Windows.Forms.Label();
            this.btnRegistroNoSocio = new System.Windows.Forms.Button();
            this.btnCuota = new System.Windows.Forms.Button();
            this.btnActividad = new System.Windows.Forms.Button();
            this.btnSocio = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCobro
            // 
            this.btnCobro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(154)))), ((int)(((byte)(180)))));
            this.btnCobro.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnCobro.ForeColor = System.Drawing.Color.White;
            this.btnCobro.Location = new System.Drawing.Point(372, 22);
            this.btnCobro.Name = "btnCobro";
            this.btnCobro.Size = new System.Drawing.Size(152, 59);
            this.btnCobro.TabIndex = 1;
            this.btnCobro.Text = "Cobrar";
            this.btnCobro.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(154)))), ((int)(((byte)(180)))));
            this.button2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(572, 22);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(152, 59);
            this.button2.TabIndex = 2;
            this.button2.Text = "Reeimpresión Carnet";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(154)))), ((int)(((byte)(180)))));
            this.button3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(772, 22);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(152, 59);
            this.button3.TabIndex = 3;
            this.button3.Text = "Listado Vencimientos";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(63, 104);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(804, 334);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(154)))), ((int)(((byte)(180)))));
            this.button1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(410, 379);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 59);
            this.button1.TabIndex = 5;
            this.button1.Text = "Salir";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblSeccion
            // 
            this.lblSeccion.AutoSize = true;
            this.lblSeccion.Location = new System.Drawing.Point(8, 4);
            this.lblSeccion.Name = "lblSeccion";
            this.lblSeccion.Size = new System.Drawing.Size(106, 13);
            this.lblSeccion.TabIndex = 6;
            this.lblSeccion.Text = "Inicio Sección como:";
            // 
            // btnRegistroNoSocio
            // 
            this.btnRegistroNoSocio.Location = new System.Drawing.Point(205, 22);
            this.btnRegistroNoSocio.Name = "btnRegistroNoSocio";
            this.btnRegistroNoSocio.Size = new System.Drawing.Size(141, 59);
            this.btnRegistroNoSocio.TabIndex = 7;
            this.btnRegistroNoSocio.Text = "RegistroNoSocio";
            this.btnRegistroNoSocio.UseVisualStyleBackColor = true;
            this.btnRegistroNoSocio.Click += new System.EventHandler(this.btnRegistroNoSocio_Click);
            // 
            // btnCuota
            // 
            this.btnCuota.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(154)))), ((int)(((byte)(180)))));
            this.btnCuota.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnCuota.ForeColor = System.Drawing.Color.White;
            this.btnCuota.Location = new System.Drawing.Point(12, 314);
            this.btnCuota.Name = "btnCuota";
            this.btnCuota.Size = new System.Drawing.Size(152, 59);
            this.btnCuota.TabIndex = 7;
            this.btnCuota.Text = "Gestion Cuota";
            this.btnCuota.UseVisualStyleBackColor = false;
            // 
            // btnActividad
            // 
            this.btnActividad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(154)))), ((int)(((byte)(180)))));
            this.btnActividad.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnActividad.ForeColor = System.Drawing.Color.White;
            this.btnActividad.Location = new System.Drawing.Point(12, 379);
            this.btnActividad.Name = "btnActividad";
            this.btnActividad.Size = new System.Drawing.Size(152, 59);
            this.btnActividad.TabIndex = 8;
            this.btnActividad.Text = "Gestion Actividades";
            this.btnActividad.UseVisualStyleBackColor = false;
            // 
            // btnSocio
            // 
            this.btnSocio.Location = new System.Drawing.Point(31, 27);
            this.btnSocio.Name = "btnSocio";
            this.btnSocio.Size = new System.Drawing.Size(156, 54);
            this.btnSocio.TabIndex = 9;
            this.btnSocio.Text = "Apartado Socio";
            this.btnSocio.UseVisualStyleBackColor = true;
            this.btnSocio.Click += new System.EventHandler(this.btnSocio_Click);
            // 
            // frmApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(241)))), ((int)(((byte)(244)))));
            this.ClientSize = new System.Drawing.Size(929, 450);
            this.Controls.Add(this.btnSocio);
            this.Controls.Add(this.btnRegistroNoSocio);
            this.Controls.Add(this.btnActividad);
            this.Controls.Add(this.btnCuota);
            this.Controls.Add(this.lblSeccion);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnCobro);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aplicación para Club Deportivo";
            this.Load += new System.EventHandler(this.frmApp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCobro;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblSeccion;
        private System.Windows.Forms.Button btnRegistroNoSocio;
        private System.Windows.Forms.Button btnCuota;
        private System.Windows.Forms.Button btnActividad;
        private System.Windows.Forms.Button btnSocio;
    }
}