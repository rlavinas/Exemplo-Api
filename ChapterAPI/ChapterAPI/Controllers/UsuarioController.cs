using ChapterAPI.Models;
using ChapterAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChapterAPI.Controllers
{
    [Produces("application/json")] //o formato de resposta do tipo json
    [Route("api/[controller]")]  //api/Usuario
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioRepository _usuarioRepository;
        public UsuarioController(UsuarioRepository usuario)
        {
            _usuarioRepository = usuario;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_usuarioRepository.Ler());
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);
                return Ok(usuario);
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        [HttpPut]
        public IActionResult Alterar(int Id, Usuario usuario)
        {
            try
            {
                _usuarioRepository.Alterar(Id, usuario);
                return StatusCode(204);
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        [HttpDelete]
        public IActionResult Deletar(int Id)
        {
            try
            {
                _usuarioRepository.Deletar(Id);
                return StatusCode(204);
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        [HttpGet("{Id}")]
        public IActionResult BuscarId(int Id)
        {
            try
            {
                Usuario usuario = _usuarioRepository.BuscarId(Id); 

                if (usuario == null)  {
                    return NotFound();
                }
                return Ok(usuario);
            } catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }
    }
}
