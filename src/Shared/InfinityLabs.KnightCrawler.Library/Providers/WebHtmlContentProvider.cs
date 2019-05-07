using System;
using System.Net.Http;
using System.Threading.Tasks;
using InfinityLabs.KnightCrawler.Library.Configuration;

namespace InfinityLabs.KnightCrawler.Library.Providers
{
    public class WebHtmlContentProvider : IHtmlContentProvider
    {
        private readonly ICrawlerConfiguration _configuration;
        private readonly HttpClient _client;

        public WebHtmlContentProvider(ICrawlerConfiguration configuration)
        {
            _configuration = configuration;
            _client = new HttpClient();
        }
        
        public async Task<string> GetHtmlContentAsync(Uri url)
        {
            if (_configuration.Trace)
            {
                Console.WriteLine($"Fetching links at '{url.ToString()}'");
            }
            var response = await _client.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }
    }
}