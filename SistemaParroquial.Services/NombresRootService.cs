using SistemaParroquial.Shared;
using System.Net.Http.Json;

namespace SistemaParroquial.Services
{
    public class NombresRootService : INombresRootService
    {
        private readonly HttpClient _httpClient;
        public NombresRootService(HttpClient pHttpClient)
        {
            _httpClient = pHttpClient;
        }

        public async Task<List<NombresRoot>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<List<NombresRoot>>($"api/nombresroot/");
            return result!;
        }
        public async Task<List<NombresRoot>> GetById(int pIdMisa)
        {
            var result = await _httpClient.GetFromJsonAsync<List<NombresRoot>>($"api/nombresroot/{pIdMisa}");
            return result!;
        }
    }
}
