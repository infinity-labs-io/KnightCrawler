using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfinityLabs.KnightCrawler.Library.Traversers
{
    public interface ILinkTraverser
    {
        Task<ILinkNode> Traverse(Uri uri, int depth);
    }
}
