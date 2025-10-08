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
    public partial class frmRegistro : Form
    {
        public frmRegistro()
        {
            InitializeComponent();
        }
        public int id;
        private void frmRegistroUsuario_Load(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)

        {
            RepositoryUsuario repositoryUsuario = new RepositoryUsuario();
           
            Entidades.E_Usuario usuario;
           
            usuario = new Entidades.E_Usuario(txtNombre.Text, txtApellido.Text, txtDni.Text,txtTelefono.Text,
                                                                   txtEmail.Text, DateTime.Now, chkCerMedico.Checked);
            id = repositoryUsuario.InsertarUsuario(usuario, chkAsociar.Checked);

            repositoryUsuario.InsertarSocio(usuario, "activo",double.Parse(txtImporte.Text), false);
            //MessageBox.Show(usuario.Nombre);
           /* frmCarnet carnet = new frmCarnet(id);
            carnet.ShowDialog();
           */

               // RegistrarSocio reg = new RegistrarSocio(usuario, chkAsociar.Checked);


        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            RepositoryUsuario repo = new RepositoryUsuario();
            repo.CambioEstadoCarnet(id, true);
        }
    }
}
