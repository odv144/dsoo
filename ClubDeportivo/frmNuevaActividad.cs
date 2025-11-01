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
    public partial class frmNuevaActividad : Form
    {
        private frmActividad frmActivadad = new frmActividad();
        public frmNuevaActividad(frmActividad actividad =null)
        {
            InitializeComponent();
            this.frmActivadad = actividad;

        }
        private RepositoryActividad repoActividad = new RepositoryActividad();
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            E_Actividad actividad = repoActividad.Insertar(new E_Actividad
            {
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
                TarifaSocio  = (double)Utilidades.ConvertirCampos<double>(txtTarifaSocio),
                TarifaNoSocio = (double)Utilidades.ConvertirCampos<double>(txtTarifaNoSocio),
                CupoMaximo = (int)Utilidades.ConvertirCampos<int>(txtCupo),
                Turno = cboTurno.SelectedItem.ToString(),


            });
            if (actividad != null)
            {
                MessageBox.Show("Actividad cargada correctamente");
            }
            frmActivadad?.CargarActividades();
            this.Close();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
                e.Handled = true;
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
                e.Handled = true;
        }

        private void txtTarifaSocio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtTarifaNoSocio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtCupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (txtNombre.Text.Length > 3)
            {
                btnGuardar.Enabled = true;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Utilidades.LimpiarControles(this);
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            frmActivadad.Show();
            this.Close();
        }
    }
}
