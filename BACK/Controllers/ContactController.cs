using Microsoft.AspNetCore.Mvc;
using seguimiento_expotec.Services;
using seguimiento_expotec.DTOs;

namespace seguimiento_expotec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ContactService _contactService;

        public ContactController(ContactService contactService)
            => _contactService = contactService;

        [HttpGet]
        public async Task<ActionResult<List<ContactDTO>>> GetContacts()
            => Ok(await _contactService.GetAllContactsAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<ContactDTO>> GetContactById(string id)
            => Ok(await _contactService.GetContactByIdAsync(id));

        [HttpPost]
        public async Task<ActionResult> CreateContact([FromBody] ContactDTO contact)
            => Ok(await _contactService.CreateContactAsync(contact));

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateContact(string id, [FromBody] ContactDTO updatedContact)
            => Ok(await _contactService.UpdateContactAsync(id, updatedContact));

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteContact(string id)
            => Ok(await _contactService.DeleteContactAsync(id));
    }
}
