using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivo.Datos
{
    internal abstract class RepositoryBase<T>: IRepository<T> where T : class
    {
        protected MySqlConnection ObtenerConexion()
        {
            return Conexion.getInstancia().CrearConexion();
        }

        // Métodos abstractos que cada repositorio debe implementar
        protected abstract T MapearDesdeReader(MySqlDataReader reader);
        protected abstract string ObtenerNombreTabla();
        protected abstract string ObtenerNombreClavePrimaria();
        protected abstract Dictionary<string, object> ObtenerParametros(T entidad);

        // Implementación genérica de operaciones comunes
        public virtual T ObtenerPorId(int id)
        {
            using (MySqlConnection conn = ObtenerConexion())
            {
                string query = $@"SELECT * FROM {ObtenerNombreTabla()} 
                            WHERE {ObtenerNombreClavePrimaria()} = @Id";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

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

        public virtual List<T> ObtenerTodos()
        {
            List<T> lista = new List<T>();

            using (MySqlConnection conn = ObtenerConexion())
            {
                string query = $"SELECT * FROM {ObtenerNombreTabla()}";
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

        public virtual int Contar()
        {
            using (MySqlConnection conn = ObtenerConexion())
            {
                string query = $"SELECT COUNT(*) FROM {ObtenerNombreTabla()}";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public virtual bool Existe(int id)
        {
            using (MySqlConnection conn = ObtenerConexion())
            {
                string query = $@"SELECT COUNT(*) FROM {ObtenerNombreTabla()} 
                            WHERE {ObtenerNombreClavePrimaria()} = @Id";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }
        // Método para verificar si un usuario ya es socio o no socio
        public string ObtenerTipoUsuario(int idUsuario)
        {
            using (MySqlConnection conn = ObtenerConexion())
            {
                // Verificar en tabla Socio
                string querySocio = "SELECT COUNT(*) FROM Socio WHERE IdUsuario = @IdUsuario";
                MySqlCommand cmdSocio = new MySqlCommand(querySocio, conn);
                cmdSocio.Parameters.AddWithValue("@IdUsuario", idUsuario);

                conn.Open();
                int esSocio = Convert.ToInt32(cmdSocio.ExecuteScalar());

                if (esSocio > 0) return "Socio";

                // Verificar en tabla NoSocio
                string queryNoSocio = "SELECT COUNT(*) FROM NoSocio WHERE IdUsuario = @IdUsuario";
                MySqlCommand cmdNoSocio = new MySqlCommand(queryNoSocio, conn);
                cmdNoSocio.Parameters.AddWithValue("@IdUsuario", idUsuario);

                int esNoSocio = Convert.ToInt32(cmdNoSocio.ExecuteScalar());

                if (esNoSocio > 0) return "NoSocio";

                return "SinAsignar"; // Usuario sin tipo definido
            }
        }
        // Métodos abstractos para operaciones específicas
        public abstract T Insertar(T entidad);
        public abstract T Actualizar(T entidad);
        public abstract bool Eliminar(int id);
    }
}
