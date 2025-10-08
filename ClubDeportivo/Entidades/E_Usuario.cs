using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivo.Entidades

{
    internal class E_Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool CertificadoMedico { get; set; }

        public E_Usuario( string nombre, 
            string apellido, string dni,
            string telefono, 
            string email, DateTime fechaRegistro, bool certificadoMedico)
        {
           
            Nombre = nombre;
            Apellido = apellido;
            Dni = dni;
            Telefono = telefono;
            Email = email;
            FechaRegistro = fechaRegistro;
            CertificadoMedico = certificadoMedico;
        }
    }
}