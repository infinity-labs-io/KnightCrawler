using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace InfinityLabs.KnightCrawler.Library.Providers
{
    public class WebHtmlContentProvider : IHtmlContentProvider
    {
        private readonly HttpClient _client;

        public WebHtmlContentProvider()
        {
            _client = new HttpClient();
        }
        
        public async Task<string> GetHtmlContentAsync(Uri url)
        {
            var response = await _client.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }
    }
}