using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InfinityLabs.KnightCrawler.Library.Crawlers;
using InfinityLabs.KnightCrawler.Library.Parsers;
using InfinityLabs.KnightCrawler.Library.Providers;

namespace InfinityLabs.KnightCrawler.Library.Crawlers
{
    public class LinkCrawler : ILinkCrawler
    {
        private readonly IHtmlContentProvider _htmlProvider;
        private readonly ILinkDiscovery _linkDiscovery;

        public LinkCrawler(IHtmlContentProvider htmlProvider, ILinkDiscovery linkDiscovery)
        {
            _htmlProvider = htmlProvider;
            _linkDiscovery = linkDiscovery;
        }
        
        public async Task<CrawlResult> GetLinksFromHtmlPageAsync(Uri url)
        {
            var result = new CrawlResult()
            {
                Success = true
            };

            try
            {
                var content = await _htmlProvider.GetHtmlContentAsync(url);
                var links = _linkDiscovery.GetLinks(content);
                foreach (var link in links)
                {
                    var crawledLink = new CrawledLink()
                    {
                        Success = false
                    };
                    if (_linkDiscovery.CanHandleLink(link))
                    {
                        try
                        {
                            if (_linkDiscovery.RequiresBasePath(link))
                            {
                                var sanitizedLink = link.Replace("//", "");
                                if (link.StartsWith("./"))
                                {
                                    sanitizedLink = sanitizedLink.Replace(".", "");
                                }
                                crawledLink.Uri = new Uri(url, sanitizedLink);
                            }
                            else
                            {
                                crawledLink.Uri = new Uri(link);
                            }
                            crawledLink.Success = true;
                            result.Links.Add(crawledLink);
                        }
                        catch (Exception ex)
                        {
                            crawledLink.Exception = ex;
                        }
                    }
                    else
                    {
                        crawledLink.Exception = new FormatException("Cannot handle format");
                    }
                }
            }
            catch (Exception ex)
            {
                result.Exception = ex;
                result.Success = false;
            }
            return result;
        }
    }
}