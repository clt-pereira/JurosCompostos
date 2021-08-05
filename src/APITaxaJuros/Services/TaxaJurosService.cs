using System.Threading.Tasks;

namespace APITaxaJuros.Services
{
    public class TaxaJurosService : ITaxaJurosService
    {
        const double PERCENTUAL_JUROS = 1;

        public async Task<double> ObterTaxaJuros()
        {
            return await Task.FromResult(PERCENTUAL_JUROS / 100);
        }
    }
}
