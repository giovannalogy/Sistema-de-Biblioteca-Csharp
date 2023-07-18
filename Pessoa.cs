using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_biblioteca
{
    public class Pessoa
    {
        // Atributos
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public List<Livro> LivrosEmprestados { get; set; }

        // Construtor
        public Pessoa(int idPessoa, string nome, string cpf, string telefone)
        {
            Id = idPessoa;
            Nome = nome;
            Cpf = cpf;
            Telefone = telefone;
            LivrosEmprestados = new List<Livro>();
        }

        // Métodos

       //Empresta o livro para a pessoa adcionando na lista de livros emprestados
        public void AdicionarLivroLista(Livro livro)
        {
            LivrosEmprestados.Add(livro);
        }

        //Pessoa devolve o livro e remove o livro da lista de emprestados 
        
        public void RemoverLivroLista(int idLivro)
        {
            LivrosEmprestados.RemoveAll(l => l.Id == idLivro);
        }
    }
}
