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
    public partial class frmConexion : Form
    {
        public frmConexion()
        {
            InitializeComponent();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {

            // Configurar temporalmente la conexión
          
            var respuesta = MessageBox.Show(
            "¿Si es la primera ves que ejecuta el software desea correr el script de la bd?",
            "Execución correcta",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
);

            if (respuesta == DialogResult.Yes)
            {
            CargarArchivo();
            }
            
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
        private void CargarArchivo()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Archivos SQL (*.sql)|*.sql|Todos los archivos (*.*)|*.*";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string mensaje;
                bool exito = Conexion.getInstancia().EjecutarArchivoSQL(openFile.FileName, out mensaje);

                if (exito)
                {
                    Console.WriteLine("Base de datos creada correctamente");
                }
                else
                {
                    Console.WriteLine($"Error: {mensaje}");
                }
            }
        }
    }
}

