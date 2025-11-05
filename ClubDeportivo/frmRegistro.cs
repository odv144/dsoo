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
    public partial class frmRegistro : Form
    {
        private frmApartadoSocio formSocio;

        //repos
        private RepositoryUsuario repositoryUsuario = new RepositoryUsuario();
        private RepositoryActividad repoActividad;
        private RepositorySocioActividad repoSocioActividad;
        private RepositorySocio repoSocio;

        public int id;
        private Entidades.E_Usuario usuario;

        //inicializo los repos
        private void InicializarRepositorios()
        {
            repoActividad = new RepositoryActividad();
            repoSocioActividad = new RepositorySocioActividad();
            repoSocio = new RepositorySocio();
        }

        public frmRegistro(frmApartadoSocio formSocio = null)
        {
            InitializeComponent();
            this.formSocio = formSocio;
            InicializarRepositorios();
        }

        public frmRegistro()
        {
            InitializeComponent();
            InicializarRepositorios();

        }

                                        //eventos de form


        private void frmRegistro_Load(object sender, EventArgs e)
        {
            // poblar metodos de pago
            cboPago.Items.Clear();
            cboPago.Items.Add("Efectivo");
            cboPago.Items.Add("Tarjeta en 3 Cuotas");
            cboPago.Items.Add("Tarjeta en 6 Cuotas");
            cboPago.Items.Add("Transferencia");
            cboPago.SelectedIndex = 0;

            // sincroniza estado inicial de botones con el check
            Utilidades.HabilitarBotones(this, chkCerMedico.Checked);
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            formSocio.CargarSocios();
            formSocio.Show();
            this.Close();
        }
            
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Utilidades.LimpiarControles(this);
        }

        private void HabilitarBotones(object sender, EventArgs e)
        {

            Utilidades.HabilitarBotones(this, chkCerMedico.Checked);
        }


        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // parseo de importe
            double importe;
            if (!double.TryParse(
                    txtImporte.Text,
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out importe) || importe <= 0)
            {
                MessageBox.Show("Ingrese un importe numérico válido mayor a 0.", "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtImporte.Focus();
                return;
            }

            // mapeo de método de pago
            string metodoPago = "Efectivo";
            switch (cboPago.SelectedItem?.ToString())
            {
                case "Tarjeta en 3 Cuotas":
                    metodoPago = "Tarjeta 3";
                    break;
                case "Tarjeta en 6 Cuotas":
                    metodoPago = "Tarjeta 6";
                    break;
                case "Transferencia":
                    metodoPago = "Transferencia";
                    break;
                default:
                    metodoPago = "Efectivo";
                    break;
            }

            // crear usuario
            this.usuario = new E_Usuario(
                txtNombre.Text,
                txtApellido.Text,
                txtDni.Text,
                txtTelefono.Text,
                txtEmail.Text,
                DateTime.Now,
                chkCerMedico.Checked
            );

            // persistir usuario
            E_Usuario user = repositoryUsuario.Insertar(usuario);

            // crear socio con cuota mensual = importe ingresado
            E_Socio socio = repoSocio.Insertar(new E_Socio(user, "activo", importe, false));
            this.id = socio.NroSocio; //esto servira para imprimir el carnet despues


            // crear cuota inicial
            RepositoryCuota repoCuota = new RepositoryCuota();
            repoCuota.Insertar(new E_Cuota
            {
                NroSocio = socio.NroSocio,
                FechaVencimiento = DateTime.Now.AddMonths(1),
                Monto = importe,
                MetodoPago = metodoPago,
                Mes = DateTime.Now.Month,
                Anio = DateTime.Now.Year,
                FechaPago = DateTime.Now,
                EstadoPago = true
            });

            // preguntar si quiere imprimir carnet
            var respuesta = MessageBox.Show(
            "Socio registrado correctamente.\n¿Desea imprimir el carnet ahora?",
            "Registro exitoso",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
);

            if (respuesta == DialogResult.Yes)
            {
                ImprimirCarnetRecienCreado(socio, importe);
            }
            // Impresion de comprobante de pago
            frmComprobantePago pago = new frmComprobantePago()
            {
                nroSocio = socio.NroSocio,
                nombre = user.Nombre,
                apellido = user.Apellido,
                importe = importe.ToString(),
                socio = true
            };
            pago.ShowDialog();
            formSocio?.CargarSocios();
            Utilidades.LimpiarControles(this);

  

        }

        //para imprimir el carnet recien creado
        private void ImprimirCarnetRecienCreado(E_Socio socio, double importe)
        {
            try
            {
                
                // actualizar estado carnet en BD
                repoSocio.CambioEstadoCarnet(socio.NroSocio, true);

                // preparar datos del carnet
                var carnet = new frmCarnetPrinter
                {
                    nroSocio = socio.NroSocio,
                    nombre = usuario.Nombre,
                    apellido = usuario.Apellido,
                    importe = importe.ToString("N2")
                };

                carnet.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al imprimir carnet: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnImprimir_Click(object sender, EventArgs e)
        {
            // protege si alguien presiona imprimir sin registrar
            if (usuario == null)
            {
                MessageBox.Show("No hay datos de usuario cargados para imprimir el carnet.",
                                "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RepositorySocio repo = new RepositorySocio();
            repo.CambioEstadoCarnet(id, true);

            var carnet = new frmCarnetPrinter
            {
                nroSocio = id,
                nombre = usuario.Nombre,
                apellido = usuario.Apellido,
                importe = txtImporte.Text
            };
            carnet.ShowDialog();

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

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}