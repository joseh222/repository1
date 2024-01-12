using SistemaParroquial.Shared;
using System.Net.Http.Json;

namespace SistemaParroquial.Services
{
    public class MisaTipoService : IMisaTipoService
    {
        private readonly HttpClient _httpClient;
        public MisaTipoService(HttpClient pHttpClient)
        {
            _httpClient = pHttpClient;
        }
        public async Task<List<MisaTipo>> GetTipoMisa()
        {
            var result = await _httpClient.GetFromJsonAsync<List<MisaTipo>>($"api/misatipo");
            return result!;
        }
    }
}
