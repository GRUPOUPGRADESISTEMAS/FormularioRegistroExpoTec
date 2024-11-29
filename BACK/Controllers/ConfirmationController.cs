using Microsoft.AspNetCore.Mvc;
using seguimiento_expotec.Services;
using seguimiento_expotec.DTOs;

namespace seguimiento_expotec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfirmationController : ControllerBase
    {
        private readonly ConfirmationService _confirmationService;

        public ConfirmationController(ConfirmationService confirmationService)
            => _confirmationService = confirmationService;

        [HttpGet]
        public async Task<ActionResult<List<ConfirmationDTO>>> GetConfirmations()
            => Ok(await _confirmationService.GetAllConfirmationsAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<ConfirmationDTO>> GetConfirmationById(string id)
            => Ok(await _confirmationService.GetConfirmationByIdAsync(id));

        [HttpPost]
        public async Task<ActionResult> CreateConfirmation([FromBody] ConfirmationDTO confirmation)
            => Ok(await _confirmationService.CreateConfirmationAsync(confirmation));

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateConfirmation(string id, [FromBody] ConfirmationDTO updatedConfirmation)
            => Ok(await _confirmationService.UpdateConfirmationAsync(id, updatedConfirmation));

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteConfirmation(string id)
            => Ok(await _confirmationService.DeleteConfirmationAsync(id));
    }
}
