using InSell.Models;
using InSell.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InSell.API.Controllers
{
    //[Authorize]
    [Route("api/leads")]
    [ApiController]
    public class LeadsController : ControllerBase
    {
        private readonly ILeadService _leadService;

        public LeadsController(ILeadService leadService)
        {
            _leadService = leadService;
        }

        [HttpGet("")]
        public Task<IList<Lead>> GetAllLeads()
        {
            return _leadService.GetAllLeads();
        }

        [HttpGet("{id}")]
        public Task<Lead> GetLead([FromRoute] string id)
        {
            return _leadService.GetLead(id);
        }

        [HttpPost]
        public Task<Lead> CreateLead([FromBody] Lead lead)
        {
            return _leadService.CreateLead(lead);
        }

        [HttpPut("{id}")]
        public void UpdateLead(string id, [FromBody] Lead lead)
        {
            _leadService.UpdateLead(id, lead);
        }

        [HttpDelete("{id}")]
        public void DeleteLead(long id)
        {
            _leadService.DeleteLead(id);
        }

    }
}