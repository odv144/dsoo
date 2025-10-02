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

        private void App_Load(object sender, EventArgs e)
        {
          
        }
        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "USUARIO")
            {
                txtUser.Text = "";
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "USUARIO";
            }
        }


        private void txtPass_Enter_1(object sender, EventArgs e)
        {
            if (txtPass.Text == "PASSWORD")
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
                    txtPass.Text = "PASSWORD";
                }
            }
        }
        private void btnIngreso_Click(object sender, EventArgs e)
        {
            DataTable tablaLogin = new DataTable();
            Datos.Usuarios datos = new Datos.Usuarios();
            tablaLogin = datos.Log_Usu(txtUser.Text, txtPass.Text);
            if (tablaLogin.Rows.Count > 0)
            {
                this.Hide();

            }
            else
            {
                MessageBox.Show("Usuario y/o password incorrecto");
            }
        }
    }
}
