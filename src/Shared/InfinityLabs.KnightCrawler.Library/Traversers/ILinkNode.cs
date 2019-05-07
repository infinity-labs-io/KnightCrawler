using System;
using System.Collections.Generic;

namespace InfinityLabs.KnightCrawler.Library.Traversers
{
    public interface ILinkNode
    {
        List<ILinkNode> Children { get; set; }

        Uri Link { get; set; }
        
        int Depth { get; set; }

        bool HasError { get; }

        Exception Exception { get; set; }

        List<Exception> Exceptions { get; }
    }
}