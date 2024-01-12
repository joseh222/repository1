using SistemaParroquial.Shared;
using System.Net.Http.Json;

namespace SistemaParroquial.Services
{
    public class MisaRootService : IMisaRootService
    {
        private readonly HttpClient _httpClient;
        public MisaRootService(HttpClient pHttpClient)
        {
            _httpClient = pHttpClient;
        }

        public async Task<List<MisaRoot>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<List<MisaRoot>>($"api/MisaRoot");
            return result!;
        }
        public async Task<MisaRoot> GetById(int pIdMisa)
        {
            var result = await _httpClient.GetFromJsonAsync<MisaRoot>($"api/misaroot/{pIdMisa}");
            return result!;
        }
        public async Task<HttpResponseMessage> Save(MisaRoot pMisa)
        {
            HttpResponseMessage result;
            if (pMisa.IdMisa == 0)
                result = await _httpClient.PostAsJsonAsync<MisaRoot>($"api/misaroot/", pMisa);
            else
                result = await _httpClient.PutAsJsonAsync<MisaRoot>($"api/misaroot/", pMisa);
            return result;
        }
        public async Task<bool> Delete(int pIdMisa)
        {
            HttpResponseMessage result;
            result = await _httpClient.PutAsJsonAsync<int>($"api/misaroot/delete/", pIdMisa);
            return result.IsSuccessStatusCode;
        }

        
    }
}
