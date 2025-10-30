using ClubDeportivo.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubDeportivo.Datos
{

    internal class RepositorySocio : RepositoryBase<E_Socio>
    {
        MySqlConnection sqlCon;
        protected override string ObtenerNombreTabla() => "Socio";
        protected override string ObtenerNombreClavePrimaria() => "NroSocio";
        public override E_Socio Actualizar(E_Socio entidad)
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public override E_Socio Insertar(E_Socio entidad)
        {
            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                string query = @"INSERT INTO Socio (IdUsuario, EstadoHabilitacion, CuotaMensual, CarnetEntregado)
                         VALUES (@IdUsuario, @EstadoHabilitacion, @CuotaMensual, @CarnetEntregado);SELECT LAST_INSERT_ID();";
                MySqlCommand cmd = new MySqlCommand(query, sqlCon);
                

                var parametros = ObtenerParametros(entidad);

                foreach (var param in parametros)
                {
                    if (param.Key != "@IdActividad")
                        cmd.Parameters.AddWithValue(param.Key, param.Value);
                }

                sqlCon.Open();

                //actividad.IdActividad = Convert.ToInt32(cmd.ExecuteScalar());
                int NroSocio = Convert.ToInt32(cmd.ExecuteScalar());

                MessageBox.Show("Registro Exito");
                E_Socio socio =  ObtenerConUsuario(NroSocio); ;
                sqlCon.Close();
                return socio;
               
                
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error a la hora de vincular el usuario con el socio");
                return null;

            }
        }


        protected override E_Socio MapearDesdeReader(MySqlDataReader reader)
        {
            //buscar new E_Sociocomo mapear el usuario dentro del socio
            return new E_Socio
                {
                NroSocio = reader.GetInt32("NroSocio"),
                IdUsuario = reader.GetInt32("IdUsuario"),
                EstadoHabilitacion = reader.GetString("EstadoHabilitacion"),
                CarnetEntregado = reader.GetBoolean("CarnetEntregado"),
                CuotaMensual = reader.GetDouble("CuotaMensual"),

                // ⭐ CARGAR OBJETO USUARIO RELACIONADO
                Usuario = new E_Usuario
                {
                    IdUsuario = reader.GetInt32("IdUsuario"),
                    Nombre = reader.GetString("Nombre"),
                    Apellido = reader.GetString("Apellido"),
                    Dni = reader.GetString("Dni"),
                    Telefono = reader.GetString("Telefono"),
                    Email = reader.GetString("Email")
                }
            };
        }

       

        protected override Dictionary<string, object> ObtenerParametros(E_Socio entidad)
        {
            return new Dictionary<string, object>
                {
                {"@NroSocio", entidad.NroSocio },
                {"@IdUsuario", entidad.IdUsuario },
                {"@EstadoHabilitacion", entidad.EstadoHabilitacion },
                {"@CuotaMensual", entidad.CuotaMensual },
                {"@CarnetEntregado", entidad.CarnetEntregado }
            };
        }

        //metodo para mostrar socios en el datagridview
     

        public DataTable ListarSocios()
        {
            DataTable tabla = new DataTable();
            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();

                string query = @"
                SELECT 
                    s.NroSocio,
                    u.Nombre,
                    u.Apellido,
                    u.Dni,
                    u.Telefono,
                    u.Email,
                    s.EstadoHabilitacion,
                    s.CuotaMensual,
                    s.CarnetEntregado
                FROM Socio s
                INNER JOIN Usuario u ON s.IdUsuario = u.IdUsuario";

                MySqlCommand cmd = new MySqlCommand(query, sqlCon);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(tabla);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar socios: " + ex.Message);
            }
            return tabla;
        }
        // ⭐ MÉTODO CLAVE: Obtener Socio CON su Usuario (JOIN)
        public E_Socio ObtenerConUsuario(int nroSocio)
        {
            using (MySqlConnection conn = ObtenerConexion())
            {
                // JOIN entre Socio y Usuario
                string query = @"
                SELECT 
                    s.NroSocio, 
                    s.IdUsuario,
                    s.EstadoHabilitacion, 
                    s.CarnetEntregado, 
                    s.CuotaMensual,
                    u.Nombre, 
                    u.Apellido, 
                    u.Dni, 
                    u.Telefono, 
                    u.Email
                FROM Socio s
                INNER JOIN Usuario u ON s.IdUsuario = u.IdUsuario
                WHERE s.NroSocio = @NroSocio";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NroSocio", nroSocio);

                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // ⭐ MAPEO: Crear objeto Socio
                       

                        return MapearDesdeReader(reader);
                    }
                }
            }
            return null;
        }
        // Obtener socio por DNI del usuario
        public E_Socio ObtenerPorDniUsuario(string dni)
        {
            using (MySqlConnection conn = ObtenerConexion())
            {
                string query = @"
                SELECT 
                    s.NroSocio, 
                    s.IdUsuario,
                    s.EstadoHabilitacion, 
                    s.CarnetEntregado, 
                    s.CuotaMensual,
                    u.Nombre, 
                    u.Apellido, 
                    u.Dni, 
                    u.Telefono, 
                    u.Email
                FROM Socio s
                INNER JOIN Usuario u ON s.IdUsuario = u.IdUsuario
                WHERE u.Dni = @Dni";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Dni", dni);

                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new E_Socio
                        {
                            NroSocio = reader.GetInt32("NroSocio"),
                            IdUsuario = reader.GetInt32("IdUsuario"),
                            EstadoHabilitacion = reader.GetString("EstadoHabilitacion"),
                            CarnetEntregado = reader.GetBoolean("CarnetEntregado"),
                            CuotaMensual = reader.GetDouble("CuotaMensual"),
                            Usuario = new E_Usuario
                            {
                                IdUsuario = reader.GetInt32("IdUsuario"),
                                Nombre = reader.GetString("Nombre"),
                                Apellido = reader.GetString("Apellido"),
                                Dni = reader.GetString("Dni"),
                                Telefono = reader.GetString("Telefono"),
                                Email = reader.GetString("Email")
                            }
                        };
                    }
                }
            }
            return null;
        }

    }
}
