using APITaxaJuros.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace APITaxaJuros.Controllers
{
    [ApiController]
    public class TaxaJurosController : ControllerBase
    {
        private readonly ITaxaJurosService _taxaJurosService;

        public TaxaJurosController(
            ITaxaJurosService taxaJurosService)
        {
            _taxaJurosService = taxaJurosService;
        }

        [HttpGet]
        [Route("taxaJuros")]
        public async Task<ActionResult<double>> Get()
        {
            var taxaJuros = await _taxaJurosService.ObterTaxaJuros();

            if (taxaJuros <= 0)
                return BadRequest();

            return taxaJuros;
        }
    }
}
