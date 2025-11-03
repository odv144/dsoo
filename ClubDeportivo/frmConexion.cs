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
    public partial class frmConexion : Form
    {
        public frmConexion()
        {
            InitializeComponent();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
             // Configurar temporalmente la conexión
            Conexion.getInstancia().ConfigurarConexion(
                txtServidor.Text.Trim(),
                txtPuerto.Text.Trim(),
                txtDbName.Text.Trim(),
                txtUsuario.Text.Trim(),
                txtPassword.Text
            );

            // Probar la conexión
            string mensaje;
            bool exito = Conexion.getInstancia().ProbarConexion(out mensaje);

            if (exito)
            {
                MessageBox.Show(mensaje, "Éxito",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show(mensaje, "Error de Conexión",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }
        }
    }
}
