using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Domain.Url
{
    public sealed class BaseEncoder : IBaseEncoder
    {
        private ILogger<BaseEncoder> _logger;
        public BaseEncoder(ILogger<BaseEncoder> logger)
        {
            _logger = logger;
        }

        public long Decode(string shortUrl)
        {
            try
            {
                return BitConverter.ToInt32(WebEncoders.Base64UrlDecode(shortUrl));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while decoding {shortUrl}", shortUrl);
                throw new ArgumentException("Invalid url has been provided", ex);
            }
        }

        public string Encode(long id)
        {
            return WebEncoders.Base64UrlEncode(BitConverter.GetBytes(id));
        }
    }
}
