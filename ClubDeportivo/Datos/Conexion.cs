using ClubDeportivo.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivo.Datos
{
    internal class Conexion
    {
        private static Conexion con;
        
        private string servidor;
        private string puerto;
        private string bd;
        private string usuario;
        private string password;
        
        private string connectionString;

        //cualquiera de estas dos cadenas conecta bien a MYSQL
        //string cadenaConecion = "Server=127.0.0.1;Port=3307;Database=biblioteca;User ID=root;Password=odv144;SslMode=None;CharSet=utf8;";
       
        public Conexion()
        {
            this.servidor = "127.0.0.1";
            this.puerto =  "3307";
            this.bd = "proyecto";
            this.usuario = "root";
            this.password = "odv144";
        }
      
        public static Conexion getInstancia()
        {
            if (con == null)
            {
                con = new Conexion();
            }
            return con;
        }
        public void ConfigurarConexion(string server, string port,string bd,string user,string pass)
        {
            this.servidor = server;//"127.0.0.1";
            this.puerto = port;// "3307";
            this.bd = bd;
            this.usuario = user;// "root";
            this.password = pass;// "odv144";
            ActualizarConnectionString();
        }
        public void ActualizarConnectionString()
        {
             
            connectionString = "datasource=" + this.servidor +
                                               "; port=" + this.puerto +
                                               ";Database=" + this.bd +
                                               ";username=" + this.usuario +
                                               ";password=" + this.password;
            
        }
        public MySqlConnection CrearConexion()
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                ActualizarConnectionString();
            }
            return new MySqlConnection(connectionString);

        }
        public bool ProbarConexion(out string mensaje)
        {
            try
            {
                using (MySqlConnection conn = CrearConexion())
                {
                    conn.Open();
                    mensaje = "Conexión exitosa";
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        mensaje = "No se puede conectar al servidor. Verifique que MySQL esté ejecutándose.";
                        break;
                    case 1042:
                        mensaje = "No se puede resolver el host. Verifique el servidor.";
                        break;
                    case 1045:
                        mensaje = "Usuario o contraseña incorrectos.";
                        break;
                    case 1049:
                        mensaje = "La base de datos no existe.";
                        break;
                    default:
                        mensaje = $"Error de conexión: {ex.Message}";
                        break;
                }
                return false;
            }
            catch (Exception ex)
            {
                mensaje = $"Error inesperado: {ex.Message}";
                return false;
            }
        }
    }
}
