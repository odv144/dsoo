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
    public partial class frmEditarSocio : Form
    {

        private readonly int _nroSocio; // ID que llega desde el grid


        private readonly frmApartadoSocio _formSocio;
        private readonly RepositorySocio repoSocio = new RepositorySocio();
        private readonly RepositoryUsuario repoUsuario = new RepositoryUsuario();


        private int _idUsuario;
        private string _emailOriginal;

        public frmEditarSocio(int nroSocio, frmApartadoSocio formSocio = null)
        {
            InitializeComponent();
            _nroSocio = nroSocio;
            _formSocio = formSocio;

        }

        private void CargarDatosSocio(int nroSocio)
        {
            try
            {
                var socio = repoSocio.ObtenerConUsuario(nroSocio); // método que trae socio + usuario
                if (socio == null)
                {
                    MessageBox.Show("No se encontró el socio especificado.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var usuario = socio.Usuario;
                if (usuario == null)
                {
                    MessageBox.Show("No se encontró el usuario asociado al socio.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                
             
                txtNombre.Text = usuario.Nombre;
                txtApellido.Text = usuario.Apellido;
                txtDni.Text = usuario.Dni;
                txtTelefono.Text = usuario.Telefono;
                txtEmail.Text = usuario.Email;
                chkCerMedico.Checked = usuario.CertificadoMedico;

               
                _idUsuario = usuario.IdUsuario;
                _emailOriginal = usuario.Email;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos del socio:\n{ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        public frmEditarSocio()
        {
            InitializeComponent();

        }

       


        private void frmEditarSocio_Load(object sender, EventArgs e)
        {
            CargarDatosSocio(_nroSocio);
            txtDni.MaxLength = 8;
            txtTelefono.MaxLength = 15;

        }




        //salvar
        private void btnAtras_Click(object sender, EventArgs e)
        {
 
            this.Close();
        }
            
        //salvar
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Utilidades.LimpiarControles(this);
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

                MessageBox.Show("Los datos del socio se actualizaron correctamente.",
                                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private bool ValidarEmail(string email)
        {
            if (!EsEmailValido(email))
            {
                MessageBox.Show("Ingrese un correo electrónico válido.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            var usuarioExistente = repoUsuario.ObtenerUsuarioPorEmail(email);
            if (usuarioExistente != null && usuarioExistente.IdUsuario != _idUsuario)
            {
                MessageBox.Show("El correo electrónico ingresado ya está registrado en otro usuario.",
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



    }
}