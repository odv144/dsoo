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
        public E_Socio(
            //int idUsuario,
            string nombre,
            string apellido,
            string dni,
            string telefono,
            string email,
            DateTime fechaRegistro,
            bool certificadoMedico,
            //int nroSocio,
            string estadoHabilitacion,
            double cuotaMensual,
            bool carnetEntregado)
            : base(/*idUsuario*/ nombre, apellido, dni, telefono, email, fechaRegistro, certificadoMedico)
        {
            //NroSocio = nroSocio;
            EstadoHabilitacion = estadoHabilitacion;
            CuotaMensual = cuotaMensual;
            CarnetEntregado = carnetEntregado;
        }
    }

   
    
}
