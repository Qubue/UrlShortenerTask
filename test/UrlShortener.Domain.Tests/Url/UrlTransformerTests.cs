using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Domain.Url;

namespace UrlShortener.Domain.Tests.Url
{
    internal class UrlTransformerTests : BaseTests
    {
        private Domain.Url.UrlTransformer _urlShortener;
        private readonly IUrlManager _urlManager;
        private readonly IBaseEncoder _baseEncoder;

        public UrlTransformerTests()
        {
            _urlManager = Substitute.For<IUrlManager>();
            _baseEncoder = Substitute.For<IBaseEncoder>();
        }

        [Test]
        public async Task UrlTransformer_Get_Short_Url_Invalid_Url_Should_Throw_Exception()
        {
            var url = Any<string>();
            _urlShortener = new Domain.Url.UrlTransformer(_urlManager, _baseEncoder);

            Assert.ThrowsAsync<ArgumentException>(() => _urlShortener.GetShortUrl(url));
            await _urlManager.Received(0).AddUrl(Any<string>());
            _baseEncoder.Received(0).Encode(Any<long>());

        }

        [Test]
        public async Task UrlTransformer_Get_Short_Url_Should_Add_Url_To_Database()
        {
            var url = Any<Uri>().ToString();
            var id = Any<long>();
            _urlManager.AddUrl(url).Returns(new Data.Entities.Url
            {
                Id = id
            });

           _urlShortener = new Domain.Url.UrlTransformer(_urlManager, _baseEncoder);
           
            await _urlShortener.GetShortUrl(url);
            await _urlManager.Received(1).AddUrl(url);
            _baseEncoder.Received(1).Encode(id);
        }
    }
}
