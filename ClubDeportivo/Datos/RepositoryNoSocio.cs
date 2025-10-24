using ClubDeportivo.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivo.Datos
{
    internal class RepositoryNoSocio : RepositoryBase<E_NoSocio>
    {
        public override E_NoSocio Actualizar(E_NoSocio entidad)
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        //agregar
        public override E_NoSocio Insertar(E_NoSocio entidad)
        {
            throw new NotImplementedException();
        }

        protected override E_NoSocio MapearDesdeReader(MySqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        protected override string ObtenerNombreClavePrimaria()
        {
            throw new NotImplementedException();
        }

        protected override string ObtenerNombreTabla()
        {
            throw new NotImplementedException();
        }

        protected override Dictionary<string, object> ObtenerParametros(E_NoSocio entidad)
        {
            throw new NotImplementedException();
        }
    }
}
