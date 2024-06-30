using Microsoft.AspNetCore.Mvc;

namespace back.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult GetInformacao()
        {
            var result = "retorno de texto";
            return Ok(result);
        }

        [HttpGet("info/{valor}")]
        public IActionResult GetInformacao2([FromRoute] string valor)
        {
            var result = "retorno de texto - 2  valor: " + valor;
            return Ok(result);
        }


        [HttpPost("info3")]
        public IActionResult GetInformacao3([FromQuery] string valor)
        {
            var result = "retorno de texto - 4  valor: " + valor;
            return Ok(result);
        }

        [HttpPost("info4")]
        public IActionResult GetInformacao4([FromHeader] string valor)
        {
            var result = "retorno de texto - 4 Header  valor: " + valor;
            return Ok(result);
        }


        [HttpPost("info5")]
        public IActionResult GetInformacao5([FromBody] Corpo corpo)
        {
            var result = "retorno de texto - 4 body  valor: " + corpo.valor;
            return Ok(result);
        }



    }


    // construtores
    public class Corpo
    {
        public string valor { get; set; }
    }

}

  