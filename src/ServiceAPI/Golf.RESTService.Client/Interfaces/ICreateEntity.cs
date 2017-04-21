using System.Threading.Tasks;

namespace Golf.RESTService.Client.Interfaces
{
    public interface ICreateEntity<T>
    {
        Task<T> CreateEntityAsync(T entity);
    }
}
