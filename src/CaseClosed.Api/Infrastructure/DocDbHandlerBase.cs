using CaseClosed.Core.DAL;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseClosed.Api.Infrastructure
{
    public class DocDbHandlerBase : IDisposable
    {
        protected DocDbConfiguration Configuration;
        protected DocumentClient Client { get; private set; }

        private Database _database = null;
        private Dictionary<string, DocumentCollection> _collections = new Dictionary<string, DocumentCollection>();

        public DocDbHandlerBase(DocDbConfiguration config)
        {
            Configuration = config;
            Client = new DocumentClient(new Uri(Configuration.EndpointUrl), Configuration.AuthorizationKey);
        }

        public async Task<Database> GetDatabase()
        {
            if (_database != null)
                return _database;

            _database = await DocumentClientHelper.GetDatabaseAsync(Client, Configuration.DatabaseId);

            return _database;
        }

        public async Task<DocumentCollection> GetCollection(string collectionId = null)
        {
            collectionId = collectionId ?? Configuration.CollectionId;

            if (_collections.ContainsKey(collectionId))
                return _collections[collectionId];

            var collection = await DocumentClientHelper.GetCollectionAsync(Client, await GetDatabase(), collectionId);
            _collections[collectionId] = collection;

            return collection;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (Client != null)
                {
                    Client.Dispose();
                    Client = null;
                }
            }
        }
    }
}