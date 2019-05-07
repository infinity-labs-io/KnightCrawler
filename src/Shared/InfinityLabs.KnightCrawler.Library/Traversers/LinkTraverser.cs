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
                    var acceptableLinks = crawlResults.Links.Where(l => l.Success);

                    var children = new ConcurrentBag<ILinkNode>();
                    var tasks = acceptableLinks
                        .Select(s => Traverse(s.Uri, depth -1))
                        .ToList();

                    var results = await Task.WhenAll(tasks);
                    foreach (var node in results)
                    {
                        children.Add(node);
                    }
                    currentNode.Children = children.ToList();
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
