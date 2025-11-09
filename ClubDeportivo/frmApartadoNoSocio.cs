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

                if (noSocios.Rows.Count > 0)
                {
                    dgvListaNoSocio.DataSource = noSocios;
                    dgvListaNoSocio.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvListaNoSocio.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvListaNoSocio.ReadOnly = true;
                }
                else
                {
                    dgvListaNoSocio.DataSource = null;
                    MessageBox.Show("No hay no socios registrados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los no socios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmApartadoNoSocio_Load(object sender, EventArgs e)
        {
            CargarNoSocios();
        }

        private void dgvListaNoSocio_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CargarNoSocios();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
