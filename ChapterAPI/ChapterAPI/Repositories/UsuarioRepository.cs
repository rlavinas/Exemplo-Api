using ChapterAPI.Contexts;
using ChapterAPI.Interfaces;
using ChapterAPI.Models;

namespace ChapterAPI.Repositories
{
    public class UsuarioRepository: IUsuarioRepository
    {
        private readonly ChapterContext _chapterContext;
        public UsuarioRepository(ChapterContext context)
        {
            _chapterContext = context;
        }

        public List<Usuario> Ler()
        {
            return _chapterContext.Usuarios.ToList();
        }

        public void Cadastrar(Usuario usuario)
        {
            _chapterContext.Usuarios.Add(usuario);
            _chapterContext.SaveChanges();
        }

        public void Alterar(int Id, Usuario usuario)
        {
            Usuario UsuarioLocalizado = _chapterContext.Usuarios.Find(Id);

            if (UsuarioLocalizado != null)
            {
                UsuarioLocalizado.Email = usuario.Email;
                UsuarioLocalizado.Senha = usuario.Senha ;
                _chapterContext.Usuarios.Update(UsuarioLocalizado);
                _chapterContext.SaveChanges();
            }
        }

        public void Deletar(int Id)
        {
            Usuario UsuarioLocalizado = _chapterContext.Usuarios.Find(Id);

            if (UsuarioLocalizado != null)
            {
                _chapterContext.Usuarios.Remove(UsuarioLocalizado);
                _chapterContext.SaveChanges();
            }
        }

        public Usuario BuscarId(int Id)
        {
            return _chapterContext.Usuarios.Find(Id);
        }

        public Usuario Login(string Email, string Senha)
        {
            _chapterContext.Usuarios.Find()
        }
    }
}
