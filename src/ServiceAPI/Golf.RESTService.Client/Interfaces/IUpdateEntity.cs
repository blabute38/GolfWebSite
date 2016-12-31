using System.Threading.Tasks;

namespace Golf.RESTService.Client.Interfaces
{
    public interface IUpdateEntity<T>
    {
        Task<T> UpdateEntityAsync(int id, T entity);
    }
}
