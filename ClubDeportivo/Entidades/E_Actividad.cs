using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivo.Entidades
{
    internal class E_Actividad
    {
        public int IdActividad { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double TarifaSocio { get; set; } 
        public double TarifaNoSocio { get; set; }  
        public int CupoMaximo { get; set; }  
        public string Turno { get; set; }

        // Constructor vacío
        public E_Actividad() { }

        // Constructor con parámetros (actualizado con nombres correctos)
        public E_Actividad(int idActividad, string nombre, string descripcion,
            double tarifaSocio, double tarifaNoSocio, int cupoMaximo, string turno)
        {
            this.IdActividad = idActividad;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.TarifaSocio = tarifaSocio;
            this.TarifaNoSocio = tarifaNoSocio;
            this.CupoMaximo = cupoMaximo;
            this.Turno = turno;
        }

    }
}
