using System;
using System.Threading.Tasks;
using InfinityLabs.KnightCrawler.Library.Traversers;

namespace InfinityLabs.KnightCrawler.Library.NodeWriters
{
    public interface INodeWriter : IDisposable
    {
        Task WriteAsync(ILinkNode node);
    }
}