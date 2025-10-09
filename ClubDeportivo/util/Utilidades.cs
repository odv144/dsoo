using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubDeportivo.util
{
    internal static class Utilidades
    {
        public static void TextBox_Leave(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            // Si el usuario deja el campo vacío, restauramos el texto predeterminado
            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                // Determinamos qué placeholder restaurar basado en el nombre del control
                switch (txt.Name)
                {
                    case "textBoxNombre":
                        txt.Text = "Ingrese su nombre";
                        break;
                    case "textBoxEmail":
                        txt.Text = "Ingrese su correo";
                        break;
                    case "textBoxMonto":
                        txt.Text = "0.00";
                        break;
                    case "textBoxDireccion":
                        txt.Text = "Dirección completa";
                        break;
                    case "textBoxTelefono":
                        txt.Text = "Teléfono de contacto";
                        break;
                }
            }
        }
    }
}
