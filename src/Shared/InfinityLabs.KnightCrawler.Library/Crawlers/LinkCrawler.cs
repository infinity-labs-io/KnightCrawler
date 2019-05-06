using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InfinityLabs.KnightCrawler.Library.Crawlers;
using InfinityLabs.KnightCrawler.Library.Providers;

namespace InfinityLabs.KnightCrawler.Library.Crawlers
{
    public class LinkCrawler : ILinkCrawler
    {
        private readonly IHtmlContentProvider _htmlProvider;

        public LinkCrawler(IHtmlContentProvider htmlProvider)
        {
            _htmlProvider = htmlProvider;
        }
        
        public Task<List<CrawledLink>> GetLinksFromHtmlPageAsync(Uri url)
        {
            throw new NotImplementedException();
        }
    }
}