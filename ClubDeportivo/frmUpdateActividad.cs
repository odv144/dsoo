using ClubDeportivo.Datos;
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
    public partial class frmUpdateActividad : Form
    {
        public int IdActividad;
        public string Nombre;
        public string Descripcion;
        public double TarifaSocio;
        public double TarifaNoSocio;
        public int CupoMaximo;
        public string Turno;
        //private frmActividad frmActividad = new frmActividad(); crea una nueva ventana
        private frmActividad frmActividad; // paso la referencia por el constructor

        public frmUpdateActividad( DataGridViewRow fila ,frmActividad frmActividad)
        {
            InitializeComponent();
            IdActividad = Convert.ToInt32(fila.Cells["IdActividad"].Value);
            Nombre = fila.Cells["Nombre"].Value?.ToString();
            Descripcion = fila.Cells["Descripción"].Value?.ToString();
            TarifaSocio = Convert.ToDouble(fila.Cells["Tarifa Socio"].Value?.ToString());
            TarifaNoSocio = Convert.ToDouble(fila.Cells["Tarifa No Socio"].Value?.ToString());
           CupoMaximo = Convert.ToInt16(fila.Cells["Cupo Máximo"].Value?.ToString());
            Turno = fila.Cells["Turno"].Value?.ToString();
            this.frmActividad = frmActividad;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //validacion  de campos obligatorios
                if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtDescripcion.Text) ||
                    string.IsNullOrWhiteSpace(txtTarifaSocio.Text) ||
                    string.IsNullOrWhiteSpace(txtTarifaNoSocio.Text) ||
                    string.IsNullOrWhiteSpace(txtCupo.Text) ||
                    cboTurno.SelectedItem == null)
                {
                    MessageBox.Show("Todos los campos son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // validacion de los datos numericos
                if (!double.TryParse(txtTarifaSocio.Text, out double tarifaSocio) ||
                    !double.TryParse(txtTarifaNoSocio.Text, out double tarifaNoSocio) ||
                    !int.TryParse(txtCupo.Text, out int cupoMaximo))
                {
                    MessageBox.Show("Verifique que los valores numéricos sean correctos.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // obtengo el turno actual modificado
                string turnoSeleccionado = cboTurno.SelectedItem.ToString();

                // persitencia en la BD
                RepositoryActividad repoActividad = new RepositoryActividad();
                repoActividad.Actualizar(new E_Actividad
                {
                    IdActividad = IdActividad,
                    Nombre = txtNombre.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim(),
                    TarifaSocio = tarifaSocio,
                    TarifaNoSocio = tarifaNoSocio,
                    CupoMaximo = cupoMaximo,
                    Turno = turnoSeleccionado
                });

                
                MessageBox.Show("Actividad actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmActividad?.CargarActividades();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error al actualizar los datos.\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void frmUpdateActividad_Load(object sender, EventArgs e)
        {

            // cargar opciones posibles del turno
            cboTurno.Items.Clear();
            cboTurno.Items.AddRange(new string[] { "mañana", "tarde", "noche" });

            txtNombre.Text = this.Nombre;
            txtDescripcion.Text = this.Descripcion;
            txtTarifaSocio.Text = this.TarifaSocio.ToString();
            txtTarifaNoSocio.Text = this.TarifaNoSocio.ToString();
            txtCupo.Text=this.CupoMaximo.ToString();

            if (!string.IsNullOrEmpty(Turno))
            {
                // normalizar el turno para comparacion
                string turnoNormalizado = Turno.Trim().ToLower();

                foreach (string item in cboTurno.Items)
                {
                    if (item.ToLower() == turnoNormalizado)
                    {
                        cboTurno.SelectedItem = item;
                        break;
                    }


                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Utilidades.LimpiarControles(this);
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
