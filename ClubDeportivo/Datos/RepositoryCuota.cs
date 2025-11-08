using ClubDeportivo.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivo.Datos
{
    internal class RepositoryCuota : RepositoryBase<E_Cuota>
    {
        protected override string ObtenerNombreTabla() => "Cuota";
        protected override string ObtenerNombreClavePrimaria() => "IdCuota"; // aqui decia NroCuota

        protected override E_Cuota MapearDesdeReader(MySqlDataReader reader)
        {
            //nos habiamos olvidado de que estado de cuota era un enum lo cambie en bd a string
           // string estadoPagoStr = reader.GetString("EstadoPago");
            //bool estadoPagoBool = estadoPagoStr.Equals("Pagada", StringComparison.OrdinalIgnoreCase);

            return new E_Cuota
            {
                IdCuota= reader.GetInt32("IdCuota"),
                NroSocio= reader.GetInt32("NroSocio"),
                Mes=reader.GetInt32("Mes"),
                Anio=reader.GetInt32("Anio"),
                Monto=reader.GetDouble("Monto"),
                FechaVencimiento=reader.GetDateTime("FechaVencimiento"),
                FechaPago=reader.GetDateTime("FechaPago"),
                MetodoPago=reader.IsDBNull(reader.GetOrdinal("MetodoPago"))
                    ? null
                    : reader.GetString("MetodoPago"),
                EstadoPago= reader.GetBoolean("estadoPago")
            };
        }

        protected override Dictionary<string, object> ObtenerParametros(E_Cuota cuota)
        {
            return new Dictionary<string, object>
        {
            { "@NroCuota", cuota.IdCuota },
            { "@NroSocio", cuota.NroSocio },
            { "@Mes", cuota.Mes },
            { "@Anio", cuota.Anio },
            { "@Monto", cuota.Monto },
            { "@FechaVencimiento", cuota.FechaVencimiento },
            { "@FechaPago", (object)cuota.FechaPago ?? DBNull.Value },
            { "@MetodoPago", (object)cuota.MetodoPago ?? DBNull.Value },
            { "@EstadoPago", cuota.EstadoPago }
        };
        }

        public override E_Cuota Insertar(E_Cuota cuota)
        {
            using (MySqlConnection conn = ObtenerConexion())
            {
                string query = @"INSERT INTO Cuota 
                (NroSocio, Mes, Anio, Monto, FechaVencimiento, FechaPago, MetodoPago, EstadoPago)
                VALUES (@NroSocio, @Mes, @Anio, @Monto, @FechaVencimiento, @FechaPago, @MetodoPago, @EstadoPago);
                SELECT LAST_INSERT_ID();";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                var parametros = ObtenerParametros(cuota);

                foreach (var param in parametros)
                {
                    if (param.Key != "@NroCuota")
                        cmd.Parameters.AddWithValue(param.Key, param.Value);
                }

                conn.Open();
                cuota.IdCuota = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return ObtenerPorId(cuota.IdCuota);
        }

        public override E_Cuota Actualizar(E_Cuota cuota)
        {
            using (MySqlConnection conn = ObtenerConexion())
            {
                string query = @"UPDATE Cuota 
                SET NroSocio = @NroSocio,
                    Mes = @Mes,
                    Anio = @Anio,
                    Monto = @Monto,
                    FechaVencimiento = @FechaVencimiento,
                    FechaPago = @FechaPago,
                    MetodoPago = @MetodoPago,
                    EstadoPago = @EstadoPago
                WHERE NroCuota = @NroCuota";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                var parametros = ObtenerParametros(cuota);

                foreach (var param in parametros)
                {
                    cmd.Parameters.AddWithValue(param.Key, param.Value);
                }

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            return ObtenerPorId(cuota.IdCuota);
        }

        public override bool Eliminar(int nroCuota)
        {
            using (MySqlConnection conn = ObtenerConexion())
            {
                string query = "DELETE FROM Cuota WHERE NroCuota = @NroCuota";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NroCuota", nroCuota);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Métodos específicos del negocio
        public List<E_Cuota> ObtenerCuotasPorSocio(int nroSocio)
        {
            List<E_Cuota> lista = new List<E_Cuota>();

            using (MySqlConnection conn = ObtenerConexion())
            {
                string query = @"SELECT * FROM Cuota 
                           WHERE NroSocio = @NroSocio 
                           ORDER BY FechaVencimiento DESC";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NroSocio", nroSocio);

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

        public List<E_Cuota> ObtenerCuotasVencidasHoy()
        {
            List<E_Cuota> lista = new List<E_Cuota>();

            using (MySqlConnection conn = ObtenerConexion())
            {
                string query = @"SELECT * FROM Cuota 
                           WHERE DATE(FechaVencimiento) = CURDATE() 
                           AND EstadoPago = 'Pendiente'";

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

        public DataTable ObtenerVencimientos()
        {
            DataTable dt = new DataTable();

            using (MySqlConnection conn = ObtenerConexion())
            {
                string query = @"
            SELECT 
                s.nrosocio,
                CONCAT(u.nombre, ' ', u.apellido) AS NombreCompleto,
                c.mes,
                c.anio,
                c.monto,
                c.fechavencimiento,
                CASE 
                    WHEN CURDATE() > c.fechavencimiento THEN 'VENCIDO'
                    WHEN DATEDIFF(c.fechavencimiento, CURDATE()) <= 3 THEN 'PRÓXIMO A VENCER'
                    ELSE 'AL DÍA'
                END AS Estado
            FROM cuota c
            INNER JOIN socio s ON c.nrosocio = s.nrosocio
            INNER JOIN usuario u ON s.idusuario = u.idusuario
            ORDER BY c.fechavencimiento ASC;";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }

            return dt;
        }

    }
}
