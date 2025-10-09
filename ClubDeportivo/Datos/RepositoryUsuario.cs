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
    internal class RepositoryUsuario
    {
        MySqlConnection sqlCon;
        public int InsertarUsuario(E_Usuario usuario, Boolean asociar)
        {

                    try
                    {
                    sqlCon = Conexion.getInstancia().CrearConexion();
                    string insertUsuario = "INSERT INTO usuario (Nombre,Apellido,Dni,Telefono,Email,FechaRegistro,CertificadoMedico)" +
                                            "VALUES (@Nombre,@Apellido,@Dni,@Telefono,@Email,@FechaRegistro,@CertificadoMedico)";
                    MySqlCommand comando = new MySqlCommand(insertUsuario, sqlCon);
                    comando.Parameters.AddWithValue("@nombre", usuario.Nombre);
                    comando.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                    comando.Parameters.AddWithValue("@Dni", usuario.Dni);
                    comando.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                    comando.Parameters.AddWithValue("Email", usuario.Email);
                    comando.Parameters.AddWithValue("FechaRegistro", usuario.FechaRegistro);
                    comando.Parameters.AddWithValue("CertificadoMedico", usuario.CertificadoMedico);
                    sqlCon.Open();
                    comando.ExecuteNonQuery();
                    usuario.IdUsuario = (int)comando.LastInsertedId;
                   
                    sqlCon.Close();
                     return (int)comando.LastInsertedId;
                /* if (asociar)
            {
                string insertSocio = "INSERT INTO socios (EstadoHabilitacion,CuotaMensual,CarnetEntregado) VALUES (@EstadoHabilitacion,@CuotaMensaul,@CarnetEntregado)";
                MySqlCommand cmd = new MySqlCommand(insertSocio, sqlCon);

                cmd.Parameters.AddWithValue("@EstadoHabilitacion",true);
                    cmd.Parameters.AddWithValue("@CuotaMensual", );
                    cmd.Parameters.AddWithValue("@CarnetEnregado", false);
                    cmd.ExecuteNonQuery();

            }
            else
            {

            }
                    // 2️⃣ Insertar según el tipo
                    if (usuario is Socio socio)
                    {
                        string insertSocio = "INSERT INTO socios (id, cuota_mensual) VALUES (@id, @cuota)";
                        using (var cmd = new MySqlCommand(insertSocio, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@id", socio.Id);
                            cmd.Parameters.AddWithValue("@cuota", socio.CuotaMensual);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else if (usuario is NoSocio noSocio)
                    {
                        string insertNoSocio = "INSERT INTO no_socios (id, tarifa_diaria) VALUES (@id, @tarifa)";
                        using (var cmd = new MySqlCommand(insertNoSocio, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@id", noSocio.Id);
                            cmd.Parameters.AddWithValue("@tarifa", noSocio.TarifaDiaria);
                            cmd.ExecuteNonQuery();
                        }
                    }

                   */
            }
            catch
                    {
                       
                        throw; // Propagamos el error para manejo superior
                    }
                }

         public void InsertarSocio(E_Usuario usuario, string Estado, double Cuota,bool Carnet)
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
        }
        public void CambioEstadoCarnet(int id,bool Estado)
        {
            //llamar a proceso para realizar impresion fisica
            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                string query = @"UPDATE Socio 
                     SET CarnetEntregado = @CarnetEntregado
                     WHERE NroSocio = @NroSocio";
                MySqlCommand cmd = new MySqlCommand(query, sqlCon);
                cmd.Parameters.AddWithValue("@NroSocio",id); // FK al Usuario
                cmd.Parameters.AddWithValue("@CarnetEntregado", Estado);
                sqlCon.Open();
                cmd.ExecuteNonQuery();
                sqlCon.Close();
                MessageBox.Show("Impresion correcta");
            }catch(Exception ex)            
            {
                MessageBox.Show("Error al momento de Imprimir");
            }
        }
      }
        
}
