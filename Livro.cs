using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaVirtual
{
    internal class Livro
    {
        public int Codigo;
        public string Titulo;
        public string Autor;
        public string Genero;
        public int AnoPublicacao;

        public Livro() { }  //Construtor vazio
        public Livro(string titulo, string autor, string genero, int anoPublicacao)  //Construtor
        {
            this.Titulo = titulo;
            this.Autor = autor;
            this.Genero = genero;
            this.AnoPublicacao = anoPublicacao;
        }
    }

    

}
