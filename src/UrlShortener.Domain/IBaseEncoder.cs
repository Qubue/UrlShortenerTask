using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Domain.Url
{
    public interface IBaseEncoder
    {
        string Encode(long id);
        long Decode(string shortUrl);
    }
}
