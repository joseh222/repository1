
using SistemaParroquial.Shared;

namespace SistemaParroquial.Services
{
    public interface IMisaMotivoService
    {
        Task<List<MisaMotivo>> GetMotivoMisa();
    }
}
