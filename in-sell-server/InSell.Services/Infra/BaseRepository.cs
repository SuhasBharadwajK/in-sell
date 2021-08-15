using InSell.Models.Persistence;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Text;

namespace InSell.Services.Infra
{
    public abstract class BaseRepository : IRepository
    {
        static CosmosRepositoryContext _context;

        string ConnectionString { get; set; }

        string DatabaseName { get; set; }

        string CollectionName { get; set; }

        string Account { get; set; }

        string Key { get; set; }

        public CosmosRepositoryContext Context
        {
            get
            {
                if (_context == null)
                {
                    CosmosClientOptions cosmosClientOptions = new CosmosClientOptions()
                    {
                        AllowBulkExecution = true,
                        SerializerOptions = new CosmosSerializationOptions()
                        {
                            PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase
                        }
                    };
                    if (!string.IsNullOrEmpty(ConnectionString))
                    {
                        _context = new CosmosRepositoryContext(new CosmosClient(ConnectionString, cosmosClientOptions), DatabaseName, CollectionName);
                    }
                    else if (!string.IsNullOrEmpty(Account))
                    {
                        _context = new CosmosRepositoryContext(new CosmosClient(Account, Key, cosmosClientOptions), DatabaseName, CollectionName);
                    }
                }
                return _context;
            }
            set
            {
                _context = value;
            }

        }

        protected BaseRepository(string connectionString, string databaseName, string collectionName)
        {
            this.ConnectionString = connectionString;
            this.DatabaseName = databaseName;
            this.CollectionName = collectionName;
        }

        protected BaseRepository(string account, string key, string databaseName, string collectionName)
        {
            this.Account = account;
            this.Key = key;
            this.DatabaseName = databaseName;
            this.CollectionName = collectionName;
        }
    }
}
