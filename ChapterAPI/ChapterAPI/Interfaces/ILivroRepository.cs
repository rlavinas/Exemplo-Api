using ChapterAPI.Models;

namespace ChapterAPI.Interfaces
{
    public interface ILivroRepository
    {
        // CRUD

        // READ
        List<Livro> Ler();

        void Cadastrar(Livro livro);

        void Alterar(int Id, Livro livro);

        void Deletar(int Id);

        Livro BuscarId(int Id);
    }
}
