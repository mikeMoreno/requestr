using Microsoft.EntityFrameworkCore;
using Requestr.DAL;
using Requestr.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requestr.Lib
{
    public class CookieService
    {
        private readonly RequestrDbContext requestrDbContext;

        public CookieService(RequestrDbContext requestrDbContext)
        {
            this.requestrDbContext = requestrDbContext;
        }
        public async Task<string> GetCookiesAsync(string url)
        {
            var uri = new Uri(url);

            var cookies = await requestrDbContext.CookieInfos.Where(c => c.Domain == uri.Host.ToLower()).ToListAsync();

            var cookieBuilder = new StringBuilder();

            foreach (var cookie in cookies)
            {
                cookieBuilder.Append($"{cookie.Name}={cookie.Value}; ");
            }

            var cookieString = cookieBuilder.ToString();

            cookieString = cookieString.Trim().TrimEnd(';');

            return cookieString;
        }

        public async Task SetCookiesAsync(IEnumerable<string> setCookies)
        {
            var cookiesToSet = new List<CookieInfo>();

            foreach (var setCookie in setCookies)
            {
                var parts = GetParts(setCookie);

                var cookieInfo = new CookieInfo()
                {
                    Name = parts["cookie-name"],
                    Value = parts["cookie-value"],
                    Domain = parts.ContainsKey("domain") ? parts["domain"].ToLower() : null,
                    Path = parts.ContainsKey("path") ? parts["path"] : null,
                    MaxAge = parts.ContainsKey("max-age") ? long.Parse(parts["max-age"]) : null,
                    Expires = parts.ContainsKey("expires") ? DateTime.Parse(parts["expires"]) : null,
                    Secure = parts.ContainsKey("Secure"),
                };

                var existingCookie = await requestrDbContext.CookieInfos
                    .FirstOrDefaultAsync(c =>
                    c.Name == cookieInfo.Name &&
                    c.Domain == cookieInfo.Domain
                );

                if (existingCookie != null)
                {
                    requestrDbContext.CookieInfos.Remove(existingCookie);
                }

                cookiesToSet.Add(cookieInfo);
            }

            await requestrDbContext.CookieInfos.AddRangeAsync(cookiesToSet);

            await requestrDbContext.SaveChangesAsync();
        }

        private static Dictionary<string, string> GetParts(string setCookie)
        {
            var dict = new Dictionary<string, string>();

            var parts = setCookie.Split(';', StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToList();

            var part = parts[0];

            dict.Add("cookie-name", part[..part.IndexOf("=")]);
            dict.Add("cookie-value", part[(part.IndexOf("=") + 1)..]);

            for (int i = 1; i < parts.Count; i++)
            {
                part = parts[i];

                if (IsKeyValuePair(part))
                {
                    var key = part[..part.IndexOf("=")].ToLower();
                    var value = part[(part.IndexOf("=") + 1)..];

                    // Strip the '.' in front of the domain. Looks like it doesn't matter anymore.
                    // https://stackoverflow.com/a/20884869/3597945
                    if (key == "domain" && value.StartsWith('.'))
                    {
                        value = value[1..];
                    }

                    dict.Add(key, value);
                }
                else
                {
                    dict.Add(part, null);
                }
            }

            return dict;
        }

        private static bool IsKeyValuePair(string part)
        {
            if (part == null)
            {
                return false;
            }

            return part.Contains('=');
        }
    }
}
