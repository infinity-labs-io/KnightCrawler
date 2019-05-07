using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using InfinityLabs.KnightCrawler.Library.Crawlers;

namespace InfinityLabs.KnightCrawler.Library.Traversers
{
    public class LinkTraverser : ILinkTraverser
    {
        private readonly ILinkCrawler _crawler;

        public LinkTraverser(ILinkCrawler crawler)
        {
            _crawler = crawler;
        }

        public async Task<ILinkNode> Traverse(Uri uri, int depth)
        {
            var currentNode = new LinkNode(uri)
            {
                Depth = depth
            };

            if (depth > 0)
            {
                try
                {
                    var crawlResults = await _crawler.GetLinksFromHtmlPageAsync(uri);
                    
                    // Build tasks to run searches in parallel
                    // Only scan Uri's that are traversable
                    var tasks = crawlResults.Links
                        .Where(l => l.Success)
                        .Select(s => Traverse(s.Uri, depth -1))
                        .ToList();
                    
                    // Wait for next search layer to complete
                    currentNode.Children = (await Task.WhenAll(tasks)).ToList();
                    return currentNode;
                }
                catch (Exception ex)
                {
                    currentNode.Exception = ex;
                }
            }
            return currentNode;
        }
    }
}
