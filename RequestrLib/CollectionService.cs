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
    public class CollectionService
    {
        private readonly RequestrDbContext requestrDbContext;

        public CollectionService(RequestrDbContext requestrDbContext)
        {
            this.requestrDbContext = requestrDbContext;
        }

        public async Task DeleteAsync(Guid id)
        {
            var collection = await requestrDbContext.RequestCollections
                .Include(c => c.Requests)
                .Where(c => c.Id == id).SingleOrDefaultAsync();

            requestrDbContext.RequestCollections.Remove(collection);

            await requestrDbContext.SaveChangesAsync();
        }

        public async Task<List<Collection>> LoadAsync()
        {
            var dalCollections = await requestrDbContext.RequestCollections
                .Include(c => c.Requests)
                .ToListAsync();

            var collections = dalCollections.Select(dalCollection => new Collection()
            {
                Id = dalCollection.Id,
                Name = dalCollection.Name,
                Requests = dalCollection.Requests.Select(r => new Request()
                {
                    Id = r.Id,
                    Name = r.Name,
                    Method = r.Method,
                    Url = r.Url,
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
