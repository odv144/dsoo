using ClubDeportivo.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
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
            this.servidor = "localhost";
            this.puerto =  "3306";
            this.bd = "proyecto";
            this.usuario = "root";
            this.password = "1234";
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
        public bool EjecutarArchivoSQL(string rutaArchivo, out string mensajeError)
        {
            mensajeError = string.Empty;
           
            try
            {
                // Verificar que el archivo existe
                if (!File.Exists(rutaArchivo))
                {
                    mensajeError = "El archivo SQL no existe";
                    return false;
                }

                // Leer el contenido del archivo
                string scriptSQL = File.ReadAllText(rutaArchivo, Encoding.UTF8);

                // Verificar que el archivo no esté vacío
                if (string.IsNullOrWhiteSpace(scriptSQL))
                {
                    mensajeError = "El archivo SQL está vacío";
                    return false;
                }
                string connStr = $"Server={servidor};Port={puerto};User ID={usuario};Password={password};";

                var instrucciones = PreprocesarScriptEliminarDelimiter(scriptSQL);
                                
                    using (var connection = new MySqlConnection(connStr))
                {
                    connection.Open();
                    foreach (string sql in instrucciones)
                    {
                        using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                        {
                            try
                            {
                                cmd.ExecuteNonQuery();
                                Console.WriteLine($"✔ Ejecutado: {sql.Split('\n')[0]}...");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"⚠ Error ejecutando instrucción:\n{sql}\n{ex.Message}");
                            }
                        }
                    }

                    connection.Close();

                    return true;
                    // Si queda algo en el buffer, intentar ejecutarlo también

                }
            }
            catch (MySqlException ex)
            {
                mensajeError = $"Error de MySQL: {ex.Message}\nNúmero de error: {ex.Number}";
                return false;
            }
            catch (Exception ex)
            {
                mensajeError = $"Error al ejecutar script: {ex.Message}";
                return false;
            }
        }
        private List<string> PreprocesarScriptEliminarDelimiter(string contenido)
        {
          
            var sentencias = new List<string>();
            string delimitador = ";";
            var sb = new System.Text.StringBuilder();

            using (StringReader reader = new StringReader(contenido))
            {
                string linea;
                while ((linea = reader.ReadLine()) != null)
                {
                    linea = linea.Trim();

                    // Ignorar comentarios
                    if (linea.StartsWith("--") || linea.Length == 0)
                        continue;

                    // Detectar cambio de delimitador
                    if (linea.StartsWith("DELIMITER", StringComparison.OrdinalIgnoreCase))
                    {
                        delimitador = linea.Split(' ')[1];
                        continue;
                    }

                    sb.AppendLine(linea);

                    string bloque = sb.ToString().TrimEnd();

                    if (bloque.EndsWith(delimitador))
                    {
                        bloque = bloque.Substring(0, bloque.Length - delimitador.Length).Trim();

                        if (!string.IsNullOrWhiteSpace(bloque))
                            sentencias.Add(bloque);

                        sb.Clear();
                    }
                }
            }

            return sentencias;
        }
    }
    
}
