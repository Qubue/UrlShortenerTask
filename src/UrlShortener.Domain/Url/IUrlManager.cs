using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Data;

namespace UrlShortener.Domain.Url
{
    public interface IUrlManager
    {
        Task<Data.Entities.Url?> GetUrlById(long id);
        Task<Data.Entities.Url> AddUrl(string url);
        Task<IReadOnlyCollection<Data.Entities.Url>> GetAll();
    }
}
