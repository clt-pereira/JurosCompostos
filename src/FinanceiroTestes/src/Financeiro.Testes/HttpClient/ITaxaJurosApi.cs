using Refit;
using System.Threading.Tasks;

namespace Financeiro.Testes
{
    public interface ITaxaJurosApi
    {
        [Get("/taxaJuros")]
        Task<ApiResponse<string>> GetAsync();
    }
}
