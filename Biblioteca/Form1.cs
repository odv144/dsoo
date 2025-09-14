using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            
//            biblioteca.cargarLibros(dgvLibros,txtTitulo.Text,txtAutor.Text,txtEditorial.Text,txtGenero.Text);
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            biblioteca.ListarLibros(dgvLibros);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(biblioteca.EliminarLibro(txtTitulo.Text,dgvLibros))
            {

               
                MessageBox.Show("SE elimino correctamente");
            }
            else
            {
                MessageBox.Show("No se elimino");
            }
        }

        private void btnDatos_Click(object sender, EventArgs e)
        {
           for(int i = 1; i<10;i++)
                biblioteca.CargarLibros(dgvLibros, txtTitulo.Text+i.ToString(),
                                    txtAutor.Text+i.ToString(), txtEditorial.Text+i.ToString(), txtGenero.Text);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Libro book;
            book= biblioteca.BuscarLibro(txtTitulo.Text);
            if(book != null)
            {
                MessageBox.Show("Se encontro el libro");
            }else
            {
                MessageBox.Show("No se encontron");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            biblioteca.CargarLibros(dgvLibros, txtTitulo.Text, txtAutor.Text, txtEditorial.Text, txtGenero.Text);
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
                cboPrestado.Items.Clear();
                foreach (Libro book in libro)
                    cboPrestado.Items.Add(book.ToString());

                cboPrestado.SelectedIndex = 0;
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
    }
}
