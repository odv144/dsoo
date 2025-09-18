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
            table.Columns.Add("Autor", typeof(string));
            table.Columns.Add("Editorial", typeof(string));
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
            Boolean flag=false;
            for (int i = 1; i < 10; i++)
            {
                flag = biblioteca.AgregarLibro(txtTitulo.Text + i.ToString(),
                                    txtAutor.Text + i.ToString(), txtEditorial.Text + i.ToString(), txtGenero.Text);
                if (flag)
                {
                    table.Rows.Add(txtTitulo.Text + i.ToString(),txtAutor.Text + i.ToString(), txtEditorial.Text + i.ToString(), txtGenero.Text);
                }
            }
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
                
                if (libro != null)
                {

                foreach (Libro book in libro)
                    {
                        cboPrestado.Items.Add(book.ToString());
                        cboPrestado.SelectedIndex = 0;
                    }
                
                libro = biblioteca.ListarLibros();      
                foreach (Libro book in libro)
                        table.Rows.Add(book.Titulo, book.Editorial, book.Autor, book.Genero);

                   

                }
                else
                {
                    MessageBox.Show("LIBRO INEXISTENTE");
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
