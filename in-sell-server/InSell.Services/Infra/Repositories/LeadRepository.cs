using InSell.Models;
using InSell.Services.Contracts.Infra;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InSell.Services.Infra.Repositories
{
    public class LeadRepository : CosmosRepository<Lead>, ILeadRepository
    {
     
        public LeadRepository(CosmosConfig cosmosConfig) : base(cosmosConfig)
        {
            
        }

    }
}
