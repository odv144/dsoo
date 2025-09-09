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

        public Biblioteca()
        {
            this.Libros = new List<Libro>();
        }
        public Libro BuscarLibro(string Titulo)
        {
            Libro libroBuscado = null;
            int i = 0;
            while (i < Libros.Count && !Libros[i].Titulo.Equals(Titulo))
                i++;
            if (i != Libros.Count)
            {
                libroBuscado = Libros[i];
            }
            return libroBuscado;
        }
        public bool agregarLibro(string Titulo, string Autor, string Editorial, string Genero)
        {
            bool resultado = false;
            Libro libro;
            libro = BuscarLibro(Titulo);
            if(libro == null)
            {
                libro = new Libro(Titulo, Autor, Editorial, Genero);
                Libros.Add(libro);
                resultado = true;
            }
            return resultado;
        }
        public void listarLibros()
        {
            foreach (var libro in Libros)
                Console.WriteLine(libro.ToString());
        }
        public bool eliminarLibro(string Titulo, DataGridView data)
        {
            bool resultado = false;
           
            int i = 0;
            while (i < Libros.Count && !Libros[i].Titulo.Equals(Titulo))
                i++;
            if (i != Libros.Count)
            {
                Libros.RemoveAt(i);
                data.Rows.RemoveAt(i);
                resultado = true;
               
            }

            return resultado;
        }
        public void cargarLibros( DataGridView data,string titulo,string autor,string editorial, string genero)
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
            pude = agregarLibro(titulo,autor,editorial,genero);

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
    }
}
