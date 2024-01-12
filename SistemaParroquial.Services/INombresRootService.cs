using SistemaParroquial.Shared;

namespace SistemaParroquial.Services
{
    public interface INombresRootService
    {
        Task<List<NombresRoot>> GetAll();
        Task<List<NombresRoot>> GetById(int pIdMisa);
    }
}
