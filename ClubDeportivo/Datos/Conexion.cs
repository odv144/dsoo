using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivo.Datos
{
    internal class Conexion
    {
        private string servidor;
        private string port;
        private string bd;
        private string usuario;
        private string pass;
        private static Conexion con = null;


        //cualquiera de estas dos cadenas conecta bien a MYSQL
        //string cadenaConecion = "Server=127.0.0.1;Port=3307;Database=biblioteca;User ID=root;Password=odv144;SslMode=None;CharSet=utf8;";
        private Conexion()
        {
            this.servidor = "127.0.0.1";
            this.port = "3306";
            this.bd = "proyecto";
            this.usuario = "root";
            this.pass = "cactus3746";
        }
        public MySqlConnection CrearConexion()
        {
            MySqlConnection cadenaConecion = new MySqlConnection();

            try
            {
                cadenaConecion.ConnectionString = "datasource=" + this.servidor +
                                                 "; port=" + this.port +
                                                 ";Database=" + this.bd +
                                                 ";username=" + this.usuario +
                                                 ";password=" + this.pass;
            }
            catch (Exception ex)
            {
                cadenaConecion = null;
                throw;
            }
            return cadenaConecion;

        }
        public static Conexion getInstancia()
        {
            if (con == null)
            {
                con = new Conexion();
            }
            return con;
        }
    }
}
