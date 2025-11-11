using ClubDeportivo.Datos;
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
    public partial class frmApartadoNoSocio : Form
    {
        public frmApartadoNoSocio()
        {
            InitializeComponent();
            this.Load += frmApartadoNoSocio_Load;
        }

        private RepositoryNoSocio repoNoSocio = new RepositoryNoSocio();

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
                dgvListaNoSocio.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                if (noSocios.Rows.Count == 0)
                {
                    MessageBox.Show("No hay no socios registrados.",
                                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            
                dgvListaNoSocio.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los no socios: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmApartadoNoSocio_Load(object sender, EventArgs e)
        {
            ConfigurarGrilla();
            CargarNoSocios();
            
        }


        private void ConfigurarGrilla()
        {
            dgvListaNoSocio.AllowUserToAddRows = false;
            dgvListaNoSocio.AllowUserToDeleteRows = false;
            dgvListaNoSocio.RowHeadersVisible = false; // oculta la columna de flecha
            dgvListaNoSocio.MultiSelect = false;
            dgvListaNoSocio.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvListaNoSocio.DefaultCellStyle.SelectionBackColor = Color.SteelBlue;
            dgvListaNoSocio.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvListaNoSocio.ReadOnly = true;
        }
    }
}
