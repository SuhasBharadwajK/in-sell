using Microsoft.Azure.Cosmos;

namespace InSell.Services.Infra
{
    public class CosmosRepositoryContext
    {
        public CosmosRepositoryContext(CosmosClient cosmosClient, string databaseName, string collectionName)
        {
            Client = cosmosClient;
            Container = Client.GetContainer(databaseName, collectionName);
        }

        public CosmosClient Client { get; }

        public Container Container { get; }
    }
}
