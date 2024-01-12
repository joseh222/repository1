using SistemaParroquial.Shared;

namespace SistemaParroquial.Repositories
{
    public interface INombresRootRepository
    {
        Task<List<NombresRoot>> GetAll();
        Task<List<NombresRoot>> GetById(int pIdMisa);
        Task<bool> Insert(int pIdMisa, NombresRoot pNombres);
        Task<bool> Update(NombresRoot pNombres);
    }
}
