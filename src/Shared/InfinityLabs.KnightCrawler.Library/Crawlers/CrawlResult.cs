using System;
using System.Collections.Generic;

namespace InfinityLabs.KnightCrawler.Library.Crawlers
{
    public class CrawlResult
    {
        public List<CrawledLink> Links { get; set; }

        public bool Success { get; set; }

        public Exception Exception { get; set; }

        public CrawlResult()
        {
            Links = new List<CrawledLink>();
        }
    }
}