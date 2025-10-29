using ClubDeportivo.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivo.Datos
{
    internal class RepositoryActividad : RepositoryBase<E_Actividad>
    {
        protected override string ObtenerNombreTabla() => "Actividad";
        protected override string ObtenerNombreClavePrimaria() => "IdActividad";

        protected override E_Actividad MapearDesdeReader(MySqlDataReader reader)
        {
            return new E_Actividad
            {
                IdActividad = reader.GetInt32("IdActividad"),
                Nombre = reader.GetString("Nombre"),
                Descripcion = reader.GetString("Descripcion"),
                TarifaSocio = reader.GetDouble("TarifaSocio"),
                TarifaNoSocio = reader.GetDouble("TarifaNoSocio"),
                CupoMaximo = reader.GetInt32("CupoMaximo"),
                Turno = reader.GetString("Turno")
            };
      
        }

        protected override Dictionary<string, object> ObtenerParametros(E_Actividad actividad)
        {
            return new Dictionary<string, object>
        {
            { "@IdActividad", actividad.IdActividad },
            {"@NroSocio" ,actividad.NroSocio},
            {"@NroNoSocio", actividad.NroNoSocio },
            { "@Nombre", actividad.Nombre },
            { "@Descripcion", actividad.Descripcion },
            { "@TarifaSocio", actividad.TarifaSocio },
            { "@TarifaNoSocio", actividad.TarifaNoSocio },
            { "@CupoMaximo", actividad.CupoMaximo },
            { "@Turno", actividad.Turno }
        };
        }

        public override E_Actividad Insertar(E_Actividad actividad)
        {
            using (MySqlConnection conn = ObtenerConexion())
            {
                string query = @"INSERT INTO Actividad 
                (NroSocio,NroNoSocio,Nombre, Descripcion, TarifaSocio, TarifaNoSocio, CupoMaximo, Turno)
                VALUES (@Nombre, @Descripcion, @TarifaSocio, @TarifaNoSocio, @CupoMaximo, @Turno);
                SELECT LAST_INSERT_ID();";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                var parametros = ObtenerParametros(actividad);

                foreach (var param in parametros)
                {
                    if (param.Key != "@IdActividad")
                        cmd.Parameters.AddWithValue(param.Key, param.Value);
                }

                conn.Open();
                actividad.IdActividad = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return ObtenerPorId(actividad.IdActividad);
        }

        public override E_Actividad Actualizar(E_Actividad actividad)
        {
            using (MySqlConnection conn = ObtenerConexion())
            {
                string query = @"UPDATE Actividad 
                SET NroSocio = @NroSocio,
                    NroNoSocio=@NroNoSocio,
                    Nombre = @Nombre,
                    Descripcion = @Descripcion,
                    TarifaSocio = @TarifaSocio,
                    TarifaNoSocio = @TarifaNoSocio,
                    CupoMaximo = @CupoMaximo,
                    Turno = @Turno
                WHERE IdActividad = @IdActividad";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                var parametros = ObtenerParametros(actividad);

                foreach (var param in parametros)
                {
                    cmd.Parameters.AddWithValue(param.Key, param.Value);
                }

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            return ObtenerPorId(actividad.IdActividad);
        }

        public override bool Eliminar(int idActividad)
        {
            using (MySqlConnection conn = ObtenerConexion())
            {
                string query = "DELETE FROM Actividad WHERE IdActividad = @IdActividad";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdActividad", idActividad);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // ====== MÉTODOS ESPECÍFICOS COMO REGLAS DEL NEGOCIO ======

        public bool TieneCupoDisponible(int idActividad)
        {
            using (MySqlConnection conn = ObtenerConexion())
            {
                // Cuenta cuántos socios están inscritos actualmente
                string query = @"SELECT 
                a.CupoMaximo,
                COUNT(DISTINCT sa.NroSocio) as Inscritos
            FROM Actividad a
            LEFT JOIN Socio_Actividad sa ON a.IdActividad = sa.IdActividad
            WHERE a.IdActividad = @IdActividad
            GROUP BY a.IdActividad, a.CupoMaximo";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdActividad", idActividad);

                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int cupoMaximo = reader.GetInt32("CupoMaximo");
                        int inscritos = reader.GetInt32("Inscritos");
                        return inscritos < cupoMaximo;
                    }
                }
            }
            return false;
        }

        public double ObtenerTarifa(int idActividad, bool esSocio)
        {
            using (MySqlConnection conn = ObtenerConexion())
            {
                string query = esSocio
                    ? "SELECT TarifaSocio FROM Actividad WHERE IdActividad = @IdActividad"
                    : "SELECT TarifaNoSocio FROM Actividad WHERE IdActividad = @IdActividad";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdActividad", idActividad);

                conn.Open();
                object resultado = cmd.ExecuteScalar();
                return resultado != null ? Convert.ToDouble(resultado) : 0;
            }
        }

        public List<E_Actividad> ObtenerPorTurno(string turno)
        {
            List<E_Actividad> lista = new List<E_Actividad>();

            using (MySqlConnection conn = ObtenerConexion())
            {
                string query = "SELECT * FROM Actividad WHERE Turno = @Turno";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Turno", turno);

                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(MapearDesdeReader(reader));
                    }
                }
            }
            return lista;
        }

        public List<E_Actividad> ObtenerActividadesConCupoDisponible()
        {
            List<E_Actividad> lista = new List<E_Actividad>();

            using (MySqlConnection conn = ObtenerConexion())
            {
                string query = @"SELECT *  FROM Actividad WHERE CupoMaximo>0";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(MapearDesdeReader(reader));
                    }
                }
            }
            return lista;
        }

        public int ObtenerCupoActual(int idActividad)
        {
            using (MySqlConnection conn = ObtenerConexion())
            {
                string query = @"SELECT COUNT(DISTINCT NroSocio) 
                FROM Socio_Actividad 
                WHERE IdActividad = @IdActividad";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdActividad", idActividad);

                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public Dictionary<string, object> ObtenerEstadisticasActividad(int idActividad)
        {
            using (MySqlConnection conn = ObtenerConexion())
            {
                string query = @"SELECT 
                a.Nombre,
                a.CupoMaximo,
                COUNT(DISTINCT sa.NroSocio) as TotalInscritos,
                (a.CupoMaximo - COUNT(DISTINCT sa.NroSocio)) as CupoDisponible,
                COUNT(DISTINCT pa.IdPagoActividad) as PagosNoSocios
            FROM Actividad a
            LEFT JOIN Socio_Actividad sa ON a.IdActividad = sa.IdActividad
            LEFT JOIN PagoActividad pa ON a.IdActividad = pa.IdActividad
            WHERE a.IdActividad = @IdActividad
            GROUP BY a.IdActividad";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdActividad", idActividad);

                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Dictionary<string, object>
                    {
                        { "Nombre", reader.GetString("Nombre") },
                        { "CupoMaximo", reader.GetInt32("CupoMaximo") },
                        { "TotalInscritos", reader.GetInt32("TotalInscritos") },
                        { "CupoDisponible", reader.GetInt32("CupoDisponible") },
                        { "PagosNoSocios", reader.GetInt32("PagosNoSocios") }
                    };
                    }
                }
            }
            return null;
            /*
            MySqlConnection sqlCon = null;

            void IRepository.GuardarDatos()
            {
                try
                {
                    sqlCon = Conexion.getInstancia().CrearConexion();
                    string query = "SELECT * FROM Actividad";
                    MySqlCommand cmd = new MySqlCommand(query, sqlCon);
                    sqlCon.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();


                }
                catch (Exception ex)
                {
                    throw new NotImplementedException();

                }
            }
            void IRepository.ModificarDatos()
            {
                throw new NotImplementedException();
            }

            void IRepository.ObtenerDatoPorID()
            {
                throw new NotImplementedException();
            }

            public void ObtenerDatos()
            {
                try
                {
                    sqlCon = Conexion.getInstancia().CrearConexion();
                    string query = "SELECT * FROM Actividad";
                    MySqlCommand cmd = new MySqlCommand(query, sqlCon);
                    sqlCon.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();


                }
                catch (Exception ex)
                {
                    throw new NotImplementedException();

                }
            }
            */
        }
    }
}
