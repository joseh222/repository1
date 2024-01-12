using SistemaParroquial.Shared;
using System.Net.Http.Json;

namespace SistemaParroquial.Services
{
    public class MisaMotivoService : IMisaMotivoService
    {
        private readonly HttpClient _httpClient;
        public MisaMotivoService(HttpClient pHttpClient)
        {
            _httpClient = pHttpClient;
        }
        public async Task<List<MisaMotivo>> GetMotivoMisa()
        {
            var result = await _httpClient.GetFromJsonAsync<List<MisaMotivo>>($"api/misamotivo");
            return result!;
        }
    }
}
