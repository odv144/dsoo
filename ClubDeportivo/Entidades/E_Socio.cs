using ClubDeportivo.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivo.Entidades
{
    internal class E_Socio : E_Usuario
    {
        public int NroSocio { get; set; }
        public string EstadoHabilitacion { get; set; }
        public double CuotaMensual { get; set; }
        public bool CarnetEntregado { get; set; }



        // Constructor con parámetros
        public E_Socio(E_Usuario usuario,
            string estadoHabilitacion,
            double cuotaMensual,
            bool carnetEntregado)
            : base(usuario.Nombre, usuario.Apellido, usuario.Dni, usuario.Telefono, usuario.Email, usuario.FechaRegistro, usuario.CertificadoMedico)
        {
            NroSocio = usuario.IdUsuario;
            EstadoHabilitacion = estadoHabilitacion;
            CuotaMensual = cuotaMensual;
            CarnetEntregado = carnetEntregado;
        }
        
       
    }

   
    
}
