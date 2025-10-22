using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivo.Datos
{
    internal interface IRepository<T> where T : class
    {

        // Operaciones CRUD básicas
        T ObtenerPorId(int id);
        List<T> ObtenerTodos();
        T Insertar(T entidad);
        T Actualizar(T entidad);
        bool Eliminar(int id);

        // Operaciones adicionales
        int Contar();
        bool Existe(int id);
    }
}
