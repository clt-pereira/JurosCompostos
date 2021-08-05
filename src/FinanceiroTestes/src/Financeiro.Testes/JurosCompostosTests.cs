using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Refit;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Financeiro.Testes
{
    public class JurosCompostosTests
    {
        private readonly ICalculaJurosCompostosAPI _apiCalculaJurosCompostos;

        public JurosCompostosTests()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json")
                .AddEnvironmentVariables();
            var configuration = builder.Build();

            _apiCalculaJurosCompostos = RestService.For<ICalculaJurosCompostosAPI>(
                           configuration["EndpointApiCalculoJuros"]);
        }

        [Theory]
        [InlineData(100, 5, "105,10")]
        [InlineData(300, 5, "315,30")]
        [InlineData(350, 8, "379,00")]
        public async Task TestarCalculosValidos(
            double valorInicial,
            int meses,   
            string valorEsperado)
        {
            var response = await _apiCalculaJurosCompostos.GetAsync(valorInicial, meses);
            response.StatusCode.Should().Be(HttpStatusCode.OK,
                $"* Ocorreu uma falha: Status Code esperado (200, OK) diferente do resultado gerado *");

            var resultado = response.Content;

            resultado.Should().Be(valorEsperado,
                "* Ocorreu uma falha: valores inválidos *");
        }

        [Theory]
        [InlineData(32, 0, "273.15")]
        [InlineData(86, 30, "303.15")]
        [InlineData(47, 50, "281.48")]
        public async Task TestarFalhaCalculos(
            double valorInicial,
            int meses,
            string valorEsperado)
        {
            var response = await _apiCalculaJurosCompostos.GetAsync(valorInicial, meses);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest,
                "* Ocorreu uma falha: Status Code esperado para o valor de" +
               $"{valorEsperado} 400 (Bad Request) *");
        }


    }
}
