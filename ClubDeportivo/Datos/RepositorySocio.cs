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

    internal class RepositorySocio : RepositoryBase<E_Socio>
    {
        MySqlConnection sqlCon;
        protected override string ObtenerNombreTabla() => "Socio";
        protected override string ObtenerNombreClavePrimaria() => "NroSocio";
        public override E_Socio Actualizar(E_Socio entidad)
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public override E_Socio Insertar(E_Socio entidad)
        {
            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                string query = @"INSERT INTO Socio (IdUsuario, EstadoHabilitacion, CuotaMensual, CarnetEntregado)
                         VALUES (@IdUsuario, @EstadoHabilitacion, @CuotaMensual, @CarnetEntregado)";
                MySqlCommand cmd = new MySqlCommand(query, sqlCon);
                

                var parametros = ObtenerParametros(entidad);

                foreach (var param in parametros)
                {
                    if (param.Key != "@IdActividad")
                        cmd.Parameters.AddWithValue(param.Key, param.Value);
                }

                sqlCon.Open();

                //actividad.IdActividad = Convert.ToInt32(cmd.ExecuteScalar());
                entidad.IdUsuario = Convert.ToInt32(cmd.ExecuteScalar());

                sqlCon.Close();
                MessageBox.Show("Registro Exito");
                E_Socio socio =  ObtenerPorId(entidad.IdUsuario); ;
                return socio;
               
                
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error a la hora de vincular el usuario con el socio");
                return null;

            }
        }


        protected override E_Socio MapearDesdeReader(MySqlDataReader reader)
        {
            //buscar como mapear el usuario dentro del socio
            E_Usuario usuario = null;
            return new E_Socio
            ( usuario,
            usuario.IdUsuario,
             reader.GetString("EstadoHabilitacion"),
             reader.GetDouble("CuotaMensual"),
             reader.GetBoolean("CarnetEntregado")
                );
        }

       

        protected override Dictionary<string, object> ObtenerParametros(E_Socio entidad)
        {
            return new Dictionary<string, object>
                {
                {"@NroSocio", entidad.NroSocio },
                {"@IdUsuario", entidad.IdUsuario },
                {"@EstadoHabilitacion", entidad.EstadoHabilitacion },
                {"@CuotaMensual", entidad.CuotaMensual },
                {"@CarnetEntregado", entidad.CarnetEntregado }
            };
        }

        //metodo para mostrar socios en el datagridview
     

        public DataTable ListarSocios()
        {
            DataTable tabla = new DataTable();
            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();

                string query = @"
                SELECT 
                    s.NroSocio,
                    u.Nombre,
                    u.Apellido,
                    u.Dni,
                    u.Telefono,
                    u.Email,
                    s.EstadoHabilitacion,
                    s.CuotaMensual,
                    s.CarnetEntregado
                FROM Socio s
                INNER JOIN Usuario u ON s.IdUsuario = u.IdUsuario";

                MySqlCommand cmd = new MySqlCommand(query, sqlCon);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(tabla);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar socios: " + ex.Message);
            }
            return tabla;
        }

    }
}
