using DocumentDB.Samples.Shared.Util;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseClosed.Core.DAL
{
    public class CaseClosedDocDB
    {
        private DocumentClient _client;
        private string _endpointUrl;
        private string _authKey;

        public CaseClosedDocDB(string endpointUrl, string authKey)
        {
            _endpointUrl = endpointUrl;
            _authKey = authKey;
        }

        public DocumentClient GetClient()
        {
            if (_client != null)
                return _client;

            _client = new DocumentClient(new Uri(_endpointUrl), _authKey);

            return _client;
        }

        private async Task<Database> GetNewDatabaseAsync(string id)
        {
            Database database = _client.CreateDatabaseQuery().Where(c => c.Id == id).ToArray().FirstOrDefault();
            if (database == null)
            {
                database = await _client.CreateDatabaseAsync(new Database { Id = id });
            }

            return database;
        }

        private async Task<DocumentCollection> GetOrCreateCollectionAsync(Database db, string id)
        {
            DocumentCollection collection = _client.CreateDocumentCollectionQuery(db.SelfLink).Where(c => c.Id == id).ToArray().FirstOrDefault();

            if (collection == null)
            {
                IndexingPolicy optimalQueriesIndexingPolicy = new IndexingPolicy();
                optimalQueriesIndexingPolicy.IncludedPaths.Add(new IncludedPath
                {
                    Path = "/*",
                    Indexes = new System.Collections.ObjectModel.Collection<Index>()
                    {
                        new RangeIndex(DataType.Number) { Precision = -1 },
                        new RangeIndex(DataType.String) { Precision = -1 }
                    }
                });

                DocumentCollection collectionDefinition = new DocumentCollection { Id = id };
                collectionDefinition.IndexingPolicy = optimalQueriesIndexingPolicy;

                collection = await DocumentClientHelper.CreateDocumentCollectionWithRetriesAsync(_client, db, collectionDefinition);
            }

            return collection;
        }
    }
}
