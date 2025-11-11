using ClubDeportivo.Datos;
using ClubDeportivo.Entidades;
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
    public partial class frmApartadoSocio : Form
    {
        

        public frmApartadoSocio()
        {
            InitializeComponent();

            
           
            this.Load += frmApartadoSocio_Load;
        }

        private RepositorySocio repoSocio = new RepositorySocio();

        internal string rol;
        internal string usuario;
        private void btnRegistrarSocio_Click(object sender, EventArgs e)
        {
            frmRegistro registro = new frmRegistro(this);
            registro.ShowDialog();

            CargarSocios();
        }

        // cargo los socios 
        public void CargarSocios()
        {
            try
            {
                DataTable socios = repoSocio.ListarSocios();

                dgvListaSocio.DataSource = socios;
                dgvListaSocio.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvListaSocio.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvListaSocio.ReadOnly = true;
                dgvListaSocio.MultiSelect = false;
                dgvListaSocio.ClearSelection(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los socios: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmApartadoSocio_Load(object sender, EventArgs e)
        {
            dgvListaSocio.AllowUserToAddRows = false;
            dgvListaSocio.AllowUserToDeleteRows = false;
            dgvListaSocio.ReadOnly = true;
            dgvListaSocio.MultiSelect = false;
            dgvListaSocio.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvListaSocio.RowHeadersVisible = false; // elimina la flecha lateral izquierda

 
            dgvListaSocio.DefaultCellStyle.SelectionBackColor = Color.SteelBlue;
            dgvListaSocio.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvListaSocio.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //evento para seleccionar correctamente la fila al hacer clic
            dgvListaSocio.CellClick += (s, ev) =>
            {
                if (ev.RowIndex >= 0)
                    dgvListaSocio.Rows[ev.RowIndex].Selected = true;
            };

          
            CargarSocios();
            dgvListaSocio.ClearSelection();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            
            if (dgvListaSocio.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione un socio de la lista para editar.",
                                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DataGridViewRow fila = dgvListaSocio.SelectedRows[0];

           
            if (fila.Cells["NroSocio"] == null || fila.Cells["NroSocio"].Value == null)
            {
                MessageBox.Show("No se pudo identificar el socio seleccionado.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int nroSocio = Convert.ToInt32(fila.Cells["NroSocio"].Value);
            frmEditarSocio frmEditar = new frmEditarSocio(nroSocio, this);
            frmEditar.ShowDialog(); 
            CargarSocios();
        }

        private void s(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
