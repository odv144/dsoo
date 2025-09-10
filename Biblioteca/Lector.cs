using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca
{
    internal class Lector
    {
        private string _nombre;
        private string _dni;
        private List<Libro> _prestamos = new List<Libro>();

        public Lector(string nombre, string dni)
        {
            _nombre = nombre;
            _dni = dni;

        }
        public string Dni
        {
            get { return _dni; }
            set { _dni = value; }

        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public int VerificarCantidadPrestamos() 
        {
            if (_prestamos == null)
            {
                return 0;
            }
            return _prestamos.Count;
            
          
        }

       

        public void AgregarPrestamo(Libro libro)
        {
            if (VerificarCantidadPrestamos() < 3)
            {
                _prestamos.Add(libro);
             
            }
            else
            {
                MessageBox.Show("Ha superado el máximo de prestamos permitidos");
            }
        }
        
        public string  ListarPrestamos(DataGridView data)
        {
            return "intentando devolver listado de prestamo";
            //data.DataSource = _prestamos;
        }

    }
}
