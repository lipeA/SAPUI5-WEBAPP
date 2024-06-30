using Microsoft.AspNetCore.Mvc;
using back.Models;
using back.Data;
using Microsoft.EntityFrameworkCore;


namespace back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotaController : Controller
    {
        private readonly NotaFiscalDbContext _context;

        public NotaController(NotaFiscalDbContext context)
        {
            _context = context;
        }


        [HttpGet("{id}")]
        public IActionResult GetUmNotaFiscais([FromQuery] Guid id)
        {
            try
            {
                var nota = _context.NotaFiscal.Find(id);

                if (nota == null)
                {
                    return BadRequest($"Não foi possivel encontrar um cliente com essa identificação {id}");
                }

                return Ok(nota);
            }
            catch (Exception e)
            {
                return BadRequest($"Error, nao foi possivel fazer a pesquisar. {e.Message}");

            }

        }

        [HttpGet]
        public IActionResult GetNotaFiscais()
        {
            try
            {
                var result = _context.NotaFiscal.Include( x =>x.Cliente).ToList();
                return Ok(result);

            }
            catch (Exception e)
            {
                return BadRequest($"Error ao listar os nota {e.Message}");
            }

        }

        [HttpPost]
        public IActionResult PostNotaFiscais([FromBody] NotaFiscal notaFiscal)
        {
            Console.WriteLine(notaFiscal);
          
            try
            {
                _context.NotaFiscal.Add(notaFiscal);
                var valor = _context.SaveChanges();
                if (valor == 1)
                {
                    return Ok($"Sucess ao cadastrar o nota {valor}");
                }
                else
                {
                    return BadRequest("Error nao cadastrar o cliente");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(notaFiscal);
                return BadRequest($"Error ao cadastrar o novo cliente {e.Message}");

            }


        }

        [HttpPut]
        public IActionResult PutNotaFiscais([FromBody] NotaFiscal notaFiscal)
        {
            try
            {
                _context.NotaFiscal.Update(notaFiscal);
                var valor = _context.SaveChanges();
                if (valor == 1)
                {
                    return Ok("Cliente atualizado!");
                }
                else
                {
                    return BadRequest("Error ao atualizar o cliente!");
                }
            }
            catch (Exception e)
            {
                return BadRequest($"Error ao atualizar {e.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNotaFiscais([FromQuery] Guid id)
        {

            try
            {
                Console.WriteLine($"encontrou dentro do try delete {id}");
                var cliente = _context.Cliente.Find(id);

                if (cliente == null)
                {
                    return BadRequest($"Não foi possivel encontar o cliente com a seguinte identificação {id}");
                }


                if (cliente.Id == id)
                {
                    _context.Cliente.Remove(cliente);
                    var valor = _context.SaveChanges();

                    if (valor == 1)
                    {
                        return Ok("Sucess! Cliente deletado");
                    }
                    else
                    {
                        return BadRequest("Error, cliente não excluido");
                    }

                }
                else
                {
                    return NotFound("Error cliente não existe!");
                }

            }
            catch (Exception e)
            {
                return BadRequest($"Error, cliente nao encontrado para deletar {e.Message}");

            }

        }
    }
}
