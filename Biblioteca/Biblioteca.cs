using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca
{
    internal class Biblioteca
    {
        private List<Libro> Libros;
        private DataTable dt = new DataTable();
        private List<Lector> lector = new List<Lector>();
        public Biblioteca()
        {
            this.Libros = new List<Libro>();
        }
        public Libro BuscarLibro(string titulo)
        {
            Libro libroBuscado = null;
            int i = 0;
            while (i < Libros.Count && !Libros[i].Titulo.Equals(titulo))
                i++;
            if (i != Libros.Count)
            {
                libroBuscado = Libros[i];
            }
            return libroBuscado;
        }
       
        public bool AgregarLibro(string titulo, string autor, string editorial, string genero)
        {
            bool resultado = false;
            Libro libro;
            libro = BuscarLibro(titulo);
            if(libro == null)
            {
                libro = new Libro(titulo, autor, editorial,genero);
                Libros.Add(libro);
                resultado = true;
            }
            return resultado;
        }
        public List<Libro> ListarLibros()
        {
            return Libros;
        }
        public bool EliminarLibro(string titulo, DataGridView data)
        {
            bool resultado = false;
           
            int i = 0;
            while (i < Libros.Count && !Libros[i].Titulo.Equals(titulo))
                i++;
            if (i != Libros.Count)
            {
                Libros.RemoveAt(i);
               // data.Rows.RemoveAt(i);
                resultado = true;
               
            }

            return resultado;
        }
        
        public Lector BuscarLector(string dni)
        {
            int x = 0;
            while (x < lector.Count && !lector[x].Dni.Equals(dni))
            {
                x++;
            }
            if (x < lector.Count)
            {
                return lector[x];
               
            }
            else
            {
                return null;
            }
        }
        public Lector AltaLector(string Nombre, string dni)
        {
            Lector lector=null;
            if(BuscarLector(dni) == null)
            {
                lector = new Lector(Nombre, dni);
                this.lector.Add(lector);
                MessageBox.Show("LECTOR CREADO EXITOSAMENTE");
            }
            else
            {
                MessageBox.Show("EL LECTOR YA EXISTE");
            }
            return lector;
        }

        public Lector PrestarLibro(string titulo, string dni)
        {
            Lector lector = BuscarLector(dni);
            if ( lector != null)
            {
                if (lector.VerificarCantidadPrestamos() < 3)
                {
                    Libro libro = BuscarLibro(titulo);
                    if(libro != null)
                    {
                        lector.AgregarPrestamo(libro);
                        QuitarDeBiblioteca(titulo);
                        MessageBox.Show("PRESTAMO EXITOSO");
                    }
                    else
                    {
                        MessageBox.Show("LIBRO INEXISTENTE");
                    }
                }
                else
                {
                    MessageBox.Show("TOPE DE PRESTAMO ALCAZADO");
                }
            }
            return lector;
        }
        public void QuitarDeBiblioteca(string titulo)
        {
            if (Libros.Remove(BuscarLibro(titulo)))
            {
               
                MessageBox.Show("SE QUITO DE LA BIBLIOTECA");
            }
            else
            {
                MessageBox.Show("NO SE QUITO DE LA BIBLIOTECA");
            }
        }

    }
}
