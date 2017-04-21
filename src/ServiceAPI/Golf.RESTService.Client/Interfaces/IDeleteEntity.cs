using System.Threading.Tasks;

namespace Golf.RESTService.Client.Interfaces
{
    public interface IDeleteEntity
    {
        Task DeleteEntityAsync(int id);
    }
}
