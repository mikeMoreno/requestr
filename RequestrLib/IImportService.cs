using Requestr.Lib.Models;

namespace Requestr.Lib
{
    public interface IImportService
    {
        Task<Collection> ImportAsync(string fileContents);
    }
}