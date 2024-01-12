using SistemaParroquial.Shared;

namespace SistemaParroquial.Services
{
    public interface IMisaTipoService
    {
        Task<List<MisaTipo>> GetTipoMisa();
    }
}
