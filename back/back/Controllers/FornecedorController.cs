using back.Data;
using back.Models;
using Microsoft.AspNetCore.Mvc;

namespace back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FornecedorController : Controller
    {
        private readonly NotaFiscalDbContext _context;

        public FornecedorController(NotaFiscalDbContext context)
        {
            _context = context;
        }


        [HttpGet("{id}")]
        public IActionResult GetUmFornecedores([FromQuery] Guid id)
        {
            try
            {
                var fornecedor = _context.Fornecedor.Find(id);

                if (fornecedor == null)
                {
                    return BadRequest($"Não foi possivel encontrar um fornecedor com essa identificação {id}");
                }

                return Ok(fornecedor);
            }
            catch (Exception e)
            {
                return BadRequest($"Error, nao foi possivel fazer a pesquisar. {e.Message}");

            }

        }

        [HttpGet]
        public IActionResult GetFornecedores()
        {
            try
            {
                var result = _context.Fornecedor.ToList();
                return Ok(result);

            }
            catch (Exception e)
            {
                return BadRequest($"Error ao listar os fornecedor {e.Message}");
            }

        }

        [HttpPost]
        public IActionResult PostFornecedores([FromBody] Fornecedor fornecedor)
        {
            try
            {
                _context.Fornecedor.Add(fornecedor);
                var valor = _context.SaveChanges();
                if (valor == 1)
                {
                    return Ok($"Sucess ao cadastrar o fornecedor");
                }
                else
                {
                    return BadRequest("Error nao cadastrar o fornecedor");
                }
            }
            catch (Exception e)
            {
                return BadRequest($"Error ao cadastrar o novo fornecedor {e.Message}");

            }


        }

        [HttpPut]
        public IActionResult PutFornecedores([FromBody] Fornecedor fornecedor)
        {
            try
            {
                _context.Fornecedor.Update(fornecedor);
                var valor = _context.SaveChanges();
                if (valor == 1)
                {
                    return Ok("fornecedor atualizado!");
                }
                else
                {
                    return BadRequest("Error ao atualizar o fornecedor!");
                }
            }
            catch (Exception e)
            {
                return BadRequest($"Error ao atualizar {e.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFornecedores([FromQuery] Guid id)
        {

            try
            {
                Console.WriteLine($"encontrou dentro do try delete {id}");
                var fornecedor = _context.Fornecedor.Find(id);

                if (fornecedor == null)
                {
                    return BadRequest($"Não foi possivel encontar o fornecedor com a seguinte identificação {id}");
                }


                if (fornecedor.Id == id)
                {
                    _context.Fornecedor.Remove(fornecedor);
                    var valor = _context.SaveChanges();

                    if (valor == 1)
                    {
                        return Ok("Sucess! fornecedor deletado");
                    }
                    else
                    {
                        return BadRequest("Error, fornecedor não excluido");
                    }

                }
                else
                {
                    return NotFound("Error fornecedor não existe!");
                }

            }
            catch (Exception e)
            {
                return BadRequest($"Error, fornecedor nao encontrado para deletar {e.Message}");

            }

        }

    }
}
