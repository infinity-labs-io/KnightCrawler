using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace InfinityLabs.KnightCrawler.Library.Traversers
{
    public class LinkNode : ILinkNode
    {
        public List<ILinkNode> Children { get; set; }

        public Uri Link { get; set; }

        [IgnoreDataMember]
        public int Depth { get; set; }

        public bool HasError => Exception != null;

        public Exception Exception { get; set; }

        public List<Exception> Exceptions => 
            Children
                .Where(c => c.HasError)
                .Select(c => c.Exception)
                .ToList();

        public LinkNode(Uri uri)
        {
            Children = new List<ILinkNode>();
            Link = uri;
        }
    }
}