using ChapterAPI.Models;
using ChapterAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ChapterAPI.ViewModels;

namespace ChapterAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _iusuarioRepository;
        public LoginController(IUsuarioRepository usuarioRepository)
        {
            _iusuarioRepository = usuarioRepository;
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                Usuario usuarioBuscado = _iusuarioRepository.Login(login.Email, login.Senha);

                if (usuarioBuscado == null)
                {
                    return Unauthorized(new { msg = "E-mail ou senha inválida." });
                }
            }
            catch (Exception Erro)
            {
                throw;
            }
        }
    }
}
