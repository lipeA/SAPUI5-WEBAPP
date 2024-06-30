using back.Data;
using back.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private readonly NotaFiscalDbContext _context;

        public ClienteController(NotaFiscalDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetUmClientes([FromQuery] Guid id)
        {
            try
            {
                var cliente = _context.Cliente.Find(id);

                if (cliente == null)
                {
                    return BadRequest($"Não foi possivel encontrar um cliente com essa identificação {id}");
                }

                return Ok(cliente);
            }
            catch (Exception e)
            {
                return BadRequest($"Error, nao foi possivel fazer a pesquisar. {e.Message}");

            }

        }

        [HttpGet]
        public IActionResult GetClientes()
        {
            try
            {
                var result = _context.Cliente.ToList();
                return Ok(result);

            }
            catch (Exception e)
            {
                return BadRequest($"Error ao listar os clientes {e.Message}");
            }

        }

        [HttpPost]
        public IActionResult PostClientes([FromBody] Cliente cliente)
        {
            try
            {
                _context.Cliente.Add(cliente);
                var valor = _context.SaveChanges();
                if (valor == 1)
                {
                    return Ok($"Sucess ao cadastrar o cliente {valor}");
                }
                else
                {
                    return BadRequest("Error nao cadastrar o cliente");
                }
            }
            catch (Exception e)
            {
                return BadRequest($"Error ao cadastrar o novo cliente {e.Message}");

            }


        }

        [HttpPut]
        public IActionResult PutCliente([FromBody] Cliente cliente)
        {
            try
            {
                _context.Cliente.Update(cliente);
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
        public IActionResult DeleteCliente([FromQuery] Guid id)
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
