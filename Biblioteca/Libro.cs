using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca
{
    internal class Libro
    {
        private string _titulo;
        private string _autor;
        private string _editorial;
        private string _genero;

        public Libro(string Titulo, string Autor, string Editorial, string Genero)
        {
            this._titulo = Titulo;
            this._autor = Autor;
            this._editorial = Editorial;
            this._genero = Genero;

        }
       public string Titulo
        {
            get { return _titulo; }
            set { _titulo = value; }
        }
        public string Autor
        {
            get { return _autor; }
            set { _autor = value; }
        }

        public string Editorial
        {
            get { return _editorial; }
            set { _editorial = value; }
        }
        public string Genero
        {
            get { return _genero; }
            set { _genero = value;}
        }

       public override string ToString()
        {
            return "Titulo: " + _titulo + " Autor: " + _autor + " Editorial: " + _editorial + " Genero: " + _genero;
        }
       
    }
}
