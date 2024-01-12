using Dapper;
using SistemaParroquial.Shared;
using System.Data;

namespace SistemaParroquial.Repositories
{
    public class MisaTipoRepository : IMisaTipoRepository
    {
        private readonly IDbConnection _connection;
        public MisaTipoRepository(IDbConnection pConnection)
        {
            _connection = pConnection;
        }
        public async Task<List<MisaTipo>> GetAll()
        {
            string xQuery = "SELECT * FROM TipoMisa";
            var result = await _connection.QueryAsync<MisaTipo>(xQuery, new { });
            return result.ToList();
        }
    }
}
