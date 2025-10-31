using ClubDeportivo.Datos;
using ClubDeportivo.Entidades;
using ClubDeportivo.util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubDeportivo
{
    public partial class frmRegistroNoSocio : Form
    {
        private frmApartadoNoSocio formNoSocio;


        // Repositorios
        private  RepositoryUsuario repositoryUsuario = new RepositoryUsuario();
        private  RepositoryNoSocio repoNoSocio = new RepositoryNoSocio();
        private  RepositoryActividad repoActividad = new RepositoryActividad();

        public int id;
        private Entidades.E_Usuario usuario;

        //tabla en memori temporal guarda la seleccion de actividades del combo
        private DataTable dtSeleccionActividades;

        public frmRegistroNoSocio(frmApartadoNoSocio formNoSocio = null)
        {
            InitializeComponent();
            this.formNoSocio = formNoSocio;
        }
        
        


        private void frmRegistroNoSocio_Load(object sender, EventArgs e)
        {
            CargarGrilla();
            CargarComboActividades();
            GridSeleccion();
        }
        
        

        public void CargarGrilla()
        {
            repoActividad.ObtenerActividadesConCupoDisponible();
                
        }


        private void btnRegistrar_Click_1(object sender, EventArgs e)
        {
            if (!chkCerMedico.Checked)
            {
                MessageBox.Show("El certificado médico es obligatorio para registrar un no socio.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // solo creo el usuario
                usuario = new E_Usuario(
                    txtNombre.Text,
                    txtApellido.Text,
                    txtDni.Text,
                    txtTelefono.Text,
                    txtEmail.Text,
                    DateTime.Now,
                    chkCerMedico.Checked
                );

                E_Usuario nuevoUsuario = repositoryUsuario.Insertar(usuario);

                // recien inserto el socio
                E_NoSocio nuevoNoSocio = new E_NoSocio(nuevoUsuario, txtObservacion.Text);
                repoNoSocio.Insertar(nuevoNoSocio);

                MessageBox.Show("Cliente No Socio registrado exitosamente.",
                    "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                formNoSocio?.CargarNoSocios();
                Utilidades.LimpiarControles(this);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar el no socio:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Utilidades.LimpiarControles(this);
        }


        private void btnAtras_Click_1(object sender, EventArgs e)
        {
            formNoSocio.CargarNoSocios();
            formNoSocio.Show();
            this.Close();

        }

        //agregar funcionalidad de imprimir comprobante
        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }



        private void txtDni_Leave(object sender, EventArgs e)
        {
            RepositoryUsuario repo = new RepositoryUsuario();
            E_Usuario usuario = repo.ObtenerUsuarioPorDni(txtDni.Text);

            if (usuario != null)
            {
                Utilidades.HabilitarBotones(this, false);
                MessageBox.Show("El DNI ingresado ya se encuentra registrado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDni.Focus();
            }
        }




        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            int pos = txtNombre.SelectionStart;
            txtNombre.Text = txtNombre.Text.ToUpper();
            txtNombre.SelectionStart = pos;
        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
                e.Handled = true;
        }



        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            int pos = txtApellido.SelectionStart;
            txtApellido.Text = txtApellido.Text.ToUpper();
            txtApellido.SelectionStart = pos;
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim().Length < 3)
            {
                MessageBox.Show("El nombre debe tener al menos 3 letras.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
            }
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
                e.Handled = true;
        }
        private void txtApellido_Leave(object sender, EventArgs e)
        {
            if (txtApellido.Text.Trim().Length < 3)
            {
                MessageBox.Show("El apellido debe tener al menos 3 letras.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellido.Focus();
            }
        }


        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (!EsEmailValido(txtEmail.Text))
            {
                MessageBox.Show("Ingrese un correo electrónico válido.");
                txtEmail.Focus();
            }
        }

        private bool EsEmailValido(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch { return false; }
        }

        private void cboActividad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        //cargar el combo box con las actividades 

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

        // grid seleccion de actividades
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

            calculoTotal();
        }

        private void calculoTotal()
        {
            double total = 0;

            foreach (DataRow r in dtSeleccionActividades.Rows)
                total += Convert.ToDouble(r["Subtotal"]);

            // Actualiza el campo visual "Pago Total"
            txtImporte.Text = total.ToString("0.##");
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


    }
}
    
    
   