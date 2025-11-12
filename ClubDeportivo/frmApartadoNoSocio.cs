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
    public partial class frmApartadoNoSocio : Form
    {
        public frmApartadoNoSocio()
        {
            InitializeComponent();
            this.Load += frmApartadoNoSocio_Load;
        }

        private RepositoryNoSocio repoNoSocio = new RepositoryNoSocio();
        private RepositoryActividad repoActividad = new RepositoryActividad();
        private RepositoryNoSocioActividad repoNoSocioAct = new RepositoryNoSocioActividad();
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
                    //dgvListaNoSocio.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvListaNoSocio.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvListaNoSocio.ReadOnly = true;
                }
                else
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

        private void frmApartadoNoSocio_Load(object sender, EventArgs e)
        {
            ConfigurarGrilla();
            CargarNoSocios();
            
        }

        private void dgvListaNoSocio_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CargarNoSocios();

        }

        private void ConfigurarGrilla()
        {

        }

        
       
        private void FormatearGrilla()
        {
            if (dgvListaNoSocio.Columns.Count == 0) return;
            //ocultar el mail
            dgvListaNoSocio.Columns["Email"].Visible = false;

            dgvListaNoSocio.Columns["nronosocio"].HeaderText = "N° no Socio";
            dgvListaNoSocio.Columns["Nombre"].HeaderText = "Nombre";
            dgvListaNoSocio.Columns["Apellido"].HeaderText = "Apellido";
            dgvListaNoSocio.Columns["Dni"].HeaderText = "DNI";
            dgvListaNoSocio.Columns["Telefono"].HeaderText = "Telefono";
            dgvListaNoSocio.Columns["Observacion"].HeaderText = "Observacion";

            // Agregar columna personalizada
            if (!dgvListaNoSocio.Columns.Contains("Estado"))
            {
                DataGridViewTextBoxColumn Estado = new DataGridViewTextBoxColumn();
                Estado.Name = "Estado";
                Estado.HeaderText = "Estado";
                Estado.Width = 100;
                dgvListaNoSocio.Columns.Add(Estado);
            }
            //buscar ultima fecha de actividades de un no socio
            foreach (DataGridViewRow fila in dgvListaNoSocio.Rows)
            {
               //DateTime FechaInsc= (DateTime)repoNoSocioAct.ObtenerUltimaFechaInscripcion(Convert.ToInt32(fila.Cells["nronosocio"].Value));
                DateTime FechaInsc = repoNoSocioAct.ObtenerUltimaFechaInscripcion(Convert.ToInt32(fila.Cells["nronosocio"].Value)) ?? DateTime.MinValue;
                if (FechaInsc != null)
                {
                  fila.Cells["Estado"].Value = (FechaInsc.Day == DateTime.Now.Day)
                    ? "Activo" : "Inactivo";
                }
               

               
            }
            dgvListaNoSocio.Columns["nronosocio"].Width = 60;
            dgvListaNoSocio.Columns["Nombre"].Width = 50;
            dgvListaNoSocio.Columns["Apellido"].Width = 50;
            dgvListaNoSocio.Columns["Dni"].Width = 60;
            dgvListaNoSocio.Columns["Telefono"].Width = 80;
            dgvListaNoSocio.Columns["Observacion"].Width = 200;
          
            dgvListaNoSocio.AllowUserToResizeColumns = false;
            dgvListaNoSocio.AllowUserToAddRows = false;
            // 🎯 Centramos columnas específicas
            /*
             dgvListaNoSocio.Columns["mes"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             dgvListaNoSocio.Columns["anio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
             dgvListaNoSocio.Columns["monto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
             dgvListaNoSocio.Columns["fechavencimiento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            */
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            
             if (dgvListaNoSocio.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione un socio de la lista para editar.",
                                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DataGridViewRow fila = dgvListaNoSocio.SelectedRows[0];

           
            if (fila.Cells["NroNoSocio"] == null || fila.Cells["NroNoSocio"].Value == null)
            {
                MessageBox.Show("No se pudo identificar el socio seleccionado.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            

            int nroNoSocio = Convert.ToInt32(fila.Cells["NroNoSocio"].Value);
            frmEditarNoSocio frmEditar = new frmEditarNoSocio(nroNoSocio,this);
            
            
            frmEditar.ShowDialog(); 
            CargarNoSocios();
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
