using ClubDeportivo.Datos;
using ClubDeportivo.Entidades;
using ClubDeportivo.util;
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
        private Entidades.E_Usuario usuario;
        private void frmRegistroUsuario_Load(object sender, EventArgs e)
        {

        }

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


                }
                else
                {
                    //registro no socio

                    id = repositoryUsuario.InsertarUsuario(usuario);

                    repositoryUsuario.InsertarNoSocio(usuario, txtObs.Text);

                }
            }

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            RepositoryUsuario repo = new RepositoryUsuario();
            if (chkAsociar.Checked)
            {
                repo.CambioEstadoCarnet(id, true);
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

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblObs_Click(object sender, EventArgs e)
        {

        }

        private void lblImporte_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
