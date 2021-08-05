using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace APICalculoJuros.Services
{
    public abstract class ServiceBase
    {
        protected async Task<T> DeserializarObjetoResponse<T>(HttpResponseMessage responseMessage)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<T>(await responseMessage.Content.ReadAsStringAsync(), options);
        }

        protected bool HasError(HttpResponseMessage response)
        {
            if (response.StatusCode == HttpStatusCode.BadRequest) return true;

            response.EnsureSuccessStatusCode();
            return false;
        }
    }
}
