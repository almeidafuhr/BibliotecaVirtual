using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaVirtual
{
    internal class Program
    {
        public static Biblioteca bbVirtual = new Biblioteca();
        static void Main(string[] args)
        {
            Menu();
        }

        #region Menu
        public static void Menu()
        {
            try
            {
                int op;
                do
                {
                    Console.WriteLine("---Biblioteca Virtual---");
                    Console.WriteLine("Digite: ");
                    Console.WriteLine("1 - Cadastrar Livros");
                    Console.WriteLine("2 - Remover Livros");
                    Console.WriteLine("3 - Listar Livros");
                    Console.WriteLine("4 - Sair");
                    Console.Write("Escolha: ");
                    op = int.Parse(Console.ReadLine());
                    switch (op)
                    {
                        case 1:
                            //Cadastrar Livro
                            if (bbVirtual.livros.Count != 0)  //Se biblioteca não estiver vazia
                            {
                                bbVirtual.CadastrarLivros(bbVirtual.livros.Last().Codigo);  //Envia o código do último elemento
                            }
                            else
                            {
                                bbVirtual.CadastrarLivros(bbVirtual.livros.Count());  //Se não, envia o quantidade de elementos(0)  
                            }

                            break;
                        case 2:
                            //Remover Livro
                            bbVirtual.RemoverLivros(bbVirtual);  //Envia biblioteca como parâmetro
                            break;
                        case 3:
                            //Listar Livro
                            bbVirtual.ListarLivros(bbVirtual);  //Envia biblioteca como parâmetro
                            break;
                        case 4:
                            //Sair
                            break;
                        default:
                            //Valor da opção inválida para o menu
                            Console.WriteLine("\nValor Inválido");
                            bbVirtual.Limpar();
                            break;
                    }
                } while (op != 4);
            } catch(Exception ex)
            {
                Console.WriteLine($"\nOpção não esperada! {ex.Message}");
                bbVirtual.Limpar();
                Menu();
            }
        }
        #endregion
    }
}
