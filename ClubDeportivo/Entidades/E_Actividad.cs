internal class E_Actividad
{
    public int IdActividad { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public double TarifaSocio { get; set; }
    public double TarifaNoSocio { get; set; }
    public int CupoMaximo { get; set; }
    public string Turno { get; set; }

    public E_Actividad() { }

    public E_Actividad(int idActividad, string nombre, string descripcion,
        double tarifaSocio, double tarifaNoSocio, int cupoMaximo, string turno)
    {
        IdActividad = idActividad;
        Nombre = nombre;
        Descripcion = descripcion;
        TarifaSocio = tarifaSocio;
        TarifaNoSocio = tarifaNoSocio;
        CupoMaximo = cupoMaximo;
        Turno = turno;
    }
}
