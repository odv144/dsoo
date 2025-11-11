namespace ClubDeportivo
{
    partial class frmControlVencimiento
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
            this.dgvVencimientos = new System.Windows.Forms.DataGridView();
            this.Actualizar = new System.Windows.Forms.Button();
            this.btnAtras = new System.Windows.Forms.Button();
            this.cmbFiltroVencimiento = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTituloPrincipal = new System.Windows.Forms.Label();
            this.btnCobrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVencimientos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvVencimientos
            // 
            this.dgvVencimientos.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvVencimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVencimientos.Location = new System.Drawing.Point(30, 73);
            this.dgvVencimientos.Name = "dgvVencimientos";
            this.dgvVencimientos.Size = new System.Drawing.Size(966, 355);
            this.dgvVencimientos.TabIndex = 0;
            // 
            // Actualizar
            // 
            this.Actualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            this.Actualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Actualizar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(136)))), ((int)(((byte)(209)))));
            this.Actualizar.FlatAppearance.BorderSize = 2;
            this.Actualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Actualizar.ForeColor = System.Drawing.Color.Black;
            this.Actualizar.Location = new System.Drawing.Point(1015, 306);
            this.Actualizar.Name = "Actualizar";
            this.Actualizar.Size = new System.Drawing.Size(142, 41);
            this.Actualizar.TabIndex = 1;
            this.Actualizar.Text = "Actualizar";
            this.Actualizar.UseVisualStyleBackColor = false;
            this.Actualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnAtras
            // 
            this.btnAtras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            this.btnAtras.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAtras.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(136)))), ((int)(((byte)(209)))));
            this.btnAtras.FlatAppearance.BorderSize = 2;
            this.btnAtras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtras.ForeColor = System.Drawing.Color.Black;
            this.btnAtras.Location = new System.Drawing.Point(1015, 353);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(142, 41);
            this.btnAtras.TabIndex = 2;
            this.btnAtras.Text = "Atrás";
            this.btnAtras.UseVisualStyleBackColor = false;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // cmbFiltroVencimiento
            // 
            this.cmbFiltroVencimiento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            this.cmbFiltroVencimiento.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmbFiltroVencimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFiltroVencimiento.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.cmbFiltroVencimiento.FormattingEnabled = true;
            this.cmbFiltroVencimiento.Location = new System.Drawing.Point(1015, 103);
            this.cmbFiltroVencimiento.Name = "cmbFiltroVencimiento";
            this.cmbFiltroVencimiento.Size = new System.Drawing.Size(142, 21);
            this.cmbFiltroVencimiento.TabIndex = 3;
            this.cmbFiltroVencimiento.SelectedValueChanged += new System.EventHandler(this.cmbFiltroVencimiento_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(1022, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Filtro de Vencimiento";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTituloPrincipal.BackColor = System.Drawing.Color.SteelBlue;
            this.lblTituloPrincipal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblTituloPrincipal.ForeColor = System.Drawing.Color.White;
            this.lblTituloPrincipal.Location = new System.Drawing.Point(30, 22);
            this.lblTituloPrincipal.Name = "lblTituloPrincipal";
            this.lblTituloPrincipal.Size = new System.Drawing.Size(1150, 33);
            this.lblTituloPrincipal.TabIndex = 3;
            this.lblTituloPrincipal.Text = "LISTADO DE VENCIMIENTOS";
            this.lblTituloPrincipal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCobrar
            // 
            this.btnCobrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            this.btnCobrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCobrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(136)))), ((int)(((byte)(209)))));
            this.btnCobrar.FlatAppearance.BorderSize = 2;
            this.btnCobrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCobrar.Location = new System.Drawing.Point(1015, 259);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Size = new System.Drawing.Size(142, 41);
            this.btnCobrar.TabIndex = 15;
            this.btnCobrar.Text = "Cobrar Cuota";
            this.btnCobrar.UseVisualStyleBackColor = false;
            this.btnCobrar.Click += new System.EventHandler(this.btnCobrar_Click);
            // 
            // frmControlVencimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1201, 450);
            this.Controls.Add(this.btnCobrar);
            this.Controls.Add(this.cmbFiltroVencimiento);
            this.Controls.Add(this.lblTituloPrincipal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.Actualizar);
            this.Controls.Add(this.dgvVencimientos);
            this.Name = "frmControlVencimiento";
            this.Text = "Listado de Vencimientos";
            this.Load += new System.EventHandler(this.frmControlVencimiento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVencimientos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVencimientos;
        private System.Windows.Forms.Button Actualizar;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Label lblTituloPrincipal;
        private System.Windows.Forms.ComboBox cmbFiltroVencimiento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCobrar;
    }
}