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
    public partial class frmComprobantePago : Form
    {
        public frmComprobantePago()
        {
            InitializeComponent();
        }
        public string nombre;
        public string apellido;
        public int nroSocio;
        public string importe;
        public bool socio;
        public DateTime fecha;
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            btnImprimir.Visible = false;
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(ImprimirComprobante);
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
        private void ImprimirComprobante(object o, PrintPageEventArgs e)
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

        private void frmComprobantePago_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = socio ? "PAGO CUOTA SOCIO" : "PAGO ACTIVIDAD NO SOCIO";
            lblNroSocio.Text = socio ? "Nro Socio" : "Nro No Socio";
            lblNro.Text = nroSocio.ToString();
            lblAyN.Text = apellido + " " + nombre;
            lblImporte.Text = importe;
            lblFecha.Text=DateTime.Now.ToString();
        }

       
    }
}
