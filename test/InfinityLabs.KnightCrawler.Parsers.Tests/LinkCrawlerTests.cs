using NUnit.Framework;
using InfinityLabs.KnightCrawler.Library.Parsers;
using InfinityLabs.KnightCrawler.Library.Exceptions;
using System.Threading.Tasks;
using InfinityLabs.KnightCrawler.Library.Providers;
using System;
using System.Linq;
using System.Collections.Generic;
using InfinityLabs.KnightCrawler.Library.Crawlers;

namespace InfinityLabs.KnightCrawler.Parsers.Tests
{
    [TestFixture]
    public class LinkCrawlerTests : FileTestFixtureBase, IHtmlContentProvider
    {
        private readonly LinkCrawler _crawler;

        public LinkCrawlerTests()
        {
            _crawler = new LinkCrawler(this, new LinkDiscovery());
        }

        public Task<string> GetHtmlContentAsync(Uri url)
        {
            var websites = new Dictionary<string, string>()
            {
                { "https://test.com/", "<a href=\"some/link/somewhere\"></a>" },
                { "http://test2.com/", "<a href=\"#some-anchor\"></a><a href=\"//some/matching/protocol\"></a>" }
            };
            return Task.FromResult(websites[url.ToString()]);
        }

        [Test]
        public async Task Test_GetLinksFromHtmlPageAsync()
        {
            // Relative
            var result = await _crawler.GetLinksFromHtmlPageAsync(new Uri("https://test.com/"));

            var expected = "https://test.com/some/link/somewhere";
            Assert.That(result.Success);
            Assert.That(result.Links.Count == 1);
            Assert.AreEqual(result.Links[0].Uri.ToString(), expected);

            result = await _crawler.GetLinksFromHtmlPageAsync(new Uri("http://test2.com/"));
            Assert.That(result.Success);
            Assert.That(result.Links.Count == 2);

            expected = "http://test2.com/#some-anchor";
            Assert.That(result.Links.Select(l => l.Uri.ToString()), Has.Member(expected));

            expected = "http://test2.com/some/matching/protocol";
            Assert.That(result.Links.Select(l => l.Uri.ToString()), Has.Member(expected));
        }
    }
}