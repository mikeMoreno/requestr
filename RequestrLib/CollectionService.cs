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
    public class CollectionService : ICollectionService
    {
        private readonly RequestrDbContext requestrDbContext;

        public CollectionService(RequestrDbContext requestrDbContext)
        {
            this.requestrDbContext = requestrDbContext;
        }

        public async Task<Collection> CloneAsync(Collection collection)
        {
            var existingCollections = await requestrDbContext.RequestCollections
                .ToListAsync();

            var clonedNameTemplate = $"{collection.Name} Copy";

            var clonedName = clonedNameTemplate;

            int i = 2;

            while (existingCollections.Any(e => e.Name == clonedName))
            {
                clonedName = $"{clonedNameTemplate} {i}";

                i++;
            }

            var clonedRequestCollection = new DAL.Models.RequestCollection()
            {
                Id = Guid.NewGuid(),
                Name = clonedName,
            };

            clonedRequestCollection.Requests = collection.Requests.Select(r => new DAL.Models.Request()
            {
                Id = Guid.NewGuid(),
                RequestCollectionId = clonedRequestCollection.Id,
                Name = r.Name,
                Method = r.Method,
                Url = r.Url,
            }).ToList();

            await requestrDbContext.RequestCollections.AddAsync(clonedRequestCollection);

            await requestrDbContext.SaveChangesAsync();

            var returnedCollection = new Collection()
            {
                Id = clonedRequestCollection.Id,
                Name = clonedRequestCollection.Name,
                Requests = clonedRequestCollection.Requests.Select(r => new Request()
                {
                    Id = r.Id,
                    RequestCollectionId = r.RequestCollectionId,
                    Name = r.Name,
                    Method = r.Method,
                    Url = r.Url,
                    RequestHeaders = r.RequestHeaders.Select(h => new RequestHeader()
                    {
                        Key = h.Key,
                        Value = h.Value,
                        Type = h.Type,
                    }).ToList(),
                }).ToList()

            };

            return returnedCollection;
        }

        public async Task DeleteAsync(Guid id)
        {
            var collection = await requestrDbContext.RequestCollections
                .Include(c => c.Requests)
                .ThenInclude(r => r.RequestHeaders)
                .Where(c => c.Id == id).SingleOrDefaultAsync();

            requestrDbContext.RequestCollections.Remove(collection);

            await requestrDbContext.SaveChangesAsync();
        }

        public async Task<List<Collection>> LoadAsync()
        {
            var dalCollections = await requestrDbContext.RequestCollections
                .Include(c => c.Requests)
                .ThenInclude(r => r.RequestHeaders)
                .ToListAsync();

            var collections = dalCollections.Select(dalCollection => new Collection()
            {
                Id = dalCollection.Id,
                Name = dalCollection.Name,
                Requests = dalCollection.Requests.Select(r => new Request()
                {
                    Id = r.Id,
                    RequestCollectionId = r.RequestCollectionId,
                    Name = r.Name,
                    Method = r.Method,
                    Url = r.Url,
                    RequestHeaders = r.RequestHeaders.Select(h => new RequestHeader()
                    {
                        Key = h.Key,
                        Value = h.Value,
                        Type = h.Type,
                    }).ToList(),
                }).ToList()
            }).ToList();

            return collections;
        }

        public async Task UpdateAsync(Collection collection)
        {
            var dalCollection = await requestrDbContext.RequestCollections.FindAsync(collection.Id);
            dalCollection.Name = collection.Name;

            await requestrDbContext.SaveChangesAsync();
        }
    }
}
