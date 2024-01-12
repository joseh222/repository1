using SistemaParroquial.Shared;

namespace SistemaParroquial.Services
{
    public interface IMisaRootService
    {
        Task<List<MisaRoot>> GetAll();
        Task<MisaRoot> GetById(int pIdMisa);
        Task<HttpResponseMessage> Save(MisaRoot pMisa);
        Task<bool> Delete(int id);
    }
}
