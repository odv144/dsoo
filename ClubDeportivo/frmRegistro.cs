using ClubDeportivo.Datos;
using ClubDeportivo.Entidades;
using ClubDeportivo.util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Text;
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
        private Entidades.E_Usuario usuario;

        private void btnRegistrar_Click(object sender, EventArgs e)

        {

            RepositoryUsuario repositoryUsuario = new RepositoryUsuario();
            usuario = new Entidades.E_Usuario(txtNombre.Text, txtApellido.Text, txtDni.Text, txtTelefono.Text,
                                                                          txtEmail.Text, DateTime.Now, chkCerMedico.Checked);
            if (chkCerMedico.Checked)
            {
                if (chkAsociar.Checked)
                {

                    id = repositoryUsuario.InsertarUsuario(usuario);
                    repositoryUsuario.InsertarSocio(usuario, "activo", double.Parse(txtImporte.Text), false);
                    usuario = repositoryUsuario.ObtenerSocio(id);
                    frmCarnetPrinter carnet = new frmCarnetPrinter();
                    carnet.nroSocio = id.ToString();
                    carnet.nombre = usuario.Nombre;
                    carnet.apellido = usuario.Apellido;
                    carnet.importe = txtImporte.Text;
                    carnet.ShowDialog();

                }
                else
                {
                    //registro no socio

                    id = repositoryUsuario.InsertarUsuario(usuario);

                    repositoryUsuario.InsertarNoSocio(usuario, txtObs.Text);

                }
            }
            //proceso para 
            Utilidades.LimpiarControles(this);

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            RepositoryUsuario repo = new RepositoryUsuario();
            E_Usuario socio = null;
             if (chkAsociar.Checked)
            {
                repo.CambioEstadoCarnet(id, true);
                /*
                 * Esto seria para la reimpresion en caso de algun error cuando se registro
                 * tener en cuenta que el importe se toma del textbox que ahora estaria vacio
                 * 
                socio = repo.ObtenerSocio(id);
                frmCarnetPrinter carnet = new frmCarnetPrinter();
                carnet.nroSocio = id.ToString(); ;
                carnet.nombre = socio.Nombre;
                carnet.apellido = socio.Apellido;
                carnet.ShowDialog();
                */
            }
            else
            {
                repo.ImpresionComprobante(usuario, id);
            }
            
            

        }
       
        private void HabilitarObs(object sender, EventArgs e)
        {
            if(!chkAsociar.Checked)
            {
                txtObs.Enabled = true;
                lblObs.Enabled = true;
            }
            else
            {
                txtObs.Enabled = false;
                lblObs.Enabled = false;
            }
        }

        private void HabilitarBotones(object sender, EventArgs e)
        {
            if(chkCerMedico.Checked)
            {
                btnImprimir.Enabled = true;
                btnRegistrar.Enabled = true;
            }
            else
            {
                btnImprimir.Enabled = false;
               btnRegistrar.Enabled = false;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Utilidades.LimpiarControles(this);
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmRegistro_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }
        public void CargarGrilla()
        {
           RepositoryActividad repo = new RepositoryActividad();
            repo.ObtenerActividadesConCupoDisponible();
        }
    }
}
