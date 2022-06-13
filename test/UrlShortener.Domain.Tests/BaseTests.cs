using AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Domain.Tests
{
    internal class BaseTests
    {
        public static readonly IFixture Fixture = new Fixture();
        public static T Any<T>() => Fixture.Create<T>();
    }
}
