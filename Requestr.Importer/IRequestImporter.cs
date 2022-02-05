using Requestr.PostmanImporter.Models;

namespace Requestr.PostmanImporter
{
    public interface IRequestImporter
    {
        Collection Import(string contents);
    }
}