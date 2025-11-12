using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivo.Entidades
{
    internal class E_NoSocio_Actividad
    {
        public int IdInscripcion { get; set; }
        public int NroNoSocio { get; set; }
        public int IdActividad { get; set; }
        public DateTime FechaInscripcion { get; set; }
        public string Estado { get; set; } // 'Activo', 'Cancelado', 'Completado'

        // Propiedades de navegación (para cargar objetos relacionados)
        public E_Socio Socio { get; set; }
        public E_Actividad Actividad { get; set; }
        public E_NoSocio_Actividad() { }
    }
}
