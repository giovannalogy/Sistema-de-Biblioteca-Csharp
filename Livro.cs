using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_biblioteca
{
    public class Livro
    {
        // Atributos
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public int QuantidadeExemplares { get; set; }

        // Construtor

        public Livro(int idLivro, string tituloLivro, string autorLivro, string editoraLivro,
            int quantidadeExemplares)
        {
            Id = idLivro;
            Titulo = tituloLivro;
            Autor = autorLivro;
            Editora = editoraLivro;
            QuantidadeExemplares = quantidadeExemplares;

        }

        // Métodos
       // Lista a quantidade de livros emprestados e realiza a matemática do sistema 
       
        public void EmprestarLivro(int quantidadeEmprestada)
        {
            QuantidadeExemplares -= quantidadeEmprestada;
        }

        // Faz o retorno do livro e realiza a matemática do sistema 
        public void DevolverLivro(int quantidadeDevolvida)
        {
            QuantidadeExemplares += quantidadeDevolvida;
        }
    }
}
