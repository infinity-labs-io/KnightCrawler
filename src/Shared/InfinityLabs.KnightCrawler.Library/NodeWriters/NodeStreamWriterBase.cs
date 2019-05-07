using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityLabs.KnightCrawler.Library.Traversers;
using static System.Environment;

namespace InfinityLabs.KnightCrawler.Library.NodeWriters
{
    public abstract class NodeStreamWriterBase : INodeWriter
    {
        private readonly Stream _stream;

        protected NodeStreamWriterBase(Stream stream)
        {
            _stream = stream;
        }

        public async Task WriteAsync(ILinkNode node)
        {
            var content = GetStreamContent(node);
            using (var writer = new StreamWriter(_stream))
            {
                await writer.WriteAsync(content);
            }
        }

        protected abstract string GetStreamContent(ILinkNode node);

        public void Dispose()
        {
            _stream?.Dispose();
        }
    }
}