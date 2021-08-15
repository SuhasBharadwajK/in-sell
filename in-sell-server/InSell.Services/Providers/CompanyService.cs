using InSell.Models;
using InSell.Services.Contracts;
using InSell.Services.Contracts.Infra;
using InSell.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InSell.Services.Providers
{
    public class CompanyService : ICompanyService
    {
        private ICompanyRepository CompanyRepository { get; set; }

        public CompanyService(ICompanyRepository companyRepository)
        {
            this.CompanyRepository = companyRepository;
        }

        public async Task<Company> CreateCompany(Company company)
        {
            var existingCompanies = this.GetCompanyByName(company.Name);

            if (existingCompanies == null)
            {
                company = await this.CompanyRepository.AddAsync(company);
                return company;
            }
            else
            {
                throw new DuplicateEntityException("A company with the same name exists");
            }
        }

        public void DeleteCompany(long companyId)
        {
            throw new NotImplementedException();
        }

        public Company GetCompany(long companyId)
        {
            throw new NotImplementedException();
        }

        public async Task<Company> GetCompanyByName(string name)
        {
            var results = await this.CompanyRepository.GetItemsByQuery($"SELECT * FROM c WHERE c.name = '{name}'");
            var company = results.FirstOrDefault();
            return company;
        }

        public void UpdateCompany(Company company)
        {
            throw new NotImplementedException();
        }

        public Task<List<Company>> GetAllCompanies()
        {
            throw new NotImplementedException();
        }
    }
}
