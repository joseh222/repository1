using Dapper;
using SistemaParroquial.Shared;
using System.Data;

namespace SistemaParroquial.Repositories
{
    public class NombresRootRepository : INombresRootRepository
    {
        private readonly IDbConnection _connection;
        public NombresRootRepository(IDbConnection pConnection)
        {
            _connection = pConnection;
        }

        public async Task<List<NombresRoot>> GetAll()
        {
            string xQry = "";
            try
            {
                xQry = "SELECT * FROM Nombres " +
                "WHERE FlgEliminado != 1";
                var result = await _connection.QueryAsync<NombresRoot>(xQry);
                return result.ToList()!;
            }
            catch (Exception ex)
            {
                Console.WriteLine(xQry);
                Console.WriteLine($"GetAll-NombresRepository().Error-{ex.Message}");
                throw;
            }
        }
        public async Task<List<NombresRoot>> GetById(int pIdMisa)
        {
            string xQry = "SELECT n.IdName, n.Name, n.Number FROM Nombres n " +
                "LEFT JOIN  Misas m ON n.IdMisa = m.IdMisa " +
                "WHERE m.IdMisa=@IdMisa AND m.FlgEliminado != 1";
            var result = await _connection.QueryAsync<NombresRoot>(xQry, param: new { IdMisa = pIdMisa });
            return result.ToList()!;
        }

        public async Task<bool> Insert(int pIdMisa, NombresRoot pNombres)
        {
            string xQry = "";
            try
            {
                xQry = "INSERT INTO Nombres (IdMisa, Name, Number, FhCreacion,FhActualizacion,FlgEliminado) " +
                "VALUES(@IdMisa,@Name,@Number,@FhCreacion,@FhActualizacion,@FlgEliminado)";
                var result = await _connection.ExecuteAsync(xQry, new
                {
                    IdMisa = pIdMisa,
                    Name = pNombres.Name,
                    Number = pNombres.Number,
                    FhCreacion = DateTime.Now,
                    FhActualizacion = DateTime.Now,
                    FlgEliminado = 0
                });
                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(xQry);
                Console.WriteLine($"Insert-NombresRepository().Error-{ex.Message}");
                throw;
            }
        }
        public async Task<bool> Update(NombresRoot pNombres)
        {
            string xQry = "";
            try
            {
                xQry = "UPDATE Nombres SET Name=@Name, Number=@Number, FhActualizacion=@FhActualizacion " +
                "WHERE IdName=@IdName";
                var result = await _connection.ExecuteAsync(xQry, new
                {
                    IdName = pNombres.IdName,
                    Name = pNombres.Name,
                    Number = pNombres.Number,
                    FhActualizacion = DateTime.Now
                });
                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(xQry);
                Console.WriteLine($"Update-NombresRepository().Error-{ex.Message}");
                throw;
            }
        }
    }
}
