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
        public frmRegistro()
        {
            InitializeComponent();
        }

        public int id;
        private Entidades.E_Usuario usuario;

        private void btnRegistrar_Click(object sender, EventArgs e)

        {

            RepositoryUsuario repositoryUsuario = new RepositoryUsuario();
            usuario = new Entidades.E_Usuario(txtNombre.Text, txtApellido.Text, txtDni.Text, txtTelefono.Text,
                                      txtEmail.Text, DateTime.Now, chkCerMedico.Checked);

            E_Usuario usuario1 = null;
            if (chkCerMedico.Checked)
            {
                RepositorySocio repoSocio = new RepositorySocio();
                usuario1 = repositoryUsuario.Insertar(usuario);
                usuario1 = repoSocio.Insertar(new E_Socio(usuario1, "activo", double.Parse(txtImporte.Text), false));
                frmCarnetPrinter carnet = new frmCarnetPrinter();
                carnet.nroSocio = id.ToString();
                carnet.nombre = usuario.Nombre;
                carnet.apellido = usuario.Apellido;
                carnet.importe = txtImporte.Text;
                carnet.ShowDialog();
            }
            else
            {
                MessageBox.Show("El certificado médico es obligatorio para registrar un socio.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            Utilidades.LimpiarControles(this);
        }



        private void btnImprimir_Click(object sender, EventArgs e)
        {
            RepositoryUsuario repo = new RepositoryUsuario();
            E_Usuario socio = null;


            repo.CambioEstadoCarnet(id, true);
            /*
             * Esto seria para la reimpresion en caso de algun error cuando se registro
             * tener en cuenta que el importe se toma del textbox que ahora estaria vacio
             * 
            socio = repo.ObtenerSocio(id);
            frmCarnetPrinter carnet = new frmCarnetPrinter();
            carnet.nroSocio = id.ToString(); ;
            carnet.nombre = socio.Nombre;
            carnet.apellido = socio.Apellido;
            carnet.ShowDialog();
           */


            //utilizarlo en registrar no socio
            // repo.ImpresionComprobante(usuario, id);


        }


        private void HabilitarBotones(object sender, EventArgs e)
        {
            if (chkCerMedico.Checked)
            {
                btnImprimir.Enabled = true;
                btnRegistrar.Enabled = true;
            }
            else
            {
                btnImprimir.Enabled = false;
                btnRegistrar.Enabled = false;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Utilidades.LimpiarControles(this);
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmRegistro_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }
        public void CargarGrilla()
        {
            RepositoryActividad repo = new RepositoryActividad();
            repo.ObtenerActividadesConCupoDisponible();
            try
            {

                RepositoryActividad repo = new RepositoryActividad();
                List<E_Actividad> actividades = repo.ObtenerTodos();
                dgvActividades.DataSource = null;
                dgvActividades.Rows.Clear();
                dgvActividades.DataSource = actividades;
                PersonalizarColumnas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar actividades: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // repo.ObtenerActividadesConCupoDisponible();
        }
        private void PersonalizarColumnas()
        { // Ocultar columnas que no quieres mostrar
            if (dgvActividades.Columns["IdActividad"] != null)
                dgvActividades.Columns["IdActividad"].Visible = false;

            // Cambiar nombres de encabezados
            if (dgvActividades.Columns["Nombre"] != null)
                dgvActividades.Columns["Nombre"].Visible=false;
                dgvActividades.Columns["Nombre"].HeaderText = "Actividad";

            if (dgvActividades.Columns["Descripcion"] != null)
                dgvActividades.Columns["Descripcion"].HeaderText = "Descripción";

            if (dgvActividades.Columns["TarifaSocio"] != null)
            {
                dgvActividades.Columns["TarifaSocio"].Visible = false;
                dgvActividades.Columns["TarifaSocio"].HeaderText = "Tarifa Socio";
                dgvActividades.Columns["TarifaSocio"].DefaultCellStyle.Format = "C2"; // Formato moneda
            }

            if (dgvActividades.Columns["TarifaNoSocio"] != null)
            {
                dgvActividades.Columns["TarifaNoSocio"].HeaderText = "Tarifa No Socio";
                dgvActividades.Columns["TarifaNoSocio"].DefaultCellStyle.Format = "C2";
            }

            if (dgvActividades.Columns["CupoMaximo"] != null)
                dgvActividades.Columns["CupoMaximo"].HeaderText = "Cupo Máximo";

            if (dgvActividades.Columns["Turno"] != null)
                dgvActividades.Columns["Turno"].HeaderText = "Turno";

            // Ajustar ancho de columnas
            dgvActividades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


        }

        private void txtObs_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDni_Leave(object sender, EventArgs e)
        {
            RepositoryUsuario repo = new RepositoryUsuario();
            E_Usuario usuario = repo.ObtenerUsuarioPorDni(txtDni.Text);

            if (usuario != null)
            {
                MessageBox.Show("El DNI ingresado ya se encuentra registrado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDni.Focus();
            }
        }
    }
}