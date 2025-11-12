using ClubDeportivo.Datos;
using ClubDeportivo.Entidades;
using ClubDeportivo.util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubDeportivo
{
    public partial class frmEditarNoSocio : Form
    {

        private readonly int _nroNoSocio; // ID que llega desde el grid


        private readonly frmApartadoNoSocio _formSocio;
        private readonly RepositoryNoSocio repoNoSocio = new RepositoryNoSocio();
        private readonly RepositoryUsuario repoUsuario = new RepositoryUsuario();
        private readonly RepositoryNoSocioActividad repoNoSocioActividad = new RepositoryNoSocioActividad();
        private readonly RepositoryActividad repoActividad = new RepositoryActividad();

        private DataTable dtSeleccionActividades;

        private int _idUsuario;
        private string _emailOriginal;

        public frmEditarNoSocio(int nroNoSocio, frmApartadoNoSocio formSocio = null)
        {
            InitializeComponent();
            
            _nroNoSocio = nroNoSocio;
            _formSocio = formSocio;

        }
        private void frmEditarSocio_Load(object sender, EventArgs e)
        {

            GridSeleccion();
            CargarGrilla();
            CargarComboActividades();
            CargarDatosNoSocio(_nroNoSocio);
            txtDni.MaxLength = 8;
            txtTelefono.MaxLength = 15;

        }
        //Metodo de configuracion de datagrid
        private void GridSeleccion()
        {
            dtSeleccionActividades = new DataTable();
            dtSeleccionActividades.Columns.Add("IdActividad", typeof(int));
            dtSeleccionActividades.Columns.Add("Nombre", typeof(string));
            dtSeleccionActividades.Columns.Add("Turno", typeof(string));
            dtSeleccionActividades.Columns.Add("TarifaNoSocio", typeof(double));
            dtSeleccionActividades.Columns.Add("Cantidad", typeof(int));
            dtSeleccionActividades.Columns.Add("Subtotal", typeof(double));

            dgvActividades.DataSource = dtSeleccionActividades;
            dgvActividades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvActividades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvActividades.ReadOnly = true; // por ahora solo agregamos desde el botón
        }
        //Cargar grilla para tener la actualización constante
        public void CargarGrilla()
        {
            repoActividad.ObtenerActividadesConCupoDisponible();

        }
        //Metodo para cargar el combobox con la tabla de actividades
        private void CargarComboActividades()
        {
            try
            {

                List<E_Actividad> actividades = repoActividad.ObtenerActividadesConCupoDisponible();

                if (actividades == null || actividades.Count == 0)  // valido que actividad teng cupo
                {
                    cboActividad.DataSource = null;
                    MessageBox.Show("No hay actividades disponibles.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Asigna los datos al ComboBox
                cboActividad.DataSource = actividades;
                cboActividad.DisplayMember = "Nombre";   // lo que se muestra
                cboActividad.ValueMember = "IdActividad"; // el valor interno (clave)
                cboActividad.SelectedIndex = -1;         // sin selección inicial
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las actividades: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosNoSocio(int nroNoSocio)
        {
            try
            {
                var noSocio = repoNoSocio.ObtenerPorId(nroNoSocio);// .ObtenerConUsuario(nroSocio); // método que trae socio + usuario
                if (noSocio == null)
                {
                    MessageBox.Show("No se encontró el socio especificado.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                            
                txtNombre.Text = noSocio.Nombre;
                txtApellido.Text = noSocio.Apellido;
                txtDni.Text = noSocio.Dni;
                txtTelefono.Text = noSocio.Telefono;
                txtEmail.Text = noSocio.Email;
                chkCerMedico.Checked = noSocio.CertificadoMedico;

                //agrega al datagridview las actividades que tiene asignadas
                dgvActividades.DataSource = null;

                // Asignar el DataSource
                List <E_NoSocio_Actividad> actividades = repoNoSocioActividad.ObtenerActividadesPorSocio(nroNoSocio);
                // dgvActividades.DataSource = actividades;
               // dgvActividades.Rows.Clear();
                CrearColumnasDataGridView();
                //GridSeleccion();
                PersonalizarColumnas();

                foreach (E_NoSocio_Actividad act in actividades)
                {
                   double subtotal = Convert.ToDouble(act.Actividad.TarifaNoSocio) ;
                    int cantidad = 1;
                    int rowIndex = dgvActividades.Rows.Add(
                        act.IdActividad,
                        act.Actividad.Nombre,
                        act.Actividad.Turno,
                        act.Actividad.TarifaNoSocio,
                        cantidad,
                        subtotal
                    );
                }

                _idUsuario = noSocio.IdUsuario;
                _emailOriginal = noSocio.Email;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos del socio:\n{ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Crea columnas para el datagridview
        public void CrearColumnasDataGridView()
        {
            // Limpiar columnas existentes
            dgvActividades.Columns.Clear();

            // Crear columna Id Actividad
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.Name = "IdActividad";
            colId.HeaderText = "Id Actividad";
            colId.DataPropertyName = "IdActividad";
            colId.Width = 80;
            dgvActividades.Columns.Add(colId);

            // Crear columna Nombre
            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
            colNombre.Name = "Nombre";
            colNombre.HeaderText = "Nombre";
            colNombre.DataPropertyName = "Nombre";
            colNombre.Width = 90;
            dgvActividades.Columns.Add(colNombre);

            // Crear columna Turno
            DataGridViewTextBoxColumn colTurno = new DataGridViewTextBoxColumn();
            colTurno.Name = "Turno";
            colTurno.HeaderText = "Turno";
            colTurno.DataPropertyName = "Turno";
            colTurno.Width = 60;
            colTurno.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvActividades.Columns.Add(colTurno);

            // Crear columna Tarifa No Socio
            DataGridViewTextBoxColumn colTarifa = new DataGridViewTextBoxColumn();
            colTarifa.Name = "TarifaNoSocio";
            colTarifa.HeaderText = "T. No Socio";
            colTarifa.DataPropertyName = "TarifaNoSocio";
            colTarifa.Width = 80;
            colTarifa.DefaultCellStyle.Format = "C2";
            colTarifa.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvActividades.Columns.Add(colTarifa);

            // Crear columna Cantidad
            DataGridViewTextBoxColumn colCantidad = new DataGridViewTextBoxColumn();
            colCantidad.Name = "Cantidad";
            colCantidad.HeaderText = "Cantidad";
            colCantidad.DataPropertyName = "Cantidad";
            colCantidad.Width = 70;
            colCantidad.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvActividades.Columns.Add(colCantidad);

            // Crear columna Subtotal
            DataGridViewTextBoxColumn colSubtotal = new DataGridViewTextBoxColumn();
            colSubtotal.Name = "Subtotal";
            colSubtotal.HeaderText = "Subtotal";
            colSubtotal.Width = 70;
            colSubtotal.DefaultCellStyle.Format = "C2";
            colSubtotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colSubtotal.ReadOnly = true;
            dgvActividades.Columns.Add(colSubtotal);
        }

        private void PersonalizarColumnas()
        {
            dgvActividades.AllowUserToAddRows = false;
            dgvActividades.AllowUserToDeleteRows = false;
            dgvActividades.ReadOnly = true;
            dgvActividades.MultiSelect = false;
            dgvActividades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvActividades.RowHeadersVisible = false; // elimina la flecha lateral izquierda


            dgvActividades.DefaultCellStyle.SelectionBackColor = Color.SteelBlue;
            dgvActividades.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvActividades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvActividades.Columns.Count == 0) return;

            // Configurar headers
            dgvActividades.Columns["IdActividad"].HeaderText = "Id Actividad";
            dgvActividades.Columns["Nombre"].HeaderText = "Nombre";
            dgvActividades.Columns["Turno"].HeaderText = "Turno";
            dgvActividades.Columns["TarifaNoSocio"].HeaderText = "Tarifa No Socio";
            dgvActividades.Columns["Cantidad"].HeaderText = "Cantidad";

            // Opcional: Ocultar columnas que no quieres mostrar
            // dgvActividades.Columns["IdActividad"].Visible = false;

            // Formato de moneda para la tarifa
            dgvActividades.Columns["TarifaNoSocio"].DefaultCellStyle.Format = "C2"; // Formato moneda

            // Centrar algunas columnas
            dgvActividades.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvActividades.Columns["Turno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Ajustar ancho de columnas
            dgvActividades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /***********************************************/
        //SECCION DE BOTONS
        
        private void btnAtras_Click(object sender, EventArgs e)
        {
             this.Close();
        }
            
       
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Utilidades.LimpiarControles(this);
        }
        //cargar combobox
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cboActividad.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una actividad.", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // actividad seleccionada
            var act = (E_Actividad)cboActividad.SelectedItem;

            // evitar duplicados
            var filas = dtSeleccionActividades.Select($"IdActividad = {act.IdActividad}");

            if (filas.Length > 0)
            {
                var row = filas[0];
                int cantidad = Convert.ToInt32(row["Cantidad"]) + 1;
                row["Cantidad"] = cantidad;
                row["Subtotal"] = cantidad * Convert.ToDouble(row["TarifaNoSocio"]);
            }
            else
            {
                // Nueva fila (Cantidad = 1)
                dtSeleccionActividades.Rows.Add(
                    act.IdActividad,
                    act.Nombre,
                    act.Turno,
                    act.TarifaNoSocio,
                    1,
                    act.TarifaNoSocio * 1
                );
            }
            dgvActividades.DataSource = dtSeleccionActividades;
            calculoTotal();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!chkCerMedico.Checked)
            {
                MessageBox.Show("Debe marcar Certificado Médico para guardar.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                chkCerMedico.Focus();
                return;
            }

            try
            {
                if (!ValidarCamposObligatorios())
                    return;

                string email = txtEmail.Text.Trim();
                if (!ValidarEmailParaGuardar(email))
                    return;


                E_Usuario actualizado = new E_Usuario
                {
                    IdUsuario = _idUsuario,
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    Dni = txtDni.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Email = email,
                    CertificadoMedico = chkCerMedico.Checked
                };

                repoUsuario.Actualizar(actualizado);

                int actividadesRegistradas = 0;
                
                foreach (DataGridViewRow fila in dgvActividades.Rows)
                {
                    int idActividad = Convert.ToInt32(fila.Cells["IdActividad"].Value);
                    // Verificar cupo disponible SOLO para no socios
                    if (repoActividad.TieneCupoDisponible(idActividad))
                    {
                        var noSocioActividad = new E_NoSocio_Actividad
                        {
                            NroNoSocio = _nroNoSocio,
                            IdActividad = idActividad,
                            FechaInscripcion = DateTime.Now,
                            Estado = "Activo"
                        };
                        repoNoSocioActividad.Insertar(noSocioActividad);
                        actividadesRegistradas++;

                    }
                }

                if (actividadesRegistradas > 0)
                {
                    MessageBox.Show($"No socio registrado exitosamente con {actividadesRegistradas} actividad(es).",
                        "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("El no socio fue registrado, pero no se pudo inscribir en ninguna actividad (sin cupos).",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //  Mostrar comprobante de pago solo si hubo al menos una actividad
                if (actividadesRegistradas > 0)
                {
                    var pago = new frmComprobantePago
                    {
                        nroSocio = _nroNoSocio,
                        nombre = actualizado.Nombre,
                        apellido = actualizado.Apellido,
                        importe = txtImporte.Text,
                        socio = false
                    };
                    pago.ShowDialog();
                }


                if (this.Tag is frmApartadoSocio formSocio)
                    formSocio.CargarSocios();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al actualizar los datos:\n{ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvActividades.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una actividad para eliminar.",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Confirmación opcional
            DialogResult confirmar = MessageBox.Show("¿Está seguro de eliminar la actividad seleccionada?",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmar == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dgvActividades.SelectedRows)
                {
                    dgvActividades.Rows.Remove(row);
                }

                calculoTotal(); // recalcula el total después de eliminar
            }
        }
        /**************************************/
        //SECCION DEVALIDACION
        private bool EsEmailValido(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch { return false; }
        }

        private bool ValidarCamposObligatorios()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Por favor complete los campos obligatorios (Nombre, Apellido y Email).",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        
              

        private bool ValidarEmailParaGuardar(string email)
        {
            // formato
            if (!EsEmailValido(email))
            {
                MessageBox.Show("Ingrese un correo electrónico válido.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            // si NO cambió respecto al original -> OK, no chequea duplicado
            if (email.Equals(_emailOriginal, StringComparison.OrdinalIgnoreCase))
                return true;

            // si cambió -> verificar duplicado
            var usuarioExistente = repoUsuario.ObtenerUsuarioPorEmail(email);
            if (usuarioExistente != null && usuarioExistente.IdUsuario != _idUsuario)
            {
                MessageBox.Show("El correo electrónico ingresado ya está registrado en otro usuario.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        /****************************************/
        //SECCION DE TEXTBOX
        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            // solo dígitos y teclas de control (Backspace, etc.)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtDni_TextChanged(object sender, EventArgs e)
        {
            // limpieza por si se pegó texto con algo raro y recorte a 8
            string soloNumeros = new string(txtDni.Text.Where(char.IsDigit).ToArray());
            if (soloNumeros.Length > 8) soloNumeros = soloNumeros.Substring(0, 8);

            if (txtDni.Text != soloNumeros)
            {
                int pos = txtDni.SelectionStart - 1;
                txtDni.Text = soloNumeros;
                txtDni.SelectionStart = Math.Max(0, pos);
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
                e.Handled = true;
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            int pos = txtNombre.SelectionStart;
            // opcional: normalizar a mayúsculas
            txtNombre.Text = txtNombre.Text.ToUpper();
            txtNombre.SelectionStart = pos;
        }


        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permite dígitos y teclas de control (Backspace, Delete, etc.)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            // Elimina caracteres no numéricos si se pegaron desde el portapapeles
            string soloNumeros = new string(txtTelefono.Text.Where(char.IsDigit).ToArray());

            if (txtTelefono.Text != soloNumeros)
            {
                int pos = txtTelefono.SelectionStart - 1;
                txtTelefono.Text = soloNumeros;
                txtTelefono.SelectionStart = Math.Max(0, pos);
            }
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
                e.Handled = true;
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            int pos = txtApellido.SelectionStart;
            txtApellido.Text = txtApellido.Text.ToUpper();
            txtApellido.SelectionStart = pos;
        }
        /*********************************/
        //SECCION DE METODOS SECUNDARIOS
       
        private void calculoTotal()
        {
            double total = 0;

            foreach (DataRow r in dtSeleccionActividades.Rows)
                total += Convert.ToDouble(r["Subtotal"]);

            // Actualiza el campo visual "Pago Total"
            txtImporte.Text = total.ToString("0.##");
        }

      
      
       
    }
}