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
        private frmActividad frmActividad = new frmActividad();
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

                RepositoryActividad repoActividad = new RepositoryActividad();
                repoActividad.Actualizar(new E_Actividad
                {
                    IdActividad = IdActividad,
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    TarifaSocio = Convert.ToDouble(txtTarifaSocio.Text),
                    TarifaNoSocio = Convert.ToDouble(txtTarifaNoSocio.Text),
                    CupoMaximo = Convert.ToInt16(txtCupo.Text),
                    Turno = cboTurno.SelectedItem.ToString(),
                });
                MessageBox.Show("Registro actualizado correctamente");

                frmActividad?.CargarActividades();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se genero un error al momento de actualizar los datos");
            }
        }

        private void frmUpdateActividad_Load(object sender, EventArgs e)
        {
            txtNombre.Text = this.Nombre;
            txtDescripcion.Text = this.Descripcion;
            txtTarifaSocio.Text = this.TarifaSocio.ToString();
            txtTarifaNoSocio.Text = this.TarifaNoSocio.ToString();
            txtCupo.Text=this.CupoMaximo.ToString();
            cboTurno.SelectedItem = Turno.ToString();


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
