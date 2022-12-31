using ChapterAPI.Models;

namespace ChapterAPI.Interfaces
{
    public interface IUsuarioRepository
    {
        // CRUD
        List<Usuario> Ler();
        void Cadastrar(Usuario usuario);

        void Alterar(int Id, Usuario usuario);

        void Deletar(int Id);

        Usuario BuscarId(int Id);

        Usuario Login(string Email, string Senha);
    }
}
