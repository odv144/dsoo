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
