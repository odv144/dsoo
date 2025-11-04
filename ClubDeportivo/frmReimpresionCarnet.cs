using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ClubDeportivo
{
    public partial class frmReimpresionCarnet : Form
    {
        public frmReimpresionCarnet()
        {
            InitializeComponent();
        }
        public string nombre;
        public string apellido;
        public int nroSocio;
        public string importe;

        //Imprimir Carnet:
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            btnImprimir.Visible = false;
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(ImprimirCarnet);
            PrintDialog printDlg = new PrintDialog();
            printDlg.AllowSomePages = true;
            printDlg.AllowSelection = true;
            printDlg.UseEXDialog = true;
            printDlg.Document = pd;
            if (printDlg.ShowDialog() == DialogResult.OK)
            {
                pd.Print();
            }
            //    pd.Print();
            btnImprimir.Visible = true;
            this.Close();


        }
        //Método para imprimir:
        private void ImprimirCarnet(object o, PrintPageEventArgs e)
        {
            int x = SystemInformation.WorkingArea.X;
            int y = SystemInformation.WorkingArea.Y;
            int ancho = this.Width;
            int alto = this.Height;
            Rectangle bounds = new Rectangle(x, y, ancho, alto);
            Bitmap img = new Bitmap(ancho, alto);
            this.DrawToBitmap(img, bounds);
            Point p = new Point(100, 100);
            e.Graphics.DrawImage(img, p);
        }
        //Carga de Formulario:

        private void frmCarnetPrinter_Load(object sender, EventArgs e)
        {
            lblNro.Text = nroSocio.ToString();
            lblAyN.Text = apellido + " " + nombre;
            lblImporte.Text = importe;
        }

        private void lblAyN_Click(object sender, EventArgs e)
        {

        }

        private void lblNro_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string dni = txtDni.Text.Trim();

            if (string.IsNullOrEmpty(dni))
            {
                MessageBox.Show("Por favor, ingresá un DNI antes de buscar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var persona = BuscarPorDni(dni);

            if (persona != null)
            {
                MessageBox.Show($"Persona encontrada: {persona.Nombre} {persona.Apellido}");

                lblAyN.Text = persona.Apellido + " " + persona.Nombre;
                lblNro.Text = persona.NroSocio.ToString();
                lblImporte.Text = persona.Importe;

                nombre = persona.Nombre;
                apellido = persona.Apellido;
                nroSocio = persona.NroSocio;
                importe = persona.Importe;
            }
            else
            {
                MessageBox.Show("No se encontró ningún registro con ese DNI.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        // MÉTODO PARA BUSCAR PERSONA POR DNI EN LA BASE DE DATOS:
        private Persona BuscarPorDni(string dni)
        {
            Persona personaEncontrada = null;

            // ⚠️ Cambiar los datos de conexión por los de su entorno local:
            string connectionString = "server=localhost;database=proyecto;uid=root;pwd=2728;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM usuario WHERE dni = @dni LIMIT 1";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@dni", dni);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            personaEncontrada = new Persona
                            {
                                Dni = reader["dni"].ToString(),
                                Nombre = reader["nombre"].ToString(),
                                Apellido = reader["apellido"].ToString(),
                                NroSocio = Convert.ToInt32(reader["id_usuario"]),
                                Importe = "0" // Tengo que traer importe de cuota
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar en la base de datos: " + ex.Message);
                }
            }

            return personaEncontrada;
        }
    }

 
    // CLASE PERSONA AUXILIAR
    public class Persona
    {
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int NroSocio { get; set; }
        public string Importe { get; set; }
    }

}

