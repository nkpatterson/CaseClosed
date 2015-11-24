using System.Linq;
using System.Threading.Tasks;

namespace CaseClosed.Api.Infrastructure.DAL
{
    public interface IDocumentClient
    {
        Task<IQueryable<T>> CreateDocumentQueryAsync<T>(string sql);
        Task CreateDocumentAsync<T>(T document);
        Task UpdateDocumentAsync<T>(T document);
    }
}