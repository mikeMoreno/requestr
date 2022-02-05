using Microsoft.EntityFrameworkCore;
using Requestr.DAL;
using Requestr.Lib.Models;
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

        public async Task UpdateAsync(Request request)
        {
            var dalRequest = await requestrDbContext.Requests.FindAsync(request.Id);
            dalRequest.Name = request.Name;

            await requestrDbContext.SaveChangesAsync();
        }
    }
}
