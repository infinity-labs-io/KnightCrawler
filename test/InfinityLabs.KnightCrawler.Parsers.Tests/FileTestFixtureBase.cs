using System.IO;
using System.Threading.Tasks;

namespace InfinityLabs.KnightCrawler.Parsers.Tests
{
    public abstract class FileTestFixtureBase
    {
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