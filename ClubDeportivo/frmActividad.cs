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
    public partial class frmActividad : Form
    {
        public frmActividad()
        {
            InitializeComponent();
        }
        RepositoryActividad repoActividad = new RepositoryActividad();
        private void frmActividad_Load(object sender, EventArgs e)
        {
            CargarActividades();
        }
        public void CargarActividades()
        {
            try
            {
                List<E_Actividad> actividad = repoActividad.ObtenerTodos();

                DataTable dt = new DataTable();
                dt.Columns.Add("IdActividad", typeof(int));
                dt.Columns.Add("NroSocio", typeof(int));
                dt.Columns.Add("NroNoSocio", typeof(int));
                dt.Columns.Add("Nombre", typeof(string));
                dt.Columns.Add("Descripcion", typeof(string));
                dt.Columns.Add("TarifaSocio", typeof(double));
                dt.Columns.Add("TarifaNoSocio", typeof(double));
                dt.Columns.Add("CupoMaximo", typeof(int));
                dt.Columns.Add("Turno", typeof(string));

                foreach (E_Actividad act in actividad)
                {
                   
                    dt.Rows.Add(
                        act.IdActividad,
                        act.NroSocio,
                        act.NroNoSocio,
                        act.Nombre,
                        act.Descripcion,
                        act.TarifaSocio,
                        act.TarifaNoSocio,
                        act.CupoMaximo,
                        act.Turno
                    );
                }
                if (actividad.Count > 0)
                {
                    
                    dgvActividades.DataSource = dt;
                    dgvActividades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvActividades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvActividades.ReadOnly = true;
                }
                else
                {
                    dgvActividades.DataSource = null;
                    MessageBox.Show("No hay actividades cargadas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los socios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
