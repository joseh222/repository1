using SistemaParroquial.Shared;

namespace SistemaParroquial.Repositories
{
    public interface IMisaTipoRepository
    {
        Task<List<MisaTipo>> GetAll();
    }
}
