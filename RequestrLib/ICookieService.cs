
namespace Requestr.Lib
{
    public interface ICookieService
    {
        Task<string> GetCookiesAsync(string url);
        Task SetCookiesAsync(IEnumerable<string> setCookies);
    }
}