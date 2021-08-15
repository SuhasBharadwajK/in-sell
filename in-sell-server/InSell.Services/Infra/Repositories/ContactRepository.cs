using InSell.Models;
using InSell.Services.Contracts.Infra;

namespace InSell.Services.Infra.Repositories
{
    public class ContactRepository : CosmosRepository<Contact>, IContactRepository
    {
        public ContactRepository(CosmosConfig cosmosConfig) : base(cosmosConfig)
        {
        }
    }
}
