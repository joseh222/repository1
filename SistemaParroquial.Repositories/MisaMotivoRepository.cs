using Dapper;
using SistemaParroquial.Shared;
using System.Data;

namespace SistemaParroquial.Repositories
{
    public class MisaMotivoRepository : IMisaMotivoRepository
    {
        private readonly IDbConnection _connection;
        public MisaMotivoRepository(IDbConnection pConnection)
        {
            _connection = pConnection;
        }
        public async Task<List<MisaMotivo>> GetAll()
        {
            string xQuery = "SELECT * FROM MotivoMisa";
            var result = await _connection.QueryAsync<MisaMotivo>(xQuery, new { });
            return result.ToList();
        }
    }
}
