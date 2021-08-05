using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financeiro.Testes
{
    public interface ICalculaJurosCompostosAPI
    {
        [Get("/calculajuros")]
        Task<ApiResponse<string>> GetAsync(double valorInicial, int meses);
    }
}
