using ClubDeportivo.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivo.Entidades
{
    internal class E_NoSocio : E_Usuario
    {

        public int NroNoSocio { get; set; }

        public int IdUsuario { get; set; }
        public E_Usuario Usuario { get; set; }
        public string Observacion { get; set; }

        public E_NoSocio() { }
        public E_NoSocio(E_Usuario usuario,/* int IdUsuario */string Obs) : base(usuario.Nombre,usuario.Apellido,usuario.Dni, usuario.Telefono, usuario.Email, usuario.FechaRegistro, usuario.CertificadoMedico)
        {   
            
            IdUsuario = usuario.IdUsuario;
            Observacion = Obs;
        }
    }

   

}
