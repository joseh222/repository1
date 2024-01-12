using Microsoft.AspNetCore.Mvc;
using SistemaParroquial.Repositories;
using SistemaParroquial.Shared;

namespace SistemaParroquial.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MisaMotivoController : ControllerBase
    {
        
        private readonly IMisaMotivoRepository _iMisaMotivoRepository;

        public MisaMotivoController(IMisaMotivoRepository pIMisaMotivoRepository)
        {
            _iMisaMotivoRepository = pIMisaMotivoRepository;
        }

        [HttpGet]
        public async Task<List<MisaMotivo>> GetAll()
        {
            var result = await _iMisaMotivoRepository.GetAll();
            return result;
        }
    }
}
