using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Data;

namespace UrlShortener.Domain.Url
{
    public sealed class UrlManager : IUrlManager
    {
        private readonly DomainDbContext _domainDbContext;

        public UrlManager(DomainDbContext domainDbContext)
        {
            _domainDbContext = domainDbContext;
        }

        public Task<Data.Entities.Url?> GetUrlById(long id)
        {
            return _domainDbContext.Urls.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Data.Entities.Url> AddUrl(string url)
        {
            var urlEntity = new Data.Entities.Url
            {
                OriginalUrl = url
            };
            await _domainDbContext.AddAsync(urlEntity);
            await _domainDbContext.SaveChangesAsync();
            return urlEntity;
        }

        //todo: add pagination
        public async Task<IReadOnlyCollection<Data.Entities.Url>> GetAll()
        {
            return await _domainDbContext.Urls.ToListAsync();
        }
    }
}
