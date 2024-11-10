using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaVirtual
{
    internal class Biblioteca
    {
        public List<Livro> livros;  //Lista para livros da biblioteca

        public Biblioteca()  //Construtor para bibliotecas
        {
            livros = new List<Livro>();  //Instanciação da lista de livros
        }

        #region Validar Texto
        public bool ValidarTexto(string texto)
        {
            return texto.Equals("");
        }
        #endregion

        #region Validar Ano
        public bool ValidarAno(int ano)
        {
            return ano > 0 && ano < 9999;
        }
        #endregion

        #region Limpar Console
        public void Limpar()  //Método para limpar console
        {
            Console.WriteLine("\n<< PRESSIONE ENTER >>");
            Console.ReadKey();
            Console.Clear();
        }
        #endregion

        #region Cadastrar Livros
        public void CadastrarLivros(int codigo)  //Recebe o código do último livro da lista para atualização
        {
            #region Código Alternativo (Construtor) 
            /*
            Console.Write("\nNome do Livro: ");
            string titulo = Console.ReadLine();
            Console.Write("Autor: ");
            string autor = Console.ReadLine();
            Console.Write("Gênero: ");
            string genero = Console.ReadLine();
            Console.Write("Ano de Publicação: ");
            int anoPublicacao = int.Parse(Console.ReadLine());
            if (ValidarTexto(titulo) && ValidarTexto(autor) && ValidarTexto(genero) && ValidarAno(anoPublicacao))
            {
                Livro novo = new Livro(titulo, autor, genero, anoPublicacao);  //Instancia o livro para adicionar na lista 
                novo.Codigo = ++codigo;  //Atualiza o código do novo livro
                livros.Add(novo);  //Adiciona o livro na lista
            }
            else
            {
                Console.WriteLine("\nAno inserido não é válido ou demais campos não foram inseridos!");
            }
            Limpar();
            */
            #endregion
            Livro novo = new Livro();
            string titulo, autor, genero;
            int anoPublicacao;

            do
            {
                Console.Write("\nTítulo: ");
                titulo = Console.ReadLine();
                if (!ValidarTexto(titulo))  //Se passar pela validação
                {
                    novo.Titulo = titulo;  //Atribui ao objeto novo
                }
                else
                {
                    Console.WriteLine("\nTítulo não foi preenchido!");
                }
            } while (ValidarTexto(titulo));  //Enquanto verdadeiro (retorno texto vazio)

            do
            {
                Console.Write("Autor: ");
                autor = Console.ReadLine();
                if (!ValidarTexto(autor))  //Se passar pela validação
                {
                    novo.Autor = autor;  //Atribui ao objeto novo
                }
                else
                {
                    Console.WriteLine("\nAutor não foi preenchido!");
                }
            } while (ValidarTexto(autor));  //Enquanto verdadeiro (retorno texto vazio)

            do
            {
                Console.Write("Gênero: ");
                genero = Console.ReadLine();
                if (!ValidarTexto(genero))  //Se passar pela validação
                {
                    novo.Genero = genero;  //Atribui ao objeto novo
                }
                else
                {
                    Console.WriteLine("\nGênero não foi preenchido!");
                }
            } while (ValidarTexto(genero));  //Enquanto verdadeiro (retorno texto vazio)

            do
            {
                Console.Write("Ano de Publicação: ");
                anoPublicacao = int.Parse(Console.ReadLine());
                if (ValidarAno(anoPublicacao))  //Se passar pela validação
                {
                    novo.AnoPublicacao = anoPublicacao;  //Atribui ao objeto novo
                }
                else
                {
                    Console.WriteLine("\nAno inserido não é válido!");
                }
            } while (!ValidarAno(anoPublicacao));  //Enquanto falso (retorno ano aceitável)

            novo.Codigo = ++codigo;  //Atualiza o código do novo livro
            livros.Add(novo);  //Adiciona o livro na lista
            Limpar();
        }
        #endregion

        #region Remover Livros
        public void RemoverLivros(Biblioteca biblioteca)  //Recebe a biblioteca para percorrer sua lista de livros
        {
            if (livros.Count() != 0)  //Se lista não está vazia
            {
                Console.Write("\nCódigo do Livro: ");
                int cod = int.Parse(Console.ReadLine());
                int max = livros.Count();
                bool encontrou = false;  
                for (int i = 0; i < max; i++)  //Percorre os elementos da lista
                {
                    if (livros[i].Codigo.Equals(cod))  //Compara os códigos
                    {
                        encontrou = true;
                        livros.Remove(livros[i]);  //Remove o livro se código for encontrado 
                        Console.Write($"\nRegistro de código '{cod}' removido com sucesso!\n");
                        break;
                    }
                }
                if (!encontrou)  //Verifica se algum registro foi encontrado
                {
                    Console.WriteLine($"\nNão foi encontrado registro de código '{cod}'");
                }
            }
            else
            {
                Console.WriteLine("\nBiblioteca está vazia!");
            }
            Limpar();
        }
        #endregion

        #region Listar Livros
        public void ListarLivros(Biblioteca biblioteca)  //Recebe a biblioteca para percorrer sua lista de livros
        {
            if (livros.Count() != 0)  //Se existir livros na biblioteca
            {
                Console.WriteLine($"\n<< Livros na Biblioteca: {livros.Count()} >>\n");
                foreach (var livro in biblioteca.livros)  //Percorre os livros da biblioteca
                {
                    Console.WriteLine($"<< Código: {livro.Codigo} >>");
                    Console.WriteLine($"\tTítulo: {livro.Titulo} \n\tAutor: {livro.Autor} \n\tGênero: {livro.Genero} \n\tAno de Publicação: {livro.AnoPublicacao}");
                    Console.WriteLine();
                }
                Limpar();
            }
            else
            {
                Console.WriteLine("\nBiblioteca está vazia!");
                Limpar();
            }
        }
        #endregion
    }
}
