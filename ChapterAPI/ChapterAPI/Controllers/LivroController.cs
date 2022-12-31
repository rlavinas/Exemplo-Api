using ChapterAPI.Models;
using ChapterAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChapterAPI.Controllers
{
    [Produces("application/json")] //o formato de resposta do tipo json
    [Route("api/[controller]")]  //api/Livro
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly LivroRepository _livroRepository;
        public LivroController(LivroRepository livro)
        {
            _livroRepository = livro;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_livroRepository.Ler());
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Livro livro)
        {
            try
            {
                _livroRepository.Cadastrar(livro);
                return Ok(livro);
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        [HttpPut]
        public IActionResult Alterar(int Id, Livro livro)
        {
            try
            {
                _livroRepository.Alterar(Id, livro);
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
                _livroRepository.Deletar(Id);
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
                Livro livro = _livroRepository.BuscarId(Id); 

                if (livro == null)  {
                    return NotFound();
                }
                return Ok(livro);
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }
    }
}
