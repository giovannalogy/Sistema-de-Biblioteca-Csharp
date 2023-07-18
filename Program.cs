using System.Runtime.CompilerServices;

namespace Sistema_de_biblioteca
{
    public class Program
    {
        static void Main()
        {
            // instanciar a biblioteca
            Biblioteca biblioteca = new Biblioteca();
            
            //Menu interativo
            int opcao = 0;
            do
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1 - Cadastrar Pessoa");
                Console.WriteLine("2 - Cadastrar Livro");
                Console.WriteLine("3 - Emprestar Livro");
                Console.WriteLine("4 - Devolver Livro");
                Console.WriteLine("5 - Listar todos os livros");
                Console.WriteLine("6 - Listar todas as pessoas cadastradas");
                Console.WriteLine("7 - Listar todos os livros emprestados");
                Console.WriteLine("0 - Sair");

                Console.Write("Opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {

                    case 1:
                        // Cadastrar a pessoa e verificar se o ID já está cadastrado.
                        Console.WriteLine("Cadastro de Pessoa:");
                        Console.Write("Id: ");
                        int idPessoa = int.Parse(Console.ReadLine());
                        if (biblioteca.VerifyPersonId(idPessoa))
                        {
                            Console.WriteLine("Pessoa já cadastrada.");

                            break;
                        }
                        Console.Write("Nome: ");
                        string nomePessoa = Console.ReadLine();
                        Console.Write("CPF: ");
                        string cpfPessoa = Console.ReadLine();
                        Console.Write("Telefone: ");
                        string telefonePessoa = Console.ReadLine();
                        Pessoa novaPessoa = new Pessoa(idPessoa, nomePessoa, cpfPessoa, telefonePessoa);
                        biblioteca.CadastrarPessoa(novaPessoa);
                        Console.WriteLine("Pessoa cadastrada com sucesso!");
                        break;


                    case 2: //Cadastrar o livro e verificar se o livro está no sistema
                        Console.WriteLine("Cadastro de Livro:");
                        Console.Write("Id: ");
                        int idLivro = int.Parse(Console.ReadLine());
                        if (biblioteca.VerifyBookId(idLivro))
                        {
                            Console.WriteLine("Livro já cadastrado.");
                            break;
                        }
                        Console.Write("Título: ");
                        string tituloLivro = Console.ReadLine();
                        Console.Write("Autor: ");
                        string autorLivro = Console.ReadLine();
                        Console.Write("Editora: ");
                        string editoraLivro = Console.ReadLine();
                        Console.Write("Quantidade de exemplares: ");
                        int quantidadeExemplares = int.Parse(Console.ReadLine());
                        Livro novoLivro = new Livro(idLivro, tituloLivro, autorLivro, editoraLivro,
                            quantidadeExemplares);
                        biblioteca.CadastrarLivro(novoLivro);
                        Console.WriteLine("Livro cadastrado com sucesso!");
                        break;

                    case 3:  //Emprestar o livro verificando o ID e o nome da pessoa cadastrada
                             
                        Console.WriteLine("Emprestar Livro:"); //Emprestar livro
                        Console.Write("Id do Livro: "); //ID do livro que irá ser emprestado
                        int idLivroEmprestimo = int.Parse(Console.ReadLine());
                        if (biblioteca.VerifyBookId(idLivroEmprestimo))
                        {
                            Console.WriteLine("Livro encontrado."); //Se o livro está disponível para empréstimo
                        }
                        else
                        {
                            Console.WriteLine("Livro não cadastrado.");//o Livro não existe
                            break;
                        }
                        Console.Write("Id da Pessoa: "); //ID da pessoa que quer pega ro livro emprestado
                        int idPessoaEmprestimo = int.Parse(Console.ReadLine());
                        if (biblioteca.VerifyPersonId(idPessoaEmprestimo))
                        {
                            Console.WriteLine("Cadastro de pessoa encontrado.");
                        }
                        else
                        {
                            Console.WriteLine("Pessoa não cadastrada.");
                            break;
                        }
                        biblioteca.EmprestarLivroBiblioteca(idLivroEmprestimo, idPessoaEmprestimo);
                        Console.WriteLine("Livro Emprestado com Sucesso!");
                        Console.WriteLine($"O livro {biblioteca.GetBookTitleById(idLivroEmprestimo)} " +
                                          $"foi emprestado para {biblioteca.GetPersonNameById(idPessoaEmprestimo)}");
                        break;

                    // Devolver o livro utilizando ID, nome do livro
                    // e o nome da pessoa que está devolvendo
                    case 4:
                        Console.WriteLine("Devolver Livro:");
                        Console.Write("Id do Livro: ");
                        int idLivroDevolucao = int.Parse(Console.ReadLine());
                        if (biblioteca.VerifyBookId(idLivroDevolucao))
                        {
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Livro não cadastrado.");
                            break;
                        }
                        Console.Write("Id da Pessoa: ");
                        int idPessoaDevolucao = int.Parse(Console.ReadLine());
                        if (biblioteca.VerifyPersonId(idPessoaDevolucao))
                        {
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Pessoa não cadastrada.");
                            break;
                        }
                        biblioteca.DevolverLivroBiblioteca(idLivroDevolucao, idPessoaDevolucao);
                        Console.WriteLine("Livro Devolvido com Sucesso!");
                        Console.WriteLine($"O livro {biblioteca.GetBookTitleById(idLivroDevolucao)} " +
                                           $"foi devolvido por {biblioteca.GetPersonNameById(idPessoaDevolucao)}");

                        break;
                    // Listar todos os livros cadastrados
                    case 5:
                        Console.WriteLine("Listar todos os livros:");
                        foreach (Livro livro in biblioteca.Livros)
                        {
                            Console.WriteLine($"Id: {livro.Id} - Título: {livro.Titulo} - Autor: {livro.Autor} - Editora: {livro.Editora} - Disponibilidade: {livro.QuantidadeExemplares}");
                        }
                        break;


                    // Listar todas as pessoas cadastradas
                    case 6:
                        Console.WriteLine("Listar todas as pessoas cadastradas:");
                        foreach (Pessoa pessoa in biblioteca.Pessoas)
                        {
                            Console.WriteLine($"Id: {pessoa.Id} - Nome: {pessoa.Nome} - CPF: {pessoa.Cpf} - Telefone: {pessoa.Telefone}");
                        }
                        break;


                    // listar todos os livros emprestados utilizando o foreach e verificar se o livro estpa disponível
                    //  e usar o if  para verificar se tem algum livro na lista de emprestados
                    case 7:
                        Console.WriteLine("Listar todos os livros emprestados:");
                        foreach (Pessoa pessoa in biblioteca.Pessoas)
                        {

                            if (pessoa.LivrosEmprestados.Count > 0)
                            {
                                foreach (Livro livro in pessoa.LivrosEmprestados)
                                {

                                    Console.WriteLine($"Id: {livro.Id} - Título: {livro.Titulo} - Autor: {livro.Autor} - Editora: {livro.Editora} - Disponibilidade: {livro.QuantidadeExemplares}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Não há livros emprestados! ");
                            }


                        }
                        break;

                }

                // apertar 0 para sair do sistema

            } while (opcao != 0);
        }
    }
}