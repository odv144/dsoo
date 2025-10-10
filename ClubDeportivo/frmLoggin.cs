using ClubDeportivo.util;
using Org.BouncyCastle.Tls;
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
    public partial class frmLoggin : Form
    {
        public frmLoggin()
        {
            InitializeComponent();
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {

            if (txtUser.Text == "Usuario")
            {
                txtUser.Text = "";
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "Usuario";
            }
        }


        private void txtPass_Enter_1(object sender, EventArgs e)
        {
            if (txtPass.Text == "Contraseña")
            {
                txtPass.Text = "";
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            {
                if (txtPass.Text == "")
                {
                    txtPass.Text = "Contraseña";
                }
            }
        }
        private void btnIngreso_Click(object sender, EventArgs e)
        {
            DataTable tablaLogin = new DataTable();
            Datos.Credencial datos = new Datos.Credencial();
            tablaLogin = datos.Log_Usu(txtUser.Text, txtPass.Text);
            if (tablaLogin.Rows.Count > 0)
            {
                this.Hide();

            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña incorrecta.");
            }
        }


        private void LimpiarCampo(object sender, EventArgs e)
        {
            Utilidades.LimpiarControles(sender);
            
            TextBox txt = sender as TextBox;
            if (txt.Name == "txtPass")
            {
                txt.UseSystemPasswordChar=true;
            }
            
        }
        private void TextBox_Leave(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            // Si el usuario deja el campo vacío, restauramos el texto predeterminado
            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                // Determinamos qué placeholder restaurar basado en el nombre del control
                switch (txt.Name)
                {
                    case "txtUser":
                        txt.Text = "Usuario";
                        break;
                    case "txtPass":
                        txt.UseSystemPasswordChar = false;
                        txt.Text = "Password";
                        break;
                    
                }
            
         
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
