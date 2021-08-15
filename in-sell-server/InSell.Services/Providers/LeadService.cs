using InSell.Models;
using InSell.Services.Contracts;
using InSell.Services.Contracts.Infra;
using InSell.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InSell.Services.Providers
{
    public class LeadService : ILeadService
    {
        private ILeadRepository LeadRepository { get; set; }

        private ICompanyService CompanyService { get; set; }

        public LeadService(ILeadRepository leadRepository, ICompanyService companyService)
        {
            this.LeadRepository = leadRepository;
            this.CompanyService = companyService;
        }

        public async Task<Lead> CreateLead(Lead lead)
        {
            // TODO: Add validation checks
            lead.AddedOn = DateTime.UtcNow;
            var company = lead.Company;
            var existingCompany = await this.CompanyService.GetCompanyByName(company.Name);
            if (existingCompany != null)
            {
                var leads = await this.GetLeadsByContactDetails(lead.Contact, lead.Company.Name);
                if (leads.Any())
                {
                    // TODO: Log this as a potential duplicate attempt in the database.
                    throw new DuplicateLeadException("This lead already exists in the system");
                }

                company = await this.CompanyService.CreateCompany(company);
            }

            lead.Company = company;

            var result = await this.LeadRepository.AddAsync(lead);
            return result;
        }

        public async Task<IList<Lead>> GetLeadsByContactDetails(Contact contact, string companyName)
        {
            return await this.LeadRepository.GetItemsByQuery($"SELECT * FROM c WHERE c.type = '{new Lead().Type}' AND c.contact.email = '{contact.Email}' AND c.company.name = '{companyName}'");
        }

        public void DeleteLead(long leadId)
        {
            throw new NotImplementedException();
        }

        public async Task<Lead> GetLead(string id)
        {
            var result = await this.LeadRepository.GetByIdAsync(id, new Lead().Type);
            return result;
        }

        public void UpdateLead(string id, Lead lead)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Lead>> GetAllLeads()
        {
            return await this.LeadRepository.GetItems();
        }
    }
}
