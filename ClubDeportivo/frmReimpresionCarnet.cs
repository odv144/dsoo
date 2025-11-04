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
using ClubDeportivo.Datos;
using ClubDeportivo.Entidades;
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

        private E_Socio socio = null;
        RepositoryUsuario repoUsuario = new RepositoryUsuario();
        RepositorySocio repoSocio = new RepositorySocio();
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
                repoSocio.CambioEstadoCarnet(socio.NroSocio, true);
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
            lblFecha.Text = "Fecha: " + DateTime.Now.ToString();
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

            E_Usuario persona = repoUsuario.ObtenerUsuarioPorDni(dni);
            socio = repoSocio.ObtenerPorDniUsuario(dni);
            if (persona != null)
            {
                MessageBox.Show($"Persona encontrada: {persona.Nombre} {persona.Apellido}");

                lblAyN.Text = persona.Apellido + " " + persona.Nombre;
                lblNro.Text = socio.NroSocio.ToString();
                lblImporte.Text = socio.CuotaMensual.ToString();

                nombre = persona.Nombre;
                apellido = persona.Apellido;
                nroSocio = socio.NroSocio;
                importe = socio.CuotaMensual.ToString();
            }
            else
            {
                MessageBox.Show("No se encontró ningún registro con ese DNI.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



    }
}

