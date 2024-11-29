using Microsoft.AspNetCore.Mvc;
using seguimiento_expotec.Services;
using seguimiento_expotec.DTOs;

namespace seguimiento_expotec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessExecutivesController : ControllerBase
    {
        private readonly BusinessExecutiveService _businessExecutiveService;

        public BusinessExecutivesController(BusinessExecutiveService businessExecutiveService)
            => _businessExecutiveService = businessExecutiveService;

        [HttpGet]
        public async Task<ActionResult<List<BusinessExecutiveDTO>>> GetBusinessExecutives()
            => Ok(await _businessExecutiveService.GetAllBusinessExecutivesAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<BusinessExecutiveDTO>> GetBusinessExecutiveById(string id)
            => Ok(await _businessExecutiveService.GetBusinessExecutiveByIdAsync(id));

        [HttpPost]
        public async Task<ActionResult> CreateBusinessExecutive([FromBody] BusinessExecutiveDTO businessExecutive)
            => Ok(await _businessExecutiveService.CreateBusinessExecutiveAsync(businessExecutive));

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBusinessExecutive(string id, [FromBody] BusinessExecutiveDTO updatedBusinessExecutive)
            => Ok(await _businessExecutiveService.UpdateBusinessExecutiveAsync(id, updatedBusinessExecutive));

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBusinessExecutive(string id) 
            => Ok(await _businessExecutiveService.DeleteBusinessExecutiveAsync(id));

    }
}
