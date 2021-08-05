using APICalculoJuros.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace APICalculoJuros.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CalculaJurosController : ControllerBase
    {
        private readonly ICalculaJurosService _calculaJurosService;

        public CalculaJurosController(
            ICalculaJurosService calculaJurosService)
        {
            _calculaJurosService = calculaJurosService;
        }

        [HttpGet]
        public async Task<ActionResult<string>> Get(double valorInicial, int meses)
        {
            var resultado = await _calculaJurosService.CalculaJurosComposto(valorInicial, meses);

            if (resultado <= 0)
                return BadRequest("O cálculo de juros está inválido");

            return resultado.ToString("0.00");
        }

        [HttpGet]
        [Route("showmethecode")]
        public string ShowTheMeCode()
        {
            return "https://github.com/clt-pereira/JurosCompostos";
        }
    }
}
