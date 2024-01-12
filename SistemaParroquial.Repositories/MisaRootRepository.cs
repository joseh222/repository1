using Dapper;
using SistemaParroquial.Shared;
using System.Data;

namespace SistemaParroquial.Repositories
{
    public class MisaRootRepository : IMisaRootRepository
    {
        private readonly IDbConnection _connection;
        public MisaRootRepository(IDbConnection pConnection)
        {
            _connection = pConnection;
        }
        public async Task<List<MisaRoot>> GetAll()
        {
            string xQuery = "";

            try
            {
                xQuery = "SELECT * FROM Misas m " +
                    "LEFT JOIN TipoMisa tm on tm.IdTipoMisa = m.IdTipoMisa " +
                    "LEFT JOIN MotivoMisa mm on mm.IdMotivoMisa = m.IdMotivoMisa " +
                    "WHERE m.FlgEliminado != 1";
                var result = await _connection.QueryAsync<MisaRoot, MisaTipo, MisaMotivo, MisaRoot>(xQuery,
                    (pMisa, pTipoMIsa, pMotivoMisa) =>
                    {
                        pMisa.TipoMisa = pTipoMIsa;
                        pMisa.MotivoMisa = pMotivoMisa;
                        return pMisa;
                    }, splitOn: "IdTipoMisa, IdMotivoMisa");
                return result.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(xQuery);
                Console.WriteLine($"GetAll-MisaRepository().Error-{ex.Message}");
                throw;
            }

        }
        public async Task<MisaRoot> GetById(int pIdMIsa)
        {
            //string xQuery = "SELECT * FROM Misas WHERE IdMisa=@Id";
            string xQuery = "SELECT * FROM Misas m " +
                "INNER JOIN TipoMisa tm on m.IdTipoMisa = tm.IdTipoMisa " +
                "LEFT JOIN MotivoMisa mm on mm.IdMotivoMisa = m.IdMotivoMisa " +
                "WHERE IdMisa=@pIdMIsa AND m.FlgEliminado != 1";
            var result = await _connection.QueryAsync<MisaRoot, MisaTipo, MisaMotivo, MisaRoot>(xQuery,
                (pMisa, pTipoMIsa, pMotivoMisa) =>
                {
                    pMisa.TipoMisa = pTipoMIsa;
                    pMisa.MotivoMisa = pMotivoMisa;
                    return pMisa;
                }, splitOn: "IdTipoMisa, IdMotivoMisa", param: new { pIdMIsa = pIdMIsa});
            return result.FirstOrDefault()!;
        }

        public async Task<int> GetNextId()
        {
            string xQry = @"SELECT IDENT_CURRENT('Misas') + 1";
            var result = await _connection.QueryFirstAsync<int>(xQry);
            return result;
        }

        public async Task<bool> Insert(MisaRoot misa)
        {
            string xQuery = "INSERT INTO Misas (IdTipoMisa,IdMotivoMisa,Motivo,FhMisa,Pay,FlgMisaPersonal,Observaciones,FhCreacion,FhActualizacion,FlgEliminado,DateMass,HoraMass) " +
                "VALUES(@IdTipoMisa,@IdMotivoMisa,@Motivo,@FhMisa,@Pay,@FlgMisaPersonal,@Observaciones,@FhCreacion,@FhActualizacion,@FlgEliminado,@DateMass,@HoraMass)";
            var result = await _connection.ExecuteAsync(xQuery, new
            {
                IdTipoMisa = misa.TipoMisa!.IdTipoMisa,
                IdMotivoMisa = misa.MotivoMisa!.IdMotivoMisa,
                Motivo = misa.Motivo,
                FhMisa = misa.FhMisa,
                Pay = misa.Pay,
                FlgMisaPersonal = misa.FlgMisaPersonal,
                Observaciones = misa.Observaciones,
                FhCreacion = DateTime.Now,
                FhActualizacion = DateTime.Now,
                FlgEliminado = 0,
                DateMass = misa.DateMass,
                HoraMass = misa.HoraMass
            });
            return result > 0;
        }

        public async Task<bool> Update(MisaRoot misa)
        {
            string xQuery = "";
            try
            {
                xQuery = "UPDATE Misas SET IdTipoMisa=@IdTipoMisa,IdMotivoMisa=@IdMotivoMisa,Motivo=@Motivo,FhMisa=@FhMisa,Pay=@Pay,FlgMisaPersonal=@FlgMisaPersonal," +
                    "Observaciones=@Observaciones,FhActualizacion=@FhActualizacion,DateMass=@DateMass,HoraMass=@HoraMass " +
                "WHERE IdMisa=@IdMisa";
                Console.WriteLine(xQuery);
                var result = await _connection.ExecuteAsync(xQuery, new
                {
                    IdTipoMisa = misa.TipoMisa!.IdTipoMisa,
                    IdMotivoMisa = misa.MotivoMisa!.IdMotivoMisa,
                    Motivo = misa.Motivo,
                    FhMisa = misa.FhMisa,
                    Pay = misa.Pay,
                    FlgMisaPersonal = misa.FlgMisaPersonal,
                    Observaciones = misa.Observaciones,
                    FhActualizacion = DateTime.Now,
                    DateMass = misa.DateMass,
                    HoraMass = misa.HoraMass,
                    IdMisa = misa.IdMisa,
                });
                Console.WriteLine(xQuery);
                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(xQuery);
                Console.WriteLine($"Update-MisaRepository().Error-{ex.Message}");
                throw;
            }
        }

        public async Task<bool> Delete(int id)
        {
            string xQuery = "UPDATE Misas SET FlgEliminado = 1 WHERE IdMisa = @IdMisa;";
            var result = await _connection.ExecuteAsync(xQuery, id);
            return result > 0;
        }
    }
}
