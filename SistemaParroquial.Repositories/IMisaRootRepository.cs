using SistemaParroquial.Shared;

namespace SistemaParroquial.Repositories
{
    public interface IMisaRootRepository
    {
        Task<List<MisaRoot>> GetAll();
        Task<MisaRoot> GetById(int id);
        Task<int> GetNextId();
        Task<bool> Insert (MisaRoot misa);
        Task<bool> Update(MisaRoot misa);
        Task<bool> Delete(int id);
    }
}
