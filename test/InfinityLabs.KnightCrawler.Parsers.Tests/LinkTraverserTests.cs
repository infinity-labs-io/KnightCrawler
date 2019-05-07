using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using InfinityLabs.KnightCrawler.Library;
using InfinityLabs.KnightCrawler.Library.Crawlers;
using InfinityLabs.KnightCrawler.Library.Parsers;
using InfinityLabs.KnightCrawler.Library.Providers;
using InfinityLabs.KnightCrawler.Library.Traversers;
using Moq;
using NUnit.Framework;

namespace InfinityLabs.KnightCrawler.Parsers.Tests
{
    public class LinkTraverserTests : FileTestFixtureBase
    {
        private Dictionary<string, string> _content = new Dictionary<string, string>()
        {
            { "http://test.com/" , "<a href=\"http://test2.com\">Test 2</a><a href=\"http://test2.com\">Test 2</a>" },
            { "http://test7.com/" , "<a href=\"http://test.com\">Test</a>" }
        };

        [Test]
        public async Task Test_Traversals()
        {
            var mockContentProvider = new Mock<IHtmlContentProvider>();
            mockContentProvider
                .Setup(s => s.GetHtmlContentAsync(It.IsAny<Uri>()))
                .Returns<Uri>(s => Task.FromResult(_content[s.ToString()]));
            var contentProvider = mockContentProvider.Object;

            var crawler = new LinkCrawler(Configuration, contentProvider, new LinkDiscovery());
            var traverser = new LinkTraverser(crawler);
            var results = await traverser.Traverse(new Uri("http://test.com"), 1);
            Assert.That(results.Children, Has.Count.EqualTo(2));
        }
    }
}