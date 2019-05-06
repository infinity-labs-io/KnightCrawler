using System;

namespace InfinityLabs.KnightCrawler.Library.Crawlers
{
    public class CrawledLink
    {
        public Uri Uri { get; set; }

        public bool Success { get; set; }

        public Exception Exception { get; set; }
    }
}