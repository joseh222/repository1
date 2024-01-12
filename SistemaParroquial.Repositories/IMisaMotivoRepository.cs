using SistemaParroquial.Shared;

namespace SistemaParroquial.Repositories
{
    public interface IMisaMotivoRepository
    {
        Task<List<MisaMotivo>> GetAll();
    }
}
