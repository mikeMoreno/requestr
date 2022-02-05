using Microsoft.EntityFrameworkCore;
using Requestr.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requestr.Lib
{
    public class RequestService
    {
        private readonly RequestrDbContext requestrDbContext;

        public RequestService(RequestrDbContext requestrDbContext)
        {
            this.requestrDbContext = requestrDbContext;
        }

        public async Task DeleteAsync(Guid id)
        {
            var request = await requestrDbContext.Requests.Where(r => r.Id == id).SingleOrDefaultAsync();

            requestrDbContext.Requests.Remove(request);

            await requestrDbContext.SaveChangesAsync();
        }
    }
}
