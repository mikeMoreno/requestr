using Requestr.Lib.Models;

namespace Requestr.Lib
{
    public interface IRequestService
    {
        Task<Request> CloneAsync(Request request);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(Request request);
    }
}