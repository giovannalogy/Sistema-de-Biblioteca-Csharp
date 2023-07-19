using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_biblioteca
{
   
    
        public class Biblioteca
        {
            // chamamento de atributos lista e pessoa
            public List<Pessoa> Pessoas { get; set; }
            public List<Livro> Livros { get; set; }


            // Construtor
            public Biblioteca()
            {
                Pessoas = new List<Pessoa>();
                Livros = new List<Livro>();
            }

            // Métodos

            //Registra a pessoa na lista de pessoa cadastradas
            
            public void CadastrarPessoa(Pessoa pessoa)
            {
                Pessoas.Add(pessoa);
            }

            //Registra livro na lista no cadastro de livros
            public void CadastrarLivro(Livro livro)
            {
                Livros.Add(livro);
            }

            //Verifica se a pessoa está cadastrada pela ID
            public bool VerifyPersonId(int PessoaID)
            {

                if (Pessoas.Exists(p => p.Id == PessoaID))
                {
                    return true;
                }

                return false;
            }

            //Verifca se o livro existe pela ID
            public bool VerifyBookId(int idLivro)
            {

                if (Livros.Exists(l => l.Id == idLivro))
                {
                    return true;
                }

                return false;
            }

            //Encontra o nome da pessoa pelo ID
            public string GetPersonNameById(int idPessoa)
        {
            return Pessoas.Find(p => p.Id == idPessoa).Nome;
        }

            // Encontra o livro pela ID
            public string GetBookTitleById(int idLivro)
            {
                return Livros.Find(l => l.Id == idLivro).Titulo;
            }
                  

            // Encontra a pessoa e o livro chamando o método emprestar o livro
            // Este método é executado caso o livro seja diferente de nulo e a pessoa seja diferente de nula (ou seja, quando encontrados)
            //O livro é emprestado e a pessoa (e o livro) são adicionados à lista de livros emprestados.
            public void EmprestarLivroBiblioteca(int idLivro, int idPessoa)
            {
                Livro livro = Livros.Find(l => l.Id == idLivro);
                Pessoa pessoa = Pessoas.Find(p => p.Id == idPessoa);

                if (livro != null && pessoa != null)
                {
                    livro.EmprestarLivro(1);
                    pessoa.AdicionarLivroLista(livro);
                }
            }
                    
             // Encontra o livro e a pessoa pelo ID e chama o método de retorno do livro
            // Mesmo método anterior
            public void DevolverLivroBiblioteca(int idLivro, int idPessoa)
            {
                Livro livro = Livros.Find(l => l.Id == idLivro);
                Pessoa pessoa = Pessoas.Find(p => p.Id == idPessoa);

                if (livro != null && pessoa != null)
                {
                    livro.DevolverLivro(1);
                    pessoa.RemoverLivroLista(idLivro);
                }
            }
        }
}
