using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Domain.Url
{
    public sealed class UrlTransformer : IUrlTransformer
    {
        private readonly IUrlManager _urlManager;
        private readonly IBaseEncoder _baseEncoder;

        public UrlTransformer(IUrlManager urlManager, IBaseEncoder baseEncoder)
        {
            _urlManager = urlManager;
            _baseEncoder = baseEncoder;
        }
        public async Task<string?> GetFullUrl(string shortUrl)
        {
            var decodedUrl = _baseEncoder.Decode(shortUrl);
            var id = await _urlManager.GetUrlById(decodedUrl);
            return id?.OriginalUrl;
        }

        public async Task<string> GetShortUrl(string longUrl)
        {
            if (!IsValidUrl(longUrl))
            {
                throw new ArgumentException($"{longUrl} is not valid Url");
            }

            var addedUrl = await _urlManager.AddUrl(longUrl);
            return _baseEncoder.Encode(addedUrl.Id);
        }

        private bool IsValidUrl(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out var _);
        }
    }
}
