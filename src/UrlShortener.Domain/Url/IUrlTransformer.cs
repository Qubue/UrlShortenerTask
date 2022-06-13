using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Domain.Url
{
    public interface IUrlTransformer
    {
        Task<string> GetShortUrl(string shortUrl);
        Task<string?> GetFullUrl(string longUrl);
    }
}
