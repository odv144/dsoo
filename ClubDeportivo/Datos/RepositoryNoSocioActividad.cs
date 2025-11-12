using ClubDeportivo.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivo.Datos
{
    internal class RepositoryNoSocioActividad : RepositoryBase<E_NoSocio_Actividad>
    {
        protected override string ObtenerNombreClavePrimaria() => "idinscripcion";
        protected override string ObtenerNombreTabla() => "nosocio_Actividad";
        protected override E_NoSocio_Actividad MapearDesdeReader(MySqlDataReader reader)
        {
            return new E_NoSocio_Actividad
            {
                IdInscripcion = reader.GetInt32("IdInscripcion"),
                NroNoSocio = reader.GetInt32("NroNoSocio"),
                IdActividad = reader.GetInt32("IdActividad"),
                FechaInscripcion = reader.GetDateTime("FechaInscripcion"),
                Estado = reader.GetString("Estado")
            };
        }



        protected override Dictionary<string, object> ObtenerParametros(E_NoSocio_Actividad SocioActividad)
        {
            return new Dictionary<string, object>
        {
            { "@IdInscripcion", SocioActividad.IdInscripcion },
            { "@NroNoSocio", SocioActividad.NroNoSocio },
            { "@IdActividad", SocioActividad.IdActividad },
            { "@FechaInscripcion", SocioActividad.FechaInscripcion },
            { "@Estado", SocioActividad.Estado }
        };
        }
        public override E_NoSocio_Actividad Insertar(E_NoSocio_Actividad SocioActividad)
        {
            using (MySqlConnection conn = ObtenerConexion())
            {
                string query = @"INSERT INTO NoSocio_Actividad 
                (NroNoSocio, IdActividad, FechaInscripcion, Estado)
                VALUES (@NroNoSocio, @IdActividad, @FechaInscripcion, @Estado);
                SELECT LAST_INSERT_ID();";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                var parametros = ObtenerParametros(SocioActividad);

                foreach (var param in parametros)
                {
                    if (param.Key != "@IdInscripcion")
                        cmd.Parameters.AddWithValue(param.Key, param.Value);
                }

                conn.Open();
                SocioActividad.IdInscripcion = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return ObtenerPorId(SocioActividad.IdInscripcion);
        }
        public override E_NoSocio_Actividad Actualizar(E_NoSocio_Actividad SocioActividad)
        {
            using (MySqlConnection conn = ObtenerConexion())
            {
                string query = @"UPDATE Socio_Actividad 
                SET NroNoSocio = @NroNoSocio,
                    IdActividad = @IdActividad,
                    FechaInscripcion = @FechaInscripcion,
                    Estado = @Estado
                WHERE IdInscripcion = @IdInscripcion";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                var parametros = ObtenerParametros(SocioActividad);

                foreach (var param in parametros)
                {
                    cmd.Parameters.AddWithValue(param.Key, param.Value);
                }

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            return ObtenerPorId(SocioActividad.IdInscripcion); 
        }

        public override bool Eliminar(int idInscripcion)
        {
            using (MySqlConnection conn = ObtenerConexion())
            {
                string query = "DELETE FROM Socio_Actividad WHERE IdInscripcion = @IdInscripcion";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdInscripcion", idInscripcion);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // ====== MÉTODOS ESPECÍFICOS DEL NEGOCIO ======

        // Obtener todas las actividades de un socio
        public List<E_NoSocio_Actividad> ObtenerActividadesPorSocio(int nroSocio)
        {
            List<E_NoSocio_Actividad> lista = new List<E_NoSocio_Actividad>();

            using (MySqlConnection conn = ObtenerConexion())
            {
                string query = @"SELECT 
                sa.*,
                a.Nombre, a.Descripcion, a.TarifaSocio, a.Turno
            FROM Socio_Actividad sa
            INNER JOIN Actividad a ON sa.IdActividad = a.IdActividad
            WHERE sa.NroSocio = @NroSocio
            AND sa.Estado = 'Activo'
            ORDER BY a.Turno, a.Nombre";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NroSocio", nroSocio);

                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        E_NoSocio_Actividad sa = MapearDesdeReader(reader);

                        // Cargar datos de la actividad
                        sa.Actividad = new E_Actividad
                        {
                            IdActividad = sa.IdActividad,
                            Nombre = reader.GetString("Nombre"),
                            Descripcion = reader.GetString("Descripcion"),
                            TarifaSocio = reader.GetDouble("TarifaSocio"),
                            Turno = reader.GetString("Turno")
                        };

                        lista.Add(sa);
                    }
                }
            }
            return lista;
        }

        // Obtener todos los socios inscritos en una actividad
        public List<E_NoSocio_Actividad> ObtenerSociosPorActividad(int idActividad)
        {
            List<E_NoSocio_Actividad> lista = new List<E_NoSocio_Actividad>();

            using (MySqlConnection conn = ObtenerConexion())
            {
                string query = @"SELECT 
                sa.*,
                s.NroNoSocio, s.CarnetEntregado,
                u.Nombre, u.Apellido, u.Dni, u.Telefono, u.Email
            FROM Socio_Actividad sa
            INNER JOIN Socio s ON sa.NroNoSocio = s.NroNoSocio
            INNER JOIN Usuario u ON s.IdUsuario = u.IdUsuario
            WHERE sa.IdActividad = @IdActividad
            AND sa.Estado = 'Activo'
            ORDER BY u.Apellido, u.Nombre";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdActividad", idActividad);

                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        E_NoSocio_Actividad sa = MapearDesdeReader(reader);

                        // Cargar datos del socio y usuario
                        sa.Socio = new E_Socio
                        {
                            Usuario = new E_Usuario
                            {
                                Nombre = reader.GetString("Nombre"),
                                Apellido = reader.GetString("Apellido"),
                                Dni = reader.GetString("Dni"),
                                Telefono = reader.GetString("Telefono"),
                                Email = reader.GetString("Email"),
                                FechaRegistro = reader.GetDateTime("FechaRegistro"),
                                CertificadoMedico = reader.GetBoolean("CertificadoMedico")

                            },
                            EstadoHabilitacion = reader.GetString("EstadoHabilitacion"),
                            CuotaMensual = reader.GetDouble("CuotaMensual"),
                            CarnetEntregado = reader.GetBoolean("CarnetEntregado")
                        };

                        lista.Add(sa);
                    }
                }
            }
            return lista;
        }

        // Verificar si un socio ya está inscrito en una actividad
        public bool EstaInscrito(int nroNoSocio, int idActividad)
        {
            using (MySqlConnection conn = ObtenerConexion())
            {
                string query = @"SELECT COUNT(*) 
                           FROM NoSocio_Actividad 
                           WHERE NroNoSocio = @NroNoSocio 
                           AND IdActividad = @IdActividad
                           AND Estado = 'Activo'";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NroNoSocio", nroNoSocio);
                    cmd.Parameters.AddWithValue("@IdActividad", idActividad);
                    conn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }
        //metodo para devolver una relacion entre actividad y no socio
        /******/
         public DateTime? ObtenerUltimaFechaInscripcion(int nroNoSocio)
{
    using (MySqlConnection conn = ObtenerConexion())
    {
        string query = @"SELECT MAX(fechainscripcion) AS FechaUltimaInscripcion
                        FROM nosocio_actividad
                        WHERE nronosocio = @NroNoSocio";
        
        MySqlCommand cmd = new MySqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@NroNoSocio", nroNoSocio);
        
        conn.Open();
        
        object resultado = cmd.ExecuteScalar();
        
        if (resultado != null && resultado != DBNull.Value)
            return Convert.ToDateTime(resultado);
        else
            return null;
    }
}
        /***** */
        public E_NoSocio_Actividad ObtenerActividadPorId(int nroNoSocio, int idActividad)
        {
            using (MySqlConnection conn = ObtenerConexion())
            {
                string query = @"SELECT * FROM Socio_Actividad 
                           WHERE NroNoSocio = @NroNoSocio 
                           AND IdActividad = @IdActividad
                           AND Estado = 'Activo'";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NroNoSocio", nroNoSocio);
                cmd.Parameters.AddWithValue("@IdActividad", idActividad);

                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        E_NoSocio_Actividad actividad =  MapearDesdeReader(reader);
                    
                    
                        return actividad;
                    }
                    else
                    {
                        return null; // No se encontró el registro
                    }
                }
            }
        }

        // Inscribir socio en actividad (con validaciones)
        public E_NoSocio_Actividad InscribirSocioEnActividad(int nroNoSocio, int idActividad)
        {
            // Validar que no esté ya inscrito
            if (EstaInscrito(nroNoSocio, idActividad))
            {
                throw new Exception("El socio ya está inscrito en esta actividad");
            }

            // Validar que haya cupo disponible
            RepositoryActividad actividadRepo = new RepositoryActividad();
            if (!actividadRepo.TieneCupoDisponible(idActividad))
            {
                throw new Exception("No hay cupo disponible en esta actividad");
            }

            // Validar que el socio esté habilitado
            RepositoryNoSocio socioNoRepo = new RepositoryNoSocio();
            E_NoSocio socio = socioNoRepo.ObtenerPorId(nroNoSocio);
            /*
            if (socio.EstadoHabilitacion != "Activo")
            {
                throw new Exception("El socio no está habilitado");
            }
            */
            // Crear inscripción
            E_NoSocio_Actividad inscripcion = new E_NoSocio_Actividad
            {
                NroNoSocio = nroNoSocio,
                IdActividad = idActividad,
                FechaInscripcion = DateTime.Now,
                Estado = "Activo"
            };

            return Insertar(inscripcion);
        }

        // Cancelar inscripción
        public bool CancelarInscripcion(int nroNoSocio, int idActividad)
        {
            using (MySqlConnection conn = ObtenerConexion())
            {
                string query = @"UPDATE Socio_Actividad 
                SET Estado = 'Cancelado'
                WHERE NroNoSocio = @NroNoSocio 
                AND IdActividad = @IdActividad
                AND Estado = 'Activo'";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NroSocio", nroNoSocio);
                cmd.Parameters.AddWithValue("@IdActividad", idActividad);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Contar actividades de un socio
        public int ContarActividadesDeSocio(int nroSocio)
        {
            using (MySqlConnection conn = ObtenerConexion())
            {
                string query = @"SELECT COUNT(*) FROM Socio_Actividad 
                           WHERE NroNoSocio = @NroNoSocio 
                           AND Estado = 'Activo'";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NroNoSocio", nroSocio);

                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // Contar socios en una actividad
        public int ContarSociosEnActividad(int idActividad)
        {
            using (MySqlConnection conn = ObtenerConexion())
            {
                string query = @"SELECT COUNT(*) FROM NoSocio_Actividad 
                           WHERE IdActividad = @IdActividad 
                           AND Estado = 'Activo'";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdActividad", idActividad);

                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public void ActualizarEstadosDiarios()
        {
            using (var conn = ObtenerConexion())
            {
                string query = @"
            UPDATE NoSocio_Actividad
            SET Estado = 'Inactivo'
            WHERE DATE(FechaInscripcion) < CURDATE()
              AND Estado = 'Activo';";

                var cmd = new MySqlCommand(query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }


}

