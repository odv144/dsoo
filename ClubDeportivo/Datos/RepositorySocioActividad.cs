using ClubDeportivo.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivo.Datos
{
    internal class RepositorySocioActividad : RepositoryBase<E_Socio_Actividad>
    {
        protected override string ObtenerNombreClavePrimaria() => "E_Socio_Acitividad";
        protected override string ObtenerNombreTabla() => "Socio_Actividad";
        protected override E_Socio_Actividad MapearDesdeReader(MySqlDataReader reader)
        {
            return new E_Socio_Actividad
            {
                IdInscripcion = reader.GetInt32("IdInscripcion"),
                NroSocio = reader.GetInt32("NroSocio"),
                NroNoSocio = reader.GetInt32("NroNoSocio"),
                IdActividad = reader.GetInt32("IdActividad"),
                FechaInscripcion = reader.GetDateTime("FechaInscripcion"),
                Estado = reader.GetString("Estado")
            };
        }



        protected override Dictionary<string, object> ObtenerParametros(E_Socio_Actividad SocioActividad)
        {
            return new Dictionary<string, object>
        {
            { "@IdInscripcion", SocioActividad.IdInscripcion },
            { "@NroSocio", SocioActividad.NroSocio },
            { "@NroNoSocio", SocioActividad.NroNoSocio },
            { "@IdActividad", SocioActividad.IdActividad },
            { "@FechaInscripcion", SocioActividad.FechaInscripcion },
            { "@Estado", SocioActividad.Estado }
        };
        }
        public override E_Socio_Actividad Insertar(E_Socio_Actividad SocioActividad)
        {
            using (MySqlConnection conn = ObtenerConexion())
            {
                string query = @"INSERT INTO Socio_Actividad 
                (NroSocio, IdActividad, FechaInscripcion, Estado)
                VALUES (@NroSocio,@NroNoSocio, @IdActividad, @FechaInscripcion, @Estado);
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
        public override E_Socio_Actividad Actualizar(E_Socio_Actividad SocioActividad)
        {
            using (MySqlConnection conn = ObtenerConexion())
            {
                string query = @"UPDATE Socio_Actividad 
                SET NroSocio = @NroSocio,
                    NroNoSocio = @NroNoSocio,
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
        public List<E_Socio_Actividad> ObtenerActividadesPorSocio(int nroSocio)
        {
            List<E_Socio_Actividad> lista = new List<E_Socio_Actividad>();

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
                        E_Socio_Actividad sa = MapearDesdeReader(reader);

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
        public List<E_Socio_Actividad> ObtenerSociosPorActividad(int idActividad)
        {
            List<E_Socio_Actividad> lista = new List<E_Socio_Actividad>();

            using (MySqlConnection conn = ObtenerConexion())
            {
                string query = @"SELECT 
                sa.*,
                s.NroSocio, s.CarnetEntregado,
                u.Nombre, u.Apellido, u.Dni, u.Telefono, u.Email
            FROM Socio_Actividad sa
            INNER JOIN Socio s ON sa.NroSocio = s.NroSocio
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
                        E_Socio_Actividad sa = MapearDesdeReader(reader);

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
        public bool EstaInscrito(int nroSocio, int idActividad)
        {
            using (MySqlConnection conn = ObtenerConexion())
            {
                string query = @"SELECT COUNT(*) FROM Socio_Actividad 
                           WHERE NroSocio = @NroSocio 
                           AND IdActividad = @IdActividad
                           AND Estado = 'Activo'";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NroSocio", nroSocio);
                cmd.Parameters.AddWithValue("@IdActividad", idActividad);

                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        // Inscribir socio en actividad (con validaciones)
        public E_Socio_Actividad InscribirSocioEnActividad(int nroSocio, int idActividad)
        {
            // Validar que no esté ya inscrito
            if (EstaInscrito(nroSocio, idActividad))
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
            RepositorySocio socioRepo = new RepositorySocio();
            E_Socio socio = socioRepo.ObtenerPorId(nroSocio);
            if (socio.EstadoHabilitacion != "Activo")
            {
                throw new Exception("El socio no está habilitado");
            }

            // Crear inscripción
            E_Socio_Actividad inscripcion = new E_Socio_Actividad
            {
                NroSocio = nroSocio,
                IdActividad = idActividad,
                FechaInscripcion = DateTime.Now,
                Estado = "Activo"
            };

            return Insertar(inscripcion);
        }

        // Cancelar inscripción
        public bool CancelarInscripcion(int nroSocio, int idActividad)
        {
            using (MySqlConnection conn = ObtenerConexion())
            {
                string query = @"UPDATE Socio_Actividad 
                SET Estado = 'Cancelado'
                WHERE NroSocio = @NroSocio 
                AND IdActividad = @IdActividad
                AND Estado = 'Activo'";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NroSocio", nroSocio);
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
                           WHERE NroSocio = @NroSocio 
                           AND Estado = 'Activo'";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NroSocio", nroSocio);

                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // Contar socios en una actividad
        public int ContarSociosEnActividad(int idActividad)
        {
            using (MySqlConnection conn = ObtenerConexion())
            {
                string query = @"SELECT COUNT(*) FROM Socio_Actividad 
                           WHERE IdActividad = @IdActividad 
                           AND Estado = 'Activo'";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdActividad", idActividad);

                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }


}

