using InSell.Models;
using InSell.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InSell.API.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet("{contactId}")]
        public async Task<Contact> GetContact([FromRoute] string contactId)
        {
            return await _contactService.GetContact(contactId);
        }

        [HttpPost]
        public void CreateContact([FromBody] Contact contact)
        {
            _contactService.CreateContact(contact);
        }

        [HttpPut]
        public void UpdateContact([FromBody] Contact contact)
        {
            _contactService.UpdateContact(contact);
        }

        [HttpDelete("{contactId}")]
        public void DeleteContact(long contactId)
        {
            _contactService.DeleteContact(contactId);
        }

    }
}