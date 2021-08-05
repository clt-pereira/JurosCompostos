using APITaxaJuros.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITaxaJuros.Services
{
    public interface ITaxaJurosService
    {
        Task<double> ObterTaxaJuros();
    }
}
