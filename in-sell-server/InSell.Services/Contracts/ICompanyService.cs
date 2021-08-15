using InSell.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InSell.Services.Contracts
{
    public interface ICompanyService
    {
        Company GetCompany(long companyId);

        Task<List<Company>> GetAllCompanies();

        Task<Company> GetCompanyByName(string name);

        Task<Company> CreateCompany(Company company);

        void UpdateCompany(Company company);

        void DeleteCompany(long companyId);
    }
}
