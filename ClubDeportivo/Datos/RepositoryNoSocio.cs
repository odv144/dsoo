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
    internal class RepositoryNoSocio : RepositoryBase<E_NoSocio>
    {
        MySqlConnection sqlCon;

        protected override string ObtenerNombreTabla() => "nosocio";
        protected override string ObtenerNombreClavePrimaria() => "NroNoSocio";


        //controlar las relaciones FK con Usuario
        public override E_NoSocio Insertar(E_NoSocio entidad)
        {
            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();

                string query = @"INSERT INTO nosocio (IdUsuario, Observacion)
                                 VALUES (@IdUsuario, @Observacion)";

                MySqlCommand cmd = new MySqlCommand(query, sqlCon);
                var parametros = ObtenerParametros(entidad);

                foreach (var param in parametros)
                {
                    cmd.Parameters.AddWithValue(param.Key, param.Value);
                }

                sqlCon.Open();
                cmd.ExecuteNonQuery();
                sqlCon.Close();

                MessageBox.Show("Registro exitoso de No Socio");
                return entidad;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar No Socio: " + ex.Message);
                return null;
            }
        }



        protected override E_NoSocio MapearDesdeReader(MySqlDataReader reader)
        {
            try
            {
                E_Usuario usuario = new E_Usuario
                {
                    
                    IdUsuario = reader.GetInt32("NroNoSocio"),
                    
                    Nombre = reader["Nombre"] != DBNull.Value ? reader.GetString("Nombre") : "",
                    Apellido = reader["Apellido"] != DBNull.Value ? reader.GetString("Apellido") : "",
                    Dni = reader["Dni"] != DBNull.Value ? reader.GetString("Dni") : "",
                    Telefono = reader["Telefono"] != DBNull.Value ? reader.GetString("Telefono") : "",
                    Email = reader["Email"] != DBNull.Value ? reader.GetString("Email") : "",
                    FechaRegistro = reader["FechaRegistro"] != DBNull.Value ? reader.GetDateTime("FechaRegistro") : DateTime.Now,
                    CertificadoMedico = reader["CertificadoMedico"] != DBNull.Value && reader.GetBoolean("CertificadoMedico")
                };

                string observacion = reader["Observacion"] != DBNull.Value ? reader.GetString("Observacion") : "";

                return new E_NoSocio(usuario, observacion);
            }
            catch
            {
                return null;
            }
        }

        protected override Dictionary<string, object> ObtenerParametros(E_NoSocio entidad)
        {
            return new Dictionary<string, object>
            {
           
                { "@NroNoSocio", entidad.NroNoSocio },
                { "@IdUsuario", entidad.IdUsuario },
                { "@Observacion", entidad.Observacion }
            };
        }

        public override E_NoSocio Actualizar(E_NoSocio entidad)
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public DataTable ListarNoSocios()
        {
            DataTable tabla = new DataTable();
            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();

                string query = @"
            SELECT 
                n.NroNoSocio,
                u.Nombre,
                u.Apellido,
                u.Dni,
                u.Telefono,
                u.Email,
                n.Observacion
            FROM nosocio n
            INNER JOIN usuario u ON n.IdUsuario = u.IdUsuario";

                MySqlCommand cmd = new MySqlCommand(query, sqlCon);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(tabla);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar no socios: " + ex.Message);
            }
            return tabla;
        }


        /*  public override E_NoSocio ObtenerPorId(int id)
          {
              E_NoSocio noSocio = null;

              try
              {
                  sqlCon = Conexion.getInstancia().CrearConexion();

                  // INNER JOIN con la tabla Usuario, ya que hereda de E_Usuario
                  string query = @"SELECT u.*, n.Observacion 
                                   FROM nosocio n 
                                   INNER JOIN usuario u ON u.IdUsuario = n.NroNoSocio 
                                   WHERE n.NroNoSocio = @NroNoSocio";

                  MySqlCommand cmd = new MySqlCommand(query, sqlCon);
                  cmd.Parameters.AddWithValue("@NroNoSocio", id);

                  sqlCon.Open();
                  MySqlDataReader reader = cmd.ExecuteReader();

                  if (reader.Read())
                  {
                      noSocio = MapearDesdeReader(reader);
                  }

                  sqlCon.Close();
              }
              catch (Exception ex)
              {
                  MessageBox.Show("Error al obtener No Socio: " + ex.Message);
              }

              return noSocio;
          }*/
    }
}
