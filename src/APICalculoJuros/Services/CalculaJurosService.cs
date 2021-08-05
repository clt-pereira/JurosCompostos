using APICalculoJuros.Extensions;
using Microsoft.Extensions.Options;
using System;
using System.Globalization;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace APICalculoJuros.Services
{
    public class CalculaJurosService : ServiceBase, ICalculaJurosService
    {
        private readonly HttpClient _httpClient;

        public CalculaJurosService(
            HttpClient httpClient, 
            IOptions<AppServicesSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.ApiTaxaJurosUrl);
        }

        public async Task<double> CalculaJurosComposto(double valorInicial, int meses)
        {
            double taxaJuros = 0.0;

            var response = await _httpClient.GetAsync("/taxaJuros");

            if (!HasError(response)) 
                taxaJuros = await DeserializarObjetoResponse<double>(response);

            var valorTotal = Math.Round(valorInicial * Math.Pow(1 + taxaJuros, meses), 2);

            return await Task.FromResult(valorTotal);
        }

    }
}
