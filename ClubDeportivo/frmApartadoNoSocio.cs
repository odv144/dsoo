using ClubDeportivo.Datos;
using ClubDeportivo.Entidades;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ClubDeportivo
{
    public partial class frmApartadoNoSocio : Form
    {
        private readonly RepositoryNoSocio repoNoSocio = new RepositoryNoSocio();
        private readonly RepositoryActividad repoActividad = new RepositoryActividad();
        private readonly RepositoryNoSocioActividad repoNoSocioAct = new RepositoryNoSocioActividad();

        public frmApartadoNoSocio()
        {
            InitializeComponent();
            this.Load += frmApartadoNoSocio_Load;
        }

        private void frmApartadoNoSocio_Load(object sender, EventArgs e)
        {
            ConfigurarGrilla();
            CargarNoSocios();
        }

        private void btnRegistrarNoSocio_Click(object sender, EventArgs e)
        {
            frmRegistroNoSocio registro = new frmRegistroNoSocio(this);
            registro.ShowDialog();
            CargarNoSocios();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void CargarNoSocios()
        {
            try
            {
                DataTable noSocios = repoNoSocio.ListarNoSocios();

                dgvListaNoSocio.DataSource = noSocios;

                if (noSocios.Rows.Count == 0)
                {
                    MessageBox.Show("No hay no socios registrados.",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                FormatearGrilla();
                dgvListaNoSocio.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los no socios: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarGrilla()
        {
            dgvListaNoSocio.AllowUserToAddRows = false;
            dgvListaNoSocio.AllowUserToDeleteRows = false;
            dgvListaNoSocio.MultiSelect = false;
            dgvListaNoSocio.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvListaNoSocio.RowHeadersVisible = false;
            dgvListaNoSocio.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvListaNoSocio.DefaultCellStyle.SelectionBackColor = Color.SteelBlue;
            dgvListaNoSocio.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvListaNoSocio.ReadOnly = true;
        }

        private void FormatearGrilla()
        {
            if (dgvListaNoSocio.Columns.Count == 0) return;

            // Ocultamos el Email (no es necesario mostrarlo)
            if (dgvListaNoSocio.Columns.Contains("Email"))
                dgvListaNoSocio.Columns["Email"].Visible = false;

            // Normalizamos encabezados
            dgvListaNoSocio.Columns["NroNoSocio"].HeaderText = "N° No Socio";
            dgvListaNoSocio.Columns["Nombre"].HeaderText = "Nombre";
            dgvListaNoSocio.Columns["Apellido"].HeaderText = "Apellido";
            dgvListaNoSocio.Columns["Dni"].HeaderText = "DNI";
            dgvListaNoSocio.Columns["Telefono"].HeaderText = "Teléfono";
            dgvListaNoSocio.Columns["FechaRegistro"].HeaderText = "Fecha Registro";
            dgvListaNoSocio.Columns["Observacion"].HeaderText = "Observación";

            // Columna personalizada "Estado"
            if (!dgvListaNoSocio.Columns.Contains("Estado"))
            {
                DataGridViewTextBoxColumn estadoCol = new DataGridViewTextBoxColumn
                {
                    Name = "Estado",
                    HeaderText = "Estado",
                    Width = 100,
                    ReadOnly = true
                };
                dgvListaNoSocio.Columns.Add(estadoCol);
            }

            // 🔹 Llenamos la columna Estado según la última inscripción
            foreach (DataGridViewRow fila in dgvListaNoSocio.Rows)
            {
                if (fila.Cells["NroNoSocio"].Value == null) continue;

                int nro = Convert.ToInt32(fila.Cells["NroNoSocio"].Value);
                DateTime? ultimaFecha = repoNoSocioAct.ObtenerUltimaFechaInscripcion(nro);

                if (ultimaFecha.HasValue)
                {
                    fila.Cells["Estado"].Value =
                        (ultimaFecha.Value.Date == DateTime.Now.Date)
                        ? "Activo"
                        : "Inactivo";
                }
                else
                {
                    fila.Cells["Estado"].Value = "Inactivo";
                }
            }

            // Ajustes de ancho específicos
            dgvListaNoSocio.Columns["NroNoSocio"].Width = 60;
            dgvListaNoSocio.Columns["Nombre"].Width = 120;
            dgvListaNoSocio.Columns["Apellido"].Width = 120;
            dgvListaNoSocio.Columns["Dni"].Width = 80;
            dgvListaNoSocio.Columns["Telefono"].Width = 100;
            dgvListaNoSocio.Columns["FechaRegistro"].Width = 110;
            dgvListaNoSocio.Columns["Observacion"].Width = 220;

            // Alineaciones visuales
            dgvListaNoSocio.Columns["NroNoSocio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvListaNoSocio.Columns["Dni"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvListaNoSocio.Columns["Telefono"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvListaNoSocio.Columns["Estado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Encabezados centrados
            foreach (DataGridViewColumn col in dgvListaNoSocio.Columns)
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvListaNoSocio.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un no socio de la lista para editar.",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow fila = dgvListaNoSocio.SelectedRows[0];
            if (fila.Cells["NroNoSocio"].Value == null)
            {
                MessageBox.Show("No se pudo identificar el no socio seleccionado.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int nroNoSocio = Convert.ToInt32(fila.Cells["NroNoSocio"].Value);
            frmEditarNoSocio frmEditar = new frmEditarNoSocio(nroNoSocio, this);
            frmEditar.ShowDialog();

            CargarNoSocios();
        }
    }
}
