using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UrlShortener.Domain.Url;
using UrlShortener.WebApplication.Models;

namespace UrlShortener.WebApplication.Controllers
{
    [ApiController]
    [Route(RoutePrefix)]
    public class UrlController : Controller
    {
        private const string RoutePrefix = "url";
        private readonly ILogger<UrlController> _logger;
        private readonly IUrlShortener _urlShortener;
        private readonly IUrlManager _urlManager;
        private readonly IBaseEncoder _baseEncoder;

        public UrlController(ILogger<UrlController> logger, IUrlShortener urlShortener, IUrlManager urlManager, IBaseEncoder baseEncoder)
        {
            _logger = logger;
            _urlShortener = urlShortener;
            _urlManager = urlManager;
            _baseEncoder = baseEncoder;
        }

        [HttpPost("/{url}")]
        public async Task<IActionResult> GetShortUrl([FromQuery] string url)
        {
            var shortUrl = await _urlShortener.GetShortUrl(url);
            return Json(new { url = $"{Request.Scheme}://{Request.Host}/{RoutePrefix}/{shortUrl}" });
        }

        [HttpGet("{url}")]
        public async Task<IActionResult> GetFullUrl([FromRoute] string url)
        {
            var fullUrl = await _urlShortener.GetFullUrl(url);
            return Redirect(fullUrl);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllMappings()
        {
            var originalUrls = await _urlManager.GetAll();
            return Json(originalUrls.Select(urls => new
            {
                urls.OriginalUrl,
                ShortUrl = $"{Request.Scheme}://{Request.Host}/{RoutePrefix}/{_baseEncoder.Encode(urls.Id)}"
            }));
        }
    }
}