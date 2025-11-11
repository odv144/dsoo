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
    public partial class frmActividad : Form
    {
        public frmActividad()
        {
            InitializeComponent();
        }
        RepositoryActividad repoActividad = new RepositoryActividad();



        private void frmActividad_Load(object sender, EventArgs e)
        {
            ConfigurarGrilla();
            CargarActividades();
            
        }

        public void CargarActividades()
        {
            try
            {
                List<E_Actividad> actividades = repoActividad.ObtenerTodos();


                if (actividades == null || actividades.Count == 0) // le añadi una validacion
                {
                    dgvActividades.DataSource = null;
                    MessageBox.Show("No hay actividades registradas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DataTable dt = new DataTable();
                dt.Columns.Add("IdActividad", typeof(int));
                dt.Columns.Add("Nombre", typeof(string));
                dt.Columns.Add("Descripción", typeof(string));
                dt.Columns.Add("Tarifa Socio", typeof(double));
                dt.Columns.Add("Tarifa No Socio", typeof(double));
                dt.Columns.Add("Cupo Máximo", typeof(int));
                dt.Columns.Add("Turno", typeof(string));

                foreach (E_Actividad act in actividades)
                {
                    dt.Rows.Add(
                        act.IdActividad,
                        act.Nombre,
                        act.Descripcion,
                        act.TarifaSocio,
                        act.TarifaNoSocio,
                        act.CupoMaximo,
                        act.Turno
                    );
                }

                dgvActividades.DataSource = dt;
                dgvActividades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvActividades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvActividades.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las actividades: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                                  //aqui decia socio  
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmNuevaActividad nuevo = new frmNuevaActividad(this);
            nuevo.Show();

        }


        private void btnActividad_Click(object sender, EventArgs e)
        {

            if (dgvActividades.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una actividad para editar.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            DataGridViewRow fila = dgvActividades.SelectedRows[0];

            try
            {

                frmUpdateActividad frmUpdate = new frmUpdateActividad(fila, this);
                frmUpdate.ShowDialog();


                CargarActividades();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al intentar editar la actividad:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

           private void ConfigurarGrilla()
        {
            dgvActividades.AllowUserToAddRows = false;
            dgvActividades.AllowUserToDeleteRows = false;
            dgvActividades.RowHeadersVisible = false; // oculta la columna de flecha
            dgvActividades.MultiSelect = false;
            dgvActividades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvActividades.DefaultCellStyle.SelectionBackColor = Color.SteelBlue;
            dgvActividades.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvActividades.ReadOnly = true;
        }
    }
}

