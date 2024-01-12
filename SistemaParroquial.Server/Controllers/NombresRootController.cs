using Microsoft.AspNetCore.Mvc;
using SistemaParroquial.Repositories;
using SistemaParroquial.Shared;

namespace SistemaParroquial.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NombresRootController : ControllerBase
    {
        private readonly INombresRootRepository _iNombresRootRepository;
        public NombresRootController(INombresRootRepository pINombresRootRepository)
        {
            _iNombresRootRepository = pINombresRootRepository;
        }

        [HttpGet]
        public async Task<List<NombresRoot>> GetAll()
        {
            var result = await _iNombresRootRepository.GetAll();
            return result;
        }
        [HttpGet("{pIdMisa:int}")]
        public async Task<List<NombresRoot>> GetById(int pIdMisa)
        {
            var result = await _iNombresRootRepository.GetById(pIdMisa);
            return result;
        }
    }
}
