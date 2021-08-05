using System.Threading.Tasks;

namespace APICalculoJuros.Services
{
    public interface ICalculaJurosService
    {
        Task<double> CalculaJurosComposto(double valorInicial, int meses);
    }
}
