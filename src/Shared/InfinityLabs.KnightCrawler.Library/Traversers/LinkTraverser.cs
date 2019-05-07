using System;
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
            throw new NotImplementedException();
        }
    }
}
