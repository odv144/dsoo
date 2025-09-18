namespace Biblioteca
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblAutor = new System.Windows.Forms.Label();
            this.txtAutor = new System.Windows.Forms.TextBox();
            this.lblEditorial = new System.Windows.Forms.Label();
            this.txtEditorial = new System.Windows.Forms.TextBox();
            this.lblGenero = new System.Windows.Forms.Label();
            this.txtGenero = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnListar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dgvLibros = new System.Windows.Forms.DataGridView();
            this.btnDatos = new System.Windows.Forms.Button();
            this.btnNuevoLector = new System.Windows.Forms.Button();
            this.btnPrestar = new System.Windows.Forms.Button();
            this.lblLector = new System.Windows.Forms.Label();
            this.txtLector = new System.Windows.Forms.TextBox();
            this.lblDniLector = new System.Windows.Forms.Label();
            this.txtDniLector = new System.Windows.Forms.TextBox();
            this.btnPrestados = new System.Windows.Forms.Button();
            this.cboPrestado = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLibros)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(16, 68);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(132, 20);
            this.txtTitulo.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(12, 45);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(53, 20);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Titulo";
            // 
            // lblAutor
            // 
            this.lblAutor.AutoSize = true;
            this.lblAutor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutor.Location = new System.Drawing.Point(12, 91);
            this.lblAutor.Name = "lblAutor";
            this.lblAutor.Size = new System.Drawing.Size(53, 20);
            this.lblAutor.TabIndex = 3;
            this.lblAutor.Text = "Autor";
            // 
            // txtAutor
            // 
            this.txtAutor.Location = new System.Drawing.Point(16, 114);
            this.txtAutor.Name = "txtAutor";
            this.txtAutor.Size = new System.Drawing.Size(132, 20);
            this.txtAutor.TabIndex = 2;
            // 
            // lblEditorial
            // 
            this.lblEditorial.AutoSize = true;
            this.lblEditorial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditorial.Location = new System.Drawing.Point(12, 137);
            this.lblEditorial.Name = "lblEditorial";
            this.lblEditorial.Size = new System.Drawing.Size(75, 20);
            this.lblEditorial.TabIndex = 5;
            this.lblEditorial.Text = "Editorial";
            // 
            // txtEditorial
            // 
            this.txtEditorial.Location = new System.Drawing.Point(16, 160);
            this.txtEditorial.Name = "txtEditorial";
            this.txtEditorial.Size = new System.Drawing.Size(132, 20);
            this.txtEditorial.TabIndex = 4;
            // 
            // lblGenero
            // 
            this.lblGenero.AutoSize = true;
            this.lblGenero.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGenero.Location = new System.Drawing.Point(12, 183);
            this.lblGenero.Name = "lblGenero";
            this.lblGenero.Size = new System.Drawing.Size(69, 20);
            this.lblGenero.TabIndex = 7;
            this.lblGenero.Text = "Genero";
            // 
            // txtGenero
            // 
            this.txtGenero.Location = new System.Drawing.Point(16, 206);
            this.txtGenero.Name = "txtGenero";
            this.txtGenero.Size = new System.Drawing.Size(132, 20);
            this.txtGenero.TabIndex = 6;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.Blue;
            this.btnBuscar.Location = new System.Drawing.Point(17, 248);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(148, 42);
            this.btnBuscar.TabIndex = 8;
            this.btnBuscar.Text = "Buscar Libro";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnListar
            // 
            this.btnListar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnListar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListar.ForeColor = System.Drawing.Color.Blue;
            this.btnListar.Location = new System.Drawing.Point(18, 290);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(147, 42);
            this.btnListar.TabIndex = 9;
            this.btnListar.Text = "Listar Libros";
            this.btnListar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListar.UseVisualStyleBackColor = false;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.Blue;
            this.btnEliminar.Location = new System.Drawing.Point(18, 332);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(147, 42);
            this.btnEliminar.TabIndex = 10;
            this.btnEliminar.Text = "Eliminar Libros";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.Blue;
            this.btnAgregar.Location = new System.Drawing.Point(18, 374);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(147, 42);
            this.btnAgregar.TabIndex = 11;
            this.btnAgregar.Text = "Agregar Libros";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dgvLibros
            // 
            this.dgvLibros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLibros.Location = new System.Drawing.Point(205, 108);
            this.dgvLibros.Name = "dgvLibros";
            this.dgvLibros.Size = new System.Drawing.Size(575, 307);
            this.dgvLibros.TabIndex = 12;
            // 
            // btnDatos
            // 
            this.btnDatos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDatos.ForeColor = System.Drawing.Color.Blue;
            this.btnDatos.Location = new System.Drawing.Point(205, 427);
            this.btnDatos.Name = "btnDatos";
            this.btnDatos.Size = new System.Drawing.Size(148, 42);
            this.btnDatos.TabIndex = 14;
            this.btnDatos.Text = "Test Datos";
            this.btnDatos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDatos.UseVisualStyleBackColor = false;
            this.btnDatos.Click += new System.EventHandler(this.btnDatos_Click);
            // 
            // btnNuevoLector
            // 
            this.btnNuevoLector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnNuevoLector.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnNuevoLector.Location = new System.Drawing.Point(215, 64);
            this.btnNuevoLector.Name = "btnNuevoLector";
            this.btnNuevoLector.Size = new System.Drawing.Size(126, 37);
            this.btnNuevoLector.TabIndex = 15;
            this.btnNuevoLector.Text = "Nuevo Lector";
            this.btnNuevoLector.UseVisualStyleBackColor = false;
            this.btnNuevoLector.Click += new System.EventHandler(this.btnNuevoLector_Click);
            // 
            // btnPrestar
            // 
            this.btnPrestar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPrestar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnPrestar.Location = new System.Drawing.Point(359, 64);
            this.btnPrestar.Name = "btnPrestar";
            this.btnPrestar.Size = new System.Drawing.Size(126, 37);
            this.btnPrestar.TabIndex = 16;
            this.btnPrestar.Text = "Prestar";
            this.btnPrestar.UseVisualStyleBackColor = false;
            this.btnPrestar.Click += new System.EventHandler(this.btnPrestar_Click);
            // 
            // lblLector
            // 
            this.lblLector.AutoSize = true;
            this.lblLector.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLector.Location = new System.Drawing.Point(211, 9);
            this.lblLector.Name = "lblLector";
            this.lblLector.Size = new System.Drawing.Size(127, 20);
            this.lblLector.TabIndex = 19;
            this.lblLector.Text = "Nombre Lector";
            // 
            // txtLector
            // 
            this.txtLector.Location = new System.Drawing.Point(215, 38);
            this.txtLector.Name = "txtLector";
            this.txtLector.Size = new System.Drawing.Size(126, 20);
            this.txtLector.TabIndex = 18;
            // 
            // lblDniLector
            // 
            this.lblDniLector.AutoSize = true;
            this.lblDniLector.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDniLector.Location = new System.Drawing.Point(355, 9);
            this.lblDniLector.Name = "lblDniLector";
            this.lblDniLector.Size = new System.Drawing.Size(55, 20);
            this.lblDniLector.TabIndex = 20;
            this.lblDniLector.Text = "D.N.I.";
            // 
            // txtDniLector
            // 
            this.txtDniLector.Location = new System.Drawing.Point(359, 38);
            this.txtDniLector.Name = "txtDniLector";
            this.txtDniLector.Size = new System.Drawing.Size(126, 20);
            this.txtDniLector.TabIndex = 21;
            // 
            // btnPrestados
            // 
            this.btnPrestados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPrestados.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnPrestados.Location = new System.Drawing.Point(634, 64);
            this.btnPrestados.Name = "btnPrestados";
            this.btnPrestados.Size = new System.Drawing.Size(126, 37);
            this.btnPrestados.TabIndex = 22;
            this.btnPrestados.Text = "Prestados";
            this.btnPrestados.UseVisualStyleBackColor = false;
            this.btnPrestados.Click += new System.EventHandler(this.btnPrestados_Click);
            // 
            // cboPrestado
            // 
            this.cboPrestado.FormattingEnabled = true;
            this.cboPrestado.Location = new System.Drawing.Point(491, 37);
            this.cboPrestado.Name = "cboPrestado";
            this.cboPrestado.Size = new System.Drawing.Size(269, 21);
            this.cboPrestado.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(559, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 20);
            this.label1.TabIndex = 24;
            this.label1.Text = "Libros Prestados";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 481);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboPrestado);
            this.Controls.Add(this.btnPrestados);
            this.Controls.Add(this.txtDniLector);
            this.Controls.Add(this.lblDniLector);
            this.Controls.Add(this.lblLector);
            this.Controls.Add(this.txtLector);
            this.Controls.Add(this.btnPrestar);
            this.Controls.Add(this.btnNuevoLector);
            this.Controls.Add(this.btnDatos);
            this.Controls.Add(this.dgvLibros);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnListar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lblGenero);
            this.Controls.Add(this.txtGenero);
            this.Controls.Add(this.lblEditorial);
            this.Controls.Add(this.txtEditorial);
            this.Controls.Add(this.lblAutor);
            this.Controls.Add(this.txtAutor);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.txtTitulo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLibros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblAutor;
        private System.Windows.Forms.TextBox txtAutor;
        private System.Windows.Forms.Label lblEditorial;
        private System.Windows.Forms.TextBox txtEditorial;
        private System.Windows.Forms.Label lblGenero;
        private System.Windows.Forms.TextBox txtGenero;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dgvLibros;
        private System.Windows.Forms.Button btnDatos;
        private System.Windows.Forms.Button btnNuevoLector;
        private System.Windows.Forms.Button btnPrestar;
        private System.Windows.Forms.Label lblLector;
        private System.Windows.Forms.TextBox txtLector;
        private System.Windows.Forms.Label lblDniLector;
        private System.Windows.Forms.TextBox txtDniLector;
        private System.Windows.Forms.Button btnPrestados;
        private System.Windows.Forms.ComboBox cboPrestado;
        private System.Windows.Forms.Label label1;
    }
}

