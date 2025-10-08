using ClubDeportivo.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubDeportivo.Datos
{
    internal class RepositoryUsuario
    {
        public void InsertarUsuario(E_Usuario usuario)
        {
            MySqlConnection sqlCon;

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
                    MessageBox.Show("Id: " + usuario.IdUsuario);
                sqlCon.Close();
                        
                    /*
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
            }
        
}
