using System.Collections.Generic;
using System.Threading.Tasks;

namespace Golf.RESTService.Client.Interfaces
{
    public interface IRetrieveEntity<T>
    {
        Task<T> GetEntityAsync();
        Task<List<T>> GetEntitiesAsync();
    }
}
