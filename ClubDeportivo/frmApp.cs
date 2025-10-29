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
    public partial class frmApp : Form
    {
        public frmApp()
        {
            InitializeComponent();
        }
        internal string rol;
        internal string usuario;

        private void frmApp_Load(object sender, EventArgs e)
        {
            lblSeccion.Text += "USUARIO: " + usuario + " (" + rol + ")"; 
            //frmLoggin login = new frmLoggin();
            //login.ShowDialog();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            frmRegistro registro = new frmRegistro();
            registro.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRegistroNoSocio_Click(object sender, EventArgs e)
        {
            frmRegistroNoSocio registro = new frmRegistroNoSocio();
            registro.ShowDialog();
        
        }

        private void btnSocio_Click(object sender, EventArgs e)
        {
            frmApartadoSocio  registro = new frmApartadoSocio();
            registro.ShowDialog();
        }
    }
}
