using Microsoft.AspNetCore.Mvc;
using SistemaParroquial.Repositories;
using SistemaParroquial.Shared;
using System.Transactions;

namespace SistemaParroquial.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MisaRootController : ControllerBase
    {
        private readonly IMisaRootRepository _iMisaRootRepository;
        private readonly INombresRootRepository _iNombresRootRepository;

        public MisaRootController(IMisaRootRepository pIMisaRootRepository, INombresRootRepository pINombresRootRepository)
        {
            _iMisaRootRepository = pIMisaRootRepository;
            _iNombresRootRepository = pINombresRootRepository;
        }

        [HttpGet]
        public async Task<List<MisaRoot>> GetAll()
        {
            var result = await _iMisaRootRepository.GetAll();
            return result;
        }

        [HttpGet("{pIdMisa:int}")]
        public async Task<MisaRoot> GetById(int pIdMisa)
        {
            var result = await _iMisaRootRepository.GetById(pIdMisa);
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] MisaRoot pMisa)
        {
            if (pMisa == null)
                return BadRequest();

            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                pMisa.IdMisa = await _iMisaRootRepository.GetNextId();
                var result = await _iMisaRootRepository.Insert(pMisa);
                if (!(pMisa.ListNombres == null || pMisa.ListNombres.Count == 0))
                {
                    foreach (var item in pMisa.ListNombres)
                    {
                        await _iNombresRootRepository.Insert(pMisa.IdMisa, item);
                    }
                }
                scope.Complete();
            }
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] MisaRoot pMisa)
        {
            if (pMisa == null)
                return BadRequest();

            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var result = await _iMisaRootRepository.Update(pMisa);
                if (!(pMisa.ListNombres == null || pMisa.ListNombres.Count == 0))
                {
                    foreach (var item in pMisa.ListNombres)
                    {
                        if (item.IdName == 0)
                            await _iNombresRootRepository.Insert(pMisa.IdMisa, item);
                        else
                            await _iNombresRootRepository.Update(item);
                    }
                }
                scope.Complete();
            }
            return NoContent();
        }

        [HttpPut]
        [Route("delete")]
        public async Task<bool> Delete([FromBody] int pIdMisa)
        {
            var result = await _iMisaRootRepository.Delete(pIdMisa);
            return result;
        }
    }
}
