using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Domain.Url
{
    public sealed class BaseEncoder : IBaseEncoder
    {
        public long Decode(string shortUrl)
        {
            return BitConverter.ToInt32(WebEncoders.Base64UrlDecode(shortUrl));
        }

        public string Encode(long id)
        {
            return WebEncoders.Base64UrlEncode(BitConverter.GetBytes(id));
        }
    }
}
