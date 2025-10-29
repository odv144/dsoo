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
        public int id;
        private Entidades.E_Usuario usuario;
        private RepositoryUsuario repositoryUsuario = new RepositoryUsuario();
        private RepositoryActividad repoActividad;
        private RepositorySocioActividad repoSocioActividad;
        private RepositorySocio repoSocio = new RepositorySocio();
        public frmRegistro()
        {
            InitializeComponent();
            repoActividad = new RepositoryActividad();
            repoSocioActividad = new RepositorySocioActividad();
            repoSocio = new RepositorySocio();
        }


        private void btnRegistrar_Click(object sender, EventArgs e)

        {
            this.usuario = new Entidades.E_Usuario(txtNombre.Text, txtApellido.Text, txtDni.Text, txtTelefono.Text,
                                        txtEmail.Text, DateTime.Now, chkCerMedico.Checked);

            E_Usuario usuario1 = null;
            if (chkCerMedico.Checked)
            {

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
            
            frmCarnetPrinter carnet = new frmCarnetPrinter();
            carnet.nroSocio = id.ToString();
            carnet.nombre = usuario.Nombre;
            carnet.apellido = usuario.Apellido;
            carnet.importe = txtImporte.Text;

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

                Utilidades.HabilitarBotones(this, true);
            }
            else
            {
                Utilidades.HabilitarBotones(this, false);

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
            CargarActividades();
            CargarGrilla();
        }
        public void CargarActividades()
        {
            var actividades = repoActividad.ObtenerActividadesConCupoDisponible();
            cboActividad.DataSource = actividades;
            cboActividad.DisplayMember = "Nombre";
            cboActividad.ValueMember = "IdActividad";
        }
        public void CargarGrilla()
        {
            try
            {

                RepositoryActividad repo = new RepositoryActividad();
                repo.ObtenerActividadesConCupoDisponible();


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
                dgvActividades.Columns["Nombre"].Visible = false;
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
                Utilidades.HabilitarBotones(this, false);
                MessageBox.Show("El DNI ingresado ya se encuentra registrado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDni.Focus();
            }
        }

        private void dgvActividades_CellContentClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            // Protección básica: fila o columna de encabezado (índice -1) no procesar.
            if (e == null || e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            // Ejemplo seguro de acceso a la celda clickeada (sin asumir tipos):
            var fila = dgvActividades.Rows[e.RowIndex];
            var celda = fila?.Cells[e.ColumnIndex];
            var valor = celda?.Value;

            // Actualmente no se añade más lógica para no cambiar comportamiento.
            // Si quieres que ocurra algo al hacer clic, añade código aquí.
        }

        private void txtDni_TextChanged(object sender, EventArgs e)
        {

        }
    }
}