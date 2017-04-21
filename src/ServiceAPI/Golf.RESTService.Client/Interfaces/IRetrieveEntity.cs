using System.Collections.Generic;
using System.Threading.Tasks;

namespace Golf.RESTService.Client.Interfaces
{
    public interface IRetrieveEntity<T>
    {
        Task<T> RetrieveEntityAsync(int id);
        Task<IEnumerable<T>> RetrieveEntitiesAsync();
    }
}
