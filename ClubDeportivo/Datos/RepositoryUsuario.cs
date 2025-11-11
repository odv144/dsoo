using ClubDeportivo.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace ClubDeportivo.Datos
{
    internal class RepositoryUsuario : RepositoryBase<E_Usuario>
    {
        MySqlConnection sqlCon;
        public void InsertarNoSocio(E_Usuario usuario, string Obs)
        {
            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                string query = @"INSERT INTO Nosocio (NroNoSocio,Observacion)
                         VALUES (@NroNoSocio,@Observacion)";
                MySqlCommand cmd = new MySqlCommand(query, sqlCon);
                cmd.Parameters.AddWithValue("@NroNoSocio", usuario.IdUsuario); // FK al Usuario
                cmd.Parameters.AddWithValue("@Observacion", Obs);

                sqlCon.Open();
                cmd.ExecuteNonQuery();
                sqlCon.Close();
                MessageBox.Show("Registro Exito de No socio");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error a la hora de vincular el usuario con el NO socio");

            }
        }

        public void ImpresionComprobante(E_Usuario usuario, int id)
        {
            MessageBox.Show("Comprobante de pago por actividad para: " + usuario.Nombre.ToString());
        }
        public E_Usuario ObtenerSocio(int id)
        {
            E_Usuario socio = new E_Usuario();
            try
            {

                sqlCon = Conexion.getInstancia().CrearConexion();
                //obtengo los datos para  del socio
                string querySelect = @"SELECT 
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
                            WHERE s.NroSocio =  @NroSocio";
                MySqlCommand cmdSelect = new MySqlCommand(querySelect, sqlCon);
                cmdSelect.Parameters.AddWithValue("@NroSocio", id);
                sqlCon.Open();
                MySqlDataReader reader = cmdSelect.ExecuteReader();

                if (reader.Read())
                {
                    MapearDesdeReader(reader);
                    //socio.Nombre = reader.GetString("Nombre");
                    //socio.Apellido = reader.GetString("Apellido");
                    //     CarnetEntregado = reader.GetBoolean("CarnetEntregado"),
                    // ... otros campos que necesites


                }

                //listo

            }
            catch (Exception ex)
            {
            }
            return socio;
        }

        protected override E_Usuario MapearDesdeReader(MySqlDataReader reader)
        {
            return new E_Usuario
            {
                IdUsuario = reader.GetInt32("IdUsuario"),
                Nombre = reader.GetString("Nombre"),
                Apellido = reader.GetString("Apellido"),
                Dni = reader.GetString("Dni"),
                Telefono = reader.GetString("Telefono"),
                Email = reader.GetString("Email"),
                FechaRegistro = reader.GetDateTime("FechaRegistro"),
                CertificadoMedico = reader.GetBoolean("CertificadoMedico")
            };

        }


        protected override string ObtenerNombreTabla() => "Usuario";




        protected override string ObtenerNombreClavePrimaria() => "IdUsuario";




        protected override Dictionary<string, object> ObtenerParametros(E_Usuario entidad)
        {
            return new Dictionary<string, object>
            {

                { "@IdUsuario", entidad.IdUsuario},
                { "@Nombre", entidad.Nombre },
                { "@Apellido", entidad.Apellido },
                { "@Dni", entidad.Dni },
                { "@Telefono", entidad.Telefono },
                { "@Email", entidad.Email },
                { "@FechaRegistro", entidad.FechaRegistro },
                { "@CertificadoMedico", entidad.CertificadoMedico}
            };

        }

        public override E_Usuario Insertar(E_Usuario entidad)
        {
            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                string insertUsuario = "INSERT INTO usuario (Nombre,Apellido,Dni,Telefono,Email,FechaRegistro,CertificadoMedico)" +
                                        "VALUES (@Nombre,@Apellido,@Dni,@Telefono,@Email,@FechaRegistro,@CertificadoMedico);SELECT LAST_INSERT_ID();";
                MySqlCommand comando = new MySqlCommand(insertUsuario, sqlCon);

                var parametros = ObtenerParametros(entidad);

                foreach (var param in parametros)
                {
                    if (param.Key != "@IdActividad")
                        comando.Parameters.AddWithValue(param.Key, param.Value);
                }

                sqlCon.Open();


                entidad.IdUsuario = Convert.ToInt32(comando.ExecuteScalar());


                return entidad;

            }
            catch
            {

                throw;
            }

        }

        public override E_Usuario Actualizar(E_Usuario entidad)
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar(int id)
        {
            throw new NotImplementedException();
        }


        public E_Usuario ObtenerUsuarioPorDni(string dni)
        {
            E_Usuario usuario = null;
            using (MySqlConnection conn = ObtenerConexion())
            {
                string query = $@"SELECT * FROM {ObtenerNombreTabla()} 
                             WHERE Dni = @Dni";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Dni", dni);
                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        usuario = MapearDesdeReader(reader);
                    }
                }
            }
            return usuario;
        }


        public E_Usuario ObtenerUsuarioPorEmail(string email)
        {
            using (MySqlConnection conn = ObtenerConexion())
            {
                string query = "SELECT * FROM usuario WHERE email = @Email";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);

                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return MapearDesdeReader(reader);
                    }
                }
            }
            return null;
        }


    }
}
