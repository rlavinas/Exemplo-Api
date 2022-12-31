using ChapterAPI.Contexts;
using ChapterAPI.Interfaces;
using ChapterAPI.Models;

namespace ChapterAPI.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly ChapterContext _chapterContext;
        public LivroRepository(ChapterContext context)
        {
            _chapterContext = context;
        }

        public List<Livro> Ler()
        {
            return _chapterContext.Livros.ToList();
        }

        public void Cadastrar(Livro livro)
        {
            _chapterContext.Livros.Add(livro);
            _chapterContext.SaveChanges();
        }

        public void Alterar(int Id, Livro livro)
        {
            Livro livroLocalizado = _chapterContext.Livros.Find(Id);

            if (livroLocalizado != null)
            {
                livroLocalizado.Titulo = livro.Titulo;
                livroLocalizado.QuantidadePaginas = livro.QuantidadePaginas;
                livroLocalizado.Disponivel = livro.Disponivel;
                _chapterContext.Livros.Update(livroLocalizado); 
                _chapterContext.SaveChanges();
            }
        }

        public void Deletar(int Id)
        {
            Livro livroLocalizado = _chapterContext.Livros.Find(Id);

            if (livroLocalizado != null)
            {
                _chapterContext.Livros.Remove(livroLocalizado);
                _chapterContext.SaveChanges();
            }
        }

        public Livro BuscarId(int Id)
        {
            return _chapterContext.Livros.Find(Id);
        }

    }
}
