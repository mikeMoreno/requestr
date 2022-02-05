using Requestr.Lib.Models;

namespace Requestr.Lib
{
    public interface ICollectionService
    {
        Task<Collection> CloneAsync(Collection collection);
        Task DeleteAsync(Guid id);
        Task<List<Collection>> LoadAsync();
        Task UpdateAsync(Collection collection);
    }
}