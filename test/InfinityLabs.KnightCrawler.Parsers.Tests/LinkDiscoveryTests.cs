using NUnit.Framework;
using InfinityLabs.KnightCrawler.Library.Parsers;
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
        
        [TestCase("sample_c", ExpectedResult = 3)]
        [TestCase("sample_d", ExpectedResult = 0)]
        public async Task<int> Test_LinkDiscovery(string fileName)
        {
            var content = await GetFileContentAsync(fileName);
            var links = _discovery.GetLinks(content);
            return links.Count;
        }
    }
}