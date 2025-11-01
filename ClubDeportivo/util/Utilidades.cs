using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ClubDeportivo.util
{
    internal static class Utilidades
    {
        public static void LimpiarControles(Object sender)
        {
            TextBox txt = sender as TextBox;
             txt.Text= string.Empty;
          
        }
        public static void LimpiarControles(Form formulario)
        {
            foreach (Control control in formulario.Controls)
            {
                if (control is CheckBox)
                {
                    CheckBox chk = control as CheckBox;
                    chk.Checked = false;
                  
                }
                if (control is TextBox)
                {
                    control.Text = string.Empty;

                }
                
            }
            

        }
        public static void HabilitarBotones(Form frm, bool estado)
        {
            foreach (Control control in frm.Controls)
            {
                if (control is Button)
                {
                    if (control.Name == "btnRegistrar")
                    {
                        control.Enabled = estado;
                    }
                    if (control.Name == "btnImprimir")
                    {
                        control.Enabled = estado;
                    }
                }
            }
        }
        public static T? ConvertirCampos<T>(TextBox txt) where T : struct
        {
            string texto = txt.Text.Trim();

            try
            {
                // Intenta convertir al tipo especificado
                var valor = (T)Convert.ChangeType(texto, typeof(T));
                return valor;
            }
            catch
            {
              
                return null;
            }
        }
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
