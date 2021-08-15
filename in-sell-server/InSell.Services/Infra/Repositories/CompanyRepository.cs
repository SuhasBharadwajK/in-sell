using InSell.Models;
using InSell.Services.Contracts.Infra;

namespace InSell.Services.Infra.Repositories
{
    public class CompanyRepository : CosmosRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(CosmosConfig cosmosConfig) : base(cosmosConfig)
        {
        }
    }
}
