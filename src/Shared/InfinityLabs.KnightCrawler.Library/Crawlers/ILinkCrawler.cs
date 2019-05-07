using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfinityLabs.KnightCrawler.Library.Crawlers
{
    public interface ILinkCrawler
    {
        Task<CrawlResult> GetLinksFromHtmlPageAsync(Uri url);
    }
}