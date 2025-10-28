using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivo.Entidades
{
    internal class E_Cuota
    {
        public int IdCuota {  get; set; }
        public int NroSocio {  get; set; }
        public int Mes {  get; set; }
        public int Anio {  get; set; }
        public double Monto { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public DateTime FechaPago { get; set; }
        public string MetodoPago { get; set; }
        public bool EstadoPago {  get; set; }

        public E_Cuota() { }
        public E_Cuota(int idCuota, int nroSocio, int mes, int anio, double monto, DateTime fechaVencimiento, DateTime fechaPago, string metodoPago, bool estadoPago)
        {
            IdCuota = idCuota;
            NroSocio = nroSocio;
            Mes = mes;
            Anio = anio;
            Monto = monto;
            FechaVencimiento = fechaVencimiento;
            FechaPago = fechaPago;
            MetodoPago = metodoPago;
            EstadoPago = estadoPago;
        }
    }
}
