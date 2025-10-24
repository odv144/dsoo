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
        /*public void InsertarSocio(E_Usuario usuario, string Estado, double Cuota, bool Carnet)
        {
            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                string query = @"INSERT INTO Socio (NroSocio, EstadoHabilitacion, CuotaMensual, CarnetEntregado)
                         VALUES (@NroSocio, @EstadoHabilitacion, @CuotaMensual, @CarnetEntregado)";
                MySqlCommand cmd = new MySqlCommand(query, sqlCon);
                cmd.Parameters.AddWithValue("@NroSocio", usuario.IdUsuario); // FK al Usuario
                cmd.Parameters.AddWithValue("@EstadoHabilitacion", Estado);
                cmd.Parameters.AddWithValue("@CuotaMensual", Cuota);
                cmd.Parameters.AddWithValue("@CarnetEntregado", Carnet);

                sqlCon.Open();
                cmd.ExecuteNonQuery();
                sqlCon.Close();
                MessageBox.Show("Registro Exito");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error a la hora de vincular el usuario con el socio");

            }
        }*/
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
        public void CambioEstadoCarnet(int id, bool Estado)
        {
            //llamar a proceso para realizar impresion fisica
            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                string query = @"UPDATE Socio 
                     SET CarnetEntregado = @CarnetEntregado
                     WHERE NroSocio = @NroSocio";
                MySqlCommand cmd = new MySqlCommand(query, sqlCon);
                cmd.Parameters.AddWithValue("@NroSocio", id); // FK al Usuario
                cmd.Parameters.AddWithValue("@CarnetEntregado", Estado);
                sqlCon.Open();
                cmd.ExecuteNonQuery();


                sqlCon.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al momento de Imprimir");
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
                string querySelect = @"SELECT * FROM Socio s INNER JOIN Usuario u ON u.IdUsuario = s.NroSocio WHERE s.NroSocio = @NroSocio";
                MySqlCommand cmdSelect = new MySqlCommand(querySelect, sqlCon);
                cmdSelect.Parameters.AddWithValue("@NroSocio", id);
                sqlCon.Open();
                MySqlDataReader reader = cmdSelect.ExecuteReader();

                if (reader.Read())
                {
                    
                    socio.Nombre = reader.GetString("Nombre");
                    socio.Apellido = reader.GetString("Apellido");
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
            throw new NotImplementedException();
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
                                        "VALUES (@Nombre,@Apellido,@Dni,@Telefono,@Email,@FechaRegistro,@CertificadoMedico)";
                MySqlCommand comando = new MySqlCommand(insertUsuario, sqlCon);

                var parametros = ObtenerParametros(entidad);

                foreach (var param in parametros)
                {
                    if (param.Key != "@IdActividad")
                        comando.Parameters.AddWithValue(param.Key, param.Value);
                }

                sqlCon.Open();

                //actividad.IdActividad = Convert.ToInt32(cmd.ExecuteScalar());
                entidad.IdUsuario = Convert.ToInt32(comando.ExecuteScalar());


                return ObtenerPorId(entidad.IdUsuario);

            }
            catch
            {

                throw; // Propagamos el error para manejo superior
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
    }  
}
