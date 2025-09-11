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
        public void ListarLibros(DataGridView data)
        {
         
              data.DataSource=Libros;
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
                data.Rows.RemoveAt(i);
                resultado = true;
               
            }

            return resultado;
        }
        public void CargarLibros( DataGridView data,string titulo,string autor,string editorial, string genero)
        {
            bool pude;
           if(data.RowCount == 0)
            {

            dt.Columns.Add("Titulo", typeof(string));
            dt.Columns.Add("Autor", typeof(string));
            dt.Columns.Add("Editorial", typeof(string));
            dt.Columns.Add("Genero", typeof(string));
            }

           
            string nro = (data.Rows.Count + 1).ToString();
//            pude = agregarLibro("Libro" + nro, "Autor" +nro, "Editorial" + nro, "Genero" + nro);
            pude = AgregarLibro(titulo,autor,editorial,genero);

            if (pude)
            {
                dt.Rows.Add(titulo, autor, editorial, genero);
                data.DataSource = dt;

            }
            else
            {
                MessageBox.Show(titulo+" ya existe en la biblioteca", "Existe Libro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
            }
           
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
                MessageBox.Show("LECTOR INEXISTENTE");
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
             }
            else
            {
                MessageBox.Show("EL LECTOR YA EXISTE");
            }
            return lector;
        }

        public void PrestarLibro(string titulo, string dni)
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
