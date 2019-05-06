using NUnit.Framework;
using InfinityLabs.KnightCrawler.Library.Parsers;
using InfinityLabs.KnightCrawler.Library.Exceptions;
using System.Threading.Tasks;

namespace InfinityLabs.KnightCrawler.Parsers.Tests
{
    [TestFixture]
    public class LinkDiscoveryTests : FileTestFixtureBase
    {
        private LinkDiscovery _discovery;

        public LinkDiscoveryTests()
        {
            _discovery = new LinkDiscovery();
        }
        
        [TestCase("sample_a", ExpectedResult = 1786)]
        [TestCase("sample_b", ExpectedResult = 232)]
        [TestCase("sample_c", ExpectedResult = 3)]
        public async Task<int> Test_LinkDiscovery(string fileName)
        {
            var content = await GetFileContentAsync(fileName);
            var links = _discovery.GetLinks(content);
            return links.Count;
        }

        public async Task Test_LinkDiscovery_ThrowsNoLinksFoundException()
        {
            var content = await GetFileContentAsync("sample_d");
            Assert.That(() => _discovery.GetLinks(content), Throws.TypeOf<NoLinksFoundException>());
        }

        [TestCase("#", ExpectedResult = true)]
        [TestCase("#something", ExpectedResult = true)]
        [TestCase("some/link", ExpectedResult = true)]
        [TestCase("//some/link", ExpectedResult = true)]
        [TestCase("https://some/link", ExpectedResult = true)]
        [TestCase("http://some/link", ExpectedResult = true)]
        [TestCase("mailto://some/link", ExpectedResult = false)]
        public bool Test_CanHandleLink(string link)
        {
            return _discovery.CanHandleLink(link);
        }
    }
}