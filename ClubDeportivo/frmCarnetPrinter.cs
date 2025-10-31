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

namespace ClubDeportivo
{
    public partial class frmCarnetPrinter : Form
    {
        public frmCarnetPrinter()
        {
            InitializeComponent();
        }
        public string nombre;
        public string apellido;
        public int nroSocio;
        public string importe;
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            
            btnImprimir.Visible=false;
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(ImprimirCarnet);
            pd.Print();
            btnImprimir.Visible = true;
            this.Close();


        }
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

        private void frmCarnetPrinter_Load(object sender, EventArgs e)
        {
            lblNro.Text=nroSocio.ToString();
            lblAyN.Text = apellido + " " + nombre;
            lblImporte.Text = importe;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
