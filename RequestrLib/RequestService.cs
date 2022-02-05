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
    public class RequestService : IRequestService
    {
        private readonly RequestrDbContext requestrDbContext;

        public RequestService(RequestrDbContext requestrDbContext)
        {
            this.requestrDbContext = requestrDbContext;
        }

        public async Task<Request> CloneAsync(Request request)
        {
            var existingRequests = await requestrDbContext.Requests
                .Where(r => r.RequestCollectionId == request.RequestCollectionId)
                .ToListAsync();

            var clonedNameTemplate = $"{request.Name} Copy";

            var clonedName = clonedNameTemplate;

            int i = 2;

            while (existingRequests.Any(e => e.Name == clonedName))
            {
                clonedName = $"{clonedNameTemplate} {i}";

                i++;
            }

            var clonedRequest = new DAL.Models.Request()
            {
                Id = Guid.NewGuid(),
                RequestCollectionId = request.RequestCollectionId,
                Name = clonedName,
                Method = request.Method,
                Url = request.Url,
            };

            await requestrDbContext.Requests.AddAsync(clonedRequest);

            await requestrDbContext.SaveChangesAsync();

            var returnedRequest = new Request()
            {
                Id = clonedRequest.Id,
                Method = clonedRequest.Method,
                Name = clonedRequest.Name,
                RequestCollectionId = clonedRequest.RequestCollectionId,
                Url = clonedRequest.Url,
            };

            return returnedRequest;
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
