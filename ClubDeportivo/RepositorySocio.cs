using ClubDeportivo.Datos;
using ClubDeportivo.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivo
{
    internal class RepositorySocio
    {
        public void InsertarSocio(E_Socio socio)
        {
            MySqlConnection sqlCon;

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                string insertUsuario = "INSERT INTO socio (NroSocio,EstadoHabilitacion,CuotaMensual,CarnetEntregado)" +
                                        "VALUES (@NroSocio,@EstadoHabilitacion,@CuotaMensual,@CarnetEntregado)";
                MySqlCommand comando = new MySqlCommand(insertUsuario, sqlCon);
                comando.Parameters.AddWithValue("@NroSocio", socio.NroSocio);
                comando.Parameters.AddWithValue("@EstadoHabilitacion", true);
                comando.Parameters.AddWithValue("@CuotaMensual", (double)socio.CuotaMensual);
                comando.Parameters.AddWithValue("@CarnetEntregado", true);
                sqlCon.Open();
                comando.ExecuteNonQuery();
                sqlCon.Close();
            }catch (Exception ex)
            {
                throw;
            }
         }
    }
}
