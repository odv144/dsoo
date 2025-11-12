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
       
        DataTable tablaLogin = new DataTable();
        
        private void btnIngreso_Click(object sender, EventArgs e)
        {
            try
            {

                Datos.Credencial datos = new Datos.Credencial();
                // Log_Usu metodo que llama al Stored Procedure de la base de datos
                tablaLogin = datos.Log_Usu(txtUser.Text, txtPass.Text);
                if (tablaLogin.Rows.Count > 0)
                {
                    frmApp frmApp = new frmApp();
                    frmApp.rol = Convert.ToString(tablaLogin.Rows[0][0]);
                    frmApp.usuario = Convert.ToString(txtUser.Text);
                    frmApp.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Usuario y/o contraseña incorrecta.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void Cerrar(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

       

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar== (char)Keys.Enter)
            {
                btnIngreso_Click(sender, e);
            }
                
        }
    }
}
