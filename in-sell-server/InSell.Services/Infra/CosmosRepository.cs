using InSell.Models;
using InSell.Models.Persistence;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;

namespace InSell.Services.Infra
{
    public class CosmosRepository<T> : BaseRepository, IRepository<T> where T : class, IBasePersistable
    {
        public CosmosRepository(CosmosConfig cosmosConfig) : base(cosmosConfig.ConnectionString, cosmosConfig.Database, cosmosConfig.Collection)
        {
        }

        public virtual async Task<T> GetByIdAsync(string id, string partitionKey = null)
        {
            var item = await Context.Container.ReadItemAsync<T>(id, !string.IsNullOrEmpty(partitionKey) ? new PartitionKey(partitionKey) : ResolvePartitionKey(id));
            return item;
        }

        public virtual async Task<T> AddAsync(T concern)
        {
            if (concern.Id == null)
            {
                concern.Id = GenerateId(concern);
            }

            var result = await Context.Container.CreateItemAsync<T>(concern, ResolvePartitionKey(concern));
            return result;
        }

        public virtual async Task<T> ReplaceAsync(T concern)
        {
            var response = await Context.Container.ReplaceItemAsync(concern, concern.Id);
            return response;
        }

        public virtual async Task<T> UpdateAsync(T concern)
        {
            var result = await Context.Container.UpsertItemAsync(concern, ResolvePartitionKey(concern));
            return result;
        }

        public virtual async Task<bool> RemoveAsync(string id)
        {
            var response = await Context.Container.DeleteItemAsync<T>(id, ResolvePartitionKey(id));
            bool isSuccess = response.StatusCode == HttpStatusCode.NoContent;
            return isSuccess;
        }

        public virtual async Task<IList<T>> GetItems()
        {
            FeedIterator<T> queryResult = Context.Container.GetItemQueryIterator<T>();
            List<T> results = new List<T>();
            while (queryResult.HasMoreResults)
            {
                FeedResponse<T> response = await queryResult.ReadNextAsync();
                results.AddRange(response);
            }

            return results;
        }

        public virtual async Task<IList<T>> GetItemsByQuery(string query)
        {
            FeedIterator<T> queryResult = Context.Container.GetItemQueryIterator<T>(new QueryDefinition(query));
            List<T> results = new List<T>();
            while (queryResult.HasMoreResults)
            {
                FeedResponse<T> response = await queryResult.ReadNextAsync();
                results.AddRange(response);
            }

            return results;
        }

        public virtual async Task<IList<T>> GetItemsByQuery(Expression<Func<T, bool>> query, Expression<Func<T, object>> orderByQuery = null, bool orderByAscending = false)
        {
            QueryDefinition qd;
            if (orderByQuery != null)
            {
                if (!orderByAscending)
                {
                    qd = Context.Container.GetItemLinqQueryable<T>().Where(query).OrderByDescending(orderByQuery).ToQueryDefinition();
                }
                else
                {
                    qd = Context.Container.GetItemLinqQueryable<T>().Where(query).OrderBy(orderByQuery).ToQueryDefinition();
                }
            }
            else
            {
                qd = Context.Container.GetItemLinqQueryable<T>().Where(query).ToQueryDefinition();
            }


            FeedIterator<T> queryResult = Context.Container.GetItemQueryIterator<T>(qd);
            List<T> results = new List<T>();
            while (queryResult.HasMoreResults)
            {
                FeedResponse<T> response = await queryResult.ReadNextAsync();
                results.AddRange(response);
            }

            return results;
        }

        public virtual async Task DeleteAsyncById(string id)
        {
            await Context.Container.DeleteItemAsync<T>(id, ResolvePartitionKey(id));
        }

        public virtual async Task<IList<T>> GetItems(string query, int skip = 0, int take = 25)
        {
            string pagedQuery = query + $"OFFSET {skip} LIMIT {take}";
            FeedIterator<T> queryResult = Context.Container.GetItemQueryIterator<T>(new QueryDefinition(pagedQuery));
            List<T> results = new List<T>();
            while (queryResult.HasMoreResults)
            {
                FeedResponse<T> response = await queryResult.ReadNextAsync();
                results.AddRange(response);
            }
            return results;
        }

        // Get first matched item
        public virtual async Task<T> GetItem(string query)
        {
            return (await this.GetItems(query, 0, 1)).FirstOrDefault();
        }

        public virtual async Task<int> GetCount(Expression<Func<T, bool>> expr)
        {
            return await Context.Container.GetItemLinqQueryable<T>(allowSynchronousQueryExecution: true).Where(expr).CountAsync();
        }

        public virtual async Task<int> GetCountByQuery(string query)
        {
            FeedIterator<int> queryResult = Context.Container.GetItemQueryIterator<int>(new QueryDefinition(query));
            List<int> results = new List<int>();
            while (queryResult.HasMoreResults)
            {
                FeedResponse<int> response = await queryResult.ReadNextAsync();
                results.AddRange(response);
            }

            return results.FirstOrDefault();
        }

        public virtual string GenerateId(T concern) => Guid.NewGuid().ToString();

        public virtual PartitionKey ResolvePartitionKey(string concernId) => PartitionKey.None;

        public virtual PartitionKey ResolvePartitionKey(T concern) => new PartitionKey(concern.Type);
    }
}
