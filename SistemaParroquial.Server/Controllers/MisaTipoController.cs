using Microsoft.AspNetCore.Mvc;
using SistemaParroquial.Repositories;
using SistemaParroquial.Shared;

namespace SistemaParroquial.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MisaTipoController : ControllerBase
    {
        
        private readonly IMisaTipoRepository _iMisaTipoRepository;

        public MisaTipoController(IMisaTipoRepository pIMisaTipoRepository)
        {
            _iMisaTipoRepository = pIMisaTipoRepository;
        }

        [HttpGet]
        public async Task<List<MisaTipo>> GetAll()
        {
            var result = await _iMisaTipoRepository.GetAll();
            return result;
        }
    }

    
}
