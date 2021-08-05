using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Refit;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Financeiro.Testes
{
    public class TaxaJurosTests
    {
        private readonly ITaxaJurosApi _apiTaxaJuros;

        public TaxaJurosTests()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json")
                .AddEnvironmentVariables();
            var configuration = builder.Build();

            _apiTaxaJuros = RestService.For<ITaxaJurosApi>(
                           configuration["EndpointApiTaxaJuros"]);
        }

        [Theory]
        [InlineData("0.01")]
        public async Task TestarValoresValidos(string valorEsperado)
        {
            var response = await _apiTaxaJuros.GetAsync();
            response.StatusCode.Should().Be(HttpStatusCode.OK,
                $"* Ocorreu uma falha: Status Code esperado (200, OK) diferente do resultado gerado *");

            var resultado = response.Content;

            resultado.Should().Be(valorEsperado,
                "* Ocorreu uma falha: valores inválidos *");
        }

        [Theory]
        [InlineData("0.00")]
        public async Task TestarFalhaValores(string valorEsperado)
        {
            var response = await _apiTaxaJuros.GetAsync();

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest,
                "* Ocorreu uma falha: Status Code esperado para a taxa de juros de" +
               $"{valorEsperado} taxa de juros: 400 (Bad Request) *");
        }


    }
}
