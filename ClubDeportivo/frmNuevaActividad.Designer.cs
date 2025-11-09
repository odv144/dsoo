namespace ClubDeportivo
{
    partial class frmNuevaActividad
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
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTarifaSocio = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTarifaNoSocio = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCupo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAtras = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.cboTurno = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Location = new System.Drawing.Point(148, 76);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(197, 20);
            this.txtNombre.TabIndex = 3;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            this.txtNombre.Leave += new System.EventHandler(this.txtNombre_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(34, 83);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nombre";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            this.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Location = new System.Drawing.Point(148, 116);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(197, 20);
            this.txtDescripcion.TabIndex = 5;
            this.txtDescripcion.TextChanged += new System.EventHandler(this.txtDescripcion_TextChanged);
            this.txtDescripcion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescripcion_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(34, 123);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Descripción";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtTarifaSocio
            // 
            this.txtTarifaSocio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            this.txtTarifaSocio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTarifaSocio.Location = new System.Drawing.Point(149, 155);
            this.txtTarifaSocio.Margin = new System.Windows.Forms.Padding(4);
            this.txtTarifaSocio.Name = "txtTarifaSocio";
            this.txtTarifaSocio.Size = new System.Drawing.Size(197, 20);
            this.txtTarifaSocio.TabIndex = 7;
            this.txtTarifaSocio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTarifaSocio_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(34, 162);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tarifa Socio";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtTarifaNoSocio
            // 
            this.txtTarifaNoSocio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            this.txtTarifaNoSocio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTarifaNoSocio.Location = new System.Drawing.Point(148, 195);
            this.txtTarifaNoSocio.Margin = new System.Windows.Forms.Padding(4);
            this.txtTarifaNoSocio.Name = "txtTarifaNoSocio";
            this.txtTarifaNoSocio.Size = new System.Drawing.Size(197, 20);
            this.txtTarifaNoSocio.TabIndex = 9;
            this.txtTarifaNoSocio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTarifaNoSocio_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(31, 202);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Tarifa No Socio";
            // 
            // txtCupo
            // 
            this.txtCupo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            this.txtCupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCupo.Location = new System.Drawing.Point(149, 237);
            this.txtCupo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCupo.Name = "txtCupo";
            this.txtCupo.Size = new System.Drawing.Size(197, 20);
            this.txtCupo.TabIndex = 11;
            this.txtCupo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCupo_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(34, 244);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Cupo Máximo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(34, 289);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Turno";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // btnAtras
            // 
            this.btnAtras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            this.btnAtras.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAtras.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(136)))), ((int)(((byte)(209)))));
            this.btnAtras.FlatAppearance.BorderSize = 2;
            this.btnAtras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtras.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnAtras.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAtras.Location = new System.Drawing.Point(418, 195);
            this.btnAtras.Margin = new System.Windows.Forms.Padding(4);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(142, 41);
            this.btnAtras.TabIndex = 16;
            this.btnAtras.Text = "Atrás";
            this.btnAtras.UseVisualStyleBackColor = false;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(136)))), ((int)(((byte)(209)))));
            this.btnLimpiar.FlatAppearance.BorderSize = 2;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnLimpiar.ForeColor = System.Drawing.Color.Black;
            this.btnLimpiar.Location = new System.Drawing.Point(418, 134);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(142, 41);
            this.btnLimpiar.TabIndex = 14;
            this.btnLimpiar.Text = "Limpiar datos";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(136)))), ((int)(((byte)(209)))));
            this.btnGuardar.FlatAppearance.BorderSize = 2;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnGuardar.ForeColor = System.Drawing.Color.Black;
            this.btnGuardar.Location = new System.Drawing.Point(418, 76);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(142, 41);
            this.btnGuardar.TabIndex = 13;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // cboTurno
            // 
            this.cboTurno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            this.cboTurno.Cursor = System.Windows.Forms.Cursors.Default;
            this.cboTurno.FormattingEnabled = true;
            this.cboTurno.Items.AddRange(new object[] {
            "MAÑANA",
            "TARDE",
            "NOCHE"});
            this.cboTurno.Location = new System.Drawing.Point(148, 281);
            this.cboTurno.Name = "cboTurno";
            this.cboTurno.Size = new System.Drawing.Size(196, 21);
            this.cboTurno.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.SteelBlue;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(34, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(526, 33);
            this.label7.TabIndex = 17;
            this.label7.Text = "REGISTRAR NUEVA ACTIVIDAD";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // frmNuevaActividad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(606, 348);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboTurno);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCupo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTarifaNoSocio);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTarifaSocio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label2);
            this.Name = "frmNuevaActividad";
            this.Text = "Nueva Actividad";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTarifaSocio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTarifaNoSocio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCupo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ComboBox cboTurno;
        private System.Windows.Forms.Label label7;
    }
}