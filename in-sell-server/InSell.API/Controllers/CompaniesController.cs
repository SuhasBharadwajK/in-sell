using InSell.Models;
using InSell.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InSell.API.Controllers
{
    //[Authorize]
    [Route("api/companies")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet()]
        public async Task<List<Company>> GetCompanies()
        {
            return await _companyService.GetAllCompanies();
        }

        [HttpGet("{companyId}")]
        public Company GetCompany([FromRoute] long companyId)
        {
            return _companyService.GetCompany(companyId);
        }

        [HttpPost]
        public Task<Company> CreateCompany([FromBody] Company company)
        {
            return _companyService.CreateCompany(company);
        }

        [HttpPut("{id}")]
        public void UpdateCompany([FromBody] Company company, string id)
        {
            _companyService.UpdateCompany(company);
        }

        [HttpDelete("{companyId}")]
        public void DeleteCompany(long companyId)
        {
            _companyService.DeleteCompany(companyId);
        }

    }
}