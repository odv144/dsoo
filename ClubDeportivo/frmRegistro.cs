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

        private void frmRegistroUsuario_Load(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)

        {
            RepositoryUsuario repositoryUsuario = new RepositoryUsuario();

            Entidades.E_Usuario usuario;
            DateTime fecha = new DateTime(1995, 10, 7); // Año, mes, día

            usuario = new Entidades.E_Usuario(txtNombre.Text, "pascal", "123456", "789456123",
                                                                   "pedtrio@gamil.com", fecha, true);
            repositoryUsuario.InsertarUsuario(usuario);
            MessageBox.Show(usuario.Nombre);



               // RegistrarSocio reg = new RegistrarSocio(usuario, chkAsociar.Checked);


        }
    }
}
