using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca
{
    public partial class Form1 : Form
    {
        Biblioteca biblioteca = new Biblioteca();

        public Form1()
        {
            InitializeComponent();
              
             
        }
        DataTable table = new DataTable();
        private void Form1_Load(object sender, EventArgs e)
        {
            table.Columns.Add("Titulo", typeof(string));
            table.Columns.Add("Editorial", typeof(string));
            table.Columns.Add("Autor", typeof(string));
            table.Columns.Add("Genero", typeof(string));
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            
//            biblioteca.cargarLibros(dgvLibros,txtTitulo.Text,txtAutor.Text,txtEditorial.Text,txtGenero.Text);
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            List<Libro> libros;
            libros = biblioteca.ListarLibros();
            table.Clear();
            foreach(Libro lib in libros)
            {
                table.Rows.Add(lib.Titulo,lib.Autor,lib.Editorial,lib.Genero);
            }
            dgvLibros.DataSource = table;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
            if (biblioteca.EliminarLibro(txtTitulo.Text, dgvLibros))
            {
                List<Libro> libros;
                libros = biblioteca.ListarLibros();
                table.Clear();
                foreach (Libro lib in libros)
                {
                    table.Rows.Add(lib.Titulo, lib.Autor, lib.Editorial, lib.Genero);
                }
                dgvLibros.DataSource = table;
               
                MessageBox.Show("SE elimino correctamente");
            }
            else
            {
                MessageBox.Show("No se elimino");
            }
        }

        private void btnDatos_Click(object sender, EventArgs e)
        {
            biblioteca.AgregarLibro("Harry Potter y la piedra filosofal", "Salamandra", "J.K. Rowling", "Fantasía");
            biblioteca.AgregarLibro("El código Da Vinci", "Roca Editorial", "Dan Brown", "Misterio/Thriller");
            biblioteca.AgregarLibro("El nombre del viento", "Plaza & Janés", "Patrick Rothfuss", "Fantasía épica");
            biblioteca.AgregarLibro("Perdida", "RBA Libros", "Gillian Flynn", "Thriller psicológico");
            biblioteca.AgregarLibro("La chica del tren", "Planeta", "Paula Hawkins", "Thriller");
            biblioteca.AgregarLibro("El camino de los reyes", "Ediciones B", "Brandon Sanderson", "Fantasía épica");
            biblioteca.AgregarLibro("El problema de los tres cuerpos", "Nova", "Cixin Liu", "Ciencia ficción");
            biblioteca.AgregarLibro("Educated", "Plataforma Editorial", "Tara Westover", "No ficción/Memorias");
            biblioteca.AgregarLibro("Los siete maridos de Evelyn Hugo", "Titania", "Taylor Jenkins Reid", "Ficción histórica");
            biblioteca.AgregarLibro("Nacidos de la bruma: El imperio final", "Ediciones B", "Brandon Sanderson", "Fantasía");

            table.Rows.Add("Harry Potter y la piedra filosofal", "Salamandra", "J.K. Rowling", "Fantasía");
            table.Rows.Add("El código Da Vinci", "Roca Editorial", "Dan Brown", "Misterio/Thriller");
            table.Rows.Add("El nombre del viento", "Plaza & Janés", "Patrick Rothfuss", "Fantasía épica");
            table.Rows.Add("Perdida", "RBA Libros", "Gillian Flynn", "Thriller psicológico");
            table.Rows.Add("La chica del tren", "Planeta", "Paula Hawkins", "Thriller");
            table.Rows.Add("El camino de los reyes", "Ediciones B", "Brandon Sanderson", "Fantasía épica");
            table.Rows.Add("El problema de los tres cuerpos", "Nova", "Cixin Liu", "Ciencia ficción");
            table.Rows.Add("Educated", "Plataforma Editorial", "Tara Westover", "No ficción/Memorias");
            table.Rows.Add("Los siete maridos de Evelyn Hugo", "Titania", "Taylor Jenkins Reid", "Ficción histórica");
            table.Rows.Add("Nacidos de la bruma: El imperio final", "Ediciones B", "Brandon Sanderson", "Fantasía");

            dgvLibros.DataSource = table;
           
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Libro book;
            book= biblioteca.BuscarLibro(txtTitulo.Text);
            if(book != null)
            {
                table.Rows.Clear();
                table.Rows.Add(book.Titulo, book.Editorial, book.Autor, book.Genero);
                dgvLibros.DataSource=table;
                MessageBox.Show("Se encontro el libro");
            }else
            {
                MessageBox.Show("No se encontron");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            bool agregado;
            agregado=biblioteca.AgregarLibro(txtTitulo.Text, txtAutor.Text, txtEditorial.Text, txtGenero.Text);
            if (agregado)
            {
                table.Rows.Add(txtTitulo.Text, txtAutor.Text, txtEditorial.Text, txtGenero.Text);
                dgvLibros.DataSource = table;
            }
            //biblioteca.CargarLibros(dgvLibros, txtTitulo.Text, txtAutor.Text, txtEditorial.Text, txtGenero.Text);
        }

        private void btnNuevoLector_Click(object sender, EventArgs e)
        {
            biblioteca.AltaLector(txtLector.Text, txtDniLector.Text);
        }

        private void btnPrestar_Click(object sender, EventArgs e)
        {
            Lector lector;
            
            lector= biblioteca.PrestarLibro(txtTitulo.Text,txtDniLector.Text);
            if (lector != null)
            {
                List<Libro> libro;
                libro=lector.ListarPrestamos();
                
                if (libro != null && libro.Count!=0)
                {

                    List<Libro> prestado=new List<Libro>();
                    foreach (Libro book in libro)
                    {
                        prestado.Add(book);
                       
                    }
                    cboPrestado.DataSource = prestado;
                    cboPrestado.SelectedIndex = 0;
                    libro = biblioteca.ListarLibros();
                    table.Rows.Clear();
                    foreach (Libro book in libro)
                        table.Rows.Add(book.Titulo, book.Editorial, book.Autor, book.Genero);

                   

                }
               
            }
            else
            {
                MessageBox.Show("LECTOR INEXISTENTE");
            }
        }

        private void btnPrestados_Click(object sender, EventArgs e)
        {
            Lector lector=biblioteca.BuscarLector(txtDniLector.Text);
            if(lector != null)
            {
                dgvLibros.DataSource = lector.ListarPrestamos();
                cboPrestado.DataSource = lector.ListarPrestamos();
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int n = dgvLibros.Rows.Add();
            dgvLibros.Rows[n].Cells[0].Value = "titulo";
            dgvLibros.Rows[n].Cells[1].Value = "autor";
            dgvLibros.Rows[n].Cells[2].Value = "editoria";
            dgvLibros.Rows[n].Cells[3].Value = "genero";
        }

       
    }
}
