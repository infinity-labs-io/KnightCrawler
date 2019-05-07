using System.IO;
using System.Threading.Tasks;
using InfinityLabs.KnightCrawler.Library.Configuration;
using Moq;

namespace InfinityLabs.KnightCrawler.Parsers.Tests
{
    public abstract class FileTestFixtureBase
    {
        protected ICrawlerConfiguration Configuration
        {
            get
            {
                if (_configuration == null)
                {
                    var configuration = new Mock<ICrawlerConfiguration>();
                    configuration
                        .SetupGet(s => s.Trace)
                        .Returns(true);
                    _configuration = configuration.Object;
                }
                return _configuration;
            }
        }
        private ICrawlerConfiguration _configuration;
        
        protected async Task<string> GetFileContentAsync(string fileName)
        {
            var sampleFolder = "Samples";
            var path = Path.Combine(sampleFolder, fileName + ".html");
            using (var fileStream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (var reader = new StreamReader(fileStream))
            {
                return await reader.ReadToEndAsync();
            }
        }
    }
}